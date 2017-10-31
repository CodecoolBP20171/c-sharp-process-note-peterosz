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

        public RunningProcessesPanel()
        {
            InitializeComponent();
        }

        private void RunningProcessesPanel_Load(object sender, EventArgs e)
        {

            dataGridView1.ColumnCount = 1;
            dataGridView1.Columns[0].Name = "Application Name";

            dataGridView2.ColumnCount = 6;
            dataGridView2.Columns[0].Name = "Process Name";
            dataGridView2.Columns[1].Name = "CPU usage";
            dataGridView2.Columns[2].Name = "Memory usage";
            dataGridView2.Columns[3].Name = "Running time";
            dataGridView2.Columns[4].Name = "Start time";
            dataGridView2.Columns[5].Name = "Threads of it in another dialog";

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
    }
}
