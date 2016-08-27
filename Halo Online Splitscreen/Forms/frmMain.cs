using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.ComponentModel;

namespace Halo_Online_Split_Screen
{
    
    public partial class frmMain : Form
    {

        FolderBrowserDialog _fbd = new FolderBrowserDialog();
        frmLoading loader;
        bool appExit = true;
        sbyte dir = 0;
        int xPos;
        int yPos;

        public frmMain(int x, int y)
        {
            
            xPos = x;
            yPos = y;

            loader = new frmLoading();

            InitializeComponent();

        }

        /// <summary>
        /// Handles frmLoading's cancel button's click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {

            DialogResult cancel = MessageBox.Show("Are you sure you want to cancel the directory configuration process? This will delete all files that were transferred and close the application.", "Halo Online Split Screen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (cancel == DialogResult.Yes)
            {
                
                wkrLoading.Dispose();
                
                loader.Message = "One moment. \n Cancelling...";

                try
                {

                    for (sbyte i = 1; i <= 4; i++)
                    {

                        if (Directory.Exists(Properties.Settings.Default.installationDirectory + "\\P" + i))
                        {

                            Directory.Delete(Properties.Settings.Default.installationDirectory + "\\P" + i, true);

                        }

                    }

                }
                finally
                {

                    Application.Exit();

                }

            }
            else
            {

                MessageBox.Show("Did not cancel directory configuration.", "Halo Online Split Screen");

            }
            
        }

        /// <summary>
        /// Copies the user's Halo Online directory four times over to be used for split screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wkrLoading_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

            BackgroundWorker worker = sender as BackgroundWorker;
            
            for (sbyte i = 1; i <= 4; i++)
            {

                if (Directory.Exists(Properties.Settings.Default.installationDirectory + "\\" + "P" + i))
                {

                    Directory.Delete(Properties.Settings.Default.installationDirectory + "\\" + "P" + i, true);

                }

            }

            for (sbyte i = 1; i <= 4; i++)
            {

                if (worker.CancellationPending == true)
                {

                    e.Cancel = true;
                    break;

                }
                else
                {

                    DirectoryCopy(Properties.Settings.Default.haloOnlineDirectory, Properties.Settings.Default.installationDirectory + "\\" + "P" + i, true, "HOSS");
                    worker.ReportProgress(i * 25);

                }

            }

        }

        /// <summary>
        /// Changes the text and progress of frmLoading's procedures when called.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wkrLoading_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            
            dir++;

            loader.Message = loader.Message.Substring(0, loader.Message.Length - 4) + dir + "/4)";
            
