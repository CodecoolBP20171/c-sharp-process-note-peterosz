using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProcessNote
{
    public partial class RunningProcessesPanel : Form
    {
        RunningProcesses runningProcesses = new RunningProcesses();
        string selectedProcessId = "";
        Dictionary<string, string> comments = new Dictionary<string, string>();

        public RunningProcessesPanel()
        {
            InitializeComponent();
        }

        private void RunningProcessesPanel_Load(object sender, EventArgs e)
        {

            dataGridView1.ColumnCount = 1;
            dataGridView1.Columns[0].Name = "Application Name";

            dataGridView2.ColumnCount = 7;
            dataGridView2.Columns[0].Name = "Process ID";
            dataGridView2.Columns[1].Name = "Process Name";
            dataGridView2.Columns[2].Name = "CPU usage";
            dataGridView2.Columns[3].Name = "Memory usage";
            dataGridView2.Columns[4].Name = "Running time";
            dataGridView2.Columns[5].Name = "Start time";
            dataGridView2.Columns[6].Name = "Threads of it in another dialog";

            foreach (string AppName in runningProcesses.GetAllWithAttributes().Keys)
            {
                dataGridView1.Rows.Add(AppName);
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Rows != null)
            {
                dataGridView2.Rows.Clear();
            }
            DataGridViewTextBoxCell selectedCell = (DataGridViewTextBoxCell)
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            string AppName = selectedCell.Value.ToString();
            foreach (string[] serviceArray in runningProcesses.GetAllWithAttributes()[AppName])
            {
                dataGridView2.Rows.Add(serviceArray);
            }
        }

        private void alwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.TopMost != true)
            {
                this.TopMost = true;
            } else
            {
                this.TopMost = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (richTextBox2.Text != null)
            {
                richTextBox2.Text = "";
            }
            DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
            string selectedProcess = selectedRow.Cells[1].Value.ToString();
            selectedProcessId = selectedRow.Cells[0].Value.ToString();
            label2.Text = selectedProcess;
            if (comments.ContainsKey(selectedProcessId))
            {
                richTextBox2.Text = comments[selectedProcessId];
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string commentToSave = richTextBox1.Text;
            if (comments.ContainsKey(selectedProcessId))
            {
                comments[selectedProcessId] = commentToSave;
            }
            else
            {
                comments.Add(selectedProcessId, commentToSave);
            }
            richTextBox1.Text = "Your comment was saved.";
            richTextBox2.Text = comments[selectedProcessId];
        }
    }
}
