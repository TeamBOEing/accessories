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
        delegate void VoidDelegate();

        public ConfigUtilityForm()
        {
            InitializeComponent();
        }

        public void Operate()
        {
            string appdataRoaming = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            string appdataLocal = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            string documents = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            string downloads = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + @"\Downloads";
            string workingDir = Directory.GetCurrentDirectory();
            //string programConfig = Path.Combine(workingDir, "config.txt");
            string ideConfigFolder = "";
            //string ideConfigLocationOverride = "";
            //string sketchbookLocationOverride = "";
            string sketchbookPath = Path.Combine(documents, @"Arduino");
            string ideConfigPath = "";
            //bool ideConfigOverride = false;
            //bool sketchbookOverride = false;
            Uri libraryLocationOnline = new Uri(@"https://github.com/TeamBOEing/user_functions/archive/master.zip");
            Uri codeAndTestLocationOnline = new Uri(@"https://github.com/TeamBOEing/accessories/archive/master.zip");

            string librariesDirectory = Path.Combine(sketchbookPath, @"libraries\BOEbot");
            string accessoriesSrc = Path.Combine(downloads, "accessories-master");
            string librariesSrc = Path.Combine(downloads, "user_functions-master");
            string boeBotProjectDst = Path.Combine(sketchbookPath, @"ESA_Robot_Project\ESA_Robot_Project.ino");
            string boeBotTestDst = Path.Combine(sketchbookPath, @"ESA_Robot_Test\ESA_Robot_Test.ino");


            WebClient client = new WebClient();
            
            try
            {
                client.DownloadFile(libraryLocationOnline, Path.Combine(downloads, "BOEbot_library.zip"));
                this.Invoke(new VoidDelegate(Download1Finished));
            }
            catch (Exception e)
            {
                this.Invoke(new VoidDelegate(Download1Error));
            }

            try
            {
                client.DownloadFile(codeAndTestLocationOnline, Path.Combine(downloads, "BOEbot_code.zip"));
                this.Invoke(new VoidDelegate(Download2Finished));
            }
            catch (Exception e)
            {
                this.Invoke(new VoidDelegate(Download2Error));
            }

            try
            {
                Directory.Delete(Path.Combine(downloads, "user_functions-master"), true);
                Directory.Delete(Path.Combine(downloads, "accessories-master"), true);
            }
            catch (Exception e) { /* will error if no such directory exists */ }

            try
            {
                ZipFile.ExtractToDirectory(Path.Combine(downloads, "BOEbot_library.zip"), downloads);
                ZipFile.ExtractToDirectory(Path.Combine(downloads, "BOEbot_code.zip"), downloads);
            }
            catch (Exception e) {  /* */ }

            if (ContainsPreferencesFile(appdataRoaming, out ideConfigFolder))
                ideConfigPath = Path.Combine(appdataRoaming, ideConfigFolder);
            else if (ContainsPreferencesFile(appdataLocal, out ideConfigFolder))
                ideConfigPath = Path.Combine(appdataLocal, ideConfigFolder);
              
            List<String> configData = new List<String>();

            try
            {
                using (StreamReader sr = new StreamReader(ideConfigPath))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        string[] options = s.Split('=');
                        switch (options[0])
                        {
                            case "board": configData.Add("board=lilypad"); break;
                            case "custom_cpu": configData.Add("custom_cpu=lilypad_atmega328"); break;
                            case "editor.linenumbers": configData.Add("editor.linenumbers=true"); break;
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

                this.Invoke(new VoidDelegate(IDEConfigFinished));
            }
            catch (Exception e)
            {
                this.Invoke(new VoidDelegate(IDEConfigError));
            }

            Microsoft.VisualBasic.Devices.Computer pc = new Microsoft.VisualBasic.Devices.Computer();

            try
            {
                pc.FileSystem.CopyDirectory(Path.Combine(librariesSrc, "v1", "BOEbot"), librariesDirectory, true);
                this.Invoke(new VoidDelegate(Install1Finished));
            }
            catch (Exception e)
            {
                this.Invoke(new VoidDelegate(Install1Error));
            }
            
            try
            {
                pc.FileSystem.CopyDirectory(Path.Combine(accessoriesSrc, "ESA_Robot_Project"), Path.Combine(sketchbookPath, "ESA_Robot_Project"), true);
                pc.FileSystem.CopyDirectory(Path.Combine(accessoriesSrc, "ESA_Robot_Test"), Path.Combine(sketchbookPath, "ESA_Robot_Test"), true);

                this.Invoke(new VoidDelegate(Install2Finished));
            }
            catch (Exception e)
            {
                this.Invoke(new VoidDelegate(Install2Error));
            }
        }

        void Download1Finished()
        {
            lblDownload1.Text = lblDownload1.Text + " Completed.";
            lblDownload1.ForeColor = Color.Green;
            pgbStatus.PerformStep();
        }

        void Download1Error()
        {
            lblDownload1.Text = lblDownload1.Text + " Error.";
            lblDownload1.ForeColor = Color.Red;
            pgbStatus.PerformStep();
        }

        void Download2Finished()
        {
            lblDownload2.Text = lblDownload2.Text + " Completed.";
            lblDownload2.ForeColor = Color.Green;
            pgbStatus.PerformStep();
        }

        void Download2Error()
        {
            lblDownload2.Text = lblDownload2.Text + " Error.";
            lblDownload2.ForeColor = Color.Red;
            pgbStatus.PerformStep();
        }

        void IDEConfigFinished()
        {
            lblUpdateIDE.Text = lblUpdateIDE.Text + " Completed.";
            lblUpdateIDE.ForeColor = Color.Green;
            pgbStatus.PerformStep();
        }

        void IDEConfigError()
        {
            lblUpdateIDE.Text = lblUpdateIDE.Text + " Error.";
            lblUpdateIDE.ForeColor = Color.Red;
            pgbStatus.PerformStep();
        }

        void Install1Finished()
        {
            lblInstall1.Text = lblInstall1.Text + " Completed.";
            lblInstall1.ForeColor = Color.Green;
            pgbStatus.PerformStep();
        }

        void Install1Error()
        {
            lblInstall1.Text = lblInstall1.Text + " Error.";
            lblInstall1.ForeColor = Color.Red;
            pgbStatus.PerformStep();
        }

        void Install2Finished()
        {
            lblInstall2.Text = lblInstall2.Text + " Completed.";
            lblInstall2.ForeColor = Color.Green;
            pgbStatus.PerformStep();
        }

        void Install2Error()
        {
            lblInstall2.Text = lblInstall2.Text + " Error.";
            lblInstall2.ForeColor = Color.Red;
            pgbStatus.PerformStep();
        }

        bool ContainsPreferencesFile(string checkPath, out string foundPath)
        {
            string[] dirs = Directory.GetDirectories(checkPath, "Arduino*");
            foundPath = "";

            try
            {
                foreach (string s in dirs)
                {
                    string[] prefs = Directory.GetFiles(s, "preferences.txt");

                    foreach (string p in prefs)
                    {
                        foundPath = p;
                        return true;
                    }
                        
                }
            } catch(Exception e) { return false; }

            return false;
        }
    }
}
