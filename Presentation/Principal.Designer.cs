
namespace Presentation
{
    partial class Principal
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
            this.pnlLeftMenu = new System.Windows.Forms.Panel();
            this.pnlSubMenuProducto = new System.Windows.Forms.Panel();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.btnShowProduct = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.pnlSubMenuOptions = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUserOptions = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlLeftMenu.SuspendLayout();
            this.pnlSubMenuProducto.SuspendLayout();
            this.pnlSubMenuOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeftMenu
            // 
            this.pnlLeftMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(75)))), ((int)(((byte)(99)))));
            this.pnlLeftMenu.Controls.Add(this.pnlSubMenuProducto);
            this.pnlLeftMenu.Controls.Add(this.btnProductos);
            this.pnlLeftMenu.Controls.Add(this.pnlSubMenuOptions);
            this.pnlLeftMenu.Controls.Add(this.btnUserOptions);
            this.pnlLeftMenu.Controls.Add(this.panel1);
            this.pnlLeftMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeftMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftMenu.Name = "pnlLeftMenu";
            this.pnlLeftMenu.Size = new System.Drawing.Size(250, 534);
            this.pnlLeftMenu.TabIndex = 0;
            // 
            // pnlSubMenuProducto
            // 
            this.pnlSubMenuProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(79)))), ((int)(((byte)(134)))));
            this.pnlSubMenuProducto.Controls.Add(this.btnDeleteProduct);
            this.pnlSubMenuProducto.Controls.Add(this.btnShowProduct);
            this.pnlSubMenuProducto.Controls.Add(this.btnAddProduct);
            this.pnlSubMenuProducto.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubMenuProducto.Location = new System.Drawing.Point(0, 315);
            this.pnlSubMenuProducto.Name = "pnlSubMenuProducto";
            this.pnlSubMenuProducto.Size = new System.Drawing.Size(250, 125);
            this.pnlSubMenuProducto.TabIndex = 4;
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDeleteProduct.FlatAppearance.BorderSize = 0;
            this.btnDeleteProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(136)))));
            this.btnDeleteProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteProduct.ForeColor = System.Drawing.Color.White;
            this.btnDeleteProduct.Location = new System.Drawing.Point(0, 80);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(250, 40);
            this.btnDeleteProduct.TabIndex = 5;
            this.btnDeleteProduct.Text = "Borrar";
            this.btnDeleteProduct.UseVisualStyleBackColor = true;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);
            // 
            // btnShowProduct
            // 
            this.btnShowProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnShowProduct.FlatAppearance.BorderSize = 0;
            this.btnShowProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(136)))));
            this.btnShowProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowProduct.ForeColor = System.Drawing.Color.White;
            this.btnShowProduct.Location = new System.Drawing.Point(0, 40);
            this.btnShowProduct.Name = "btnShowProduct";
            this.btnShowProduct.Size = new System.Drawing.Size(250, 40);
            this.btnShowProduct.TabIndex = 4;
            this.btnShowProduct.Text = "Mostrar";
            this.btnShowProduct.UseVisualStyleBackColor = true;
            this.btnShowProduct.Click += new System.EventHandler(this.btnShowProduct_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddProduct.FlatAppearance.BorderSize = 0;
            this.btnAddProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(136)))));
            this.btnAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProduct.ForeColor = System.Drawing.Color.White;
            this.btnAddProduct.Location = new System.Drawing.Point(0, 0);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(250, 40);
            this.btnAddProduct.TabIndex = 3;
            this.btnAddProduct.Text = "Agregar";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProductos.FlatAppearance.BorderSize = 0;
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.ForeColor = System.Drawing.Color.White;
            this.btnProductos.Location = new System.Drawing.Point(0, 270);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnProductos.Size = new System.Drawing.Size(250, 45);
            this.btnProductos.TabIndex = 3;
            this.btnProductos.Text = "Producto";
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // pnlSubMenuOptions
            // 
            this.pnlSubMenuOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(79)))), ((int)(((byte)(134)))));
            this.pnlSubMenuOptions.Controls.Add(this.btnDelete);
            this.pnlSubMenuOptions.Controls.Add(this.btnShow);
            this.pnlSubMenuOptions.Controls.Add(this.btnAdd);
            this.pnlSubMenuOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubMenuOptions.Location = new System.Drawing.Point(0, 145);
            this.pnlSubMenuOptions.Name = "pnlSubMenuOptions";
            this.pnlSubMenuOptions.Size = new System.Drawing.Size(250, 125);
            this.pnlSubMenuOptions.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(136)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(0, 80);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(250, 40);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Borrar";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnShow
            // 
            this.btnShow.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnShow.FlatAppearance.BorderSize = 0;
            this.btnShow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(136)))));
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.ForeColor = System.Drawing.Color.White;
            this.btnShow.Location = new System.Drawing.Point(0, 40);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(250, 40);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "Mostrar";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(136)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(0, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(250, 40);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUserOptions
            // 
            this.btnUserOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUserOptions.FlatAppearance.BorderSize = 0;
            this.btnUserOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserOptions.ForeColor = System.Drawing.Color.White;
            this.btnUserOptions.Location = new System.Drawing.Point(0, 100);
            this.btnUserOptions.Name = "btnUserOptions";
            this.btnUserOptions.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnUserOptions.Size = new System.Drawing.Size(250, 45);
            this.btnUserOptions.TabIndex = 1;
            this.btnUserOptions.Text = "Usuario";
            this.btnUserOptions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserOptions.UseVisualStyleBackColor = true;
            this.btnUserOptions.Click += new System.EventHandler(this.btnUserOptions_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 100);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(250, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(604, 534);
            this.panel2.TabIndex = 1;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 534);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlLeftMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Principal";
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.pnlLeftMenu.ResumeLayout(false);
            this.pnlSubMenuProducto.ResumeLayout(false);
            this.pnlSubMenuOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeftMenu;
        private System.Windows.Forms.Panel pnlSubMenuProducto;
        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.Button btnShowProduct;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Panel pnlSubMenuOptions;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUserOptions;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}