namespace RenombraFacturas
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnRenombrarArchivos = new System.Windows.Forms.Button();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.RFCEmisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreEmisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreArchivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NuevoNombreArchivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DirectorioFacturas = new System.Windows.Forms.TextBox();
            this.btnSeleccionarDirectorio = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRenombrarArchivos
            // 
            this.btnRenombrarArchivos.Location = new System.Drawing.Point(755, 27);
            this.btnRenombrarArchivos.Name = "btnRenombrarArchivos";
            this.btnRenombrarArchivos.Size = new System.Drawing.Size(133, 23);
            this.btnRenombrarArchivos.TabIndex = 7;
            this.btnRenombrarArchivos.Text = "Renombrar archivos";
            this.btnRenombrarArchivos.UseVisualStyleBackColor = true;
            this.btnRenombrarArchivos.Click += new System.EventHandler(this.renombrar_Click);
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RFCEmisor,
            this.NombreEmisor,
            this.NombreArchivo,
            this.NuevoNombreArchivo,
            this.Fecha,
            this.UUID});
            this.dgvDatos.Location = new System.Drawing.Point(31, 72);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.Size = new System.Drawing.Size(961, 282);
            this.dgvDatos.TabIndex = 6;
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
            // DirectorioFacturas
            // 
            this.DirectorioFacturas.Location = new System.Drawing.Point(50, 30);
            this.DirectorioFacturas.Name = "DirectorioFacturas";
            this.DirectorioFacturas.ReadOnly = true;
            this.DirectorioFacturas.Size = new System.Drawing.Size(549, 20);
            this.DirectorioFacturas.TabIndex = 5;
            // 
            // btnSeleccionarDirectorio
            // 
            this.btnSeleccionarDirectorio.Location = new System.Drawing.Point(605, 27);
            this.btnSeleccionarDirectorio.Name = "btnSeleccionarDirectorio";
            this.btnSeleccionarDirectorio.Size = new System.Drawing.Size(133, 23);
            this.btnSeleccionarDirectorio.TabIndex = 4;
            this.btnSeleccionarDirectorio.Text = "Seleccionar Directorio";
            this.btnSeleccionarDirectorio.UseVisualStyleBackColor = true;
            this.btnSeleccionarDirectorio.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(906, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Acerca de...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(944, 360);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Salir";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 393);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRenombrarArchivos);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.DirectorioFacturas);
            this.Controls.Add(this.btnSeleccionarDirectorio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Renombra Facturas";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRenombrarArchivos;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.TextBox DirectorioFacturas;
        private System.Windows.Forms.Button btnSeleccionarDirectorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn RFCEmisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreEmisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreArchivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NuevoNombreArchivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn UUID;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

