
namespace Sistema_MDQ
{
    partial class frmSalvoconducto
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
        public void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNombreSal = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPlacaS = new System.Windows.Forms.TextBox();
            this.verHorario = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Cedula";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 26;
            // 
            // textBoxNombreSal
            // 
            this.textBoxNombreSal.Location = new System.Drawing.Point(85, 28);
            this.textBoxNombreSal.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxNombreSal.Name = "textBoxNombreSal";
            this.textBoxNombreSal.Size = new System.Drawing.Size(111, 20);
            this.textBoxNombreSal.TabIndex = 23;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(128, 77);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(239, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Placa";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // textBoxPlacaS
            // 
            this.textBoxPlacaS.Location = new System.Drawing.Point(303, 31);
            this.textBoxPlacaS.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPlacaS.Name = "textBoxPlacaS";
            this.textBoxPlacaS.Size = new System.Drawing.Size(111, 20);
            this.textBoxPlacaS.TabIndex = 29;
            // 
            // verHorario
            // 
            this.verHorario.Location = new System.Drawing.Point(446, 26);
            this.verHorario.Name = "verHorario";
            this.verHorario.Size = new System.Drawing.Size(75, 23);
            this.verHorario.TabIndex = 30;
            this.verHorario.Text = "Mostrar";
            this.verHorario.UseVisualStyleBackColor = true;
            this.verHorario.Click += new System.EventHandler(this.verHorario_Click);
            // 
            // frmSalvoconducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 276);
            this.Controls.Add(this.verHorario);
            this.Controls.Add(this.textBoxPlacaS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBoxNombreSal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmSalvoconducto";
            this.Text = "frmSalvoconducto";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNombreSal;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPlacaS;
        private System.Windows.Forms.Button verHorario;
    }
}