            loader.ProgressValue = e.ProgressPercentage;

        }

        /// <summary>
        /// Called when frmLoading has finished its procedures, and it is time for frmMain to show itself.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wkrLoading_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

            if (e.Error != null)
            {

                dir = 0;
                MessageBox.Show("Error: " + e.Error.Message, "Halo Online Split Screen");
                Application.Exit();

            } else
            {
                
                GameMethods.CreateShortcut("Halo Online Split Screen", Properties.Settings.Default.haloOnlineDirectory + "\\", Properties.Settings.Default.installationDirectory + "\\Halo Online Split Screen.exe", "", Properties.Settings.Default.installationDirectory, Properties.Settings.Default.installationDirectory + "\\bin\\logo.ico", "Get your friends and hop into a game of Halo Online on one PC!");
                Console.WriteLine("Successfully created the Halo Online Split Screen shortcut in the user's Halo Online Directory.");

                dir = 0;
                this.Enabled = true;
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                this.Opacity = 100;

            }

            loader.Close();

        }

        /// <summary>
        /// Loads up the application for installation or basic use.
        /// </summary>
        private void loadApplication()
        {

            this.Location = new Point(xPos, yPos);

            if (!Directory.Exists(Properties.Settings.Default.installationDirectory + "\\P1") || !Directory.Exists(Properties.Settings.Default.installationDirectory + "\\P2")
                || !Directory.Exists(Properties.Settings.Default.installationDirectory + "\\P3") || !Directory.Exists(Properties.Settings.Default.installationDirectory + "\\P4"))
            {

                this.Enabled = false;
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                this.Opacity = 0;

                DialogResult storage = MessageBox.Show("This program requires an average of around 16 gigabytes of storage to install. Is this okay?", "Halo Online Split Screen", MessageBoxButtons.OKCancel);

                if (storage == DialogResult.Cancel)
                {

                    Environment.Exit(0);

                }
                else
                {

                    wkrLoading.RunWorkerAsync();

                }

                loader.Canceled += new EventHandler<EventArgs>(btnCancel_Click);
                loader.Show();
                loader.TopMost = true;
                loader.Visible = false;
                loader.Visible = true;

            }
            else
            {

                this.Enabled = true;
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                this.Opacity = 100;

            }

            loadSettingsFromConfig();
            setChangelogText();

            KeyPreview = true;

            Console.WriteLine("Installation Directory: " + Properties.Settings.Default.haloOnlineDirectory);
            Console.WriteLine("Halo Online Directory: " + Properties.Settings.Default.installationDirectory);

            if (Properties.Settings.Default.amtInstances < 1)
            {

                Properties.Settings.Default.amtInstances = 1;
                cbxAmtInstances.SelectedIndex = Properties.Settings.Default.amtInstances - 1;

            }

            cbxAmtInstances.SelectedIndex = Properties.Settings.Default.amtInstances - 1;
            cbxScreen1.SelectedIndex = Properties.Settings.Default.resolutionP1;
            cbxScreen2.SelectedIndex = Properties.Settings.Default.resolutionP2;
            cbxScreen3.SelectedIndex = Properties.Settings.Default.resolutionP3;
            cbxScreen4.SelectedIndex = Properties.Settings.Default.resolutionP4;
            cbxGraphicSetting.SelectedIndex = Properties.Settings.Default.graphicSetting;

            chkConsoleMode.Checked = Properties.Settings.Default.launchConsoleMode;
            cbxConsoleModeOrientation.SelectedIndex = Properties.Settings.Default.consoleModeOrientation;
            chkFullscreen.Checked = Properties.Settings.Default.launchFullscreen;
            chkVSync.Checked = Properties.Settings.Default.launchVSync;
            chkAntiAliasing.Checked = Properties.Settings.Default.launchAntiAliasing;
            chkKeyboardControlsP1.Checked = Properties.Settings.Default.keyboardControlsP1;
            chkCloseLauncherAfterLaunch.Checked = Properties.Settings.Default.closeLauncherAfterLaunch;
            txtTimeBtwnLaunches.Text = Properties.Settings.Default.secondsAmidLaunches.ToString();

            Properties.Settings.Default.Save();

            writeSettingsToConfig();
            setEnabledSettings();

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
            Properties.Settings.Default.haloOnlineDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6).Substring(0, Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6).Length - (Environment.CurrentDirectory.Substring(Environment.CurrentDirectory.LastIndexOf("\\") + 1, Environment.CurrentDirectory.Substring(Environment.CurrentDirectory.LastIndexOf("\\")).Length - 1).Length + 1));
            Properties.Settings.Default.installationDirectory = Properties.Settings.Default.haloOnlineDirectory + "\\" + Environment.CurrentDirectory.Substring(Environment.CurrentDirectory.LastIndexOf("\\") + 1, Environment.CurrentDirectory.Substring(Environment.CurrentDirectory.LastIndexOf("\\")).Length - 1);

            if (!File.Exists(Properties.Settings.Default.haloOnlineDirectory + "\\eldorado.exe") ||
                !File.Exists(Properties.Settings.Default.haloOnlineDirectory + "\\mtndew.dll") ||
                !File.Exists(Properties.Settings.Default.haloOnlineDirectory + "\\binkw32.dll"))
            {

                MessageBox.Show("Please place your HOSS installation files inside of a working 0.5.1.1 Halo Online directory.", "Halo Online Split Screen");
                Environment.Exit(0);

            }
            else if (File.Exists(Properties.Settings.Default.haloOnlineDirectory + "\\eldorado.exe") &&
                File.Exists(Properties.Settings.Default.haloOnlineDirectory + "\\mtndew.dll") &&
                File.Exists(Properties.Settings.Default.haloOnlineDirectory + "\\binkw32.dll") &&
                FileVersionInfo.GetVersionInfo(Properties.Settings.Default.haloOnlineDirectory + "\\mtndew.dll").ProductVersion != "0.5.1.1" &&
                Properties.Settings.Default.serverMessage)
            {

                if (FileVersionInfo.GetVersionInfo(Properties.Settings.Default.haloOnlineDirectory + "\\mtndew.dll").ProductVersion == "0.5.0.2")
                {

                    DialogResult server = MessageBox.Show("Your Halo Online directory is out of date, but on a version that is compatible with /u/RabidSquabbit's dedicated server hosting tool. Are you using a server hosting tool?", "Halo Online Split Screen", MessageBoxButtons.YesNo);

                    if (server == DialogResult.Yes)
                    {

                        Properties.Settings.Default.serverMessage = false;
                        Properties.Settings.Default.Save();
                        loadApplication();

                    }
                    else
                    {

                        Environment.Exit(0);

                    }

                }
                else
                {

                    MessageBox.Show("Your Halo Online directory is out of date. Please update it before installing Halo Online Split Screen", "Halo Online Split Screen");
                    Environment.Exit(0);

                }

            }
            else if (File.Exists(Properties.Settings.Default.haloOnlineDirectory + "\\eldorado.exe") &&
                File.Exists(Properties.Settings.Default.haloOnlineDirectory + "\\mtndew.dll") &&
                File.Exists(Properties.Settings.Default.haloOnlineDirectory + "\\binkw32.dll") &&
                FileVersionInfo.GetVersionInfo(Properties.Settings.Default.haloOnlineDirectory + "\\mtndew.dll").ProductVersion == "0.5.1.1")
            {

                loadApplication();

            }

        }
        
        /// <summary>
        /// Create's a HOSS.cfg file with the application's settings.
        /// </summary>
        public void writeSettingsToConfig()
        {
            
            FileStream tmp = File.Create(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6).Substring(0, Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6).Length - (Environment.CurrentDirectory.Substring(Environment.CurrentDirectory.LastIndexOf("\\") + 1, Environment.CurrentDirectory.Substring(Environment.CurrentDirectory.LastIndexOf("\\")).Length - 1).Length)) + Environment.CurrentDirectory.Substring(Environment.CurrentDirectory.LastIndexOf("\\") + 1, Environment.CurrentDirectory.Substring(Environment.CurrentDirectory.LastIndexOf("\\")).Length - 1) + "\\bin\\HOSS.cfg");
            
            StreamWriter sw = new StreamWriter(tmp);

            sw.WriteLine(Properties.Settings.Default.P1Name.ToString());
            sw.WriteLine(Properties.Settings.Default.P2Name.ToString());
            sw.WriteLine(Properties.Settings.Default.P3Name.ToString());
            sw.WriteLine(Properties.Settings.Default.P4Name.ToString());

            sw.WriteLine(Properties.Settings.Default.haloOnlineDirectory.ToString());
            sw.WriteLine(Properties.Settings.Default.installationDirectory.ToString());

            sw.WriteLine(Properties.Settings.Default.amtInstances.ToString());
            sw.WriteLine(Properties.Settings.Default.resolutionP1.ToString());
            sw.WriteLine(Properties.Settings.Default.resolutionP2.ToString());
            sw.WriteLine(Properties.Settings.Default.resolutionP3.ToString());
            sw.WriteLine(Properties.Settings.Default.resolutionP4.ToString());
            sw.WriteLine(Properties.Settings.Default.graphicSetting.ToString());

            sw.WriteLine(Properties.Settings.Default.launchConsoleMode.ToString());
            sw.WriteLine(Properties.Settings.Default.consoleModeOrientation.ToString());
            sw.WriteLine(Properties.Settings.Default.launchFullscreen.ToString());
            sw.WriteLine(Properties.Settings.Default.launchVSync.ToString());
            sw.WriteLine(Properties.Settings.Default.launchAntiAliasing.ToString());
            sw.WriteLine(Properties.Settings.Default.keyboardControlsP1.ToString());
            sw.WriteLine(Properties.Settings.Default.closeLauncherAfterLaunch.ToString());
            sw.WriteLine(Properties.Settings.Default.secondsAmidLaunches.ToString());

            sw.Dispose();
            tmp.Dispose();
            
            Console.WriteLine("Successfully wrote settings to the config.");

        }

        /// <summary>
        /// Sets the application's settings to the ones determined in the HOSS.cfg file.
        /// </summary>
        public void loadSettingsFromConfig()
        {
            
            if (File.Exists(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6).Substring(0, Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6).Length - (Environment.CurrentDirectory.Substring(Environment.CurrentDirectory.LastIndexOf("\\") + 1, Environment.CurrentDirectory.Substring(Environment.CurrentDirectory.LastIndexOf("\\")).Length - 1).Length)) + Environment.CurrentDirectory.Substring(Environment.CurrentDirectory.LastIndexOf("\\") + 1, Environment.CurrentDirectory.Substring(Environment.CurrentDirectory.LastIndexOf("\\")).Length - 1) + "\\bin\\HOSS.cfg"))
            {

                Properties.Settings.Default.P1Directory = Properties.Settings.Default.installationDirectory + "\\" + "P1";
                Properties.Settings.Default.P2Directory = Properties.Settings.Default.installationDirectory + "\\" + "P2";
                Properties.Settings.Default.P3Directory = Properties.Settings.Default.installationDirectory + "\\" + "P3";
                Properties.Settings.Default.P4Directory = Properties.Settings.Default.installationDirectory + "\\" + "P4";

                Properties.Settings.Default.Save();

                StreamReader sr = new StreamReader(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6).Substring(0, Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6).Length - (Environment.CurrentDirectory.Substring(Environment.CurrentDirectory.LastIndexOf("\\") + 1, Environment.CurrentDirectory.Substring(Environment.CurrentDirectory.LastIndexOf("\\")).Length - 1).Length)) + Environment.CurrentDirectory.Substring(Environment.CurrentDirectory.LastIndexOf("\\") + 1, Environment.CurrentDirectory.Substring(Environment.CurrentDirectory.LastIndexOf("\\")).Length - 1) + "\\bin\\HOSS.cfg");

                try
                {

                    Properties.Settings.Default.P1Name = sr.ReadLine();
                    Properties.Settings.Default.P2Name = sr.ReadLine();
                    Properties.Settings.Default.P3Name = sr.ReadLine();
                    Properties.Settings.Default.P4Name = sr.ReadLine();

                    sr.ReadLine();
                    sr.ReadLine();

                    Properties.Settings.Default.amtInstances = Convert.ToSByte(sr.ReadLine());
                    Properties.Settings.Default.resolutionP1 = Convert.ToSByte(sr.ReadLine());
                    Properties.Settings.Default.resolutionP2 = Convert.ToSByte(sr.ReadLine());
                    Properties.Settings.Default.resolutionP3 = Convert.ToSByte(sr.ReadLine());
                    Properties.Settings.Default.resolutionP4 = Convert.ToSByte(sr.ReadLine());
                    Properties.Settings.Default.graphicSetting = Convert.ToSByte(sr.ReadLine());

                    Properties.Settings.Default.launchConsoleMode = Convert.ToBoolean(sr.ReadLine());
                    Properties.Settings.Default.consoleModeOrientation = Convert.ToSByte(sr.ReadLine());
                    Properties.Settings.Default.launchFullscreen = Convert.ToBoolean(sr.ReadLine());
                    Properties.Settings.Default.launchVSync = Convert.ToBoolean(sr.ReadLine());
                    Properties.Settings.Default.launchAntiAliasing = Convert.ToBoolean(sr.ReadLine());
                    Properties.Settings.Default.keyboardControlsP1 = Convert.ToBoolean(sr.ReadLine());
                    Properties.Settings.Default.closeLauncherAfterLaunch = Convert.ToBoolean(sr.ReadLine());
                    Properties.Settings.Default.secondsAmidLaunches = Convert.ToInt32(sr.ReadLine());

                    sr.Dispose();

                }
                catch
                {

                    sr.Dispose();
                    writeSettingsToConfig();
                    loadSettingsFromConfig();

                }

            } else
            {

                writeSettingsToConfig();
                loadSettingsFromConfig();

            }

            Console.WriteLine("Successfully loaded settings from the config.");

        }
        
        /// <summary>
        /// Saves the user's selected settings into memory and then writes them to the HOSS.cfg file.
        /// </summary>
        public void SaveSettings()
        {

            Properties.Settings.Default.amtInstances = Convert.ToSByte(cbxAmtInstances.Text);

            Properties.Settings.Default.resolutionP1 = Convert.ToSByte(cbxScreen1.SelectedIndex);
            Properties.Settings.Default.resolutionP2 = Convert.ToSByte(cbxScreen2.SelectedIndex);
            Properties.Settings.Default.resolutionP3 = Convert.ToSByte(cbxScreen3.SelectedIndex);
            Properties.Settings.Default.resolutionP4 = Convert.ToSByte(cbxScreen4.SelectedIndex);

            Properties.Settings.Default.resP1Width = cbxScreen1.Text.Substring(0, cbxScreen1.Text.IndexOf("x"));
            Properties.Settings.Default.resP1Height = cbxScreen1.Text.Substring(cbxScreen1.Text.IndexOf("x") + 1, cbxScreen1.Text.Length - cbxScreen1.Text.Substring(0, cbxScreen1.Text.IndexOf("x")).Length - 1);

            Properties.Settings.Default.resP2Width = cbxScreen2.Text.Substring(0, cbxScreen2.Text.IndexOf("x"));
            Properties.Settings.Default.resP2Height = cbxScreen2.Text.Substring(cbxScreen2.Text.IndexOf("x") + 1, cbxScreen2.Text.Length - cbxScreen2.Text.Substring(0, cbxScreen2.Text.IndexOf("x")).Length - 1);

            Properties.Settings.Default.resP3Width = cbxScreen3.Text.Substring(0, cbxScreen3.Text.IndexOf("x"));
            Properties.Settings.Default.resP3Height = cbxScreen3.Text.Substring(cbxScreen3.Text.IndexOf("x") + 1, cbxScreen3.Text.Length - cbxScreen3.Text.Substring(0, cbxScreen3.Text.IndexOf("x")).Length - 1);

            Properties.Settings.Default.resP4Width = cbxScreen4.Text.Substring(0, cbxScreen4.Text.IndexOf("x"));
            Properties.Settings.Default.resP4Height = cbxScreen4.Text.Substring(cbxScreen4.Text.IndexOf("x") + 1, cbxScreen4.Text.Length - cbxScreen4.Text.Substring(0, cbxScreen4.Text.IndexOf("x")).Length - 1);

            Properties.Settings.Default.graphicSetting = Convert.ToSByte(cbxGraphicSetting.SelectedIndex);

            if (chkConsoleMode.CheckState == CheckState.Checked)
            {

                Properties.Settings.Default.launchConsoleMode = true;

            }
            else if (chkConsoleMode.CheckState == CheckState.Unchecked)
            {

                Properties.Settings.Default.launchConsoleMode = false;

            }

            Properties.Settings.Default.consoleModeOrientation = Convert.ToSByte(cbxConsoleModeOrientation.SelectedIndex);

            if (chkFullscreen.CheckState == CheckState.Checked)
            {

                Properties.Settings.Default.launchFullscreen = true;

            }
            else if (chkFullscreen.CheckState == CheckState.Unchecked)
            {

                Properties.Settings.Default.launchFullscreen = false;

            }

            if (chkVSync.CheckState == CheckState.Checked)
            {

                Properties.Settings.Default.launchVSync = true;

            }
            else if (chkVSync.CheckState == CheckState.Unchecked)
            {

                Properties.Settings.Default.launchVSync = false;

            }

            if (chkAntiAliasing.CheckState == CheckState.Checked)
            {

                Properties.Settings.Default.launchAntiAliasing = true;

            }
            else if (chkAntiAliasing.CheckState == CheckState.Unchecked)
            {

                Properties.Settings.Default.launchAntiAliasing = false;

            }

            if (chkKeyboardControlsP1.CheckState == CheckState.Checked)
            {

                Properties.Settings.Default.keyboardControlsP1 = true;

            }
            else if (chkKeyboardControlsP1.CheckState == CheckState.Unchecked)
            {

                Properties.Settings.Default.keyboardControlsP1 = false;

            }

            if (chkCloseLauncherAfterLaunch.CheckState == CheckState.Checked)
            {

                Properties.Settings.Default.closeLauncherAfterLaunch = true;

            }
            else if (chkCloseLauncherAfterLaunch.CheckState == CheckState.Unchecked)
            {

                Properties.Settings.Default.closeLauncherAfterLaunch = false;

            }

            if ( txtTimeBtwnLaunches.Text != null && txtTimeBtwnLaunches.Text != "")
            {

                Properties.Settings.Default.secondsAmidLaunches = Convert.ToInt32(txtTimeBtwnLaunches.Text);

            } else
            {

                txtTimeBtwnLaunches.Text = Properties.Settings.Default.secondsAmidLaunches.ToString();
                Properties.Settings.Default.secondsAmidLaunches = Convert.ToInt32(txtTimeBtwnLaunches.Text);

            }

            Properties.Settings.Default.Save();

            writeSettingsToConfig();

            MessageBox.Show("Successfully saved user settings.", "Halo Online Split Screen");

        }

        /// <summary>
        /// Copies either just a specific directory, or that directory and its sub directories while allowing for a specific directory name not to be copied in case of an infinite loop.
        /// </summary>
        /// <param name="sourceDirName"></param>
        /// <param name="destDirName"></param>
        /// <param name="copySubDirs"></param>
        /// <param name="doNotCopyDirName"></param>
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs, string doNotCopyDirName)
        {

            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {

                throw new DirectoryNotFoundException("Source directory does not exist or could not be found: " + sourceDirName);

            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!Directory.Exists(destDirName))
            {

                Directory.CreateDirectory(destDirName);

            }

            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {

                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);

            }

            if (copySubDirs)
            {

                foreach (DirectoryInfo subdir in dirs)
                {

                    if (subdir.ToString() != doNotCopyDirName)
                    {

                        Console.WriteLine(subdir.ToString());

                        string temppath = Path.Combine(destDirName, subdir.Name);
                        DirectoryCopy(subdir.FullName, temppath, copySubDirs, "HOSS");

                    }

                }

            }

        }


        private void launch()
        {

            if (Control.ModifierKeys == Keys.Control)
            {

                DialogResult egg = MessageBox.Show("Do you know what it's like to wait for Eldewrito 0.6.0 for this long?", "Halo Online Split Screen", MessageBoxButtons.YesNo);

                if (egg == DialogResult.Yes)
                {

                    Process.Start("https://www.youtube.com/watch?v=dPY1IvAGnAM");

                }
                else
                {

                    DialogResult yellowEgg = MessageBox.Show("Do you want to?", "Halo Online Split Screen", MessageBoxButtons.YesNo);

                    if (yellowEgg == DialogResult.Yes)
                    {

                        Process.Start("https://www.youtube.com/watch?v=dPY1IvAGnAM");

                    }
                    else
                    {

                        MessageBox.Show("Fine.", "Halo Online Split Screen");

                    }

                }

            }
            else
            {

                if (!GameMethods.checkIfProcessIsRunning("eldorado") ||
                    !GameMethods.checkIfProcessIsRunning("eldoradoP1") ||
                    !GameMethods.checkIfProcessIsRunning("eldoradoP2") ||
                    !GameMethods.checkIfProcessIsRunning("eldoradoP3") ||
                    !GameMethods.checkIfProcessIsRunning("eldoradoP4"))
                {

                    switch (cbxAmtInstances.SelectedIndex + 1)
                    {

                        case 1:

                            if (Properties.Settings.Default.P1Name == "")
                            {

                                MessageBox.Show("P1's profile has not been assigned. Please do so in the Profile Configuration Menu. This menu can be accessed via the middle button on the Main Menu labeled 'Profiles'", "Halo Online Split Screen");

                                frmProfiles profiles = new frmProfiles(Bounds.Left, Bounds.Top);
                                profiles.Show();
                                appExit = false;
                                this.Close();

                            }
                            else
                            {

                                if (Properties.Settings.Default.amtInstances != Convert.ToSByte(cbxAmtInstances.SelectedIndex + 1) ||
                                    Properties.Settings.Default.resolutionP1 != Convert.ToSByte(cbxScreen1.SelectedIndex) ||
                                    Properties.Settings.Default.resolutionP2 != Convert.ToSByte(cbxScreen2.SelectedIndex) ||
                                    Properties.Settings.Default.resolutionP3 != Convert.ToSByte(cbxScreen3.SelectedIndex) ||
                                    Properties.Settings.Default.resolutionP4 != Convert.ToSByte(cbxScreen4.SelectedIndex) ||
                                    Properties.Settings.Default.graphicSetting != Convert.ToSByte(cbxGraphicSetting.SelectedIndex) ||
                                    Properties.Settings.Default.launchConsoleMode != Convert.ToBoolean(chkConsoleMode.CheckState) ||
                                    Properties.Settings.Default.consoleModeOrientation != Convert.ToSByte(cbxConsoleModeOrientation.SelectedIndex) ||
                                    Properties.Settings.Default.launchFullscreen != Convert.ToBoolean(chkFullscreen.CheckState) ||
                                    Properties.Settings.Default.launchVSync != Convert.ToBoolean(chkVSync.CheckState) ||
                                    Properties.Settings.Default.launchAntiAliasing != Convert.ToBoolean(chkAntiAliasing.CheckState) ||
                                    Properties.Settings.Default.keyboardControlsP1 != Convert.ToBoolean(chkKeyboardControlsP1.CheckState) ||
                                    Properties.Settings.Default.closeLauncherAfterLaunch != Convert.ToBoolean(chkCloseLauncherAfterLaunch.CheckState) ||
                                    Properties.Settings.Default.secondsAmidLaunches != Convert.ToInt32(txtTimeBtwnLaunches.Text) ||
                                    Properties.Settings.Default.P1Directory == "")
                                {

                                    DialogResult save = MessageBox.Show("Some if not all of the user settings have not been saved. Would you like to save them before launching?", "Halo Online Split Screen", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                                    if (save == DialogResult.Yes)
                                    {

                                        SaveSettings();

                                        if (!Directory.Exists(Properties.Settings.Default.installationDirectory + "\\shortcuts"))
                                        {

                                            Directory.CreateDirectory(Properties.Settings.Default.installationDirectory + "\\shortcuts");

                                        }

                                        GameMethods methods = new GameMethods();
                                        methods.launch(1);

                                        if (Properties.Settings.Default.closeLauncherAfterLaunch == true)
                                        {

                                            Application.Exit();

                                        }

                                    }
                                    else if (save == DialogResult.No)
                                    {

                                        if (!Directory.Exists(Properties.Settings.Default.installationDirectory + "\\shortcuts"))
                                        {

                                            Directory.CreateDirectory(Properties.Settings.Default.installationDirectory + "\\shortcuts");

                                        }

                                        GameMethods methods = new GameMethods();
                                        methods.launch(1);

                                        if (Properties.Settings.Default.closeLauncherAfterLaunch == true)
                                        {

                                            Application.Exit();

                                        }

                                    }
                                    else if (save == DialogResult.Cancel)
                                    {

                                        Console.WriteLine("Did not start the game.");

                                    }

                                }
                                else
                                {

                                    if (!Directory.Exists(Properties.Settings.Default.installationDirectory + "\\shortcuts"))
                                    {

                                        Directory.CreateDirectory(Properties.Settings.Default.installationDirectory + "\\shortcuts");

                                    }

                                    GameMethods methods = new GameMethods();
                                    methods.launch(1);

                                    if (Properties.Settings.Default.closeLauncherAfterLaunch == true)
                                    {

                                        Application.Exit();

                                    }

                                }

                            }

                            break;

                        case 2:

                            if (Properties.Settings.Default.P1Name == "" || Properties.Settings.Default.P2Name == "")
                            {

                                MessageBox.Show("One or more profiles have not been assigned. Please do so in the Profile Configuration Menu. This menu can be accessed via the middle button on the Main Menu labeled 'Profiles'", "Halo Online Split Screen");

                                frmProfiles profiles = new frmProfiles(Bounds.Left, Bounds.Top);
                                profiles.Show();
                                appExit = false;
                                this.Close();

                            }
                            else
                            {

                                if (Screen.AllScreens.Length < Properties.Settings.Default.amtInstances && Properties.Settings.Default.launchFullscreen)
                                {

                                    MessageBox.Show("You do not have enough screens to run this many fullscreen instances at once. Please uncheck 'Launch game in fullscreen' option or lower the amount of instances to run at this time or lower the amount of instances to run at this time.", "Halo Online Split Screen");

                                }
                                else
                                {

                                    if (Properties.Settings.Default.P1Name == "" ||
                                    Properties.Settings.Default.P2Name == "" ||
                                    Properties.Settings.Default.amtInstances != Convert.ToSByte(cbxAmtInstances.SelectedIndex + 1) ||
                                    Properties.Settings.Default.resolutionP1 != Convert.ToSByte(cbxScreen1.SelectedIndex) ||
                                    Properties.Settings.Default.resolutionP2 != Convert.ToSByte(cbxScreen2.SelectedIndex) ||
                                    Properties.Settings.Default.resolutionP3 != Convert.ToSByte(cbxScreen3.SelectedIndex) ||
                                    Properties.Settings.Default.resolutionP4 != Convert.ToSByte(cbxScreen4.SelectedIndex) ||
                                    Properties.Settings.Default.graphicSetting != Convert.ToSByte(cbxGraphicSetting.SelectedIndex) ||
                                    Properties.Settings.Default.launchConsoleMode != Convert.ToBoolean(chkConsoleMode.CheckState) ||
                                    Properties.Settings.Default.consoleModeOrientation != Convert.ToSByte(cbxConsoleModeOrientation.SelectedIndex) ||
                                    Properties.Settings.Default.launchFullscreen != Convert.ToBoolean(chkFullscreen.CheckState) ||
                                    Properties.Settings.Default.launchVSync != Convert.ToBoolean(chkVSync.CheckState) ||
                                    Properties.Settings.Default.launchAntiAliasing != Convert.ToBoolean(chkAntiAliasing.CheckState) ||
                                    Properties.Settings.Default.keyboardControlsP1 != Convert.ToBoolean(chkKeyboardControlsP1.CheckState) ||
                                    Properties.Settings.Default.closeLauncherAfterLaunch != Convert.ToBoolean(chkCloseLauncherAfterLaunch.CheckState) ||
                                    Properties.Settings.Default.secondsAmidLaunches != Convert.ToInt32(txtTimeBtwnLaunches.Text) ||
                                    Properties.Settings.Default.P1Directory == "" ||
                                    Properties.Settings.Default.P2Directory == "")
                                    {

                                        DialogResult save = MessageBox.Show("Some if not all of the user settings have not been saved. Would you like to save them before launching?", "Halo Online Split Screen", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                                        if (save == DialogResult.Yes)
                                        {

                                            SaveSettings();

                                            if (!Directory.Exists(Properties.Settings.Default.installationDirectory + "\\shortcuts"))
                                            {

                                                Directory.CreateDirectory(Properties.Settings.Default.installationDirectory + "\\shortcuts");

                                            }

                                            GameMethods methods = new GameMethods();
                                            for (sbyte i = 1; i <= 2; i++)
                                            {

                                                methods.launch(i);

                                                if (i != 2)
                                                {

                                                    System.Threading.Thread.Sleep(Properties.Settings.Default.secondsAmidLaunches * 1000);

                                                }
                                                
                                            }

                                            if (Properties.Settings.Default.closeLauncherAfterLaunch == true)
                                            {

                                                Application.Exit();

                                            }

                                        }
                                        else if (save == DialogResult.No)
                                        {

                                            if (!Directory.Exists(Properties.Settings.Default.installationDirectory + "\\shortcuts"))
                                            {

                                                Directory.CreateDirectory(Properties.Settings.Default.installationDirectory + "\\shortcuts");

                                            }

                                            GameMethods methods = new GameMethods();
                                            for (sbyte i = 1; i <= 2; i++)
                                            {

                                                methods.launch(i);

                                                if (i != 2)
                                                {

                                                    System.Threading.Thread.Sleep(Properties.Settings.Default.secondsAmidLaunches * 1000);

                                                }

                                            }

                                            if (Properties.Settings.Default.closeLauncherAfterLaunch == true)
                                            {

                                                Application.Exit();

                                            }

                                        }
                                        else if (save == DialogResult.Cancel)
                                        {

                                            Console.WriteLine("Did not start the game.");

                                        }

                                    }
                                    else
                                    {

                                        if (!Directory.Exists(Properties.Settings.Default.installationDirectory + "\\shortcuts"))
                                        {

                                            Directory.CreateDirectory(Properties.Settings.Default.installationDirectory + "\\shortcuts");

                                        }

                                        GameMethods methods = new GameMethods();
                                        for (sbyte i = 1; i <= 2; i++)
                                        {

                                            methods.launch(i);

                                            if (i != 2)
                                            {

                                                System.Threading.Thread.Sleep(Properties.Settings.Default.secondsAmidLaunches * 1000);

                                            }

                                        }

                                        if (Properties.Settings.Default.closeLauncherAfterLaunch == true)
                                        {

                                            Application.Exit();

                                        }

                                    }

                                }

                            }

                            break;

                        case 3:

                            if (Properties.Settings.Default.P1Name == "" || Properties.Settings.Default.P2Name == "" || Properties.Settings.Default.P3Name == "")
                            {

                                MessageBox.Show("One or more profiles have not been assigned. Please do so in the Profile Configuration Menu. This menu can be accessed via the middle button on the Main Menu labeled 'Profiles'", "Halo Online Split Screen");

                                frmProfiles profiles = new frmProfiles(Bounds.Left, Bounds.Top);
                                profiles.Show();
                                appExit = false;
                                this.Close();

                            }
                            else
                            {

                                if (Screen.AllScreens.Length < Properties.Settings.Default.amtInstances && Properties.Settings.Default.launchFullscreen)
                                {

                                    MessageBox.Show("You do not have enough screens to run this many fullscreen instances at once. Please uncheck 'Launch game in fullscreen' option or lower the amount of instances to run at this time.", "Halo Online Split Screen");

                                }
                                else
                                {

                                    if (Properties.Settings.Default.P1Name == "" ||
                                    Properties.Settings.Default.P2Name == "" ||
                                    Properties.Settings.Default.P3Name == "" ||
                                    Properties.Settings.Default.amtInstances != Convert.ToSByte(cbxAmtInstances.SelectedIndex + 1) ||
                                    Properties.Settings.Default.resolutionP1 != Convert.ToSByte(cbxScreen1.SelectedIndex) ||
                                    Properties.Settings.Default.resolutionP2 != Convert.ToSByte(cbxScreen2.SelectedIndex) ||
                                    Properties.Settings.Default.resolutionP3 != Convert.ToSByte(cbxScreen3.SelectedIndex) ||
                                    Properties.Settings.Default.resolutionP4 != Convert.ToSByte(cbxScreen4.SelectedIndex) ||
                                    Properties.Settings.Default.graphicSetting != Convert.ToSByte(cbxGraphicSetting.SelectedIndex) ||
                                    Properties.Settings.Default.launchConsoleMode != Convert.ToBoolean(chkConsoleMode.CheckState) ||
                                    Properties.Settings.Default.consoleModeOrientation != Convert.ToSByte(cbxConsoleModeOrientation.SelectedIndex) ||
                                    Properties.Settings.Default.launchFullscreen != Convert.ToBoolean(chkFullscreen.CheckState) ||
                                    Properties.Settings.Default.launchVSync != Convert.ToBoolean(chkVSync.CheckState) ||
                                    Properties.Settings.Default.launchAntiAliasing != Convert.ToBoolean(chkAntiAliasing.CheckState) ||
                                    Properties.Settings.Default.keyboardControlsP1 != Convert.ToBoolean(chkKeyboardControlsP1.CheckState) ||
                                    Properties.Settings.Default.closeLauncherAfterLaunch != Convert.ToBoolean(chkCloseLauncherAfterLaunch.CheckState) ||
                                    Properties.Settings.Default.secondsAmidLaunches != Convert.ToInt32(txtTimeBtwnLaunches.Text) ||
                                    Properties.Settings.Default.P1Directory == "" ||
                                    Properties.Settings.Default.P2Directory == "" ||
                                    Properties.Settings.Default.P3Directory == "")
                                    {

                                        DialogResult save = MessageBox.Show("Some if not all of the user settings have not been saved. Would you like to save them before launching?", "Halo Online Split Screen", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                                        if (save == DialogResult.Yes)
                                        {

                                            SaveSettings();

                                            if (!Directory.Exists(Properties.Settings.Default.installationDirectory + "\\shortcuts"))
                                            {

                                                Directory.CreateDirectory(Properties.Settings.Default.installationDirectory + "\\shortcuts");

                                            }

                                            GameMethods methods = new GameMethods();
                                            for (sbyte i = 1; i <= 3; i++)
                                            {

                                                methods.launch(i);

                                                if (i != 3)
                                                {

                                                    System.Threading.Thread.Sleep(Properties.Settings.Default.secondsAmidLaunches * 1000);

                                                }

                                            }

                                            if (Properties.Settings.Default.closeLauncherAfterLaunch == true)
                                            {

                                                Application.Exit();

                                            }

                                        }
                                        else if (save == DialogResult.No)
                                        {

                                            if (!Directory.Exists(Properties.Settings.Default.installationDirectory + "\\shortcuts"))
                                            {

                                                Directory.CreateDirectory(Properties.Settings.Default.installationDirectory + "\\shortcuts");

                                            }

                                            GameMethods methods = new GameMethods();
                                            for (sbyte i = 1; i <= 3; i++)
                                            {

                                                methods.launch(i);

                                                if (i != 3)
                                                {

                                                    System.Threading.Thread.Sleep(Properties.Settings.Default.secondsAmidLaunches * 1000);

                                                }

                                            }

                                            if (Properties.Settings.Default.closeLauncherAfterLaunch == true)
                                            {

                                                Application.Exit();

                                            }

                                        }
                                        else if (save == DialogResult.Cancel)
                                        {

                                            Console.WriteLine("Did not start the game.");

                                        }

                                    }
                                    else
                                    {

                                        if (!Directory.Exists(Properties.Settings.Default.installationDirectory + "\\shortcuts"))
                                        {

                                            Directory.CreateDirectory(Properties.Settings.Default.installationDirectory + "\\shortcuts");

                                        }

                                        GameMethods methods = new GameMethods();
                                        for (sbyte i = 1; i <= 3; i++)
                                        {

                                            methods.launch(i);

                                            if (i != 3)
                                            {

                                                System.Threading.Thread.Sleep(Properties.Settings.Default.secondsAmidLaunches * 1000);

                                            }

                                        }

                                        if (Properties.Settings.Default.closeLauncherAfterLaunch == true)
                                        {

                                            Application.Exit();

                                        }

                                    }

                                }

                            }

                            break;

                        case 4:

                            if (Properties.Settings.Default.P1Name == "" || Properties.Settings.Default.P2Name == "")
                            {

                                MessageBox.Show("One or more profiles have not been assigned. Please do so in the Profile Configuration Menu. This menu can be accessed via the middle button on the Main Menu labeled 'Profiles'", "Halo Online Split Screen");

                                frmProfiles profiles = new frmProfiles(Bounds.Left, Bounds.Top);
                                profiles.Show();
                                appExit = false;
                                this.Close();

                            }
                            else
                            {

                                if (Screen.AllScreens.Length < Properties.Settings.Default.amtInstances && Properties.Settings.Default.launchFullscreen)
                                {

                                    MessageBox.Show("You do not have enough screens to run this many fullscreen instances at once. Please uncheck 'Launch game in fullscreen' option or lower the amount of instances to run at this time.", "Halo Online Split Screen");

                                }
                                else
                                {

                                    if (Properties.Settings.Default.P1Name == "" ||
                                    Properties.Settings.Default.P2Name == "" ||
                                    Properties.Settings.Default.P3Name == "" ||
                                    Properties.Settings.Default.P4Name == "" ||
                                    Properties.Settings.Default.amtInstances != Convert.ToSByte(cbxAmtInstances.SelectedIndex + 1) ||
                                    Properties.Settings.Default.resolutionP1 != Convert.ToSByte(cbxScreen1.SelectedIndex) ||
                                    Properties.Settings.Default.resolutionP2 != Convert.ToSByte(cbxScreen2.SelectedIndex) ||
                                    Properties.Settings.Default.resolutionP3 != Convert.ToSByte(cbxScreen3.SelectedIndex) ||
                                    Properties.Settings.Default.resolutionP4 != Convert.ToSByte(cbxScreen4.SelectedIndex) ||
                                    Properties.Settings.Default.graphicSetting != Convert.ToSByte(cbxGraphicSetting.SelectedIndex) ||
                                    Properties.Settings.Default.launchConsoleMode != Convert.ToBoolean(chkConsoleMode.CheckState) ||
                                    Properties.Settings.Default.consoleModeOrientation != Convert.ToSByte(cbxConsoleModeOrientation.SelectedIndex) ||
                                    Properties.Settings.Default.launchFullscreen != Convert.ToBoolean(chkFullscreen.CheckState) ||
                                    Properties.Settings.Default.launchVSync != Convert.ToBoolean(chkVSync.CheckState) ||
                                    Properties.Settings.Default.launchAntiAliasing != Convert.ToBoolean(chkAntiAliasing.CheckState) ||
                                    Properties.Settings.Default.keyboardControlsP1 != Convert.ToBoolean(chkKeyboardControlsP1.CheckState) ||
                                    Properties.Settings.Default.closeLauncherAfterLaunch != Convert.ToBoolean(chkCloseLauncherAfterLaunch.CheckState) ||
                                    Properties.Settings.Default.secondsAmidLaunches != Convert.ToInt32(txtTimeBtwnLaunches.Text) ||
                                    Properties.Settings.Default.P1Directory == "" ||
                                    Properties.Settings.Default.P2Directory == "" ||
                                    Properties.Settings.Default.P3Directory == "" ||
                                    Properties.Settings.Default.P4Directory == "")
                                    {

                                        DialogResult save = MessageBox.Show("Some if not all of the user settings have not been saved. Would you like to save them before launching?", "Halo Online Split Screen", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                                        if (save == DialogResult.Yes)
                                        {

                                            SaveSettings();

                                            if (!Directory.Exists(Properties.Settings.Default.installationDirectory + "\\shortcuts"))
                                            {

                                                Directory.CreateDirectory(Properties.Settings.Default.installationDirectory + "\\shortcuts");

                                            }

                                            GameMethods methods = new GameMethods();
                                            for (sbyte i = 1; i <= 4; i++)
                                            {

                                                methods.launch(i);

                                                if (i != 4)
                                                {

                                                    System.Threading.Thread.Sleep(Properties.Settings.Default.secondsAmidLaunches * 1000);

                                                }

                                            }

                                            if (Properties.Settings.Default.closeLauncherAfterLaunch == true)
                                            {

                                                Application.Exit();

                                            }

                                        }
                                        else if (save == DialogResult.No)
                                        {

                                            if (!Directory.Exists(Properties.Settings.Default.installationDirectory + "\\shortcuts"))
                                            {

                                                Directory.CreateDirectory(Properties.Settings.Default.installationDirectory + "\\shortcuts");

                                            }

                                            GameMethods methods = new GameMethods();
                                            for (sbyte i = 1; i <= 4; i++)
                                            {

                                                methods.launch(i);

                                                if (i != 4)
                                                {

                                                    System.Threading.Thread.Sleep(Properties.Settings.Default.secondsAmidLaunches * 1000);

                                                }

                                            }

                                            if (Properties.Settings.Default.closeLauncherAfterLaunch == true)
                                            {

                                                Application.Exit();

                                            }

                                        }
                                        else if (save == DialogResult.Cancel)
                                        {

                                            Console.WriteLine("Did not start the game.");

                                        }

                                    }
                                    else
                                    {

                                        if (!Directory.Exists(Properties.Settings.Default.installationDirectory + "\\shortcuts"))
                                        {

                                            Directory.CreateDirectory(Properties.Settings.Default.installationDirectory + "\\shortcuts");

                                        }

                                        GameMethods methods = new GameMethods();
                                        for (sbyte i = 1; i <= 4; i++)
                                        {

                                            methods.launch(i);

                                            if (i != 4)
                                            {

                                                System.Threading.Thread.Sleep(Properties.Settings.Default.secondsAmidLaunches * 1000);

                                            }

                                        }

                                        if (Properties.Settings.Default.closeLauncherAfterLaunch == true)
                                        {

                                            Application.Exit();

                                        }

                                    }

                                }

                            }

                            break;

                    }

                }
                else
                {

                    MessageBox.Show("Please close any currently running instances of Halo Online before launching.", "Halo Online Split Screen");

                }

            }

        }

        private void lblLaunch_Click(object sender, EventArgs e)
        {

            launch();

        }

        private void lblLaunch_MouseEnter(object sender, EventArgs e)
        {

            lblLaunch.BackColor = Color.FromArgb(25, 25, 25);

        }

        private void lblLaunch_MouseLeave(object sender, EventArgs e)
        {

            lblLaunch.BackColor = Color.FromArgb(35, 35, 35);

        }

        private void lblLaunch_MouseHover(object sender, EventArgs e)
        {

            tipDefault.Show("Launches the game with the settings and profiles created by the user.", this.lblLaunch);

        }



        private void lblProfiles_Click(object sender, EventArgs e)
        {

            frmProfiles profiles = new frmProfiles(Bounds.Left, Bounds.Top);
            profiles.Show();
            appExit = false;
            this.Close();

        }

        private void lblProfiles_MouseEnter(object sender, EventArgs e)
        {

            lblProfiles.BackColor = Color.FromArgb(25, 25, 25);

        }

        private void lblProfiles_MouseLeave(object sender, EventArgs e)
        {

            lblProfiles.BackColor = Color.FromArgb(35, 35, 35);

        }

        private void lblProfiles_MouseHover(object sender, EventArgs e)
        {

            tipDefault.Show("A menu to configure each player's profile.", this.lblProfiles);

        }



        private void lblExit_Click(object sender, EventArgs e)
        {

            Application.Exit();

        }

        private void lblExit_MouseEnter(object sender, EventArgs e)
        {

            lblExit.BackColor = Color.FromArgb(25, 25, 25);

        }

        private void lblExit_MouseLeave(object sender, EventArgs e)
        {

            lblExit.BackColor = Color.FromArgb(35, 35, 35);

        }

        private void lblExit_MouseHover(object sender, EventArgs e)
        {

            tipDefault.Show("Closes this application.", this.lblExit);

        }



        private void lblSaveSettings_Click(object sender, EventArgs e)
        {

            SaveSettings();

        }

        private void lblSaveSettings_MouseEnter(object sender, EventArgs e)
        {

            lblSaveSettings.BackColor = Color.FromArgb(25, 25, 25);

        }

        private void lblSaveSettings_MouseLeave(object sender, EventArgs e)
        {

            lblSaveSettings.BackColor = Color.FromArgb(35, 35, 35);

        }

        private void lblSaveSettings_MouseHover(object sender, EventArgs e)
        {

            tipDefault.Show("Saves your configured Halo Online Split Screen settings. [Above]", this.lblSaveSettings);

        }



        private void reloadHOSSFiles()
        {

            DialogResult reload = MessageBox.Show("Do you really want to reload your HOSS game files? This will take your current main game files and copy them to the P1, P2, P3, and P4 directories. This should be only be necessary if you have made any sort of changes to your main game files that you wish to be carried over to your HOSS game files. For example, if you have installed a new mod in your main game files and do not wish to install it one by one in your HOSS game files. This will completely erase your P1, P2, P3, and P4 directories before copying the content of your main directory into each just as it did the first time you loaded up HOSS. Note that this will not erase any profiles or changes you have made to the application's settings.", "Halo Online Split Screen", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            if (reload == DialogResult.OK)
            {

                for (sbyte i = 1; i <= 4; i++)
                {

                    Directory.Delete(Properties.Settings.Default.installationDirectory + "\\P" + i, true);

                }

                Process.Start(Properties.Settings.Default.installationDirectory + "\\Halo Online Split Screen.exe");
                this.Close();

            }
            else
            {

                MessageBox.Show("Did not reload HOSS game files.", "Halo Online Split Screen");

            }

        }

        private void lblReloadPlayerFiles_Click(object sender, EventArgs e)
        {

            reloadHOSSFiles();

        }
        
        private void lblReloadPlayerFiles_MouseEnter(object sender, EventArgs e)
        {

            lblReloadPlayerFiles.BackColor = Color.FromArgb(25, 25, 25);

        }

        private void lblReloadPlayerFiles_MouseLeave(object sender, EventArgs e)
        {

            lblReloadPlayerFiles.BackColor = Color.FromArgb(35, 35, 35);

        }

        private void lblReloadPlayerFiles_MouseHover(object sender, EventArgs e)
        {

            tipDefault.Show("Replaces your P1, P2, P3, and P4 directories located within your HOSS installation directory with your main game files.", this.lblReloadPlayerFiles);

        }
        
        private void txtChangelog_MouseMove(object sender, MouseEventArgs e)
        {

            Cursor.Current = Cursors.Default;

        }
        
        private void txtTimeBtwnLaunches_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {

                e.Handled = true;

            }
            
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (appExit == true)
            {

                Application.Exit();

            }

        }

        private void frmMain_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (lblRightTitle.Text == "Console Mode" && e.KeyCode == Keys.Enter)
            {

                Process.Start("https://www.youtube.com/watch?v=algyPNUvHG4");

            }

            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.S)
            {

                SaveSettings();

            }

            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.R)
            {

                reloadHOSSFiles();

            }

            if (e.KeyCode == Keys.R)
            {

                if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                {

                    if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                    {

                        Application.Restart();

                    }

                }

            }

            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.P)
            {

                frmProfiles profiles = new frmProfiles(Bounds.Left, Bounds.Top);
                profiles.Show();
                appExit = false;
                this.Close();

            }

            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.L)
            {

                launch();

            }

        }



        /// <summary>
        /// Sets lblRightTitle and txtRight's text parameters to text that describes the setting that is being hovered over
        /// </summary>
        /// <param name="title"></param>
        /// <param name="text"></param>
        private void describeSetting(string title, string text)
        {

            lblRightTitle.Text = title;
            txtRight.Text = text;

        }

        /// <summary>
        /// Sets lblRightTitle and txtRight's text parameters to the changelog of the application
        /// </summary>
        private void setChangelogText()
        {

            lblRightTitle.Text = "Recent Changes";
            txtRight.Text = "";

            for (int line = 0; line < File.ReadAllLines(Properties.Settings.Default.installationDirectory + "\\bin\\Changelog.txt").Length; line++)
            {

                if (line == 0)
                {

                    txtRight.Text += File.ReadAllLines(Properties.Settings.Default.installationDirectory + "\\bin\\Changelog.txt")[line];

                }
                else
                {

                    txtRight.Text += "\r\n\r\n";
                    txtRight.Text += File.ReadAllLines(Properties.Settings.Default.installationDirectory + "\\bin\\Changelog.txt")[line];

                }

            }

        }

        private void setEnabledSettings()
        {

            if (chkFullscreen.Checked)
            {

                chkConsoleMode.CheckState = CheckState.Unchecked;
                lblConsoleMode.Enabled = false;
                chkConsoleMode.Enabled = false;

                lblConsoleModeOrientation.Enabled = false;
                cbxConsoleModeOrientation.Enabled = false;

                lblScreen1.Enabled = false;
                cbxScreen1.Enabled = false;
                lblScreen2.Enabled = false;
                cbxScreen2.Enabled = false;
                lblScreen3.Enabled = false;
                cbxScreen3.Enabled = false;
                lblScreen4.Enabled = false;
                cbxScreen4.Enabled = false;

            }
            else if (chkConsoleMode.Checked)
            {

                lblConsoleMode.Enabled = true;
                chkConsoleMode.Enabled = true;

                lblConsoleModeOrientation.Enabled = true;
                cbxConsoleModeOrientation.Enabled = true;

                lblScreen1.Enabled = false;
                cbxScreen1.Enabled = false;
                lblScreen2.Enabled = false;
                cbxScreen2.Enabled = false;
                lblScreen3.Enabled = false;
                cbxScreen3.Enabled = false;
                lblScreen4.Enabled = false;
                cbxScreen4.Enabled = false;

            }
            else if (chkFullscreen.CheckState == CheckState.Unchecked || chkConsoleMode.CheckState == CheckState.Unchecked)
            {

                lblConsoleMode.Enabled = true;
                chkConsoleMode.Enabled = true;

                lblConsoleModeOrientation.Enabled = false;
                cbxConsoleModeOrientation.Enabled = false;

                lblScreen1.Enabled = true;
                cbxScreen1.Enabled = true;
                lblScreen2.Enabled = true;
                cbxScreen2.Enabled = true;
                lblScreen3.Enabled = true;
                cbxScreen3.Enabled = true;
                lblScreen4.Enabled = true;
                cbxScreen4.Enabled = true;

            }
            
        }

        private void lblAmtInstances_MouseEnter(object sender, EventArgs e)
        {
            describeSetting("Amount of Instances", "Sets the amount of games to be launched.\r\n\r\nIf you plan on launching more than two, make sure you have a good CPU.");
        }

        private void lblAmtInstances_MouseLeave(object sender, EventArgs e)
        {
            setChangelogText();
        }

        private void cbxAmtInstances_MouseEnter(object sender, EventArgs e)
        {
            describeSetting("Amount of Instances", "Sets the amount of games to be launched.\r\n\r\nIf you plan on launching more than two, make sure you have a good CPU.");

        }

        private void cbxAmtInstances_MouseLeave(object sender, EventArgs e)
        {
            setChangelogText();
        }

        private void lblConsoleMode_MouseEnter(object sender, EventArgs e)
        {
            KeyPreview = true;
            describeSetting("Console Mode", "Console Mode disregards otherwise determined resolutions of each window in order to split your screen the way a console would.\r\n\r\nYOU MUST FIRST SET CUSTOM RESOLUTIONS FOR THIS FEATURE TO WORK PROPERLY.\r\n\r\nPress 'Enter' now to learn how to set up this feature.");
        }

        private void lblConsoleMode_MouseLeave(object sender, EventArgs e)
        {
            setChangelogText();
        }

        private void chkConsoleMode_MouseEnter(object sender, EventArgs e)
        {
            KeyPreview = true;
            describeSetting("Console Mode", "Console Mode disregards otherwise determined resolutions of each window in order to split your screen the way a console would.\r\n\r\nYOU MUST FIRST SET CUSTOM RESOLUTIONS FOR THIS FEATURE TO WORK PROPERLY.\r\n\r\nPress 'Enter' now to learn how to set up this feature.");
        }

        private void chkConsoleMode_MouseLeave(object sender, EventArgs e)
        {
            setChangelogText();
        }

        private void lblConsoleModeOrientation_MouseEnter(object sender, EventArgs e)
        {
            describeSetting("Game Orientations", "This option determines which way the game(s) will split if ran in Console Mode.\r\n\r\nThis will have no effect if one or four instances are run without fullscreen enabled or if fullscreen is enabled at all.");
        }

        private void lblConsoleModeOrientation_MouseLeave(object sender, EventArgs e)
        {
            setChangelogText();
        }

        private void cbxConsoleModeOrientation_MouseEnter(object sender, EventArgs e)
        {
            describeSetting("Game Orientations", "This option determines which way the game(s) will split if ran in Console Mode.\r\n\r\nThis will have no effect if one or four instances are run without fullscreen enabled or if fullscreen is enabled at all.");
        }

        private void cbxConsoleModeOrientation_MouseLeave(object sender, EventArgs e)
        {
            setChangelogText();
        }

        private void lblScreen1_MouseEnter(object sender, EventArgs e)
        {
            describeSetting("Screen Resolutions", "These comboboxes allow you to select the resolution of each indivisual instance.\r\n\r\nThis will only apply if Console Mode is not enabled.");
        }

        private void lblScreen1_MouseLeave(object sender, EventArgs e)
        {
            setChangelogText();
        }

        private void cbxScreen1_MouseEnter(object sender, EventArgs e)
        {
            describeSetting("Screen Resolutions", "These comboboxes allow you to select the resolution of each indivisual instance.\r\n\r\nThis will only apply if Console Mode is not enabled.");
        }

        private void cbxScreen1_MouseLeave(object sender, EventArgs e)
        {
            setChangelogText();
        }

        private void lblScreen2_MouseEnter(object sender, EventArgs e)
        {
            describeSetting("Screen Resolutions", "These comboboxes allow you to select the resolution of each indivisual instance.\r\n\r\nThis will only apply if Console Mode is not enabled.");
        }

        private void lblScreen2_MouseLeave(object sender, EventArgs e)
        {
            setChangelogText();
        }

        private void cbxScreen2_MouseEnter(object sender, EventArgs e)
        {
            describeSetting("Screen Resolutions", "These comboboxes allow you to select the resolution of each indivisual instance.\r\n\r\nThis will only apply if Console Mode is not enabled.");
        }

        private void cbxScreen2_MouseLeave(object sender, EventArgs e)
        {
            setChangelogText();
        }

        private void lblScreen3_MouseEnter(object sender, EventArgs e)
        {
            describeSetting("Screen Resolutions", "These comboboxes allow you to select the resolution of each indivisual instance.\r\n\r\nThis will only apply if Console Mode is not enabled.");
        }

        private void lblScreen3_MouseLeave(object sender, EventArgs e)
        {
            setChangelogText();
        }

        private void cbxScreen3_MouseEnter(object sender, EventArgs e)
        {
            describeSetting("Screen Resolutions", "These comboboxes allow you to select the resolution of each indivisual instance.\r\n\r\nThis will only apply if Console Mode is not enabled.");
        }

        private void cbxScreen3_MouseLeave(object sender, EventArgs e)
        {
            setChangelogText();
        }

        private void lblScreen4_MouseEnter(object sender, EventArgs e)
        {
            describeSetting("Screen Resolutions", "These comboboxes allow you to select the resolution of each indivisual instance.\r\n\r\nThis will only apply if Console Mode is not enabled.");
        }

        private void lblScreen4_MouseLeave(object sender, EventArgs e)
        {
            setChangelogText();
        }

        private void cbxScreen4_MouseEnter(object sender, EventArgs e)
        {
            describeSetting("Screen Resolutions", "These comboboxes allow you to select the resolution of each indivisual instance.\r\n\r\nThis will only apply if Console Mode is not enabled.");
        }

        private void cbxScreen4_MouseLeave(object sender, EventArgs e)
        {
            setChangelogText();
        }

        private void lblGraphicsSetting_MouseEnter(object sender, EventArgs e)
        {
            describeSetting("Graphics Settings", "This option will set all video settings to a base setting in order to simplify the process of setting them indivisually.\r\n\r\nBe careful not to set this to easy if your computer can handle it to avoid the active camo bug.");
        }

        private void lblGraphicsSetting_MouseLeave(object sender, EventArgs e)
        {
            setChangelogText();
        }

        private void cbxGraphicSetting_MouseEnter(object sender, EventArgs e)
        {
            describeSetting("Graphics Settings", "This option will set all video settings to a base setting in order to simplify the process of setting them indivisually.\r\n\r\nBe careful not to set this to easy if your computer can handle it to avoid the active camo bug.");
        }

        private void cbxGraphicSetting_MouseLeave(object sender, EventArgs e)
        {
            setChangelogText();
        }

        private void lblFullscreen_MouseEnter(object sender, EventArgs e)
        {
            describeSetting("Fullscreen", "Launches the game(s) in borderless windows that match the screen resolution of each screen.\r\n\r\nMake sure you have enough screens to launch the selected amount of instances.");
        }

        private void lblFullscreen_MouseLeave(object sender, EventArgs e)
        {
            setChangelogText();
        }

        private void chkFullscreen_MouseEnter(object sender, EventArgs e)
        {
            describeSetting("Fullscreen", "Launches the game(s) in borderless windows that match the screen resolution of each screen.\r\n\r\nMake sure you have enough screens to launch the selected amount of instances.");
        }

        private void chkFullscreen_MouseLeave(object sender, EventArgs e)
        {
            setChangelogText();
        }

        private void lblVSync_MouseEnter(object sender, EventArgs e)
        {
            describeSetting("Vertical Sync", "Vertical Sync, sometimes shortened to VSync, is a method of maintaining a smooth framerate by locking the frames per second to the refresh rate of the monitor the game is running on.\r\n\r\nThis normally helps on computers that can handle the game(s), but can really mess with computers that have a difficult time running them.");
        }

        private void lblVSync_MouseLeave(object sender, EventArgs e)
        {
            setChangelogText();
        }

        private void chkVSync_MouseEnter(object sender, EventArgs e)
        {
            describeSetting("Vertical Sync", "Vertical Sync, sometimes shortened to VSync, is a method of maintaining a smooth framerate by locking the frames per second to the refresh rate of the monitor the game is running on.\r\n\r\nThis normally helps on computers that can handle the game(s), but can really mess with computers that have a difficult time running them.");
        }

        private void chkVSync_MouseLeave(object sender, EventArgs e)
        {
            setChangelogText();
        }

        private void lblAntiAliasing_MouseEnter(object sender, EventArgs e)
        {
            describeSetting("Anti Aliasing", "Anti Aliasing smoothes diagonal lines by changing colors of pixels around them.\r\n\r\nPerformance may take a slight hit if enabled.");
        }

        private void lblAntiAliasing_MouseLeave(object sender, EventArgs e)
        {
            setChangelogText();
        }

        private void chkAntiAliasing_MouseEnter(object sender, EventArgs e)
        {
            describeSetting("Anti Aliasing", "Anti Aliasing smoothes diagonal lines by changing colors of pixels around them.\r\n\r\nPerformance may take a slight hit if enabled.");
        }

        private void chkAntiAliasing_MouseLeave(object sender, EventArgs e)
        {
            setChangelogText();
        }

        private void lblKeyboardControlsP1_MouseEnter(object sender, EventArgs e)
        {
            describeSetting("Keyboad Controls P1", "If enabled, player 1's screen is controlled by keyboard and mouse, and all other screens are controlled by controllers 1, 2, and 3.");
        }

        private void lblKeyboardControlsP1_MouseLeave(object sender, EventArgs e)
        {
            setChangelogText();
        }

        private void chkKeyboardControlsP1_MouseEnter(object sender, EventArgs e)
        {
            describeSetting("Keyboad Controls P1", "If enabled, player 1's screen is controlled by keyboard and mouse, and all other screens are controlled by controllers 1, 2, and 3.");
        }

        private void chkKeyboardControlsP1_MouseLeave(object sender, EventArgs e)
        {
            setChangelogText();
        }

        private void lblCloseLauncherAfterLaunch_MouseEnter(object sender, EventArgs e)
        {
            describeSetting("Close After Launch", "If enabled, after all instances have been launched, Halo Online Split Screen will automatically close.");
        }

        private void lblCloseLauncherAfterLaunch_MouseLeave(object sender, EventArgs e)
        {
            setChangelogText();
        }

        private void chkCloseLauncherAfterLaunch_MouseEnter(object sender, EventArgs e)
        {
            describeSetting("Close After Launch", "If enabled, after all instances have been launched, Halo Online Split Screen will automatically close.");
        }

        private void chkCloseLauncherAfterLaunch_MouseLeave(object sender, EventArgs e)
        {
            setChangelogText();
        }

        private void lblTimeBtwnLaunches_MouseEnter(object sender, EventArgs e)
        {
            describeSetting("Time Between Launches", "This option determines the amount of seconds between the launch of each game.\r\n\r\nIf you need more than nine hundred ninety nine seconds between each launch I feel sorry for you.");
        }

        private void lblTimeBtwnLaunches_MouseLeave(object sender, EventArgs e)
        {
            setChangelogText();
        }

        private void txtTimeBtwnLaunches_MouseEnter(object sender, EventArgs e)
        {
            describeSetting("Time Between Launches", "This option determines the amount of seconds between the launch of each game.\r\n\r\nIf you need more than nine hundred ninety nine seconds between each launch I feel sorry for you.");
        }

        private void txtTimeBtwnLaunches_MouseLeave(object sender, EventArgs e)
        {
            setChangelogText();
        }

        private void chkConsoleMode_CheckStateChanged(object sender, EventArgs e)
        {
            setEnabledSettings();
        }

        private void chkFullscreen_CheckStateChanged(object sender, EventArgs e)
        {
            setEnabledSettings();
        }
        
    }

}
