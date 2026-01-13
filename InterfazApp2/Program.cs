using System;
using System.Windows.Forms;

namespace InterfazApp2
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }    
    }
}