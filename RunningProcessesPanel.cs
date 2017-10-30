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
        public RunningProcessesPanel()
        {
            InitializeComponent();
        }

        private void RunningProcessesPanel_Load(object sender, EventArgs e)
        {
            RunningProcesses runningProcesses = new RunningProcesses();

            dataGridView1.ColumnCount = 1;
            dataGridView1.Columns[0].Name = "Process Name";

            foreach(string process in runningProcesses.getRunningProcesses())
            {
                dataGridView1.Rows.Add(process);
            }
        }
    }
}
