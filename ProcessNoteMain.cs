using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ProcessNote
{
    class ProcessNoteMain
    {

        public static void Main(string[] args)
        {
            RunningProcesses runningProcesses = new RunningProcesses();
            runningProcesses.ShowRunningProcesses();
        }
    }
}
