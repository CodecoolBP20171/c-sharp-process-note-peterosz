using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace ProcessNote
{
    class RunningProcesses
    {
        public RunningProcesses()
        {
       
        }

        public Dictionary<string, List
            <string[]>> GetAllWithAttributes()
        {
            Process[] localAll = Process.GetProcesses();
            Dictionary<string, List<string[]>> ProcessDict = new Dictionary<string, List<string[]>>();
            foreach (Process local in localAll)
            {
                string[] processAttributes = new string[6];
                string KeyToAdd = "";
                try
                {
                    processAttributes[0] = local.ProcessName.ToString();
                    processAttributes[1] = local.TotalProcessorTime.ToString();
                    processAttributes[2] = local.WorkingSet64.ToString();
                    processAttributes[3] = (DateTime.Now - local.StartTime).ToString();
                    processAttributes[4] = local.StartTime.ToString();
                    processAttributes[5] = local.Threads.ToString();
                    
                    KeyToAdd = Path.GetFileName(local.MainModule.FileName);
                }
                catch (Exception e) { }
                if (ProcessDict.ContainsKey(KeyToAdd)){
                    List<string[]> ListOfProcesses = new List<string[]>();
                    ListOfProcesses = ProcessDict[KeyToAdd];
                    ListOfProcesses.Add(processAttributes); 
                    ProcessDict[KeyToAdd] = ListOfProcesses;
                }
                else {
                    ProcessDict.Add(KeyToAdd, new List<string[]> { processAttributes });
                }
            }
            return ProcessDict;
        }
}
}
