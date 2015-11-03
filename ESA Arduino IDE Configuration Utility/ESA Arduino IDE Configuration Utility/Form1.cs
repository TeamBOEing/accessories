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
using System.IO.Compression;
using System.Net;

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
            string downloads = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + @"\Downloads";
            string workingDir = Directory.GetCurrentDirectory();
            string programConfig = Path.Combine(workingDir, "config.txt");
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
                            case "IDEConfigPath":
                                ideConfigFolder = options[1].Trim();
                                break;
                            case "SketchbookFolder":
                                sketchbookFolder = options[1].Trim();
                                break;
                        }
                    }
                }
            }

            WebClient client = new WebClient();
            Uri libraryLocationOnline = new Uri(@"https://github.com/TeamBOEing/user_functions/archive/master.zip");
            Uri codeAndTestLocationOnline = new Uri(@"https://github.com/TeamBOEing/accessories/archive/master.zip");

            client.DownloadFile(libraryLocationOnline, Path.Combine (downloads, "BOEbot_library.zip"));
            client.DownloadFile(codeAndTestLocationOnline, Path.Combine(downloads, "BOEbot_code.zip"));

            Directory.Delete(Path.Combine(downloads, "user_functions-master"), true);
            Directory.Delete(Path.Combine(downloads, "accessories-master"), true);
            ZipFile.ExtractToDirectory(Path.Combine(downloads, "BOEbot_library.zip"), downloads);
            ZipFile.ExtractToDirectory(Path.Combine(downloads, "BOEbot_code.zip"), downloads);

            string ideConfigPath = ideConfigOverride ? ideConfigLocationOverride : Path.Combine(appdataRoaming, ideConfigFolder);
            string sketchbookPath = sketchbookOverride ? sketchbookLocationOverride : Path.Combine(documents, sketchbookFolder);
            string librariesDirectory = Path.Combine(sketchbookPath, @"libraries\BOEbot");
            string accessoriesSrc = Path.Combine(downloads, "accessories-master");
            string librariesSrc = Path.Combine(downloads, "user_functions-master");
            string boeBotProjectDst = Path.Combine(sketchbookPath, @"ESA_Robot_Project\ESA_Robot_Project.ino");
            string boeBotTestDst = Path.Combine(sketchbookPath, @"ESA_Robot_Test\ESA_Robot_Test.ino");

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
                        case "recent.sketches": configData.Add("recent.sketches=" + boeBotProjectDst + "," + boeBotTestDst);  break;
                        case "serial.debug_rate": configData.Add("serial.debug_rate=115200"); break;
                        case "sketchbook.path": configData.Add("sketchbook.path=" + sketchbookPath); break;
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
            pc.FileSystem.CopyDirectory(Path.Combine(librariesSrc, "v1", "BOEbot"), librariesDirectory, true);

            lblStatus.Text = "Installing Robot Project template...";
            pc.FileSystem.CopyDirectory(Path.Combine(accessoriesSrc, "ESA_Robot_Project"), Path.Combine(sketchbookPath, "ESA_Robot_Project"), true);
            pc.FileSystem.CopyDirectory(Path.Combine(accessoriesSrc, "ESA_Robot_Test"), Path.Combine(sketchbookPath, "ESA_Robot_Test"), true);
        }
    }
}
