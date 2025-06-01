using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TaskFlowApp
{
    public partial class MainForm : Form
    {
        private List<TaskFlowApp.Task> tasks;
        private List<TaskFlowApp.Task> filteredTasks;
        private bool isDataModified = false;

        public MainForm()
        {
            InitializeComponent();
            tasks = new List<TaskFlowApp.Task>();
            filteredTasks = new List<TaskFlowApp.Task>();

            // ����������� �������� ��������
            cmbStatus.SelectedIndex = 0; // "��"
            cmbSort.SelectedIndex = 0;   // "��������� �� �����"

            // ����������� ����������� ���
            LoadTasksFromXml();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            RefreshTaskList();
        }

        private void SetupDataGridView()
        {
            dataGridTasks.AutoGenerateColumns = false;
            dataGridTasks.Columns.Clear();

            // ������ �������
            dataGridTasks.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "�����",
                DataPropertyName = "Name",
                Width = 200
            });

            dataGridTasks.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Description",
                HeaderText = "����",
                DataPropertyName = "Description",
                Width = 300
            });

            dataGridTasks.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "������",
                DataPropertyName = "Status",
                Width = 100
            });

            dataGridTasks.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DueDate",
                HeaderText = "�����",
                DataPropertyName = "DueDate",
                Width = 120
            });

            dataGridTasks.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Tag",
                HeaderText = "���",
                DataPropertyName = "Tag",
                Width = 150
            });

            // ����������� ������������ ����
            dataGridTasks.CellFormatting += DataGridTasks_CellFormatting;

            // ������ �������� ��������� ���� ��� �����������
            dataGridTasks.CellDoubleClick += DataGridTasks_CellDoubleClick;
        }

        private void DataGridTasks_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridTasks.Columns[e.ColumnIndex].Name == "DueDate" && e.Value != null)
            {
                if (e.Value is DateTime dateTime)
                {
                    e.Value = dateTime.ToString("dd.MM.yyyy");
                    e.FormattingApplied = true;
                }
            }
        }

        private void DataGridTasks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < filteredTasks.Count)
            {
                EditTask(filteredTasks[e.RowIndex]);
            }
        }

        private void btnNewTask_Click(object sender, EventArgs e)
        {
            using (TaskForm taskForm = new TaskForm())
            {
                if (taskForm.ShowDialog() == DialogResult.OK)
                {
                    tasks.Add(taskForm.Task);
                    isDataModified = true;
                    RefreshTaskList();
                }
            }
        }

        // ���� ����ֲ�����Ͳ��� ���������
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridTasks.SelectedRows.Count == 0)
            {
                MessageBox.Show("���� �����, ������ �������� ��� ���������.",
                    "������������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedTask = (TaskFlowApp.Task)dataGridTasks.SelectedRows[0].DataBoundItem;

            DialogResult result = MessageBox.Show(
                $"�� �������, �� ������ �������� �������� \"{selectedTask.Name}\"?",
                "ϳ����������� ���������",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // ��������� � ��������� ������
                    tasks.Remove(selectedTask);

                    // ��������� ��� �� �����
                    isDataModified = true;

                    // ��������� �����������
                    RefreshTaskList();

                    MessageBox.Show("�������� �������� ������!",
                        "���������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"������� ��� �������� ��������: {ex.Message}",
                        "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EditTask(TaskFlowApp.Task taskToEdit)
        {
            using (TaskForm taskForm = new TaskForm(taskToEdit))
            {
                if (taskForm.ShowDialog() == DialogResult.OK)
                {
                    // ��������� ������ ���������� ������
                    int index = tasks.IndexOf(taskToEdit);
                    if (index >= 0)
                    {
                        tasks[index] = taskForm.Task;
                        isDataModified = true;
                        RefreshTaskList();
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveTasksToXml();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // ������ �� "������������" ����� � ����� �������
            LoadTasksFromXml();
        }

        private void SaveTasksToXml()
        {
            try
            {
                XmlManager.SaveTasks(tasks);
                isDataModified = false;
                MessageBox.Show("��� ������ ���������!", "����������",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������� ����������: {ex.Message}", "�������",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTasksFromXml()
        {
            try
            {
                tasks = XmlManager.LoadTasks();
                isDataModified = false;
                RefreshTaskList();
                MessageBox.Show("��� ������ �����������!", "������������",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������� ������������: {ex.Message}", "�������",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                tasks = new List<TaskFlowApp.Task>();
                RefreshTaskList();
            }
        }

        private void RefreshTaskList()
        {
            ApplyFilters();
            ApplySorting();
            dataGridTasks.DataSource = null;
            dataGridTasks.DataSource = filteredTasks;
        }

        private void ApplyFilters()
        {
            filteredTasks = new List<TaskFlowApp.Task>(tasks);

            // Գ���� �� ��������
            string selectedStatus = cmbStatus.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedStatus) && selectedStatus != "��")
            {
                filteredTasks = filteredTasks.Where(t => t.Status == selectedStatus).ToList();
            }

            // Գ���� ������
            string searchText = txtSearch.Text;
            if (!string.IsNullOrEmpty(searchText) && searchText != "�����")
            {
                filteredTasks = filteredTasks.Where(t =>
                    t.Name.ToLower().Contains(searchText.ToLower()) ||
                    t.Description.ToLower().Contains(searchText.ToLower()) ||
                    t.Tag.ToLower().Contains(searchText.ToLower())
                ).ToList();
            }
        }

        private void ApplySorting()
        {
            string selectedSort = cmbSort.SelectedItem?.ToString();

            switch (selectedSort)
            {
                case "��������� �� �����":
                    filteredTasks = filteredTasks.OrderBy(t => t.DueDate).ToList();
                    break;
                case "��������� �� ������":
                    filteredTasks = filteredTasks.OrderBy(t => t.Name).ToList();
                    break;
                case "��������� �� ��������":
                    filteredTasks = filteredTasks.OrderBy(t => t.Status).ToList();
                    break;
            }
        }

        // ��������� ����
        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "�� ��������";
            cmbStatus.SelectedIndex = 0; // "��"
            RefreshTaskList();
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "�������";
            // Գ������� ������ �� �������
            DateTime today = DateTime.Today;
            filteredTasks = tasks.Where(t => t.DueDate.Date == today).ToList();
            ApplySorting();
            dataGridTasks.DataSource = null;
            dataGridTasks.DataSource = filteredTasks;
        }

        private void ���������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "���������";
            cmbStatus.SelectedIndex = 3; // "��������"
            RefreshTaskList();
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // �������� ������� ����
            var uniqueTags = tasks.Where(t => !string.IsNullOrEmpty(t.Tag))
                                 .Select(t => t.Tag)
                                 .Distinct()
                                 .ToList();

            string message = uniqueTags.Count > 0
                ? "������� ����:\n" + string.Join("\n", uniqueTags)
                : "���� ��������� ����";

            MessageBox.Show(message, "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("������������ ���� �� ���������", "������������",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ��������� �������
        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshTaskList();
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshTaskList();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshTaskList();
        }

        // ��������� ��� placeholder ������ � ������
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "�����")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "�����";
                txtSearch.ForeColor = System.Drawing.Color.Gray;
            }
        }

        // �������� ����� ��������� �����
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (isDataModified)
            {
                DialogResult result = MessageBox.Show(
                    "� ��� � ���������� ����. ������ �������� �� ����� ���������?",
                    "���������� ����",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SaveTasksToXml();
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }

            base.OnFormClosing(e);
        }
    }
}