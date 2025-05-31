using System;
using System.Windows.Forms;

namespace TaskFlowApp
{
    internal static class Program
    {
        /// <summary>
        /// ������� ����� ����� ��� ��������.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"�������� ������� ��������: {ex.Message}",
                    "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}