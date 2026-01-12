using System;
<<<<<<< HEAD
=======
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
>>>>>>> 94dfd5bc9b72ff1b971c2a48c666bcc782ed5fa5
using System.Windows.Forms;

namespace InterfazApp
{
    internal static class Program
    {
<<<<<<< HEAD
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
=======
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
>>>>>>> 94dfd5bc9b72ff1b971c2a48c666bcc782ed5fa5
            Application.Run(new Form1());
        }
    }
}
