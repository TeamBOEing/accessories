using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ESA_Arduino_IDE_Configuration_Utility
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ConfigUtilityForm cfg = new ConfigUtilityForm();

            Thread t = new Thread(cfg.Operate);
            t.Start();

            Application.Run(cfg);

        }
    }
}
