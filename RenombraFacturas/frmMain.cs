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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            int j = 0;

            DirectorioFacturas.Text = fbd.SelectedPath;
            dgvDatos.Rows.Clear();
            string[] files = Directory.GetFiles(fbd.SelectedPath,"*.xml");
            // Load the file names to the box
            foreach (string file in files)
            {
                dgvDatos.Rows.Add();
                ReadFile(file, j);
                j++;
            }
        }

        private void ReadFile(string file, int j)
        {
            string rfc="", serie="", folio="", fecha="";
            XmlTextReader XmlTextReader = new XmlTextReader(file);
            dgvDatos.Rows[j].Cells[2].Value = Path.GetFileNameWithoutExtension(file);
            while (XmlTextReader.Read())
            {
                if (XmlTextReader.IsStartElement())
                {
                    switch (XmlTextReader.Name)
                    {
                        case "cfdi:Emisor":
                            dgvDatos.Rows[j].Cells[0].Value = (XmlTextReader.GetAttribute("rfc"));
                            dgvDatos.Rows[j].Cells[1].Value = (XmlTextReader.GetAttribute("nombre"));
                            rfc = (XmlTextReader.GetAttribute("rfc"));
                            break;
                        case "cfdi:Comprobante":
                            serie = (XmlTextReader.GetAttribute("serie"));
                            folio = (XmlTextReader.GetAttribute("folio"));
                            break;
                        case "cfdi:DomicilioFiscal":
                            break;
                        case "tfd:TimbreFiscalDigital":
                            dgvDatos.Rows[j].Cells[5].Value = (XmlTextReader.GetAttribute("UUID"));
                            fecha = (XmlTextReader.GetAttribute("FechaTimbrado"));
                            break;
                    }
                }

            }
            dgvDatos.Rows[j].Cells[3].Value = rfc + "_" + serie + folio + "_" + DateTime.ParseExact(fecha, "yyyy-MM-ddTHH:mm:ss",
                                           System.Globalization.CultureInfo.InvariantCulture).ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            dgvDatos.Rows[j].Cells[4].Value = fecha;
            XmlTextReader.Close();
        }

        private void renombrar_Click(object sender, EventArgs e)
        {
            int j = 0;
            string[] PDFfiles = Directory.GetFiles(DirectorioFacturas.Text, "*.pdf");
            List<string> list = new List<string>(PDFfiles);

            for (j = 0; j < dgvDatos.Rows.Count - 1; j++)
            {
                if (File.Exists(DirectorioFacturas.Text + "\\" + dgvDatos.Rows[j].Cells[2].Value.ToString() + ".xml") &&
                     !File.Exists(DirectorioFacturas.Text + "\\" + dgvDatos.Rows[j].Cells[3].Value + ".xml"))
                {
                    System.IO.File.Move(DirectorioFacturas.Text + "\\" + dgvDatos.Rows[j].Cells[2].Value.ToString() + ".xml", DirectorioFacturas.Text + "\\" + dgvDatos.Rows[j].Cells[3].Value.ToString() + ".xml");
                    File.SetCreationTime(DirectorioFacturas.Text + "\\" + dgvDatos.Rows[j].Cells[3].Value + ".xml", DateTime.ParseExact(dgvDatos.Rows[j].Cells[4].Value.ToString(), "yyyy-MM-ddTHH:mm:ss",
                                           System.Globalization.CultureInfo.InvariantCulture));
                    File.SetLastWriteTime(DirectorioFacturas.Text + "\\" + dgvDatos.Rows[j].Cells[3].Value + ".xml", DateTime.ParseExact(dgvDatos.Rows[j].Cells[4].Value.ToString(), "yyyy-MM-ddTHH:mm:ss",
                                           System.Globalization.CultureInfo.InvariantCulture));
                }
                if (File.Exists(DirectorioFacturas.Text + "\\" + dgvDatos.Rows[j].Cells[2].Value.ToString() + ".pdf") &&
                    !File.Exists(DirectorioFacturas.Text + "\\" + dgvDatos.Rows[j].Cells[3].Value + ".pdf"))
                {
                    System.IO.File.Move(DirectorioFacturas.Text + "\\" + dgvDatos.Rows[j].Cells[2].Value.ToString() + ".pdf", DirectorioFacturas.Text + "\\" + dgvDatos.Rows[j].Cells[3].Value.ToString() + ".pdf");
                    File.SetCreationTime(DirectorioFacturas.Text + "\\" + dgvDatos.Rows[j].Cells[3].Value + ".pdf", DateTime.ParseExact(dgvDatos.Rows[j].Cells[4].Value.ToString(), "yyyy-MM-ddTHH:mm:ss",
                                           System.Globalization.CultureInfo.InvariantCulture));
                    File.SetLastWriteTime(DirectorioFacturas.Text + "\\" + dgvDatos.Rows[j].Cells[3].Value + ".pdf", DateTime.ParseExact(dgvDatos.Rows[j].Cells[4].Value.ToString(), "yyyy-MM-ddTHH:mm:ss",
                                           System.Globalization.CultureInfo.InvariantCulture));
                    list.Remove(DirectorioFacturas.Text + "\\" + dgvDatos.Rows[j].Cells[2].Value.ToString() + ".pdf");
                    dgvDatos.Rows[j].Cells[5].Value = "";
                } 
            }
            for (j = 0; j < dgvDatos.Rows.Count - 1; j++)
            {
                if (!dgvDatos.Rows[j].Cells[5].Value.Equals(""))
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
                    Regex regex = new Regex(dgvDatos.Rows[j].Cells[5].Value.ToString());
                    MatchCollection matches = regex.Matches(text);
                    if(matches.Count > 0)
                    {
                        if (!File.Exists(DirectorioFacturas.Text + "\\" + dgvDatos.Rows[j].Cells[3].Value + ".pdf"))
                        {
                            System.IO.File.Move(file, DirectorioFacturas.Text + "\\" + dgvDatos.Rows[j].Cells[3].Value.ToString() + ".pdf");
                            File.SetCreationTime(DirectorioFacturas.Text + "\\" + dgvDatos.Rows[j].Cells[3].Value + ".pdf", DateTime.ParseExact(dgvDatos.Rows[j].Cells[4].Value.ToString(), "yyyy-MM-ddTHH:mm:ss",
                                                   System.Globalization.CultureInfo.InvariantCulture));
                            File.SetLastWriteTime(DirectorioFacturas.Text + "\\" + dgvDatos.Rows[j].Cells[3].Value + ".pdf", DateTime.ParseExact(dgvDatos.Rows[j].Cells[4].Value.ToString(), "yyyy-MM-ddTHH:mm:ss",
                                                   System.Globalization.CultureInfo.InvariantCulture));
                            list.Remove(file);
                            break;
                        }
                        else
                        {
                            int i = 1;
                            while (File.Exists(DirectorioFacturas.Text + "\\" + dgvDatos.Rows[j].Cells[3].Value + "_" + i.ToString() + ".pdf"))
                            {
                                i++;
                            }
                            System.IO.File.Move(file, DirectorioFacturas.Text + "\\" + dgvDatos.Rows[j].Cells[3].Value.ToString() + "_" + i.ToString() + ".pdf");
                            File.SetCreationTime(DirectorioFacturas.Text + "\\" + dgvDatos.Rows[j].Cells[3].Value + "_" + i.ToString() + ".pdf", DateTime.ParseExact(dgvDatos.Rows[j].Cells[4].Value.ToString(), "yyyy-MM-ddTHH:mm:ss",
                                                   System.Globalization.CultureInfo.InvariantCulture));
                            File.SetLastWriteTime(DirectorioFacturas.Text + "\\" + dgvDatos.Rows[j].Cells[3].Value + "_" + i.ToString() + ".pdf", DateTime.ParseExact(dgvDatos.Rows[j].Cells[4].Value.ToString(), "yyyy-MM-ddTHH:mm:ss",
                                                   System.Globalization.CultureInfo.InvariantCulture));
                            list.Remove(file);
                            break;
                        }
                    }
                }
            }
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
                Regex regex = new Regex(@"\s*(?<FolioFiscal>[A-Z0-9]+\-[A-Z0-9]+\-[A-Z0-9]+\-[A-Z0-9]+\-[A-Z0-9]+)\s*");
                MatchCollection matches = regex.Matches(text);
                if(matches.Count > 0)
                for (j = 0; j < dgvDatos.Rows.Count - 1; j++)
                {
                    if (dgvDatos.Rows[j].Cells[5].Value.Equals(matches[0].Groups["FolioFiscal"].Value))
                    {
                        int i = 1;
                        while (File.Exists(DirectorioFacturas.Text + "\\" + dgvDatos.Rows[j].Cells[3].Value + "_" + i.ToString() + ".pdf"))
                        {
                            i++;
                        }
                        System.IO.File.Move(file, DirectorioFacturas.Text + "\\" + dgvDatos.Rows[j].Cells[3].Value.ToString() + "_" + i.ToString() + ".pdf");
                        File.SetCreationTime(DirectorioFacturas.Text + "\\" + dgvDatos.Rows[j].Cells[3].Value + "_" + i.ToString() + ".pdf", DateTime.ParseExact(dgvDatos.Rows[j].Cells[4].Value.ToString(), "yyyy-MM-ddTHH:mm:ss",
                                               System.Globalization.CultureInfo.InvariantCulture));
                        File.SetLastWriteTime(DirectorioFacturas.Text + "\\" + dgvDatos.Rows[j].Cells[3].Value + "_" + i.ToString() + ".pdf", DateTime.ParseExact(dgvDatos.Rows[j].Cells[4].Value.ToString(), "yyyy-MM-ddTHH:mm:ss",
                                               System.Globalization.CultureInfo.InvariantCulture));
                        //list.Remove(file);
                        break;
                    }
                }
            }
            MessageBox.Show("Archivos Renombrados.");
        }

    }
}
