using System.Windows.Forms;

namespace ProcessNote
{
    class ProcessNoteMain
    {
        
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RunningProcessesPanel());
        }
    }
}
