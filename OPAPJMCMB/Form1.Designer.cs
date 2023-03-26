namespace OPAPJMCMB
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtFuente = new RichTextBox();
            txtIDS = new RichTextBox();
            btntAnalizar = new Button();
            dtgIdes = new DataGridView();
            dtgError = new DataGridView();
            Tipo = new DataGridViewTextBoxColumn();
            Linea = new DataGridViewTextBoxColumn();
            Descripcion = new DataGridViewTextBoxColumn();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnAbrir = new Button();
            identificador = new DataGridViewTextBoxColumn();
            Nombe = new DataGridViewTextBoxColumn();
            tipoDato = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dtgIdes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgError).BeginInit();
            SuspendLayout();
            // 
            // txtFuente
            // 
            txtFuente.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            txtFuente.Location = new Point(12, 59);
            txtFuente.Name = "txtFuente";
            txtFuente.Size = new Size(413, 424);
            txtFuente.TabIndex = 0;
            txtFuente.Text = "";
            // 
            // txtIDS
            // 
            txtIDS.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            txtIDS.Location = new Point(431, 59);
            txtIDS.Name = "txtIDS";
            txtIDS.Size = new Size(417, 424);
            txtIDS.TabIndex = 1;
            txtIDS.Text = "";
            // 
            // btntAnalizar
            // 
            btntAnalizar.BackColor = Color.Tomato;
            btntAnalizar.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btntAnalizar.Location = new Point(300, 489);
            btntAnalizar.Name = "btntAnalizar";
            btntAnalizar.Size = new Size(247, 105);
            btntAnalizar.TabIndex = 2;
            btntAnalizar.Text = "Analizar";
            btntAnalizar.UseVisualStyleBackColor = false;
            btntAnalizar.Click += button1_Click;
            // 
            // dtgIdes
            // 
            dtgIdes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgIdes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgIdes.Columns.AddRange(new DataGridViewColumn[] { identificador, Nombe, tipoDato });
            dtgIdes.Location = new Point(854, 59);
            dtgIdes.Name = "dtgIdes";
            dtgIdes.RowTemplate.Height = 25;
            dtgIdes.Size = new Size(409, 182);
            dtgIdes.TabIndex = 3;
            // 
            // dtgError
            // 
            dtgError.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgError.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgError.Columns.AddRange(new DataGridViewColumn[] { Tipo, Linea, Descripcion });
            dtgError.Location = new Point(854, 290);
            dtgError.Name = "dtgError";
            dtgError.RowTemplate.Height = 25;
            dtgError.Size = new Size(409, 193);
            dtgError.TabIndex = 4;
            // 
            // Tipo
            // 
            Tipo.HeaderText = "Tipo de error";
            Tipo.Name = "Tipo";
            Tipo.ReadOnly = true;
            // 
            // Linea
            // 
            Linea.HeaderText = "Linea";
            Linea.Name = "Linea";
            Linea.ReadOnly = true;
            // 
            // Descripcion
            // 
            Descripcion.HeaderText = "Descripcion";
            Descripcion.Name = "Descripcion";
            Descripcion.ReadOnly = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(158, 22);
            label1.Name = "label1";
            label1.Size = new Size(71, 25);
            label1.TabIndex = 5;
            label1.Text = "Fuente";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label2.Location = new Point(564, 15);
            label2.Name = "label2";
            label2.Size = new Size(73, 25);
            label2.TabIndex = 6;
            label2.Text = "Tokens";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label3.Location = new Point(980, 15);
            label3.Name = "label3";
            label3.Size = new Size(140, 25);
            label3.TabIndex = 7;
            label3.Text = "Identificadores";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label4.Location = new Point(1013, 254);
            label4.Name = "label4";
            label4.Size = new Size(72, 25);
            label4.TabIndex = 8;
            label4.Text = "Errores";
            // 
            // btnAbrir
            // 
            btnAbrir.Location = new Point(97, 499);
            btnAbrir.Name = "btnAbrir";
            btnAbrir.Size = new Size(75, 23);
            btnAbrir.TabIndex = 9;
            btnAbrir.Text = "Abrir";
            btnAbrir.UseVisualStyleBackColor = true;
            btnAbrir.Click += btnAbrir_Click;
            // 
            // identificador
            // 
            identificador.HeaderText = "Identificador";
            identificador.Name = "identificador";
            identificador.ReadOnly = true;
            // 
            // Nombe
            // 
            Nombe.HeaderText = "Nombre";
            Nombe.Name = "Nombe";
            Nombe.ReadOnly = true;
            // 
            // tipoDato
            // 
            tipoDato.HeaderText = "Tipo de dato";
            tipoDato.Name = "tipoDato";
            tipoDato.ReadOnly = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1275, 606);
            Controls.Add(btnAbrir);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtgError);
            Controls.Add(dtgIdes);
            Controls.Add(btntAnalizar);
            Controls.Add(txtIDS);
            Controls.Add(txtFuente);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dtgIdes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgError).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox txtFuente;
        private RichTextBox txtIDS;
        private Button btntAnalizar;
        private DataGridView dtgIdes;
        private DataGridView dtgError;
        private DataGridViewTextBoxColumn Tipo;
        private DataGridViewTextBoxColumn Linea;
        private DataGridViewTextBoxColumn Descripcion;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnAbrir;
        private DataGridViewTextBoxColumn identificador;
        private DataGridViewTextBoxColumn Nombe;
        private DataGridViewTextBoxColumn tipoDato;
    }
}