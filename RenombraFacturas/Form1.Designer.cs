namespace RenombraFacturas
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.renombrar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.RFCEmisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreEmisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreArchivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NuevoNombreArchivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // renombrar
            // 
            this.renombrar.Location = new System.Drawing.Point(755, 27);
            this.renombrar.Name = "renombrar";
            this.renombrar.Size = new System.Drawing.Size(133, 23);
            this.renombrar.TabIndex = 7;
            this.renombrar.Text = "Renombrar archivos";
            this.renombrar.UseVisualStyleBackColor = true;
            this.renombrar.Click += new System.EventHandler(this.renombrar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RFCEmisor,
            this.NombreEmisor,
            this.NombreArchivo,
            this.NuevoNombreArchivo,
            this.Fecha,
            this.UUID});
            this.dataGridView1.Location = new System.Drawing.Point(31, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(961, 282);
            this.dataGridView1.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(50, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(549, 20);
            this.textBox1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(605, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Seleccionar Directorio";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RFCEmisor
            // 
            this.RFCEmisor.HeaderText = "RFC Emisor";
            this.RFCEmisor.Name = "RFCEmisor";
            // 
            // NombreEmisor
            // 
            this.NombreEmisor.HeaderText = "Nombre Emisor";
            this.NombreEmisor.Name = "NombreEmisor";
            this.NombreEmisor.Width = 250;
            // 
            // NombreArchivo
            // 
            this.NombreArchivo.HeaderText = "Nombre Archivo";
            this.NombreArchivo.Name = "NombreArchivo";
            this.NombreArchivo.Width = 200;
            // 
            // NuevoNombreArchivo
            // 
            this.NuevoNombreArchivo.HeaderText = "Nuevo Nombre Archivo";
            this.NuevoNombreArchivo.Name = "NuevoNombreArchivo";
            this.NuevoNombreArchivo.Width = 200;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.Width = 150;
            // 
            // UUID
            // 
            this.UUID.HeaderText = "UUID";
            this.UUID.Name = "UUID";
            this.UUID.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 382);
            this.Controls.Add(this.renombrar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Renombra Facturas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button renombrar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RFCEmisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreEmisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreArchivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NuevoNombreArchivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn UUID;
    }
}

