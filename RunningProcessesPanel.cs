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
            
            foreach (string process in runningProcesses.GetAllWithAttributes().Keys)
            {
                dataGridView1.Rows.Add(process);
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.ColumnCount = 6;
            dataGridView2.Columns[0].Name = "Process Name";
            dataGridView2.Columns[1].Name = "CPU usage";
            dataGridView2.Columns[2].Name = "Memory usage";
            dataGridView2.Columns[3].Name = "Running time";
            dataGridView2.Columns[4].Name = "Start time";
            dataGridView2.Columns[5].Name = "Threads of it in another dialog";
            DataGridViewCell selectedCell = (DataGridViewCell)
        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            foreach (Array list in runningProcesses.GetAllWithAttributes()[selectedCell.Value.ToString()])
            {
                foreach (string item in list)
                {
                    dataGridView2.Rows.Add(item);
                }
            }

        }
    }
}
