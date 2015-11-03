using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESA_Arduino_IDE_Configuration_Utility
{
    public partial class ConfigUtilityForm : Form
    {
        public ConfigUtilityForm()
        {
            InitializeComponent();
            Operate();
        }

        private void Operate()
        {
            string appdataRoaming = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            string documents = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            string programConfig = Path.Combine(Directory.GetCurrentDirectory(), "config.txt");
            string boeBotLibraries = Path.Combine(Directory.GetCurrentDirectory(), "BOEbot");
            string boeBotProjectCopyFrom = Path.Combine(Directory.GetCurrentDirectory(), "ESA_Robot_Project");
            string boeBotTestCopyFrom = Path.Combine(Directory.GetCurrentDirectory(), "ESA_Robot_Test");
            string ideConfigFolder = "";
            string sketchbookFolder = "";
            string ideConfigLocationOverride = "";
            string sketchbookLocationOverride = "";
            bool ideConfigOverride = false;
            bool sketchbookOverride = false;

            using (StreamReader sr = File.OpenText(programConfig))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null && !(ideConfigOverride && sketchbookOverride))
                {
                    if (s[0] != '#')
                    {
                        string[] options = s.Split(':');
                        switch(options[0])
                        {
                            case "IDEConfigLocationOverride":
                                ideConfigOverride = true;
                                ideConfigLocationOverride = options[1].Trim();
                                break;
                            case "SketchbookLocationOverride":
                                sketchbookOverride = true;
                                sketchbookLocationOverride = options[1].Trim();
                                break;
                            case "IDEConfigFolder":
                                ideConfigFolder = options[1].Trim();
                                break;
                            case "SketchbookFolder":
                                sketchbookFolder = options[1].Trim();
                                break;
                        }
                    }
                }
            }

            string ideConfigPath = ideConfigOverride ? ideConfigLocationOverride : Path.Combine(appdataRoaming, ideConfigFolder);
            string sketchbookPath = sketchbookOverride ? sketchbookLocationOverride : Path.Combine(documents, sketchbookFolder);
            string librariesDirectory = Path.Combine(sketchbookPath, @"libraries\BOEbot");
            string boeBotProject = Path.Combine(sketchbookPath, @"ESA_Robot_Project\ESA_Robot_Project.ino");
            string boeBotTest = Path.Combine(sketchbookPath, @"ESA_Robot_Test\ESA_Robot_Test.ino");

            lblStatus.Text = "Configuring Arduino IDE...";

            List<String> configData = new List<String>();

            using (StreamReader sr = new StreamReader(ideConfigPath))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    string[] options = s.Split('=');
                    switch(options[0])
                    {
                        case "board": configData.Add("board=lilypad"); break;
                        case "custom_cpu": configData.Add("custom_cpu=lilypad_atmega328"); break;
                        case "editor.linenumbers": configData.Add("editor.linenumbers=true"); break;
                        case "recent.sketches": configData.Add("recent.sketches=" + boeBotProject + "," + boeBotTest);  break;
                        case "serial.debug_rate": configData.Add("serial.debug_rate=115200"); break;
                        default: configData.Add(s); break;
                    }
                }
            }

            using (StreamWriter sw = new StreamWriter(ideConfigPath, false))
            {
                foreach (string s in configData)
                {
                    sw.WriteLine(s);
                }
            }

            Microsoft.VisualBasic.Devices.Computer pc = new Microsoft.VisualBasic.Devices.Computer();

            lblStatus.Text = "Installing BOEbot libraries...";
            pc.FileSystem.CopyDirectory(boeBotLibraries, librariesDirectory, true);

            lblStatus.Text = "Installing Robot Project template...";
            pc.FileSystem.CopyDirectory(boeBotProjectCopyFrom, Path.Combine(sketchbookPath, "ESA_Robot_Project"), true);
            pc.FileSystem.CopyDirectory(boeBotTestCopyFrom, Path.Combine(sketchbookPath, "ESA_Robot_Test"), true);
        }
    }
}
