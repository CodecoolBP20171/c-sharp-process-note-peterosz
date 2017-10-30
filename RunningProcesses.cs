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

        public List<string> getRunningProcesses()
        {
            Process[] localAll = Process.GetProcesses();
            List<string> ProcessList = new List<string>();
            foreach (Process local in localAll)
            {
                ProcessList.Add(local.ProcessName.ToString());
            }
            return ProcessList;
        }
}
}
