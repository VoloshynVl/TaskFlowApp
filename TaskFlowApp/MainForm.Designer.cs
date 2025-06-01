namespace TaskFlowApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem усіЗавданняToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сьогодніToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem завершеноToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem налаштуванняToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тегиToolStripMenuItem;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnNewTask;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridTasks;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            усіЗавданняToolStripMenuItem = new ToolStripMenuItem();
            сьогодніToolStripMenuItem = new ToolStripMenuItem();
            тегиToolStripMenuItem = new ToolStripMenuItem();
            завершеноToolStripMenuItem = new ToolStripMenuItem();
            налаштуванняToolStripMenuItem = new ToolStripMenuItem();
            panelTop = new Panel();
            btnNewTask = new Button();
            txtSearch = new TextBox();
            lblTitle = new Label();
            panelFilter = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            btnDelete = new Button();
            cmbSort = new ComboBox();
            cmbStatus = new ComboBox();
            dataGridTasks = new DataGridView();

            menuStrip1.SuspendLayout();
            panelTop.SuspendLayout();
            panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridTasks).BeginInit();
            SuspendLayout();

            // menuStrip1
            menuStrip1.BackColor = Color.FromArgb(55, 65, 81);
            menuStrip1.ForeColor = Color.White;
            menuStrip1.Items.AddRange(new ToolStripItem[] {
                усіЗавданняToolStripMenuItem,
                сьогодніToolStripMenuItem,
                тегиToolStripMenuItem,
                завершеноToolStripMenuItem,
                налаштуванняToolStripMenuItem
            });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(8, 4, 0, 4);
            menuStrip1.Size = new Size(1167, 35);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";

            // усіЗавданняToolStripMenuItem
            усіЗавданняToolStripMenuItem.ForeColor = Color.FromArgb(209, 213, 219);
            усіЗавданняToolStripMenuItem.Name = "усіЗавданняToolStripMenuItem";
            усіЗавданняToolStripMenuItem.Padding = new Padding(12, 6, 12, 6);
            усіЗавданняToolStripMenuItem.Size = new Size(124, 27);
            усіЗавданняToolStripMenuItem.Text = "Усі завдання";
            усіЗавданняToolStripMenuItem.Click += усіЗавданняToolStripMenuItem_Click;

            // сьогодніToolStripMenuItem
            сьогодніToolStripMenuItem.ForeColor = Color.FromArgb(209, 213, 219);
            сьогодніToolStripMenuItem.Name = "сьогодніToolStripMenuItem";
            сьогодніToolStripMenuItem.Padding = new Padding(12, 6, 12, 6);
            сьогодніToolStripMenuItem.Size = new Size(101, 27);
            сьогодніToolStripMenuItem.Text = "Сьогодні";
            сьогодніToolStripMenuItem.Click += сьогодніToolStripMenuItem_Click;

            // тегиToolStripMenuItem
            тегиToolStripMenuItem.ForeColor = Color.FromArgb(209, 213, 219);
            тегиToolStripMenuItem.Name = "тегиToolStripMenuItem";
            тегиToolStripMenuItem.Padding = new Padding(12, 6, 12, 6);
            тегиToolStripMenuItem.Size = new Size(72, 27);
            тегиToolStripMenuItem.Text = "Теги";
            тегиToolStripMenuItem.Click += тегиToolStripMenuItem_Click;

            // завершеноToolStripMenuItem
            завершеноToolStripMenuItem.ForeColor = Color.FromArgb(209, 213, 219);
            завершеноToolStripMenuItem.Name = "завершеноToolStripMenuItem";
            завершеноToolStripMenuItem.Padding = new Padding(12, 6, 12, 6);
            завершеноToolStripMenuItem.Size = new Size(116, 27);
            завершеноToolStripMenuItem.Text = "Завершено";
            завершеноToolStripMenuItem.Click += завершеноToolStripMenuItem_Click;

            // налаштуванняToolStripMenuItem
            налаштуванняToolStripMenuItem.ForeColor = Color.FromArgb(209, 213, 219);
            налаштуванняToolStripMenuItem.Name = "налаштуванняToolStripMenuItem";
            налаштуванняToolStripMenuItem.Padding = new Padding(12, 6, 12, 6);
            налаштуванняToolStripMenuItem.Size = new Size(137, 27);
            налаштуванняToolStripMenuItem.Text = "Налаштування";
            налаштуванняToolStripMenuItem.Click += налаштуванняToolStripMenuItem_Click;

            // panelTop
            panelTop.BackColor = Color.FromArgb(249, 250, 251);
            panelTop.Controls.Add(btnNewTask);
            panelTop.Controls.Add(txtSearch);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 35);
            panelTop.Margin = new Padding(4, 3, 4, 3);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(30, 25, 30, 25);
            panelTop.Size = new Size(1167, 100);
            panelTop.TabIndex = 1;

            // btnNewTask
            btnNewTask.BackColor = Color.FromArgb(79, 70, 229);
            btnNewTask.FlatAppearance.BorderColor = Color.FromArgb(67, 56, 202);
            btnNewTask.FlatAppearance.BorderSize = 2;
            btnNewTask.FlatAppearance.MouseDownBackColor = Color.FromArgb(67, 56, 202);
            btnNewTask.FlatAppearance.MouseOverBackColor = Color.FromArgb(99, 102, 241);
            btnNewTask.FlatStyle = FlatStyle.Flat;
            btnNewTask.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNewTask.ForeColor = Color.White;
            btnNewTask.Location = new Point(875, 30);
            btnNewTask.Margin = new Padding(4, 3, 4, 3);
            btnNewTask.Name = "btnNewTask";
            btnNewTask.Size = new Size(150, 45);
            btnNewTask.TabIndex = 2;
            btnNewTask.Text = "+ Нова задача";
            btnNewTask.UseVisualStyleBackColor = false;
            btnNewTask.Click += btnNewTask_Click;

            // txtSearch
            txtSearch.Font = new Font("Segoe UI", 12F);
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Location = new Point(467, 29);
            txtSearch.Margin = new Padding(4, 3, 4, 3);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(349, 29);
            txtSearch.TabIndex = 1;
            txtSearch.Text = "Пошук";
            txtSearch.TextChanged += txtSearch_TextChanged;
            txtSearch.Enter += txtSearch_Enter;
            txtSearch.Leave += txtSearch_Leave;

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(31, 41, 55);
            lblTitle.Location = new Point(30, 25);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(232, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Усі завдання";

            // panelFilter
            panelFilter.BackColor = Color.FromArgb(243, 244, 246);
            panelFilter.Controls.Add(btnDelete);
            panelFilter.Controls.Add(btnCancel);
            panelFilter.Controls.Add(btnSave);
            panelFilter.Controls.Add(cmbSort);
            panelFilter.Controls.Add(cmbStatus);
            panelFilter.Dock = DockStyle.Top;
            panelFilter.Location = new Point(0, 135);
            panelFilter.Margin = new Padding(4, 3, 4, 3);
            panelFilter.Name = "panelFilter";
            panelFilter.Padding = new Padding(30, 20, 30, 20);
            panelFilter.Size = new Size(1167, 75);
            panelFilter.TabIndex = 2;

            // btnDelete - НОВА КНОПКА "ВИДАЛИТИ"
            btnDelete.BackColor = Color.FromArgb(220, 38, 38);
            btnDelete.FlatAppearance.BorderColor = Color.FromArgb(185, 28, 28);
            btnDelete.FlatAppearance.BorderSize = 2;
            btnDelete.FlatAppearance.MouseDownBackColor = Color.FromArgb(185, 28, 28);
            btnDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(239, 68, 68);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(650, 20);
            btnDelete.Margin = new Padding(4, 3, 4, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 35);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "🗑️ Видалити";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;

            // btnCancel
            btnCancel.BackColor = Color.FromArgb(34, 197, 94);
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(22, 163, 74);
            btnCancel.FlatAppearance.BorderSize = 2;
            btnCancel.FlatAppearance.MouseDownBackColor = Color.FromArgb(22, 163, 74);
            btnCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 211, 153);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(920, 20);
            btnCancel.Margin = new Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(130, 35);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "📤 Експорт";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;


            // btnSave
            btnSave.BackColor = Color.FromArgb(79, 70, 229);
            btnSave.FlatAppearance.BorderColor = Color.FromArgb(67, 56, 202);
            btnSave.FlatAppearance.BorderSize = 2;
            btnSave.FlatAppearance.MouseDownBackColor = Color.FromArgb(67, 56, 202);
            btnSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(99, 102, 241);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(785, 20);
            btnSave.Margin = new Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 35);
            btnSave.TabIndex = 2;
            btnSave.Text = "💾 Зберегти";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;

            // cmbSort
            cmbSort.BackColor = Color.White;
            cmbSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSort.FlatStyle = FlatStyle.Flat;
            cmbSort.Font = new Font("Segoe UI", 10F);
            cmbSort.ForeColor = Color.FromArgb(75, 85, 99);
            cmbSort.FormattingEnabled = true;
            cmbSort.Items.AddRange(new object[] {
                "Сортувати за датою",
                "Сортувати за назвою",
                "Сортувати за статусом"
            });
            cmbSort.Location = new Point(260, 25);
            cmbSort.Margin = new Padding(4, 3, 4, 3);
            cmbSort.Name = "cmbSort";
            cmbSort.Size = new Size(220, 25);
            cmbSort.TabIndex = 1;
            cmbSort.SelectedIndexChanged += cmbSort_SelectedIndexChanged;

            // cmbStatus
            cmbStatus.BackColor = Color.White;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FlatStyle = FlatStyle.Flat;
            cmbStatus.Font = new Font("Segoe UI", 10F);
            cmbStatus.ForeColor = Color.FromArgb(75, 85, 99);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Всі", "До", "В Процесі", "Зроблено" });
            cmbStatus.Location = new Point(30, 25);
            cmbStatus.Margin = new Padding(4, 3, 4, 3);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(200, 25);
            cmbStatus.TabIndex = 0;
            cmbStatus.SelectedIndexChanged += cmbStatus_SelectedIndexChanged;

            // dataGridTasks
            dataGridTasks.AllowUserToAddRows = false;
            dataGridTasks.AllowUserToDeleteRows = false;
            dataGridTasks.BackgroundColor = Color.White;
            dataGridTasks.BorderStyle = BorderStyle.None;
            dataGridTasks.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridTasks.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridTasks.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(55, 65, 81);
            dataGridTasks.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridTasks.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridTasks.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 8, 10, 8);
            dataGridTasks.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(55, 65, 81);
            dataGridTasks.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dataGridTasks.ColumnHeadersHeight = 45;
            dataGridTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridTasks.DefaultCellStyle.BackColor = Color.White;
            dataGridTasks.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dataGridTasks.DefaultCellStyle.ForeColor = Color.FromArgb(55, 65, 81);
            dataGridTasks.DefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
            dataGridTasks.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dataGridTasks.DefaultCellStyle.SelectionForeColor = Color.FromArgb(55, 65, 81);
            dataGridTasks.Dock = DockStyle.Fill;
            dataGridTasks.EnableHeadersVisualStyles = false;
            dataGridTasks.GridColor = Color.FromArgb(229, 231, 235);
            dataGridTasks.Location = new Point(0, 210);
            dataGridTasks.Margin = new Padding(4, 3, 4, 3);
            dataGridTasks.MultiSelect = false;
            dataGridTasks.Name = "dataGridTasks";
            dataGridTasks.ReadOnly = true;
            dataGridTasks.RowHeadersVisible = false;
            dataGridTasks.RowTemplate.Height = 40;
            dataGridTasks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridTasks.Size = new Size(1167, 540);
            dataGridTasks.TabIndex = 3;

            // MainForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 244, 246);
            ClientSize = new Size(1167, 750);
            Controls.Add(dataGridTasks);
            Controls.Add(panelFilter);
            Controls.Add(panelTop);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TaskFlow - Сучасний менеджер завдань";
            Load += MainForm_Load;

            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridTasks).EndInit();
            ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}