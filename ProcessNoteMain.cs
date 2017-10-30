using System.Windows.Forms;

namespace ProcessNote
{
    class ProcessNoteMain
    {
        
        public static void Main(string[] args)
        {
            //runningprocesses runningprocesses = new runningprocesses();
            //foreach (string process in runningprocesses.getrunningprocesses())
            //{
            //    console.writeline(process);
            //}
            //console.readkey();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RunningProcessesPanel());
        }
    }
}
