namespace SistemaCrud
{
    partial class FrmUbigeo
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtbuscardistrito = new System.Windows.Forms.TextBox();
            this.DgvUbigeo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DgvUbigeo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar por Distrito:";
            // 
            // txtbuscardistrito
            // 
            this.txtbuscardistrito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtbuscardistrito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbuscardistrito.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbuscardistrito.ForeColor = System.Drawing.Color.Lime;
            this.txtbuscardistrito.Location = new System.Drawing.Point(137, 22);
            this.txtbuscardistrito.Name = "txtbuscardistrito";
            this.txtbuscardistrito.Size = new System.Drawing.Size(157, 25);
            this.txtbuscardistrito.TabIndex = 1;
            this.txtbuscardistrito.TextChanged += new System.EventHandler(this.txtbuscardistrito_TextChanged);
            // 
            // DgvUbigeo
            // 
            this.DgvUbigeo.AllowUserToAddRows = false;
            this.DgvUbigeo.AllowUserToDeleteRows = false;
            this.DgvUbigeo.AllowUserToOrderColumns = true;
            this.DgvUbigeo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.DgvUbigeo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvUbigeo.Location = new System.Drawing.Point(15, 62);
            this.DgvUbigeo.Name = "DgvUbigeo";
            this.DgvUbigeo.ReadOnly = true;
            this.DgvUbigeo.RowHeadersVisible = false;
            this.DgvUbigeo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvUbigeo.Size = new System.Drawing.Size(322, 196);
            this.DgvUbigeo.TabIndex = 2;
            this.DgvUbigeo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvUbigeo_CellDoubleClick);
            // 
            // FrmUbigeo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(348, 270);
            this.Controls.Add(this.DgvUbigeo);
            this.Controls.Add(this.txtbuscardistrito);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.Name = "FrmUbigeo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Distritos del Perú";
            ((System.ComponentModel.ISupportInitialize)(this.DgvUbigeo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbuscardistrito;
        private System.Windows.Forms.DataGridView DgvUbigeo;
    }
}