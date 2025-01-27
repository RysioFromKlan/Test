namespace WinFormsApp
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
            components = new System.ComponentModel.Container();
            bindingSource1 = new BindingSource(components);
            dbDataGrid = new DataGridView();
            loadButton = new Button();
            columnGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dbDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)columnGridView).BeginInit();
            SuspendLayout();
            // 
            // dbDataGrid
            // 
            dbDataGrid.AllowUserToAddRows = false;
            dbDataGrid.AllowUserToDeleteRows = false;
            dbDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dbDataGrid.Location = new Point(12, 49);
            dbDataGrid.MultiSelect = false;
            dbDataGrid.Name = "dbDataGrid";
            dbDataGrid.ReadOnly = true;
            dbDataGrid.RowHeadersWidth = 55;
            dbDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dbDataGrid.ShowEditingIcon = false;
            dbDataGrid.ShowRowErrors = false;
            dbDataGrid.Size = new Size(462, 389);
            dbDataGrid.StandardTab = true;
            dbDataGrid.TabIndex = 0;
            dbDataGrid.CellClick += dbDataGrid_CellClick;
            // 
            // loadButton
            // 
            loadButton.Location = new Point(12, 12);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(205, 31);
            loadButton.TabIndex = 1;
            loadButton.Text = "Załaduj bazę danych";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Click += button1_Click;
            // 
            // columnGridView
            // 
            columnGridView.AllowUserToAddRows = false;
            columnGridView.AllowUserToDeleteRows = false;
            columnGridView.AllowUserToResizeRows = false;
            columnGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            columnGridView.Location = new Point(505, 49);
            columnGridView.MultiSelect = false;
            columnGridView.Name = "columnGridView";
            columnGridView.ReadOnly = true;
            columnGridView.RowHeadersWidth = 55;
            columnGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            columnGridView.ShowEditingIcon = false;
            columnGridView.ShowRowErrors = false;
            columnGridView.Size = new Size(545, 389);
            columnGridView.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1128, 688);
            Controls.Add(columnGridView);
            Controls.Add(loadButton);
            Controls.Add(dbDataGrid);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dbDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)columnGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private BindingSource bindingSource1;
        private DataGridView dbDataGrid;
        private Button loadButton;
        private DataGridView columnGridView;
    }
}
