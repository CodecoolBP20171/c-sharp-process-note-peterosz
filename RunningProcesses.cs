using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ProcessNote
{
    class RunningProcesses
    {
        public RunningProcesses()
        {
       
        }

        public void ShowRunningProcesses()
        {
            Process[] localAll = Process.GetProcesses();
            foreach (Process local in localAll)
            {
                Console.WriteLine(local.ToString());
            }
        }
}
}
