using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Collections;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Text.RegularExpressions;

namespace RenombraFacturas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            int j = 0;

            textBox1.Text = fbd.SelectedPath;
            dataGridView1.Rows.Clear();
            string[] files = Directory.GetFiles(fbd.SelectedPath,"*.xml");
            // Load the file names to the box
            foreach (string file in files)
            {
                dataGridView1.Rows.Add();
                ReadFile(file, j);
                j++;
            }
        }

        private void ReadFile(string file, int j)
        {
            string rfc="", serie="", folio="", fecha="";
            XmlTextReader XmlTextReader = new XmlTextReader(file);
            dataGridView1.Rows[j].Cells[2].Value = Path.GetFileNameWithoutExtension(file);
            while (XmlTextReader.Read())
            {
                if (XmlTextReader.IsStartElement())
                {
                    switch (XmlTextReader.Name)
                    {
                        case "cfdi:Emisor":
                            dataGridView1.Rows[j].Cells[0].Value = (XmlTextReader.GetAttribute("rfc"));
                            dataGridView1.Rows[j].Cells[1].Value = (XmlTextReader.GetAttribute("nombre"));
                            rfc = (XmlTextReader.GetAttribute("rfc"));
                            break;
                        case "cfdi:Comprobante":
                            serie = (XmlTextReader.GetAttribute("serie"));
                            folio = (XmlTextReader.GetAttribute("folio"));
                            fecha = (XmlTextReader.GetAttribute("fecha"));
                            break;
                        case "cfdi:DomicilioFiscal":
                            break;
                        case "tfd:TimbreFiscalDigital":
                            dataGridView1.Rows[j].Cells[5].Value = (XmlTextReader.GetAttribute("UUID"));
                            break;
                    }
                }

            }
            dataGridView1.Rows[j].Cells[3].Value = rfc + "_" + serie + folio + "_" + DateTime.ParseExact(fecha, "yyyy-MM-ddTHH:mm:ss",
                                           System.Globalization.CultureInfo.InvariantCulture).ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            dataGridView1.Rows[j].Cells[4].Value = fecha;
            XmlTextReader.Close();
        }

        private void renombrar_Click(object sender, EventArgs e)
        {
            int j = 0;
            string[] PDFfiles = Directory.GetFiles(textBox1.Text, "*.pdf");
            List<string> list = new List<string>(PDFfiles);

            for (j = 0; j < dataGridView1.Rows.Count - 1; j++)
            {
                if (File.Exists(textBox1.Text + "\\" + dataGridView1.Rows[j].Cells[2].Value.ToString() + ".xml") &&
                     !File.Exists(textBox1.Text + "\\" + dataGridView1.Rows[j].Cells[3].Value + ".xml"))
                {
                    System.IO.File.Move(textBox1.Text + "\\" + dataGridView1.Rows[j].Cells[2].Value.ToString() + ".xml", textBox1.Text + "\\" + dataGridView1.Rows[j].Cells[3].Value.ToString() + ".xml");
                    File.SetCreationTime(textBox1.Text + "\\" + dataGridView1.Rows[j].Cells[3].Value + ".xml", DateTime.ParseExact(dataGridView1.Rows[j].Cells[4].Value.ToString(), "yyyy-MM-ddTHH:mm:ss",
                                           System.Globalization.CultureInfo.InvariantCulture));
                    File.SetLastWriteTime(textBox1.Text + "\\" + dataGridView1.Rows[j].Cells[3].Value + ".xml", DateTime.ParseExact(dataGridView1.Rows[j].Cells[4].Value.ToString(), "yyyy-MM-ddTHH:mm:ss",
                                           System.Globalization.CultureInfo.InvariantCulture));
                }
                if (File.Exists(textBox1.Text + "\\" + dataGridView1.Rows[j].Cells[2].Value.ToString() + ".pdf") &&
                    !File.Exists(textBox1.Text + "\\" + dataGridView1.Rows[j].Cells[3].Value + ".pdf"))
                {
                    System.IO.File.Move(textBox1.Text + "\\" + dataGridView1.Rows[j].Cells[2].Value.ToString() + ".pdf", textBox1.Text + "\\" + dataGridView1.Rows[j].Cells[3].Value.ToString() + ".pdf");
                    File.SetCreationTime(textBox1.Text + "\\" + dataGridView1.Rows[j].Cells[3].Value + ".pdf", DateTime.ParseExact(dataGridView1.Rows[j].Cells[4].Value.ToString(), "yyyy-MM-ddTHH:mm:ss",
                                           System.Globalization.CultureInfo.InvariantCulture));
                    File.SetLastWriteTime(textBox1.Text + "\\" + dataGridView1.Rows[j].Cells[3].Value + ".pdf", DateTime.ParseExact(dataGridView1.Rows[j].Cells[4].Value.ToString(), "yyyy-MM-ddTHH:mm:ss",
                                           System.Globalization.CultureInfo.InvariantCulture));
                    list.Remove(textBox1.Text + "\\" + dataGridView1.Rows[j].Cells[2].Value.ToString() + ".pdf");
                    dataGridView1.Rows[j].Cells[5].Value = "";
                } 
            }
            for (j = 0; j < dataGridView1.Rows.Count - 1; j++)
            {
                if (!dataGridView1.Rows[j].Cells[5].Value.Equals(""))
                foreach (string file in list)
                {
                    PdfReader reader = new PdfReader(file);
                    int numeroDePaginas;
                    string text = "";
                    numeroDePaginas = reader.NumberOfPages;
                    for (int i = 0; i < numeroDePaginas; i++)
                    {
                        text += PdfTextExtractor.GetTextFromPage(reader, i + 1);
                    }
                    try { reader.Close(); }
                    catch { }
                    Regex regex = new Regex(dataGridView1.Rows[j].Cells[5].Value.ToString());
                    MatchCollection matches = regex.Matches(text);
                    if((matches.Count > 0) &&
                        !File.Exists(textBox1.Text + "\\" + dataGridView1.Rows[j].Cells[3].Value + ".pdf"))
                    {
                        System.IO.File.Move(file, textBox1.Text + "\\" + dataGridView1.Rows[j].Cells[3].Value.ToString() + ".pdf");
                        File.SetCreationTime(textBox1.Text + "\\" + dataGridView1.Rows[j].Cells[3].Value + ".pdf", DateTime.ParseExact(dataGridView1.Rows[j].Cells[4].Value.ToString(), "yyyy-MM-ddTHH:mm:ss",
                                               System.Globalization.CultureInfo.InvariantCulture));
                        File.SetLastWriteTime(textBox1.Text + "\\" + dataGridView1.Rows[j].Cells[3].Value + ".pdf", DateTime.ParseExact(dataGridView1.Rows[j].Cells[4].Value.ToString(), "yyyy-MM-ddTHH:mm:ss",
                                               System.Globalization.CultureInfo.InvariantCulture));
                        list.Remove(file);
                        break;
                    }
                }
            }

            MessageBox.Show("Archivos Renombrados.");
        }

    }
}
