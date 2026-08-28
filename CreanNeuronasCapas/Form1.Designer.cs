namespace CreanNeuronasCapas
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Tabla = new System.Windows.Forms.DataGridView();
            this.lbs = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.backp = new System.Windows.Forms.Button();
            this.Compuertas = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.error = new System.Windows.Forms.TextBox();
            this.epocas = new System.Windows.Forms.TextBox();
            this.razona = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CaNe = new System.Windows.Forms.DataGridView();
            this.CapaOculta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NeuronasCapa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.capas = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tabla)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CaNe)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Tabla);
            this.groupBox2.Controls.Add(this.lbs);
            this.groupBox2.Location = new System.Drawing.Point(627, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(755, 544);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resultados";
            // 
            // Tabla
            // 
            this.Tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Tabla.Location = new System.Drawing.Point(6, 22);
            this.Tabla.Name = "Tabla";
            this.Tabla.RowHeadersWidth = 51;
            this.Tabla.RowTemplate.Height = 24;
            this.Tabla.Size = new System.Drawing.Size(494, 447);
            this.Tabla.TabIndex = 2;
            // 
            // lbs
            // 
            this.lbs.FormattingEnabled = true;
            this.lbs.ItemHeight = 16;
            this.lbs.Location = new System.Drawing.Point(506, 22);
            this.lbs.Name = "lbs";
            this.lbs.Size = new System.Drawing.Size(243, 516);
            this.lbs.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.backp);
            this.groupBox1.Controls.Add(this.Compuertas);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.error);
            this.groupBox1.Controls.Add(this.epocas);
            this.groupBox1.Controls.Add(this.razona);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CaNe);
            this.groupBox1.Controls.Add(this.crear);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.capas);
            this.groupBox1.Location = new System.Drawing.Point(50, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(571, 544);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Red Neuronal";
            // 
            // backp
            // 
            this.backp.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.backp.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backp.Location = new System.Drawing.Point(308, 467);
            this.backp.Name = "backp";
            this.backp.Size = new System.Drawing.Size(177, 42);
            this.backp.TabIndex = 12;
            this.backp.Text = "BackPropagation";
            this.backp.UseVisualStyleBackColor = false;
            this.backp.Click += new System.EventHandler(this.backp_Click);
            // 
            // Compuertas
            // 
            this.Compuertas.FormattingEnabled = true;
            this.Compuertas.Items.AddRange(new object[] {
            "AND",
            "OR",
            "XOR",
            "Mayoria-Simple",
            "Paridad",
            "Ejercicio"});
            this.Compuertas.Location = new System.Drawing.Point(98, 485);
            this.Compuertas.Name = "Compuertas";
            this.Compuertas.Size = new System.Drawing.Size(121, 24);
            this.Compuertas.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(95, 453);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Problema a resolver";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(313, 403);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Error";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 400);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Epocas";
            // 
            // error
            // 
            this.error.Location = new System.Drawing.Point(355, 400);
            this.error.Name = "error";
            this.error.Size = new System.Drawing.Size(100, 22);
            this.error.TabIndex = 7;
            // 
            // epocas
            // 
            this.epocas.Location = new System.Drawing.Point(155, 400);
            this.epocas.Name = "epocas";
            this.epocas.Size = new System.Drawing.Size(100, 22);
            this.epocas.TabIndex = 6;
            // 
            // razona
            // 
            this.razona.Location = new System.Drawing.Point(155, 355);
            this.razona.Name = "razona";
            this.razona.Size = new System.Drawing.Size(100, 22);
            this.razona.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 355);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Razon de aprendizaje";
            // 
            // CaNe
            // 
            this.CaNe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CaNe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CapaOculta,
            this.NeuronasCapa});
            this.CaNe.Location = new System.Drawing.Point(50, 121);
            this.CaNe.Name = "CaNe";
            this.CaNe.RowHeadersWidth = 51;
            this.CaNe.RowTemplate.Height = 24;
            this.CaNe.Size = new System.Drawing.Size(405, 161);
            this.CaNe.TabIndex = 3;
            // 
            // CapaOculta
            // 
            this.CapaOculta.HeaderText = "CapaOculta";
            this.CapaOculta.MinimumWidth = 6;
            this.CapaOculta.Name = "CapaOculta";
            this.CapaOculta.Width = 125;
            // 
            // NeuronasCapa
            // 
            this.NeuronasCapa.HeaderText = "Neuronas por capa";
            this.NeuronasCapa.MinimumWidth = 6;
            this.NeuronasCapa.Name = "NeuronasCapa";
            this.NeuronasCapa.Width = 125;
            // 
            // crear
            // 
            this.crear.Location = new System.Drawing.Point(380, 48);
            this.crear.Name = "crear";
            this.crear.Size = new System.Drawing.Size(93, 35);
            this.crear.TabIndex = 2;
            this.crear.Text = "Crear";
            this.crear.UseVisualStyleBackColor = true;
            this.crear.Click += new System.EventHandler(this.crear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "No. de capas ocultas";
            // 
            // capas
            // 
            this.capas.Location = new System.Drawing.Point(156, 54);
            this.capas.Name = "capas";
            this.capas.Size = new System.Drawing.Size(100, 22);
            this.capas.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1433, 664);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Tabla)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CaNe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView Tabla;
        private System.Windows.Forms.ListBox lbs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button backp;
        private System.Windows.Forms.ComboBox Compuertas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox error;
        private System.Windows.Forms.TextBox epocas;
        private System.Windows.Forms.TextBox razona;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView CaNe;
        private System.Windows.Forms.DataGridViewTextBoxColumn CapaOculta;
        private System.Windows.Forms.DataGridViewTextBoxColumn NeuronasCapa;
        private System.Windows.Forms.Button crear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox capas;
    }
}

