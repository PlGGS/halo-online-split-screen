using IWshRuntimeLibrary;
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Halo_Online_Split_Screen
{
    class GameMethods
    {

        /// <summary>
        /// Checks if a process is running... Duh...
        /// </summary>
        /// <param name="nameSubstring"></param>
        /// <returns></returns>
        public static bool checkIfProcessIsRunning(string nameSubstring)
        {
            return Process.GetProcesses().Any(p => p.ProcessName.Contains(nameSubstring));
        }

        /// <summary>
        /// Asks the user if they could close all games before trying to launch another set.
        /// </summary>
        public static void closeGamesThenRetry(string methodName, string hopPath, sbyte playerNum)
        {
            
            if (methodName == "setDewritoPrefsFileAsHOPFile")
            {

                DialogResult close = MessageBox.Show("Please close any instances of Eldorado that might currently be running, and then click 'Okay', or click 'Cancel'.", "Halo Online Split Screen", MessageBoxButtons.OKCancel);

                if (close == DialogResult.OK)
                {

                    setDewritoPrefsFileAsHOPFile(hopPath, playerNum);

                }
                else
                {

                    Process.Start(Properties.Settings.Default.installationDirectory + "\\Halo Online Split Screen.exe");
                    Environment.Exit(0);

                }

            }
            else if (methodName == "setPreferencesFileAstmpPreferencesFile")
            {


                DialogResult close = MessageBox.Show("Please close any instances of Eldorado that might currently be running, and then click 'Okay', or click 'Cancel'.", "Halo Online Split Screen", MessageBoxButtons.OKCancel);


                if (close == DialogResult.OK)
                {

                    setPreferencesFileAstmpPreferencesFile(playerNum);

                }
                else
                {

                    Process.Start(Properties.Settings.Default.installationDirectory + "\\Halo Online Split Screen.exe");
                    Environment.Exit(0);

                }

            }
            else if (methodName == "setDuraznoFilesAstmpDuraznoFiles")
            {

                DialogResult close = MessageBox.Show("Please close any instances of Eldorado that might currently be running, and then click 'Okay', or click 'Cancel'.", "Halo Online Split Screen", MessageBoxButtons.OKCancel);


                if (close == DialogResult.OK)
                {

                    setDuraznoFilesAstmpDuraznoFiles(playerNum);

                }
                else
                {

                    Process.Start(Properties.Settings.Default.installationDirectory + "\\Halo Online Split Screen.exe");
                    Environment.Exit(0);

                }

            }

        }

        /// <summary>
        /// Creates a new shortcut of a selected program. In this case we use it to create Halo Online shortcuts that don't need to be run by the default launcher.
        /// </summary>
        /// <param name="shortcutName"></param>
        /// <param name="shortcutPath"></param>
        /// <param name="shortcutTargetFileLocation"></param>
        /// <param name="shortcutArguments"></param>
        /// <param name="shortcutStartInDirectory"></param>
        /// <param name="shortcutIconLocation"></param>
        /// <param name="shortcutDescription"></param>
        public static void CreateShortcut(string shortcutName, string shortcutPath, string shortcutTargetFileLocation, string shortcutArguments, string shortcutStartInDirectory, string shortcutIconLocation, string shortcutDescription)
        {
            
            string shortcutLocation = System.IO.Path.Combine(shortcutPath, shortcutName + ".lnk");
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

            shortcut.Description = shortcutDescription;
            shortcut.IconLocation = shortcutIconLocation;
            shortcut.TargetPath = shortcutTargetFileLocation;
            shortcut.Arguments = shortcutArguments;
            shortcut.WorkingDirectory = shortcutStartInDirectory;
            shortcut.Save();

        }

        /// <summary>
        /// Sets the player's eldorado.exe file to the correspondingly numbered replacement eldoradoP(1,2,3,4).exe file.
        /// </summary>
        public static void setEldoradoExeAstmpEldoradoExe()
        {

            if (!System.IO.File.Exists(Properties.Settings.Default.P1Directory + "\\eldoradoP1.exe"))
            {
                
                System.IO.File.Delete(Properties.Settings.Default.P1Directory + "\\eldorado.exe");
                System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\eldoradoP1.exe", Properties.Settings.Default.P1Directory + "\\eldoradoP1.exe");
                Console.WriteLine("Successfully loaded eldoradoP1.exe");

            }

            if (!System.IO.File.Exists(Properties.Settings.Default.P2Directory + "\\eldoradoP2.exe"))
            {

                System.IO.File.Delete(Properties.Settings.Default.P2Directory + "\\eldorado.exe");
                System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\eldoradoP2.exe", Properties.Settings.Default.P2Directory + "\\eldoradoP2.exe");
                Console.WriteLine("Successfully loaded eldoradoP2.exe");

            }

            if (!System.IO.File.Exists(Properties.Settings.Default.P3Directory + "\\eldoradoP3.exe"))
            {

                System.IO.File.Delete(Properties.Settings.Default.P3Directory + "\\eldorado.exe");
                System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\eldoradoP3.exe", Properties.Settings.Default.P3Directory + "\\eldoradoP3.exe");
                Console.WriteLine("Successfully loaded eldoradoP3.exe");

            }

            if (!System.IO.File.Exists(Properties.Settings.Default.P4Directory + "\\eldoradoP4.exe"))
            {

                System.IO.File.Delete(Properties.Settings.Default.P4Directory + "\\eldorado.exe");
                System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\eldoradoP4.exe", Properties.Settings.Default.P4Directory + "\\eldoradoP4.exe");
                Console.WriteLine("Successfully loaded eldoradoP4.exe");

            }

        }

        /// <summary>
        /// Sets the player's dewrito_pref(1,2,3,4) files as the hop (Halo Online Profile) files created in the profile configuration menu.
        /// </summary>
        /// <param name="hopPath"></param>
        /// <param name="playerNum"></param>
        public static void setDewritoPrefsFileAsHOPFile(string hopPath, sbyte playerNum)
        {

            if (!checkIfProcessIsRunning("eldoradoP1") && !checkIfProcessIsRunning("eldoradoP2") && !checkIfProcessIsRunning("eldoradoP3") && !checkIfProcessIsRunning("eldoradoP4"))
            {

                if (System.IO.File.Exists(Properties.Settings.Default.P1Directory + "\\dewrito_prefs.cfg"))
                {

                    System.IO.File.Delete(Properties.Settings.Default.P1Directory + "\\dewrito_prefs.cfg");

                }

                if (System.IO.File.Exists(Properties.Settings.Default.P2Directory + "\\dewrito_prefs.cfg"))
                {

                    System.IO.File.Delete(Properties.Settings.Default.P2Directory + "\\dewrito_prefs.cfg");

                }

                if (System.IO.File.Exists(Properties.Settings.Default.P3Directory + "\\dewrito_prefs.cfg"))
                {

                    System.IO.File.Delete(Properties.Settings.Default.P3Directory + "\\dewrito_prefs.cfg");

                }

                if (System.IO.File.Exists(Properties.Settings.Default.P4Directory + "\\dewrito_prefs.cfg"))
                {

                    System.IO.File.Delete(Properties.Settings.Default.P4Directory + "\\dewrito_prefs.cfg");

                }

            }

            try
            {

                switch (playerNum)
                {

                    case 1:

                        System.IO.File.Copy(hopPath, Properties.Settings.Default.P1Directory + "\\dewrito_prefs.cfg");
                        Console.WriteLine("Successfully replaced dewrito_prefs.cfg with " + Properties.Settings.Default.P1Name + ".hop.");
                        break;

                    case 2:
                        System.IO.File.Copy(hopPath, Properties.Settings.Default.P2Directory + "\\dewrito_prefs.cfg");
                        Console.WriteLine("Successfully replaced dewrito_prefs.cfg with " + Properties.Settings.Default.P2Name + ".hop.");
                        break;

                    case 3:
                        System.IO.File.Copy(hopPath, Properties.Settings.Default.P3Directory + "\\dewrito_prefs.cfg");
                        Console.WriteLine("Successfully replaced dewrito_prefs.cfg with " + Properties.Settings.Default.P3Name + ".hop.");
                        break;

                    case 4:
                        System.IO.File.Copy(hopPath, Properties.Settings.Default.P4Directory + "\\dewrito_prefs.cfg");
                        Console.WriteLine("Successfully replaced dewrito_prefs.cfg with " + Properties.Settings.Default.P4Name + ".hop.");
                        break;

                }

            }
            catch
            {

                closeGamesThenRetry("setDewritoPrefsFileAsHOPFile", hopPath, playerNum);

            }

        }

        /// <summary>
        /// Copies the player's preferences file to the selected profile's files in order to apply their selected video settings and such.
        /// </summary>
        /// <param name="newFileName"></param>
        /// <param name="playerNum"></param>
        public static void setPreferencesFileAstmpPreferencesFile(sbyte playerNum)
        {

            if (!checkIfProcessIsRunning("eldoradoP1") && !checkIfProcessIsRunning("eldoradoP2") && !checkIfProcessIsRunning("eldoradoP3") && !checkIfProcessIsRunning("eldoradoP4"))
            {

                if (System.IO.File.Exists(Properties.Settings.Default.P1Directory + "\\preference1.dat"))
                {

                    System.IO.File.Delete(Properties.Settings.Default.P1Directory + "\\preference1.dat");

                }
                
                if (System.IO.File.Exists(Properties.Settings.Default.P2Directory + "\\preference2.dat"))
                {

                    System.IO.File.Delete(Properties.Settings.Default.P2Directory + "\\preference2.dat");

                }

                if (System.IO.File.Exists(Properties.Settings.Default.P3Directory + "\\preference3.dat"))
                {

                    System.IO.File.Delete(Properties.Settings.Default.P3Directory + "\\preference3.dat");

                }

                if (System.IO.File.Exists(Properties.Settings.Default.P4Directory + "\\preference4.dat"))
                {

                    System.IO.File.Delete(Properties.Settings.Default.P4Directory + "\\preference4.dat");

                }

            }

            try
            {

                if (playerNum == 1)
                {

                    switch (Properties.Settings.Default.launchVSync)
                    {

                        case false:

                            switch (Properties.Settings.Default.launchAntiAliasing)
                            {

                                case false:

                                    switch (Properties.Settings.Default.keyboardControlsP1)
                                    {

                                        case false:

                                            switch (Properties.Settings.Default.graphicSetting)
                                            {

                                                case 0:

                                                    System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesLow.dat", Properties.Settings.Default.P1Directory + "\\preference1.dat");
                                                    Console.WriteLine("Successfully loaded P1's preferencesLow.dat as preference1.dat.");

                                                    break;

                                                case 1:

                                                    System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesMed.dat", Properties.Settings.Default.P1Directory + "\\preference1.dat");
                                                    Console.WriteLine("Successfully loaded P1's preferencesMed.dat as preference1.dat.");

                                                    break;

                                                case 2:

                                                    System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesHigh.dat", Properties.Settings.Default.P1Directory + "\\preference1.dat");
                                                    Console.WriteLine("Successfully loaded P1's preferencesHigh.dat as preference1.dat.");

                                                    break;

                                            }

                                            break;

                                        case true:

                                            switch (Properties.Settings.Default.graphicSetting)
                                            {

                                                case 0:

                                                    System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesLowK.dat", Properties.Settings.Default.P1Directory + "\\preference1.dat");
                                                    Console.WriteLine("Successfully loaded P1's preferencesLowK.dat as preference1.dat.");

                                                    break;

                                                case 1:

                                                    System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesMedK.dat", Properties.Settings.Default.P1Directory + "\\preference1.dat");
                                                    Console.WriteLine("Successfully loaded P1's preferencesMedK.dat as preference1.dat.");

                                                    break;

                                                case 2:

                                                    System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesHighK.dat", Properties.Settings.Default.P1Directory + "\\preference1.dat");
                                                    Console.WriteLine("Successfully loaded P1's preferencesHighK.dat as preference1.dat.");

                                                    break;

                                            }

                                            break;

                                    }

                                    break;

                                case true:

                                    switch (Properties.Settings.Default.keyboardControlsP1)
                                    {

                                        case false:

                                            switch (Properties.Settings.Default.graphicSetting)
                                            {

                                                case 0:

                                                    System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesLowA.dat", Properties.Settings.Default.P1Directory + "\\preference1.dat");
                                                    Console.WriteLine("Successfully loaded P1's preferencesLowA.dat as preference1.dat.");

                                                    break;

                                                case 1:

                                                    System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesMedA.dat", Properties.Settings.Default.P1Directory + "\\preference1.dat");
                                                    Console.WriteLine("Successfully loaded P1's preferencesMedA.dat as preference1.dat.");

                                                    break;

                                                case 2:

                                                    System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesHighA.dat", Properties.Settings.Default.P1Directory + "\\preference1.dat");
                                                    Console.WriteLine("Successfully loaded P1's preferencesHighA.dat as preference1.dat.");

                                                    break;

                                            }

                                            break;

                                        case true:

                                            switch (Properties.Settings.Default.graphicSetting)
                                            {

                                                case 0:

                                                    System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesLowAK.dat", Properties.Settings.Default.P1Directory + "\\preference1.dat");
                                                    Console.WriteLine("Successfully loaded P1's preferencesLowAK.dat as preference1.dat.");

                                                    break;

                                                case 1:

                                                    System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesMedAK.dat", Properties.Settings.Default.P1Directory + "\\preference1.dat");
                                                    Console.WriteLine("Successfully loaded P1's preferencesMedAK.dat as preference1.dat.");

                                                    break;

                                                case 2:

                                                    System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesHighAK.dat", Properties.Settings.Default.P1Directory + "\\preference1.dat");
                                                    Console.WriteLine("Successfully loaded P1's preferencesHighAK.dat as preference1.dat.");

                                                    break;

                                            }

                                            break;

                                    }

                                    break;

                            }

                            break;

                        case true:

                            switch (Properties.Settings.Default.launchAntiAliasing)
                            {

                                case false:

                                    switch (Properties.Settings.Default.keyboardControlsP1)
                                    {

                                        case false:

                                            switch (Properties.Settings.Default.graphicSetting)
                                            {

                                                case 0:

                                                    System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesLowV.dat", Properties.Settings.Default.P1Directory + "\\preference1.dat");
                                                    Console.WriteLine("Successfully loaded P1's preferencesLowV.dat as preference1.dat.");

                                                    break;

                                                case 1:

                                                    System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesMedV.dat", Properties.Settings.Default.P1Directory + "\\preference1.dat");
                                                    Console.WriteLine("Successfully loaded P1's preferencesMedV.dat as preference1.dat.");

                                                    break;

                                                case 2:

                                                    System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesHighV.dat", Properties.Settings.Default.P1Directory + "\\preference1.dat");
                                                    Console.WriteLine("Successfully loaded P1's preferencesHighV.dat as preference1.dat.");

                                                    break;

                                            }

                                            break;

                                        case true:

                                            switch (Properties.Settings.Default.graphicSetting)
                                            {

                                                case 0:

                                                    System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesLowVK.dat", Properties.Settings.Default.P1Directory + "\\preference1.dat");
                                                    Console.WriteLine("Successfully loaded P1's preferencesLowVK.dat as preference1.dat.");

                                                    break;

                                                case 1:

                                                    System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesMedVK.dat", Properties.Settings.Default.P1Directory + "\\preference1.dat");
                                                    Console.WriteLine("Successfully loaded P1's preferencesMedVK.dat as preference1.dat.");

                                                    break;

                                                case 2:

                                                    System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesHighVK.dat", Properties.Settings.Default.P1Directory + "\\preference1.dat");
                                                    Console.WriteLine("Successfully loaded P1's preferencesHighVK.dat as preference1.dat.");

                                                    break;

                                            }

                                            break;

                                    }

                                    break;

                                case true:

                                    switch (Properties.Settings.Default.keyboardControlsP1)
                                    {

                                        case false:

                                            switch (Properties.Settings.Default.graphicSetting)
                                            {

                                                case 0:

                                                    System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesLowVA.dat", Properties.Settings.Default.P1Directory + "\\preference1.dat");
                                                    Console.WriteLine("Successfully loaded P1's preferencesLowVA.dat as preference1.dat.");

                                                    break;

                                                case 1:

                                                    System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesMedVA.dat", Properties.Settings.Default.P1Directory + "\\preference1.dat");
                                                    Console.WriteLine("Successfully loaded P1's preferencesMedVA.dat as preference1.dat.");

                                                    break;

                                                case 2:

                                                    System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesHighVA.dat", Properties.Settings.Default.P1Directory + "\\preference1.dat");
                                                    Console.WriteLine("Successfully loaded P1's preferencesHighVA.dat as preference1.dat.");

                                                    break;

                                            }

                                            break;

                                        case true:

                                            switch (Properties.Settings.Default.graphicSetting)
                                            {

                                                case 0:

                                                    System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesLowVAK.dat", Properties.Settings.Default.P1Directory + "\\preference1.dat");
                                                    Console.WriteLine("Successfully loaded P1's preferencesLowVAK.dat as preference1.dat.");

                                                    break;

                                                case 1:

                                                    System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesMedVAK.dat", Properties.Settings.Default.P1Directory + "\\preference1.dat");
                                                    Console.WriteLine("Successfully loaded P1's preferencesMedVAK.dat as preference1.dat.");

                                                    break;

                                                case 2:

                                                    System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesHighVAK.dat", Properties.Settings.Default.P1Directory + "\\preference1.dat");
                                                    Console.WriteLine("Successfully loaded P1's preferencesHighVAK.dat as preference1.dat.");

                                                    break;

                                            }

                                            break;

                                    }

                                    break;

                            }

                            break;

                    }

                }
                else if (playerNum == 2)
                {

                    switch (Properties.Settings.Default.launchVSync)
                    {

                        case false:

                            switch (Properties.Settings.Default.launchAntiAliasing)
                            {

                                case false:

                                    switch (Properties.Settings.Default.graphicSetting)
                                    {

                                        case 0:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesLow.dat", Properties.Settings.Default.P2Directory + "\\preference2.dat");
                                            Console.WriteLine("Successfully loaded P2's preferencesLow.dat as preference2.dat.");

                                            break;

                                        case 1:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesMed.dat", Properties.Settings.Default.P2Directory + "\\preference2.dat");
                                            Console.WriteLine("Successfully loaded P2's preferencesMed.dat as preference2.dat.");

                                            break;

                                        case 2:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesHigh.dat", Properties.Settings.Default.P2Directory + "\\preference2.dat");
                                            Console.WriteLine("Successfully loaded P2's preferencesHigh.dat as preference2.dat.");

                                            break;

                                    }

                                    break;

                                case true:

                                    switch (Properties.Settings.Default.graphicSetting)
                                    {

                                        case 0:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesLowA.dat", Properties.Settings.Default.P2Directory + "\\preference2.dat");
                                            Console.WriteLine("Successfully loaded P2's preferencesLowA.dat as preference2.dat.");

                                            break;

                                        case 1:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesMedA.dat", Properties.Settings.Default.P2Directory + "\\preference2.dat");
                                            Console.WriteLine("Successfully loaded P2's preferencesMedA.dat as preference2.dat.");

                                            break;

                                        case 2:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesHighA.dat", Properties.Settings.Default.P2Directory + "\\preference2.dat");
                                            Console.WriteLine("Successfully loaded P2's preferencesHighA.dat as preference2.dat.");

                                            break;

                                    }

                                    break;

                            }

                            break;

                        case true:

                            switch (Properties.Settings.Default.launchAntiAliasing)
                            {

                                case false:

                                    switch (Properties.Settings.Default.graphicSetting)
                                    {

                                        case 0:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesLowV.dat", Properties.Settings.Default.P2Directory + "\\preference2.dat");
                                            Console.WriteLine("Successfully loaded P2's preferencesLowV.dat as preference2.dat.");

                                            break;

                                        case 1:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesMedV.dat", Properties.Settings.Default.P2Directory + "\\preference2.dat");
                                            Console.WriteLine("Successfully loaded P2's preferencesMedV.dat as preference2.dat.");

                                            break;

                                        case 2:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesHighV.dat", Properties.Settings.Default.P2Directory + "\\preference2.dat");
                                            Console.WriteLine("Successfully loaded P2's preferencesHighV.dat as preference2.dat.");

                                            break;

                                    }

                                    break;

                                case true:

                                    switch (Properties.Settings.Default.graphicSetting)
                                    {

                                        case 0:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesLowVA.dat", Properties.Settings.Default.P2Directory + "\\preference2.dat");
                                            Console.WriteLine("Successfully loaded P2's preferencesLowVA.dat as preference2.dat.");

                                            break;

                                        case 1:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesMedVA.dat", Properties.Settings.Default.P2Directory + "\\preference2.dat");
                                            Console.WriteLine("Successfully loaded P2's preferencesMedVA.dat as preference2.dat.");

                                            break;

                                        case 2:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesHighVA.dat", Properties.Settings.Default.P2Directory + "\\preference2.dat");
                                            Console.WriteLine("Successfully loaded P2's preferencesHighVA.dat as preference2.dat.");

                                            break;

                                    }

                                    break;

                            }

                            break;

                    }

                }
                else if (playerNum == 3)
                {

                    switch (Properties.Settings.Default.launchVSync)
                    {

                        case false:

                            switch (Properties.Settings.Default.launchAntiAliasing)
                            {

                                case false:

                                    switch (Properties.Settings.Default.graphicSetting)
                                    {

                                        case 0:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesLow.dat", Properties.Settings.Default.P3Directory + "\\preference3.dat");
                                            Console.WriteLine("Successfully loaded P3's preferencesLow.dat as preference3.dat.");

                                            break;

                                        case 1:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesMed.dat", Properties.Settings.Default.P3Directory + "\\preference3.dat");
                                            Console.WriteLine("Successfully loaded P3's preferencesMed.dat as preference3.dat.");

                                            break;

                                        case 2:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesHigh.dat", Properties.Settings.Default.P3Directory + "\\preference3.dat");
                                            Console.WriteLine("Successfully loaded P3's preferencesHigh.dat as preference3.dat.");

                                            break;

                                    }

                                    break;

                                case true:

                                    switch (Properties.Settings.Default.graphicSetting)
                                    {

                                        case 0:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesLowA.dat", Properties.Settings.Default.P3Directory + "\\preference3.dat");
                                            Console.WriteLine("Successfully loaded P3's preferencesLowA.dat as preference3.dat.");

                                            break;

                                        case 1:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesMedA.dat", Properties.Settings.Default.P3Directory + "\\preference3.dat");
                                            Console.WriteLine("Successfully loaded P3's preferencesMedA.dat as preference3.dat.");

                                            break;

                                        case 2:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesHighA.dat", Properties.Settings.Default.P3Directory + "\\preference3.dat");
                                            Console.WriteLine("Successfully loaded P3's preferencesHighA.dat as preference3.dat.");

                                            break;

                                    }

                                    break;

                            }

                            break;

                        case true:

                            switch (Properties.Settings.Default.launchAntiAliasing)
                            {

                                case false:

                                    switch (Properties.Settings.Default.graphicSetting)
                                    {

                                        case 0:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesLowV.dat", Properties.Settings.Default.P3Directory + "\\preference3.dat");
                                            Console.WriteLine("Successfully loaded P3's preferencesLowV.dat as preference3.dat.");

                                            break;

                                        case 1:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesMedV.dat", Properties.Settings.Default.P3Directory + "\\preference3.dat");
                                            Console.WriteLine("Successfully loaded P3's preferencesMedV.dat as preference3.dat.");

                                            break;

                                        case 2:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesHighV.dat", Properties.Settings.Default.P3Directory + "\\preference3.dat");
                                            Console.WriteLine("Successfully loaded P3's preferencesHighV.dat as preference3.dat.");

                                            break;

                                    }

                                    break;

                                case true:

                                    switch (Properties.Settings.Default.graphicSetting)
                                    {

                                        case 0:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesLowVA.dat", Properties.Settings.Default.P3Directory + "\\preference3.dat");
                                            Console.WriteLine("Successfully loaded P3's preferencesLowVA.dat as preference3.dat.");

                                            break;

                                        case 1:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesMedVA.dat", Properties.Settings.Default.P3Directory + "\\preference3.dat");
                                            Console.WriteLine("Successfully loaded P3's preferencesMedVA.dat as preference3.dat.");

                                            break;

                                        case 2:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesHighVA.dat", Properties.Settings.Default.P3Directory + "\\preference3.dat");
                                            Console.WriteLine("Successfully loaded P3's preferencesHighVA.dat as preference3.dat.");

                                            break;

                                    }

                                    break;

                            }

                            break;

                    }

                }
                else if (playerNum == 4)
                {

                    switch (Properties.Settings.Default.launchVSync)
                    {

                        case false:

                            switch (Properties.Settings.Default.launchAntiAliasing)
                            {

                                case false:

                                    switch (Properties.Settings.Default.graphicSetting)
                                    {

                                        case 0:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesLow.dat", Properties.Settings.Default.P4Directory + "\\preference4.dat");
                                            Console.WriteLine("Successfully loaded P4's preferencesLow.dat as preference4.dat.");

                                            break;

                                        case 1:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesMed.dat", Properties.Settings.Default.P4Directory + "\\preference4.dat");
                                            Console.WriteLine("Successfully loaded P4's preferencesMed.dat as preference4.dat.");

                                            break;

                                        case 2:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesHigh.dat", Properties.Settings.Default.P4Directory + "\\preference4.dat");
                                            Console.WriteLine("Successfully loaded P4's preferencesHigh.dat as preference4.dat.");

                                            break;

                                    }

                                    break;

                                case true:

                                    switch (Properties.Settings.Default.graphicSetting)
                                    {

                                        case 0:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesLowA.dat", Properties.Settings.Default.P4Directory + "\\preference4.dat");
                                            Console.WriteLine("Successfully loaded P4's preferencesLowA.dat as preference4.dat.");

                                            break;

                                        case 1:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesMedA.dat", Properties.Settings.Default.P4Directory + "\\preference4.dat");
                                            Console.WriteLine("Successfully loaded P4's preferencesMedA.dat as preference4.dat.");

                                            break;

                                        case 2:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesHighA.dat", Properties.Settings.Default.P4Directory + "\\preference4.dat");
                                            Console.WriteLine("Successfully loaded P4's preferencesHighA.dat as preference4.dat.");

                                            break;

                                    }

                                    break;

                            }

                            break;

                        case true:

                            switch (Properties.Settings.Default.launchAntiAliasing)
                            {

                                case false:

                                    switch (Properties.Settings.Default.graphicSetting)
                                    {

                                        case 0:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesLowV.dat", Properties.Settings.Default.P4Directory + "\\preference4.dat");
                                            Console.WriteLine("Successfully loaded P4's preferencesLowV.dat as preference4.dat.");

                                            break;

                                        case 1:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesMedV.dat", Properties.Settings.Default.P4Directory + "\\preference4.dat");
                                            Console.WriteLine("Successfully loaded P4's preferencesMedV.dat as preference4.dat.");

                                            break;

                                        case 2:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesHighV.dat", Properties.Settings.Default.P4Directory + "\\preference4.dat");
                                            Console.WriteLine("Successfully loaded P4's preferencesHighV.dat as preference4.dat.");

                                            break;

                                    }

                                    break;

                                case true:

                                    switch (Properties.Settings.Default.graphicSetting)
                                    {

                                        case 0:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesLowVA.dat", Properties.Settings.Default.P4Directory + "\\preference4.dat");
                                            Console.WriteLine("Successfully loaded P4's preferencesLowVA.dat as preference4.dat.");

                                            break;

                                        case 1:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesMedVA.dat", Properties.Settings.Default.P4Directory + "\\preference4.dat");
                                            Console.WriteLine("Successfully loaded P4's preferencesMedVA.dat as preference4.dat.");

                                            break;

                                        case 2:

                                            System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\preferencesHighVA.dat", Properties.Settings.Default.P4Directory + "\\preference4.dat");
                                            Console.WriteLine("Successfully loaded P4's preferencesHighVA.dat as preference4.dat.");

                                            break;

                                    }

                                    break;

                            }

                            break;

                    }

                }

            }
            catch
            {
                closeGamesThenRetry("setPreferencesFileAstmpPreferencesFile", "", playerNum);
            }

        }

        /// <summary>
        /// Copies the player's Durazno and xinput files to the corresponding profile's files in order to trick the game into thinking that that player's controller is controller 1.
        /// </summary>
        /// <param name="playerNum"></param>
        public static void setDuraznoFilesAstmpDuraznoFiles(sbyte playerNum)
        {

            if (!checkIfProcessIsRunning("eldoradoP1") && !checkIfProcessIsRunning("eldoradoP2") && !checkIfProcessIsRunning("eldoradoP3") && !checkIfProcessIsRunning("eldoradoP4"))
            {

                System.IO.File.Delete(Properties.Settings.Default.P1Directory + "\\xinput1_3.dll");
                System.IO.File.Delete(Properties.Settings.Default.P2Directory + "\\xinput1_3.dll");
                System.IO.File.Delete(Properties.Settings.Default.P3Directory + "\\xinput1_3.dll");
                System.IO.File.Delete(Properties.Settings.Default.P4Directory + "\\xinput1_3.dll");

                System.IO.File.Delete(Properties.Settings.Default.P1Directory + "\\Durazno.ini");
                System.IO.File.Delete(Properties.Settings.Default.P2Directory + "\\Durazno.ini");
                System.IO.File.Delete(Properties.Settings.Default.P3Directory + "\\Durazno.ini");
                System.IO.File.Delete(Properties.Settings.Default.P4Directory + "\\Durazno.ini");

            }

            try
            {

                switch (Properties.Settings.Default.keyboardControlsP1)
                {

                    case false:

                        switch (playerNum)
                        {

                            case 1:

                                System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\xinP1_1_3.dll", Properties.Settings.Default.P1Directory + "\\xinput1_3.dll");
                                System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\DuraznoP1.ini", Properties.Settings.Default.P1Directory + "\\Durazno.ini");
                                Console.WriteLine("Successfully loaded xinP1_1_3.dll and DuraznoP1.ini");

                                break;

                            case 2:

                                System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\xinP2_1_3.dll", Properties.Settings.Default.P2Directory + "\\xinput1_3.dll");
                                System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\DuraznoP2.ini", Properties.Settings.Default.P2Directory + "\\Durazno.ini");
                                Console.WriteLine("Successfully loaded xinP2_1_3.dll and DuraznoP2.ini");

                                break;

                            case 3:

                                System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\xinP3_1_3.dll", Properties.Settings.Default.P3Directory + "\\xinput1_3.dll");
                                System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\DuraznoP3.ini", Properties.Settings.Default.P3Directory + "\\Durazno.ini");
                                Console.WriteLine("Successfully loaded xinP3_1_3.dll and DuraznoP3.ini");

                                break;

                            case 4:

                                System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\xinP4_1_3.dll", Properties.Settings.Default.P4Directory + "\\xinput1_3.dll");
                                System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\DuraznoP4.ini", Properties.Settings.Default.P4Directory + "\\Durazno.ini");
                                Console.WriteLine("Successfully loaded xinP4_1_3.dll and DuraznoP4.ini");

                                break;

                        }

                        break;

                    case true:

                        switch (playerNum)
                        {

                            case 1:

                                if (checkIfProcessIsRunning("eldoradoP1") || checkIfProcessIsRunning("eldoradoP2") || checkIfProcessIsRunning("eldoradoP3") || checkIfProcessIsRunning("eldoradoP4"))
                                {

                                    closeGamesThenRetry("setDuraznoFilesAstmpDuraznoFiles", "", playerNum);

                                }

                                break;

                            case 2:

                                System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\xinP1_1_3.dll", Properties.Settings.Default.P2Directory + "\\xinput1_3.dll");
                                System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\DuraznoP1.ini", Properties.Settings.Default.P2Directory + "\\Durazno.ini");
                                Console.WriteLine("Successfully loaded xinP1_1_3.dll and DuraznoP1.ini");

                                break;

                            case 3:

                                System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\xinP2_1_3.dll", Properties.Settings.Default.P3Directory + "\\xinput1_3.dll");
                                System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\DuraznoP2.ini", Properties.Settings.Default.P3Directory + "\\Durazno.ini");
                                Console.WriteLine("Successfully loaded xinP2_1_3.dll and DuraznoP2.ini");

                                break;

                            case 4:

                                System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\xinP3_1_3.dll", Properties.Settings.Default.P4Directory + "\\xinput1_3.dll");
                                System.IO.File.Copy(Properties.Settings.Default.installationDirectory + "\\bin\\DuraznoP3.ini", Properties.Settings.Default.P4Directory + "\\Durazno.ini");
                                Console.WriteLine("Successfully loaded xinP3_1_3.dll and DuraznoP3.ini");

                                break;

                        }

                        break;

                }

            }
            catch
            {

                closeGamesThenRetry("setDuraznoFilesAstmpDuraznoFiles", "", playerNum);

            }

        }
        
        /// <summary>
        /// Launches a chosen player's game with their selected profile configuration
        /// </summary>
        /// <param name="playerNum"></param>
        public void launch(sbyte playerNum)
        {

            Screen[] screens = Screen.AllScreens;
            setEldoradoExeAstmpEldoradoExe();

            switch (playerNum)
            {

                case 1:

                    switch (Properties.Settings.Default.launchFullscreen)
                    {

                        case true:

                            setDuraznoFilesAstmpDuraznoFiles(1);
                            setPreferencesFileAstmpPreferencesFile(1);
                            setDewritoPrefsFileAsHOPFile(Properties.Settings.Default.installationDirectory + "\\profiles\\" + Properties.Settings.Default.P1Name + ".hop", 1);
                            CreateShortcut("eldoradoP1",
                                Properties.Settings.Default.installationDirectory + "\\shortcuts\\",
                                Properties.Settings.Default.installationDirectory + "\\P1\\eldoradoP1.exe",
                                "-launcher -multiInstance -windowed -height " + screens[0].Bounds.Height + " -width " + screens[0].Bounds.Width,
                                Properties.Settings.Default.installationDirectory + "\\P1",
                                Properties.Settings.Default.installationDirectory + "\\bin\\logoP1.ico",
                                "Play some Halo Online in splitscreen as P1!");
                            Console.WriteLine("Successfully created shortcut: (eldoradoP1).");
                            Process.Start(Properties.Settings.Default.installationDirectory + "\\shortcuts\\eldoradoP1.lnk");
                            Console.WriteLine("Successfully launched P1's game.");
                            Process.GetProcessesByName("EldoradoP1")[0].WaitForInputIdle();
                            try
                            {
                                IntPtr window = Process.GetProcessesByName("EldoradoP1")[0].MainWindowHandle;
                                SetWindowLong(window, gwlStyle, wsSysMenu);
                                SetWindowPos(window, 0, screens[0].Bounds.X, screens[0].Bounds.Y, screens[0].Bounds.Width, screens[0].Bounds.Height, 0x0040);
                                DrawMenuBar(window);
                            }
                            catch
                            {
                                MessageBox.Show("Failed to properly place P1's fullscreen game.", "Halo Online Split Screen");
                            }
                            Console.WriteLine("Successfully set P1's game.");

                            break;

                        case false:

                            setDuraznoFilesAstmpDuraznoFiles(1);
                            setPreferencesFileAstmpPreferencesFile(1);
                            setDewritoPrefsFileAsHOPFile(Properties.Settings.Default.installationDirectory + "\\profiles\\" + Properties.Settings.Default.P1Name + ".hop", 1);
                            if (Properties.Settings.Default.launchConsoleMode)
                            {
                                if (Properties.Settings.Default.amtInstances == 1)
                                {
                                    CreateShortcut("eldoradoP1",
                                    Properties.Settings.Default.installationDirectory + "\\shortcuts\\",
                                    Properties.Settings.Default.installationDirectory + "\\P1\\eldoradoP1.exe",
                                    "-launcher -multiInstance -windowed -height " + screens[0].Bounds.Height + " -width " + screens[0].Bounds.Width,
                                    Properties.Settings.Default.installationDirectory + "\\P1",
                                    Properties.Settings.Default.installationDirectory + "\\bin\\logoP1.ico",
                                    "Play some Halo Online in splitscreen as P1!");
                                }
                                else if ((Properties.Settings.Default.amtInstances == 2 || Properties.Settings.Default.amtInstances == 3) && Properties.Settings.Default.consoleModeOrientation == 0)
                                {
                                    CreateShortcut("eldoradoP1",
                                    Properties.Settings.Default.installationDirectory + "\\shortcuts\\",
                                    Properties.Settings.Default.installationDirectory + "\\P1\\eldoradoP1.exe",
                                    "-launcher -multiInstance -windowed -height " + screens[0].Bounds.Height / 2 + " -width " + screens[0].Bounds.Width,
                                    Properties.Settings.Default.installationDirectory + "\\P1",
                                    Properties.Settings.Default.installationDirectory + "\\bin\\logoP1.ico",
                                    "Play some Halo Online in splitscreen as P1!");
                                }
                                else if ((Properties.Settings.Default.amtInstances == 2 || Properties.Settings.Default.amtInstances == 3) && Properties.Settings.Default.consoleModeOrientation == 1)
                                {
                                    CreateShortcut("eldoradoP1",
                                    Properties.Settings.Default.installationDirectory + "\\shortcuts\\",
                                    Properties.Settings.Default.installationDirectory + "\\P1\\eldoradoP1.exe",
                                    "-launcher -multiInstance -windowed -height " + screens[0].Bounds.Height + " -width " + screens[0].Bounds.Width / 2,
                                    Properties.Settings.Default.installationDirectory + "\\P1",
                                    Properties.Settings.Default.installationDirectory + "\\bin\\logoP1.ico",
                                    "Play some Halo Online in splitscreen as P1!");
                                }
                                else if (Properties.Settings.Default.amtInstances == 4)
                                {
                                    CreateShortcut("eldoradoP1",
                                    Properties.Settings.Default.installationDirectory + "\\shortcuts\\",
                                    Properties.Settings.Default.installationDirectory + "\\P1\\eldoradoP1.exe",
                                    "-launcher -multiInstance -windowed -height " + screens[0].Bounds.Height / 2 + " -width " + screens[0].Bounds.Width / 2,
                                    Properties.Settings.Default.installationDirectory + "\\P1",
                                    Properties.Settings.Default.installationDirectory + "\\bin\\logoP1.ico",
                                    "Play some Halo Online in splitscreen as P1!");
                                }
                            }
                            else
                            {
                                CreateShortcut("eldoradoP1",
                                    Properties.Settings.Default.installationDirectory + "\\shortcuts\\",
                                    Properties.Settings.Default.installationDirectory + "\\P1\\eldoradoP1.exe",
                                    "-launcher -multiInstance -windowed -height " + Properties.Settings.Default.resP1Height + " -width " + Properties.Settings.Default.resP1Width,
                                    Properties.Settings.Default.installationDirectory + "\\P1",
                                    Properties.Settings.Default.installationDirectory + "\\bin\\logoP1.ico",
                                    "Play some Halo Online in splitscreen as P1!");
                            }
                            Console.WriteLine("Successfully created shortcut: (eldoradoP1).");
                            Process.Start(Properties.Settings.Default.installationDirectory + "\\shortcuts\\eldoradoP1.lnk");
                            Console.WriteLine("Successfully launched P1's game.");
                            Process.GetProcessesByName("EldoradoP1")[0].WaitForInputIdle();
                            if (Properties.Settings.Default.launchConsoleMode)
                            {
                                if (Properties.Settings.Default.amtInstances == 1)
                                {
                                    try
                                    {
                                        IntPtr window = Process.GetProcessesByName("EldoradoP1")[0].MainWindowHandle;
                                        SetWindowLong(window, gwlStyle, wsSysMenu);
                                        SetWindowPos(window, 0, screens[0].Bounds.X, screens[0].Bounds.Y, screens[0].Bounds.Width, screens[0].Bounds.Height, 0x0040);
                                        DrawMenuBar(window);
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Failed to properly place P1's fullscreen game.", "Halo Online Split Screen");
                                    }
                                }
                                else if ((Properties.Settings.Default.amtInstances == 2 || Properties.Settings.Default.amtInstances == 3) && Properties.Settings.Default.consoleModeOrientation == 0)
                                {
                                    try
                                    {
                                        IntPtr window = Process.GetProcessesByName("EldoradoP1")[0].MainWindowHandle;
                                        SetWindowLong(window, gwlStyle, wsSysMenu);
                                        SetWindowPos(window, 0, screens[0].Bounds.X, screens[0].Bounds.Y, screens[0].Bounds.Width, screens[0].Bounds.Height / 2, 0x0040);
                                        DrawMenuBar(window);
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Failed to properly place P1's fullscreen game.", "Halo Online Split Screen");
                                    }
                                }
                                else if ((Properties.Settings.Default.amtInstances == 2 || Properties.Settings.Default.amtInstances == 3) && Properties.Settings.Default.consoleModeOrientation == 1)
                                {
                                    try
                                    {
                                        IntPtr window = Process.GetProcessesByName("EldoradoP1")[0].MainWindowHandle;
                                        SetWindowLong(window, gwlStyle, wsSysMenu);
                                        SetWindowPos(window, 0, screens[0].Bounds.X, screens[0].Bounds.Y, screens[0].Bounds.Width / 2, screens[0].Bounds.Height, 0x0040);
                                        DrawMenuBar(window);
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Failed to properly place P1's fullscreen game.", "Halo Online Split Screen");
                                    }
                                }
                                else if (Properties.Settings.Default.amtInstances == 4)
                                {
                                    try
                                    {
                                        IntPtr window = Process.GetProcessesByName("EldoradoP1")[0].MainWindowHandle;
                                        SetWindowLong(window, gwlStyle, wsSysMenu);
                                        SetWindowPos(window, 0, screens[0].Bounds.X, screens[0].Bounds.Y, screens[0].Bounds.Width / 2, screens[0].Bounds.Height / 2, 0x0040);
                                        DrawMenuBar(window);
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Failed to properly place P1's fullscreen game.", "Halo Online Split Screen");
                                    }
                                }
                            }
                            Console.WriteLine("Successfully set P1's game.");

                            break;

                    }

                    break;

                case 2:

                    switch (Properties.Settings.Default.launchFullscreen)
                    {

                        case true:

                            setDuraznoFilesAstmpDuraznoFiles(2);
                            setPreferencesFileAstmpPreferencesFile(2);
                            setDewritoPrefsFileAsHOPFile(Properties.Settings.Default.installationDirectory + "\\profiles\\" + Properties.Settings.Default.P2Name + ".hop", 2);
                            CreateShortcut("eldoradoP2",
                                Properties.Settings.Default.installationDirectory + "\\shortcuts\\",
                                Properties.Settings.Default.installationDirectory + "\\P2\\eldoradoP2.exe",
                                "-launcher -multiInstance -windowed -height " + screens[1].Bounds.Height + " -width " + screens[1].Bounds.Width,
                                Properties.Settings.Default.installationDirectory + "\\P2",
                                Properties.Settings.Default.installationDirectory + "\\bin\\logoP2.ico",
                                "Play some Halo Online in splitscreen as P2!");
                            Console.WriteLine("Successfully created shortcut: (eldoradoP2).");
                            Process.Start(Properties.Settings.Default.installationDirectory + "\\shortcuts\\eldoradoP2.lnk");
                            Console.WriteLine("Successfully launched P2's game.");
                            Process.GetProcessesByName("EldoradoP2")[0].WaitForInputIdle();
                            try
                            {
                                IntPtr window = Process.GetProcessesByName("EldoradoP2")[0].MainWindowHandle;
                                SetWindowLong(window, gwlStyle, wsSysMenu);
                                SetWindowPos(window, 0, screens[1].Bounds.X, screens[1].Bounds.Y, screens[1].Bounds.Width, screens[1].Bounds.Height, 0x0040);
                                DrawMenuBar(window);
                            }
                            catch
                            {
                                MessageBox.Show("Failed to properly place P2's fullscreen game.", "Halo Online Split Screen");
                            }
                            Console.WriteLine("Successfully set P2's game.");

                            break;

                        case false:

                            setDuraznoFilesAstmpDuraznoFiles(2);
                            setPreferencesFileAstmpPreferencesFile(2);
                            setDewritoPrefsFileAsHOPFile(Properties.Settings.Default.installationDirectory + "\\profiles\\" + Properties.Settings.Default.P2Name + ".hop", 2);
                            if (Properties.Settings.Default.launchConsoleMode)
                            {
                                if (Properties.Settings.Default.amtInstances == 2 && Properties.Settings.Default.consoleModeOrientation == 0)
                                {
                                    CreateShortcut("eldoradoP2",
                                    Properties.Settings.Default.installationDirectory + "\\shortcuts\\",
                                    Properties.Settings.Default.installationDirectory + "\\P2\\eldoradoP2.exe",
                                    "-launcher -multiInstance -windowed -height " + screens[0].Bounds.Height / 2 + " -width " + screens[0].Bounds.Width,
                                    Properties.Settings.Default.installationDirectory + "\\P2",
                                    Properties.Settings.Default.installationDirectory + "\\bin\\logoP2.ico",
                                    "Play some Halo Online in splitscreen as P2!");
                                }
                                if (Properties.Settings.Default.amtInstances == 2 && Properties.Settings.Default.consoleModeOrientation == 1)
                                {
                                    CreateShortcut("eldoradoP2",
                                    Properties.Settings.Default.installationDirectory + "\\shortcuts\\",
                                    Properties.Settings.Default.installationDirectory + "\\P2\\eldoradoP2.exe",
                                    "-launcher -multiInstance -windowed -height " + screens[0].Bounds.Height + " -width " + screens[0].Bounds.Width / 2,
                                    Properties.Settings.Default.installationDirectory + "\\P2",
                                    Properties.Settings.Default.installationDirectory + "\\bin\\logoP2.ico",
                                    "Play some Halo Online in splitscreen as P2!");
                                }
                                else if (Properties.Settings.Default.amtInstances > 2)
                                {
                                    CreateShortcut("eldoradoP2",
                                    Properties.Settings.Default.installationDirectory + "\\shortcuts\\",
                                    Properties.Settings.Default.installationDirectory + "\\P2\\eldoradoP2.exe",
                                    "-launcher -multiInstance -windowed -height " + screens[0].Bounds.Height / 2 + " -width " + screens[0].Bounds.Width / 2,
                                    Properties.Settings.Default.installationDirectory + "\\P2",
                                    Properties.Settings.Default.installationDirectory + "\\bin\\logoP2.ico",
                                    "Play some Halo Online in splitscreen as P2!");
                                }
                            }
                            else
                            {
                                CreateShortcut("eldoradoP2",
                                   Properties.Settings.Default.installationDirectory + "\\shortcuts\\",
                                   Properties.Settings.Default.installationDirectory + "\\P2\\eldoradoP2.exe",
                                   "-launcher -multiInstance -windowed -height " + Properties.Settings.Default.resP2Height + " -width " + Properties.Settings.Default.resP2Width,
                                   Properties.Settings.Default.installationDirectory + "\\P2",
                                   Properties.Settings.Default.installationDirectory + "\\bin\\logoP2.ico",
                                   "Play some Halo Online in splitscreen as P2!");
                            }
                            Console.WriteLine("Successfully created shortcut: (eldoradoP2).");
                            Process.Start(Properties.Settings.Default.installationDirectory + "\\shortcuts\\eldoradoP2.lnk");
                            Console.WriteLine("Successfully launched P2's game.");
                            Process.GetProcessesByName("EldoradoP2")[0].WaitForInputIdle();
                            if (Properties.Settings.Default.launchConsoleMode)
                            {
                                if (Properties.Settings.Default.amtInstances == 2 && Properties.Settings.Default.consoleModeOrientation == 0)
                                {
                                    try
                                    {
                                        IntPtr window = Process.GetProcessesByName("EldoradoP2")[0].MainWindowHandle;
                                        SetWindowLong(window, gwlStyle, wsSysMenu);
                                        SetWindowPos(window, 0, screens[0].Bounds.X, screens[0].Bounds.Height / 2, screens[0].Bounds.Width, screens[0].Bounds.Height / 2, 0x0040);
                                        DrawMenuBar(window);
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Failed to properly place P2's fullscreen game.", "Halo Online Split Screen");
                                    }
                                }
                                else if (Properties.Settings.Default.amtInstances == 2 && Properties.Settings.Default.consoleModeOrientation == 1)
                                {
                                    try
                                    {
                                        IntPtr window = Process.GetProcessesByName("EldoradoP2")[0].MainWindowHandle;
                                        SetWindowLong(window, gwlStyle, wsSysMenu);
                                        SetWindowPos(window, 0, screens[0].Bounds.Width / 2, screens[0].Bounds.Y, screens[0].Bounds.Width / 2, screens[0].Bounds.Height, 0x0040);
                                        DrawMenuBar(window);
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Failed to properly place P2's fullscreen game.", "Halo Online Split Screen");
                                    }
                                }
                                else if (Properties.Settings.Default.amtInstances == 3 && Properties.Settings.Default.consoleModeOrientation == 0)
                                {
                                    try
                                    {
                                        IntPtr window = Process.GetProcessesByName("EldoradoP2")[0].MainWindowHandle;
                                        SetWindowLong(window, gwlStyle, wsSysMenu);
                                        SetWindowPos(window, 0, screens[0].Bounds.X, screens[0].Bounds.Height / 2, screens[0].Bounds.Width / 2, screens[0].Bounds.Height / 2, 0x0040);
                                        DrawMenuBar(window);
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Failed to properly place P2's fullscreen game.", "Halo Online Split Screen");
                                    }
                                }
                                else if (Properties.Settings.Default.amtInstances == 3 && Properties.Settings.Default.consoleModeOrientation == 1)
                                {
                                    try
                                    {
                                        IntPtr window = Process.GetProcessesByName("EldoradoP2")[0].MainWindowHandle;
                                        SetWindowLong(window, gwlStyle, wsSysMenu);
                                        SetWindowPos(window, 0, screens[0].Bounds.Width / 2, screens[0].Bounds.Y, screens[0].Bounds.Width / 2, screens[0].Bounds.Height / 2, 0x0040);
                                        DrawMenuBar(window);
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Failed to properly place P2's fullscreen game.", "Halo Online Split Screen");
                                    }
                                }
                                else if (Properties.Settings.Default.amtInstances == 4)
                                {
                                    try
                                    {
                                        IntPtr window = Process.GetProcessesByName("EldoradoP2")[0].MainWindowHandle;
                                        SetWindowLong(window, gwlStyle, wsSysMenu);
                                        SetWindowPos(window, 0, screens[0].Bounds.Width / 2, screens[0].Bounds.Y, screens[0].Bounds.Width / 2, screens[0].Bounds.Height / 2, 0x0040);
                                        DrawMenuBar(window);
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Failed to properly place P2's fullscreen game.", "Halo Online Split Screen");
                                    }
                                }
                            }
                            Console.WriteLine("Successfully set P2's game.");

                            break;

                    }

                    break;

                case 3:

                    switch (Properties.Settings.Default.launchFullscreen)
                    {

                        case true:

                            setDuraznoFilesAstmpDuraznoFiles(3);
                            setPreferencesFileAstmpPreferencesFile(3);
                            setDewritoPrefsFileAsHOPFile(Properties.Settings.Default.installationDirectory + "\\profiles\\" + Properties.Settings.Default.P3Name + ".hop", 3);
                            CreateShortcut("eldoradoP3",
                                Properties.Settings.Default.installationDirectory + "\\shortcuts\\",
                                Properties.Settings.Default.installationDirectory + "\\P3\\eldoradoP3.exe",
                                "-launcher -multiInstance -windowed -height " + screens[2].Bounds.Height + " -width " + screens[2].Bounds.Width,
                                Properties.Settings.Default.installationDirectory + "\\P3",
                                Properties.Settings.Default.installationDirectory + "\\bin\\logoP3.ico",
                                "Play some Halo Online in splitscreen as P3!");
                            Console.WriteLine("Successfully created shortcut: (eldoradoP3).");
                            Process.Start(Properties.Settings.Default.installationDirectory + "\\shortcuts\\eldoradoP3.lnk");
                            Console.WriteLine("Successfully launched P3's game.");
                            Process.GetProcessesByName("EldoradoP3")[0].WaitForInputIdle();
                            try
                            {
                                IntPtr window = Process.GetProcessesByName("EldoradoP3")[0].MainWindowHandle;
                                SetWindowLong(window, gwlStyle, wsSysMenu);
                                SetWindowPos(window, 0, screens[2].Bounds.X, screens[2].Bounds.Y, screens[2].Bounds.Width, screens[2].Bounds.Height, 0x0040);
                                DrawMenuBar(window);
                            }
                            catch
                            {
                                MessageBox.Show("Failed to properly place P3's fullscreen game.", "Halo Online Split Screen");
                            }
                            Console.WriteLine("Successfully set P3's game.");

                            break;

                        case false:

                            setDuraznoFilesAstmpDuraznoFiles(3);
                            setPreferencesFileAstmpPreferencesFile(3);
                            setDewritoPrefsFileAsHOPFile(Properties.Settings.Default.installationDirectory + "\\profiles\\" + Properties.Settings.Default.P3Name + ".hop", 3);
                            if (Properties.Settings.Default.launchConsoleMode)
                            {
                                CreateShortcut("eldoradoP3",
                                Properties.Settings.Default.installationDirectory + "\\shortcuts\\",
                                Properties.Settings.Default.installationDirectory + "\\P3\\eldoradoP3.exe",
                                "-launcher -multiInstance -windowed -height " + screens[0].Bounds.Height / 2 + " -width " + screens[0].Bounds.Width / 2,
                                Properties.Settings.Default.installationDirectory + "\\P3",
                                Properties.Settings.Default.installationDirectory + "\\bin\\logoP3.ico",
                                "Play some Halo Online in splitscreen as P3!");
                            }
                            else
                            {
                                CreateShortcut("eldoradoP3",
                                Properties.Settings.Default.installationDirectory + "\\shortcuts\\",
                                Properties.Settings.Default.installationDirectory + "\\P3\\eldoradoP3.exe",
                                "-launcher -multiInstance -windowed -height " + Properties.Settings.Default.resP3Height + " -width " + Properties.Settings.Default.resP3Width,
                                Properties.Settings.Default.installationDirectory + "\\P3",
                                Properties.Settings.Default.installationDirectory + "\\bin\\logoP3.ico",
                                "Play some Halo Online in splitscreen as P3!");
                            }
                            Console.WriteLine("Successfully created shortcut: (eldoradoP3).");
                            Process.Start(Properties.Settings.Default.installationDirectory + "\\shortcuts\\eldoradoP3.lnk");
                            Console.WriteLine("Successfully launched P3's game.");
                            Process.GetProcessesByName("EldoradoP3")[0].WaitForInputIdle();
                            if (Properties.Settings.Default.launchConsoleMode)
                            {
                                if (Properties.Settings.Default.amtInstances == 3)
                                {
                                    try
                                    {
                                        IntPtr window = Process.GetProcessesByName("EldoradoP3")[0].MainWindowHandle;
                                        SetWindowLong(window, gwlStyle, wsSysMenu);
                                        SetWindowPos(window, 0, screens[0].Bounds.Width / 2, screens[0].Bounds.Height / 2, screens[0].Bounds.Width / 2, screens[0].Bounds.Height / 2, 0x0040);
                                        DrawMenuBar(window);
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Failed to properly place P3's fullscreen game.", "Halo Online Split Screen");
                                    }
                                }
                                else if  (Properties.Settings.Default.amtInstances == 4)
                                {
                                    try
                                    {
                                        IntPtr window = Process.GetProcessesByName("EldoradoP3")[0].MainWindowHandle;
                                        SetWindowLong(window, gwlStyle, wsSysMenu);
                                        SetWindowPos(window, 0, screens[0].Bounds.X, screens[0].Bounds.Height / 2, screens[0].Bounds.Width / 2, screens[0].Bounds.Height / 2, 0x0040);
                                        DrawMenuBar(window);
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Failed to properly place P3's fullscreen game.", "Halo Online Split Screen");
                                    }
                                }
                                
                            }
                            Console.WriteLine("Successfully set P3's game.");

                            break;

                    }

                    break;

                case 4:

                    switch (Properties.Settings.Default.launchFullscreen)
                    {

                        case true:

                            setDuraznoFilesAstmpDuraznoFiles(4);
                            setPreferencesFileAstmpPreferencesFile(4);
                            setDewritoPrefsFileAsHOPFile(Properties.Settings.Default.installationDirectory + "\\profiles\\" + Properties.Settings.Default.P4Name + ".hop", 4);
                            CreateShortcut("eldoradoP4",
                                Properties.Settings.Default.installationDirectory + "\\shortcuts\\",
                                Properties.Settings.Default.installationDirectory + "\\P4\\eldoradoP4.exe",
                                "-launcher -multiInstance -windowed -height " + screens[3].Bounds.Height + " -width " + screens[3].Bounds.Width,
                                Properties.Settings.Default.installationDirectory + "\\P4",
                                Properties.Settings.Default.installationDirectory + "\\bin\\logoP4.ico",
                                "Play some Halo Online in splitscreen as P4!");
                            Console.WriteLine("Successfully created shortcut: (eldoradoP4).");
                            Process.Start(Properties.Settings.Default.installationDirectory + "\\shortcuts\\eldoradoP4.lnk");
                            Console.WriteLine("Successfully launched P4's game.");
                            Process.GetProcessesByName("EldoradoP4")[0].WaitForInputIdle();
                            try
                            {
                                IntPtr window = Process.GetProcessesByName("EldoradoP4")[0].MainWindowHandle;
                                SetWindowLong(window, gwlStyle, wsSysMenu);
                                SetWindowPos(window, 0, screens[3].Bounds.X, screens[3].Bounds.Y, screens[3].Bounds.Width, screens[3].Bounds.Height, 0x0040);
                                DrawMenuBar(window);
                            }
                            catch
                            {
                                MessageBox.Show("Failed to properly place P4's fullscreen game.", "Halo Online Split Screen");
                            }
                            Console.WriteLine("Successfully set P4's game.");

                            break;

                        case false:

                            setDuraznoFilesAstmpDuraznoFiles(4);
                            setPreferencesFileAstmpPreferencesFile(4);
                            setDewritoPrefsFileAsHOPFile(Properties.Settings.Default.installationDirectory + "\\profiles\\" + Properties.Settings.Default.P4Name + ".hop", 4);
                            if (Properties.Settings.Default.launchConsoleMode)
                            {
                                CreateShortcut("eldoradoP4",
                                Properties.Settings.Default.installationDirectory + "\\shortcuts\\",
                                Properties.Settings.Default.installationDirectory + "\\P4\\eldoradoP4.exe",
                                "-launcher -multiInstance -windowed -height " + screens[0].Bounds.Height / 2 + " -width " + screens[0].Bounds.Width / 2,
                                Properties.Settings.Default.installationDirectory + "\\P4",
                                Properties.Settings.Default.installationDirectory + "\\bin\\logoP4.ico",
                                "Play some Halo Online in splitscreen as P4!");
                            }
                            else
                            {
                                CreateShortcut("eldoradoP4",
                                Properties.Settings.Default.installationDirectory + "\\shortcuts\\",
                                Properties.Settings.Default.installationDirectory + "\\P4\\eldoradoP4.exe",
                                "-launcher -multiInstance -windowed -height " + Properties.Settings.Default.resP4Height + " -width " + Properties.Settings.Default.resP4Width,
                                Properties.Settings.Default.installationDirectory + "\\P4",
                                Properties.Settings.Default.installationDirectory + "\\bin\\logoP4.ico",
                                "Play some Halo Online in splitscreen as P4!");
                            }
                            Console.WriteLine("Successfully created shortcut: (eldoradoP4).");
                            Process.Start(Properties.Settings.Default.installationDirectory + "\\shortcuts\\eldoradoP4.lnk");
                            Console.WriteLine("Successfully launched P4's game.");
                            Process.GetProcessesByName("EldoradoP4")[0].WaitForInputIdle();
                            if (Properties.Settings.Default.launchConsoleMode)
                            {
                                try
                                {
                                    IntPtr window = Process.GetProcessesByName("EldoradoP4")[0].MainWindowHandle;
                                    SetWindowLong(window, gwlStyle, wsSysMenu);
                                    SetWindowPos(window, 0, screens[0].Bounds.Width / 2, screens[0].Bounds.Height / 2, screens[0].Bounds.Width / 2, screens[0].Bounds.Height / 2, 0x0040);
                                    DrawMenuBar(window);
                                }
                                catch
                                {
                                    MessageBox.Show("Failed to properly place P4's fullscreen game.", "Halo Online Split Screen");
                                }
                            }
                            Console.WriteLine("Successfully set P4's game.");

                            break;

                    }

                    break;

            }

        }
        
        /// <summary>
        /// Imports window changing function
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nIndex"></param>
        /// <param name="dwNewLong"></param>
        /// <returns></returns>
        [DllImport("USER32.DLL")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        /// <summary>
        /// Imports find window function
        /// </summary>
        /// <param name="ZeroOnly"></param>
        /// <param name="lpWindowName"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        /// <summary>
        /// Imports force window draw function
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        static extern bool DrawMenuBar(IntPtr hWnd);

        /// <summary>
        /// Imports window placement function
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="hWndInsertAfter"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="cx"></param>
        /// <param name="cy"></param>
        /// <param name="wFlags"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);
        
        private const int gwlStyle = -16;              //hex constant for style changing
        private const int wsBorder = 0x00800000;       //window with border
        private const int wsCaption = 0x00C00000;      //window with a title bar
        private const int wsSysMenu = 0x00080000;      //window with no borders etc.
        private const int wsMinimizeBox = 0x00020000;  //window with minimizebox

    }

}
