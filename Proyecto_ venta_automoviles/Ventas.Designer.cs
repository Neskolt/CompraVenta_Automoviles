namespace WinFormsApp1
{
    partial class Ventas
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
            components = new System.ComponentModel.Container();
            cb_clientes = new ComboBox();
            cb_vehiculo = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tx_precio = new TextBox();
            listView1 = new ListView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            eliminarToolStripMenuItem = new ToolStripMenuItem();
            modificarToolStripMenuItem = new ToolStripMenuItem();
            bt_guardar = new Button();
            bt_cancelar = new Button();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // cb_clientes
            // 
            cb_clientes.FormattingEnabled = true;
            cb_clientes.Location = new Point(26, 37);
            cb_clientes.Name = "cb_clientes";
            cb_clientes.Size = new Size(302, 23);
            cb_clientes.TabIndex = 0;
            // 
            // cb_vehiculo
            // 
            cb_vehiculo.FormattingEnabled = true;
            cb_vehiculo.Location = new Point(25, 81);
            cb_vehiculo.Name = "cb_vehiculo";
            cb_vehiculo.Size = new Size(303, 23);
            cb_vehiculo.TabIndex = 1;
            cb_vehiculo.SelectedIndexChanged += cb_vehiculo_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 63);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 0;
            label1.Text = "Vehiculo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 23);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 0;
            label2.Text = "Cliente";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 115);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 0;
            label3.Text = "Precio";
            // 
            // tx_precio
            // 
            tx_precio.Location = new Point(26, 133);
            tx_precio.Name = "tx_precio";
            tx_precio.ReadOnly = true;
            tx_precio.Size = new Size(115, 23);
            tx_precio.TabIndex = 2;
            // 
            // listView1
            // 
            listView1.ContextMenuStrip = contextMenuStrip1;
            listView1.Location = new Point(25, 227);
            listView1.Name = "listView1";
            listView1.Size = new Size(303, 227);
            listView1.TabIndex = 7;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { eliminarToolStripMenuItem, modificarToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(126, 48);
            // 
            // eliminarToolStripMenuItem
            // 
            eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            eliminarToolStripMenuItem.Size = new Size(125, 22);
            eliminarToolStripMenuItem.Text = "Eliminar";
            eliminarToolStripMenuItem.Click += eliminarToolStripMenuItem_Click;
            // 
            // modificarToolStripMenuItem
            // 
            modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            modificarToolStripMenuItem.Size = new Size(125, 22);
            modificarToolStripMenuItem.Text = "Modificar";
            modificarToolStripMenuItem.Click += modificarToolStripMenuItem_Click_1;
            // 
            // bt_guardar
            // 
            bt_guardar.Location = new Point(253, 187);
            bt_guardar.Name = "bt_guardar";
            bt_guardar.Size = new Size(75, 23);
            bt_guardar.TabIndex = 8;
            bt_guardar.Text = "Guardar";
            bt_guardar.UseVisualStyleBackColor = true;
            bt_guardar.Click += bt_guardar_Click;
            // 
            // bt_cancelar
            // 
            bt_cancelar.Location = new Point(26, 187);
            bt_cancelar.Name = "bt_cancelar";
            bt_cancelar.Size = new Size(75, 23);
            bt_cancelar.TabIndex = 9;
            bt_cancelar.Text = "Cancelar";
            bt_cancelar.UseVisualStyleBackColor = true;
            bt_cancelar.Click += bt_cancelar_Click;
            // 
            // Ventas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 490);
            Controls.Add(bt_cancelar);
            Controls.Add(bt_guardar);
            Controls.Add(listView1);
            Controls.Add(tx_precio);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cb_vehiculo);
            Controls.Add(cb_clientes);
            Name = "Ventas";
            Text = "Ventas";
            Load += Ventas_Load;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cb_clientes;
        private ComboBox cb_vehiculo;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tx_precio;
        private ListView listView1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem eliminarToolStripMenuItem;
        private ToolStripMenuItem modificarToolStripMenuItem;
        private Button bt_guardar;
        private Button bt_cancelar;
    }
}