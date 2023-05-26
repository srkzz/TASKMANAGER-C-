using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Process[] proc;

        private void GetAllProcess()
        {
            proc = Process.GetProcesses();
            listBox.Items.Clear();
            foreach (Process p in proc)
                listBox.Items.Add(p.ProcessName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                proc[listBox.SelectedIndex].Kill();
                GetAllProcess();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetAllProcess();
        }

        private void novaTarefaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmRunTask frm = new frmRunTask())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    GetAllProcess();
            }
        }
    }
}