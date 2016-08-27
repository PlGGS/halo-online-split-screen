using System;
using System.Windows.Forms;

namespace Halo_Online_Split_Screen
{

    static class Program
    {
        
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmMain main = new frmMain(Screen.PrimaryScreen.Bounds.Width / 2 - 700 / 2, Screen.PrimaryScreen.Bounds.Height / 2 - 500 / 2);
            main.Show();
            Application.Run();

        }
        
    }

}
