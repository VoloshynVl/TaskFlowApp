using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TaskFlowApp
{
    public partial class MainForm : Form
    {
        private List<Task> tasks;
        private List<Task> filteredTasks;
        private BindingSource bindingSource;

        public MainForm()
        {
            InitializeComponent();
            tasks = new List<Task>();
            filteredTasks = new List<Task>();
            bindingSource = new BindingSource();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeDataGrid();
            LoadTasks();
            ApplyFilters();
        }

        private void InitializeDataGrid()
        {
            dataGridTasks.AutoGenerateColumns = false;
            dataGridTasks.Columns.Clear();

            // ������� �����
            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.DataPropertyName = "Name";
            nameColumn.HeaderText = "�����";
            nameColumn.Width = 250;
            dataGridTasks.Columns.Add(nameColumn);

            // ������� �����
            DataGridViewTextBoxColumn descColumn = new DataGridViewTextBoxColumn();
            descColumn.DataPropertyName = "Description";
            descColumn.HeaderText = "����";
            descColumn.Width = 300;
            dataGridTasks.Columns.Add(descColumn);

            // ������� �������
            DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn();
            statusColumn.DataPropertyName = "Status";
            statusColumn.HeaderText = "������";
            statusColumn.Width = 120;
            statusColumn.Items.AddRange(new string[] { "��", "� ������", "��������" });
            dataGridTasks.Columns.Add(statusColumn);

            // ������� ����
            DataGridViewTextBoxColumn dateColumn = new DataGridViewTextBoxColumn();
            dateColumn.DataPropertyName = "DueDate";
            dateColumn.HeaderText = "�����";
            dateColumn.Width = 120;
            dateColumn.DefaultCellStyle.Format = "dd.MM.yyyy";
            dataGridTasks.Columns.Add(dateColumn);

            // ������� ����
            DataGridViewTextBoxColumn tagColumn = new DataGridViewTextBoxColumn();
            tagColumn.DataPropertyName = "Tag";
            tagColumn.HeaderText = "����";
            tagColumn.Width = 150;
            dataGridTasks.Columns.Add(tagColumn);

            dataGridTasks.DataSource = bindingSource;
        }

        private void LoadTasks()
        {
            try
            {
                tasks = XmlManager.LoadTasks();
                if (tasks.Count == 0)
                {
                    // ������ �������� �����
                    tasks.Add(new Task("��������� ������ �������", "�������� ����� ����������", "������", DateTime.Now.AddDays(2), "������"));
                    tasks.Add(new Task("�������� ������������", "ϳ��������� ������� ������������", "������", DateTime.Now.AddDays(-1), "���������"));
                    tasks.Add(new Task("ϳ��������� �����������", "�������� ������ ��� �����������", "������", DateTime.Now.AddDays(1), "������"));
                    SaveTasks();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������� ������������: {ex.Message}", "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tasks = new List<Task>();
            }
        }

        private void SaveTasks()
        {
            try
            {
                XmlManager.SaveTasks(tasks);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������� ����������: {ex.Message}", "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilters()
        {
            filteredTasks = new List<Task>(tasks);

            // Գ���� �� ��������
            if (cmbStatus.SelectedItem != null && cmbStatus.SelectedItem.ToString() != "��")
            {
                string selectedStatus = cmbStatus.SelectedItem.ToString();
                filteredTasks = filteredTasks.Where(t => t.Status == selectedStatus).ToList();
            }

            // Գ���� �� �������
            if (!string.IsNullOrEmpty(txtSearch.Text) && txtSearch.Text != "�����")
            {
                string searchText = txtSearch.Text.ToLower();
                filteredTasks = filteredTasks.Where(t =>
                    t.Name.ToLower().Contains(searchText) ||
                    t.Description.ToLower().Contains(searchText) ||
                    t.Tag.ToLower().Contains(searchText)).ToList();
            }

            // ����������
            if (cmbSort.SelectedItem != null)
            {
                string sortBy = cmbSort.SelectedItem.ToString();
                switch (sortBy)
                {
                    case "��������� �� ������":
                        filteredTasks = filteredTasks.OrderBy(t => t.Name).ToList();
                        break;
                    case "��������� �� ��������":
                        filteredTasks = filteredTasks.OrderBy(t => t.Status).ToList();
                        break;
                    default: // �� �����
                        filteredTasks = filteredTasks.OrderBy(t => t.DueDate).ToList();
                        break;
                }
            }

            bindingSource.DataSource = filteredTasks;
            bindingSource.ResetBindings(false);
        }

        // ��������� ���� ����
        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "�� ��������";
            cmbStatus.SelectedIndex = 0;
            ApplyFilters();
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "�������";
            filteredTasks = tasks.Where(t => t.DueDate.Date == DateTime.Now.Date).ToList();
            bindingSource.DataSource = filteredTasks;
            bindingSource.ResetBindings(false);
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "����";
            MessageBox.Show("������� ��������� ������ ���� ������ � ��������� ������", "����������", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ���������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "���������";
            filteredTasks = tasks.Where(t => t.Status == "��������").ToList();
            bindingSource.DataSource = filteredTasks;
            bindingSource.ResetBindings(false);
        }

        private void ������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("������� ����������� ���� ������ � ��������� ������", "����������", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ��������� ���� �������
        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        // ��������� ���� ������
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "�����")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "�����";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        // ��������� ���� ������
        private void btnNewTask_Click(object sender, EventArgs e)
        {
            TaskForm taskForm = new TaskForm();
            if (taskForm.ShowDialog() == DialogResult.OK)
            {
                tasks.Add(taskForm.Task);
                SaveTasks();
                ApplyFilters();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // �������� ���� � DataGrid ����� �� ������ �����
                bindingSource.EndEdit();

                // ��������� ����������� ������ �����
                foreach (Task filteredTask in filteredTasks)
                {
                    Task originalTask = tasks.FirstOrDefault(t =>
                        t.Name == filteredTask.Name &&
                        t.Description == filteredTask.Description);

                    if (originalTask != null)
                    {
                        originalTask.Status = filteredTask.Status;
                        originalTask.DueDate = filteredTask.DueDate;
                        originalTask.Tag = filteredTask.Tag;
                    }
                }

                SaveTasks();
                MessageBox.Show("���� ��������� ������!", "����������", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������� ����������: {ex.Message}", "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadTasks();
            ApplyFilters();
            MessageBox.Show("���� ���������", "����������", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}