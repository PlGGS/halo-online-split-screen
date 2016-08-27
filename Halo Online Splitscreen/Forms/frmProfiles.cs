using System;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Halo_Online_Split_Screen
{

    public partial class frmProfiles : Form
    {

        bool appExit = true;
        private static int xPos;
        private static int yPos;

        public frmProfiles(int x, int y)
        {

            xPos = x;
            yPos = y;

            InitializeComponent();

        }

        private void frmProfiles_Load(object sender, EventArgs e)
        {
            
            this.Location = new Point(xPos, yPos);

            KeyPreview = true;

            if (System.IO.Directory.Exists(Properties.Settings.Default.installationDirectory + "\\profiles") == false)
            {

                System.IO.Directory.CreateDirectory(Properties.Settings.Default.installationDirectory + "\\profiles");

            }

            loadTraitsWithoutFileDialogP1();
            loadTraitsWithoutFileDialogP2();
            loadTraitsWithoutFileDialogP3();
            loadTraitsWithoutFileDialogP4();

        }
        
        /// <summary>
        /// Updates the player's settings while ingame.
        /// </summary>
        /// <param name="playerNum"></param>
        /// <returns></returns>
        public static void updatePlayerSettingsIngame()
        {

            if (GameMethods.checkIfProcessIsRunning("eldoradoP1"))
            {

                dewCmd("Execute dewrito_prefs.cfg");
                Console.WriteLine("Updated P1's player settings in-game.");

            }
            else
            {

                Console.WriteLine("Did not update P1's player setting's in-game.");

            }

        }

        /// <summary>
        /// Writes to the game's console.
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static string dewCmd(string cmd)
        {

            byte[] data = new byte[1024];
            string stringData;
            TcpClient server;

            try
            {

                server = new TcpClient("127.0.0.1", 2448);

            }

            catch (SocketException)
            {
                
                return "Is Eldorito Running?";

            }

            Stream ns = server.GetStream();

            var recv = ns.Read(data, 0, data.Length);
            stringData = Encoding.ASCII.GetString(data, 0, recv);

            ns.Write(Encoding.ASCII.GetBytes(cmd), 0, cmd.Length);
            ns.Flush();

            ns.Close();
            server.Close();

            return "Done";

        }

        private void lblBack_Click(object sender, EventArgs e)
        {

            if (cbxArmsP1.Text != "" && cbxChestP1.Text != "" && cbxHelmetP1.Text != "" && cbxLegsP1.Text != "" && cbxShouldersP1.Text != "" && txtNameP1.Text != "" && cbxWeaponP1.Text != "")
            {

                if (!File.Exists(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop") &&
                    !File.Exists(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop"))
                {

                    DialogResult save = MessageBox.Show("All of P1's parameters have been filled out but are not yet saved. Would you like to save P1's profile?", "Halo Online Split Screen", MessageBoxButtons.YesNo);

                    if (save == DialogResult.Yes)
                    {

                        File.Copy(Properties.Settings.Default.haloOnlineDirectory + "\\dewrito_prefs.cfg", Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop");

                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.Name " + "\"" + txtNameP1.Text + "\"");
                        switch (cbxWeaponP1.SelectedIndex)
                        {
                            case 0:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"assault rifle\"");
                                break;
                            case 1:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_2\"");
                                break;
                            case 2:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_3\"");
                                break;
                            case 3:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_5\"");
                                break;
                            case 4:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_6\"");
                                break;
                            case 5:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"battle_rifle\"");
                                break;
                            case 6:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_1\"");
                                break;
                            case 7:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_2\"");
                                break;
                            case 8:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_3\"");
                                break;
                            case 9:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_4\"");
                                break;
                            case 10:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_5\"");
                                break;
                            case 11:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_6\"");
                                break;
                            case 12:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine\"");
                                break;
                            case 13:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_1\"");
                                break;
                            case 14:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_2\"");
                                break;
                            case 15:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_3\"");
                                break;
                            case 16:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_4\"");
                                break;
                            case 17:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_5\"");
                                break;
                            case 18:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_6\"");
                                break;
                            case 19:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr\"");
                                break;
                            case 20:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_1\"");
                                break;
                            case 21:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_2\"");
                                break;
                            case 22:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_3\"");
                                break;
                            case 23:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_4\"");
                                break;
                            case 24:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_5\"");
                                break;
                            case 25:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_6\"");
                                break;
                            case 26:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"plasma_rifle\"");
                                break;
                            case 27:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"plasma_rifle_variant_6\"");
                                break;
                            case 28:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg\"");
                                break;
                            case 29:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_1\"");
                                break;
                            case 30:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_2\"");
                                break;
                            case 31:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_4\"");
                                break;
                            case 32:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_6\"");
                                break;
                        }

                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 8, "Player.Armor.Helmet " + "\"" + cbxHelmetP1.Text.ToLower() + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 7, "Player.Armor.Chest " + "\"" + cbxChestP1.Text.ToLower() + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 11, "Player.Armor.Shoulders " + "\"" + cbxShouldersP1.Text.ToLower() + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 6, "Player.Armor.Arms " + "\"" + cbxArmsP1.Text.ToLower() + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 9, "Player.Armor.Legs " + "\"" + cbxLegsP1.Text.ToLower() + "\"");

                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 12, "Player.Colors.Primary " + "\"#" + txtPrimaryP1.BackColor.R.ToString("X2") + txtPrimaryP1.BackColor.G.ToString("X2") + txtPrimaryP1.BackColor.B.ToString("X2") + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 13, "Player.Colors.Secondary " + "\"#" + txtSecondaryP1.BackColor.R.ToString("X2") + txtSecondaryP1.BackColor.G.ToString("X2") + txtSecondaryP1.BackColor.B.ToString("X2") + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 14, "Player.Colors.Visor " + "\"#" + txtVisorP1.BackColor.R.ToString("X2") + txtVisorP1.BackColor.G.ToString("X2") + txtVisorP1.BackColor.B.ToString("X2") + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 15, "Player.Colors.Lights " + "\"#" + txtLightsP1.BackColor.R.ToString("X2") + txtLightsP1.BackColor.G.ToString("X2") + txtLightsP1.BackColor.B.ToString("X2") + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 16, "Player.Colors.Holo " + "\"#" + txtHoloP1.BackColor.R.ToString("X2") + txtHoloP1.BackColor.G.ToString("X2") + txtHoloP1.BackColor.B.ToString("X2") + "\"");

                        FileStream tmp = File.Create(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".ref");

                        StreamWriter sw = new StreamWriter(tmp);

                        sw.WriteLine(txtNameP1.Text);
                        sw.WriteLine(cbxWeaponP1.Text);

                        sw.WriteLine(cbxHelmetP1.Text);
                        sw.WriteLine(cbxChestP1.Text);
                        sw.WriteLine(cbxShouldersP1.Text);
                        sw.WriteLine(cbxArmsP1.Text);
                        sw.WriteLine(cbxLegsP1.Text);

                        sw.WriteLine(txtPrimaryP1.BackColor.R.ToString() + " " + txtPrimaryP1.BackColor.G.ToString() + " " + txtPrimaryP1.BackColor.B.ToString());
                        sw.WriteLine(txtSecondaryP1.BackColor.R.ToString() + " " + txtSecondaryP1.BackColor.G.ToString() + " " + txtSecondaryP1.BackColor.B.ToString());
                        sw.WriteLine(txtVisorP1.BackColor.R.ToString() + " " + txtVisorP1.BackColor.G.ToString() + " " + txtVisorP1.BackColor.B.ToString());
                        sw.WriteLine(txtLightsP1.BackColor.R.ToString() + " " + txtLightsP1.BackColor.G.ToString() + " " + txtLightsP1.BackColor.B.ToString());
                        sw.Write(txtHoloP1.BackColor.R.ToString() + " " + txtHoloP1.BackColor.G.ToString() + " " + txtHoloP1.BackColor.B.ToString());

                        sw.Close();
                        tmp.Close();

                        lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 1, txtNameP1.Text);

                        Console.WriteLine("Successfully saved " + txtNameP1.Text + ".hop and " + txtNameP1.Text + ".ref to '" + Properties.Settings.Default.installationDirectory + "\\profiles'.");
                        MessageBox.Show("Successfully saved " + txtNameP1.Text + ".hop and " + txtNameP1.Text + ".ref to '" + Properties.Settings.Default.installationDirectory + "\\profiles'.", "Halo Online Split Screen");

                    }
                    else
                    {

                        MessageBox.Show("Did not save P1's profile.", "Halo Online Split Screen");

                    }

                }

            }
            
            if (cbxArmsP2.Text != "" && cbxChestP2.Text != "" && cbxHelmetP2.Text != "" && cbxLegsP2.Text != "" && cbxShouldersP2.Text != "" && txtNameP2.Text != "" && cbxWeaponP2.Text != "")
            {

                if (!File.Exists(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop") &&
                    !File.Exists(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop"))
                {

                    DialogResult save = MessageBox.Show("All of P2's parameters have been filled out but are not yet saved. Would you like to save P2's profile?", "Halo Online Split Screen", MessageBoxButtons.YesNo);

                    if (save == DialogResult.Yes)
                    {

                        File.Copy(Properties.Settings.Default.haloOnlineDirectory + "\\dewrito_prefs.cfg", Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop");

                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.Name " + "\"" + txtNameP2.Text + "\"");
                        switch (cbxWeaponP2.SelectedIndex)
                        {
                            case 0:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"assault rifle\"");
                                break;
                            case 1:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_2\"");
                                break;
                            case 2:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_3\"");
                                break;
                            case 3:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_5\"");
                                break;
                            case 4:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_6\"");
                                break;
                            case 5:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"battle_rifle\"");
                                break;
                            case 6:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_1\"");
                                break;
                            case 7:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_2\"");
                                break;
                            case 8:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_3\"");
                                break;
                            case 9:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_4\"");
                                break;
                            case 10:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_5\"");
                                break;
                            case 11:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_6\"");
                                break;
                            case 12:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine\"");
                                break;
                            case 13:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_1\"");
                                break;
                            case 14:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_2\"");
                                break;
                            case 15:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_3\"");
                                break;
                            case 16:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_4\"");
                                break;
                            case 17:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_5\"");
                                break;
                            case 18:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_6\"");
                                break;
                            case 19:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr\"");
                                break;
                            case 20:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_1\"");
                                break;
                            case 21:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_2\"");
                                break;
                            case 22:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_3\"");
                                break;
                            case 23:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_4\"");
                                break;
                            case 24:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_5\"");
                                break;
                            case 25:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_6\"");
                                break;
                            case 26:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"plasma_rifle\"");
                                break;
                            case 27:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"plasma_rifle_variant_6\"");
                                break;
                            case 28:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg\"");
                                break;
                            case 29:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_1\"");
                                break;
                            case 30:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_2\"");
                                break;
                            case 31:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_4\"");
                                break;
                            case 32:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_6\"");
                                break;
                        }

                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 8, "Player.Armor.Helmet " + "\"" + cbxHelmetP2.Text.ToLower() + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 7, "Player.Armor.Chest " + "\"" + cbxChestP2.Text.ToLower() + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 11, "Player.Armor.Shoulders " + "\"" + cbxShouldersP2.Text.ToLower() + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 6, "Player.Armor.Arms " + "\"" + cbxArmsP2.Text.ToLower() + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 9, "Player.Armor.Legs " + "\"" + cbxLegsP2.Text.ToLower() + "\"");

                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 12, "Player.Colors.Primary " + "\"#" + txtPrimaryP2.BackColor.R.ToString("X2") + txtPrimaryP2.BackColor.G.ToString("X2") + txtPrimaryP2.BackColor.B.ToString("X2") + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 13, "Player.Colors.Secondary " + "\"#" + txtSecondaryP2.BackColor.R.ToString("X2") + txtSecondaryP2.BackColor.G.ToString("X2") + txtSecondaryP2.BackColor.B.ToString("X2") + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 14, "Player.Colors.Visor " + "\"#" + txtVisorP2.BackColor.R.ToString("X2") + txtVisorP2.BackColor.G.ToString("X2") + txtVisorP2.BackColor.B.ToString("X2") + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 15, "Player.Colors.Lights " + "\"#" + txtLightsP2.BackColor.R.ToString("X2") + txtLightsP2.BackColor.G.ToString("X2") + txtLightsP2.BackColor.B.ToString("X2") + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 16, "Player.Colors.Holo " + "\"#" + txtHoloP2.BackColor.R.ToString("X2") + txtHoloP2.BackColor.G.ToString("X2") + txtHoloP2.BackColor.B.ToString("X2") + "\"");

                        FileStream tmp = File.Create(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".ref");

                        StreamWriter sw = new StreamWriter(tmp);

                        sw.WriteLine(txtNameP2.Text);
                        sw.WriteLine(cbxWeaponP2.Text);

                        sw.WriteLine(cbxHelmetP2.Text);
                        sw.WriteLine(cbxChestP2.Text);
                        sw.WriteLine(cbxShouldersP2.Text);
                        sw.WriteLine(cbxArmsP2.Text);
                        sw.WriteLine(cbxLegsP2.Text);

                        sw.WriteLine(txtPrimaryP2.BackColor.R.ToString() + " " + txtPrimaryP2.BackColor.G.ToString() + " " + txtPrimaryP2.BackColor.B.ToString());
                        sw.WriteLine(txtSecondaryP2.BackColor.R.ToString() + " " + txtSecondaryP2.BackColor.G.ToString() + " " + txtSecondaryP2.BackColor.B.ToString());
                        sw.WriteLine(txtVisorP2.BackColor.R.ToString() + " " + txtVisorP2.BackColor.G.ToString() + " " + txtVisorP2.BackColor.B.ToString());
                        sw.WriteLine(txtLightsP2.BackColor.R.ToString() + " " + txtLightsP2.BackColor.G.ToString() + " " + txtLightsP2.BackColor.B.ToString());
                        sw.Write(txtHoloP2.BackColor.R.ToString() + " " + txtHoloP2.BackColor.G.ToString() + " " + txtHoloP2.BackColor.B.ToString());

                        sw.Close();
                        tmp.Close();

                        lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 2, txtNameP2.Text);

                        Console.WriteLine("Successfully saved " + txtNameP2.Text + ".hop and " + txtNameP2.Text + ".ref to '" + Properties.Settings.Default.installationDirectory + "\\profiles'.");
                        MessageBox.Show("Successfully saved " + txtNameP2.Text + ".hop and " + txtNameP2.Text + ".ref to '" + Properties.Settings.Default.installationDirectory + "\\profiles'.", "Halo Online Split Screen");

                    }
                    else
                    {

                        MessageBox.Show("Did not save P2's profile.", "Halo Online Split Screen");

                    }

                }

            }

            if (cbxArmsP3.Text != "" && cbxChestP3.Text != "" && cbxHelmetP3.Text != "" && cbxLegsP3.Text != "" && cbxShouldersP3.Text != "" && txtNameP3.Text != "" && cbxWeaponP3.Text != "")
            {

                if (!File.Exists(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop") &&
                    !File.Exists(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop"))
                {

                    DialogResult save = MessageBox.Show("All of P3's parameters have been filled out but are not yet saved. Would you like to save P3's profile?", "Halo Online Split Screen", MessageBoxButtons.YesNo);

                    if (save == DialogResult.Yes)
                    {

                        File.Copy(Properties.Settings.Default.haloOnlineDirectory + "\\dewrito_prefs.cfg", Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop");

                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.Name " + "\"" + txtNameP3.Text + "\"");
                        switch (cbxWeaponP3.SelectedIndex)
                        {
                            case 0:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"assault rifle\"");
                                break;
                            case 1:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_2\"");
                                break;
                            case 2:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_3\"");
                                break;
                            case 3:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_5\"");
                                break;
                            case 4:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_6\"");
                                break;
                            case 5:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"battle_rifle\"");
                                break;
                            case 6:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_1\"");
                                break;
                            case 7:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_2\"");
                                break;
                            case 8:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_3\"");
                                break;
                            case 9:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_4\"");
                                break;
                            case 10:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_5\"");
                                break;
                            case 11:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_6\"");
                                break;
                            case 12:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine\"");
                                break;
                            case 13:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_1\"");
                                break;
                            case 14:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_2\"");
                                break;
                            case 15:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_3\"");
                                break;
                            case 16:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_4\"");
                                break;
                            case 17:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_5\"");
                                break;
                            case 18:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_6\"");
                                break;
                            case 19:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr\"");
                                break;
                            case 20:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_1\"");
                                break;
                            case 21:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_2\"");
                                break;
                            case 22:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_3\"");
                                break;
                            case 23:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_4\"");
                                break;
                            case 24:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_5\"");
                                break;
                            case 25:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_6\"");
                                break;
                            case 26:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"plasma_rifle\"");
                                break;
                            case 27:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"plasma_rifle_variant_6\"");
                                break;
                            case 28:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg\"");
                                break;
                            case 29:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_1\"");
                                break;
                            case 30:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_2\"");
                                break;
                            case 31:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_4\"");
                                break;
                            case 32:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_6\"");
                                break;
                        }

                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 8, "Player.Armor.Helmet " + "\"" + cbxHelmetP3.Text.ToLower() + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 7, "Player.Armor.Chest " + "\"" + cbxChestP3.Text.ToLower() + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 11, "Player.Armor.Shoulders " + "\"" + cbxShouldersP3.Text.ToLower() + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 6, "Player.Armor.Arms " + "\"" + cbxArmsP3.Text.ToLower() + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 9, "Player.Armor.Legs " + "\"" + cbxLegsP3.Text.ToLower() + "\"");

                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 12, "Player.Colors.Primary " + "\"#" + txtPrimaryP3.BackColor.R.ToString("X2") + txtPrimaryP3.BackColor.G.ToString("X2") + txtPrimaryP3.BackColor.B.ToString("X2") + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 13, "Player.Colors.Secondary " + "\"#" + txtSecondaryP3.BackColor.R.ToString("X2") + txtSecondaryP3.BackColor.G.ToString("X2") + txtSecondaryP3.BackColor.B.ToString("X2") + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 14, "Player.Colors.Visor " + "\"#" + txtVisorP3.BackColor.R.ToString("X2") + txtVisorP3.BackColor.G.ToString("X2") + txtVisorP3.BackColor.B.ToString("X2") + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 15, "Player.Colors.Lights " + "\"#" + txtLightsP3.BackColor.R.ToString("X2") + txtLightsP3.BackColor.G.ToString("X2") + txtLightsP3.BackColor.B.ToString("X2") + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 16, "Player.Colors.Holo " + "\"#" + txtHoloP3.BackColor.R.ToString("X2") + txtHoloP3.BackColor.G.ToString("X2") + txtHoloP3.BackColor.B.ToString("X2") + "\"");

                        FileStream tmp = File.Create(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".ref");

                        StreamWriter sw = new StreamWriter(tmp);

                        sw.WriteLine(txtNameP3.Text);
                        sw.WriteLine(cbxWeaponP3.Text);

                        sw.WriteLine(cbxHelmetP3.Text);
                        sw.WriteLine(cbxChestP3.Text);
                        sw.WriteLine(cbxShouldersP3.Text);
                        sw.WriteLine(cbxArmsP3.Text);
                        sw.WriteLine(cbxLegsP3.Text);

                        sw.WriteLine(txtPrimaryP3.BackColor.R.ToString() + " " + txtPrimaryP3.BackColor.G.ToString() + " " + txtPrimaryP3.BackColor.B.ToString());
                        sw.WriteLine(txtSecondaryP3.BackColor.R.ToString() + " " + txtSecondaryP3.BackColor.G.ToString() + " " + txtSecondaryP3.BackColor.B.ToString());
                        sw.WriteLine(txtVisorP3.BackColor.R.ToString() + " " + txtVisorP3.BackColor.G.ToString() + " " + txtVisorP3.BackColor.B.ToString());
                        sw.WriteLine(txtLightsP3.BackColor.R.ToString() + " " + txtLightsP3.BackColor.G.ToString() + " " + txtLightsP3.BackColor.B.ToString());
                        sw.Write(txtHoloP3.BackColor.R.ToString() + " " + txtHoloP3.BackColor.G.ToString() + " " + txtHoloP3.BackColor.B.ToString());

                        sw.Close();
                        tmp.Close();

                        lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 3, txtNameP3.Text);

                        Console.WriteLine("Successfully saved " + txtNameP3.Text + ".hop and " + txtNameP3.Text + ".ref to '" + Properties.Settings.Default.installationDirectory + "\\profiles'.");
                        MessageBox.Show("Successfully saved " + txtNameP3.Text + ".hop and " + txtNameP3.Text + ".ref to '" + Properties.Settings.Default.installationDirectory + "\\profiles'.", "Halo Online Split Screen");

                    }
                    else
                    {

                        MessageBox.Show("Did not save P3's profile.", "Halo Online Split Screen");

                    }

                }

            }

            if (cbxArmsP4.Text != "" && cbxChestP4.Text != "" && cbxHelmetP4.Text != "" && cbxLegsP4.Text != "" && cbxShouldersP4.Text != "" && txtNameP4.Text != "" && cbxWeaponP4.Text != "")
            {

                if (!File.Exists(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop") &&
                    !File.Exists(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop"))
                {

                    DialogResult save = MessageBox.Show("All of P4's parameters have been filled out but are not yet saved. Would you like to save P4's profile?", "Halo Online Split Screen", MessageBoxButtons.YesNo);

                    if (save == DialogResult.Yes)
                    {

                        File.Copy(Properties.Settings.Default.haloOnlineDirectory + "\\dewrito_prefs.cfg", Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop");

                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.Name " + "\"" + txtNameP4.Text + "\"");
                        switch (cbxWeaponP4.SelectedIndex)
                        {
                            case 0:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"assault rifle\"");
                                break;
                            case 1:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_2\"");
                                break;
                            case 2:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_3\"");
                                break;
                            case 3:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_5\"");
                                break;
                            case 4:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_6\"");
                                break;
                            case 5:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"battle_rifle\"");
                                break;
                            case 6:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_1\"");
                                break;
                            case 7:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_2\"");
                                break;
                            case 8:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_3\"");
                                break;
                            case 9:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_4\"");
                                break;
                            case 10:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_5\"");
                                break;
                            case 11:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_6\"");
                                break;
                            case 12:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine\"");
                                break;
                            case 13:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_1\"");
                                break;
                            case 14:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_2\"");
                                break;
                            case 15:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_3\"");
                                break;
                            case 16:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_4\"");
                                break;
                            case 17:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_5\"");
                                break;
                            case 18:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_6\"");
                                break;
                            case 19:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr\"");
                                break;
                            case 20:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_1\"");
                                break;
                            case 21:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_2\"");
                                break;
                            case 22:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_3\"");
                                break;
                            case 23:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_4\"");
                                break;
                            case 24:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_5\"");
                                break;
                            case 25:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_6\"");
                                break;
                            case 26:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"plasma_rifle\"");
                                break;
                            case 27:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"plasma_rifle_variant_6\"");
                                break;
                            case 28:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg\"");
                                break;
                            case 29:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_1\"");
                                break;
                            case 30:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_2\"");
                                break;
                            case 31:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_4\"");
                                break;
                            case 32:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_6\"");
                                break;
                        }

                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 8, "Player.Armor.Helmet " + "\"" + cbxHelmetP4.Text.ToLower() + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 7, "Player.Armor.Chest " + "\"" + cbxChestP4.Text.ToLower() + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 11, "Player.Armor.Shoulders " + "\"" + cbxShouldersP4.Text.ToLower() + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 6, "Player.Armor.Arms " + "\"" + cbxArmsP4.Text.ToLower() + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 9, "Player.Armor.Legs " + "\"" + cbxLegsP4.Text.ToLower() + "\"");

                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 12, "Player.Colors.Primary " + "\"#" + txtPrimaryP4.BackColor.R.ToString("X2") + txtPrimaryP4.BackColor.G.ToString("X2") + txtPrimaryP4.BackColor.B.ToString("X2") + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 13, "Player.Colors.Secondary " + "\"#" + txtSecondaryP4.BackColor.R.ToString("X2") + txtSecondaryP4.BackColor.G.ToString("X2") + txtSecondaryP4.BackColor.B.ToString("X2") + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 14, "Player.Colors.Visor " + "\"#" + txtVisorP4.BackColor.R.ToString("X2") + txtVisorP4.BackColor.G.ToString("X2") + txtVisorP4.BackColor.B.ToString("X2") + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 15, "Player.Colors.Lights " + "\"#" + txtLightsP4.BackColor.R.ToString("X2") + txtLightsP4.BackColor.G.ToString("X2") + txtLightsP4.BackColor.B.ToString("X2") + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 16, "Player.Colors.Holo " + "\"#" + txtHoloP4.BackColor.R.ToString("X2") + txtHoloP4.BackColor.G.ToString("X2") + txtHoloP4.BackColor.B.ToString("X2") + "\"");

                        FileStream tmp = File.Create(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".ref");

                        StreamWriter sw = new StreamWriter(tmp);

                        sw.WriteLine(txtNameP4.Text);
                        sw.WriteLine(cbxWeaponP4.Text);

                        sw.WriteLine(cbxHelmetP4.Text);
                        sw.WriteLine(cbxChestP4.Text);
                        sw.WriteLine(cbxShouldersP4.Text);
                        sw.WriteLine(cbxArmsP4.Text);
                        sw.WriteLine(cbxLegsP4.Text);

                        sw.WriteLine(txtPrimaryP4.BackColor.R.ToString() + " " + txtPrimaryP4.BackColor.G.ToString() + " " + txtPrimaryP4.BackColor.B.ToString());
                        sw.WriteLine(txtSecondaryP4.BackColor.R.ToString() + " " + txtSecondaryP4.BackColor.G.ToString() + " " + txtSecondaryP4.BackColor.B.ToString());
                        sw.WriteLine(txtVisorP4.BackColor.R.ToString() + " " + txtVisorP4.BackColor.G.ToString() + " " + txtVisorP4.BackColor.B.ToString());
                        sw.WriteLine(txtLightsP4.BackColor.R.ToString() + " " + txtLightsP4.BackColor.G.ToString() + " " + txtLightsP4.BackColor.B.ToString());
                        sw.Write(txtHoloP4.BackColor.R.ToString() + " " + txtHoloP4.BackColor.G.ToString() + " " + txtHoloP4.BackColor.B.ToString());

                        sw.Close();
                        tmp.Close();

                        lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 1, txtNameP4.Text);

                        Console.WriteLine("Successfully saved " + txtNameP4.Text + ".hop and " + txtNameP4.Text + ".ref to '" + Properties.Settings.Default.installationDirectory + "\\profiles'.");
                        MessageBox.Show("Successfully saved " + txtNameP4.Text + ".hop and " + txtNameP4.Text + ".ref to '" + Properties.Settings.Default.installationDirectory + "\\profiles'.", "Halo Online Split Screen");

                    }
                    else
                    {

                        MessageBox.Show("Did not save P4's profile.", "Halo Online Split Screen");

                    }

                }

            }

            frmMain main = new frmMain(Bounds.Left, Bounds.Top);
            main.Show();
            appExit = false;
            this.Close();

        }


        private void lblClearP1_Click(object sender, EventArgs e)
        {
            clearTraitsP1();
        }

        private void lblClearP2_Click(object sender, EventArgs e)
        {

            clearTraitsP2();

        }

        private void lblClearP3_Click(object sender, EventArgs e)
        {
            clearTraitsP3();
        }

        private void lblClearP4_Click(object sender, EventArgs e)
        {
            clearTraitsP4();
        }



        private void lblLoadP1_Click(object sender, EventArgs e)
        {
            loadTraitsP1();
        }

        private void lblLoadP2_Click(object sender, EventArgs e)
        {
            loadTraitsP2();
        }

        private void lblLoadP3_Click(object sender, EventArgs e)
        {
            loadTraitsP3();
        }

        private void lblLoadP4_Click(object sender, EventArgs e)
        {
            loadTraitsP4();
        }



        private void lblSaveP1_Click(object sender, EventArgs e)
        {
            saveTraitsP1();
        }

        private void lblSaveP2_Click(object sender, EventArgs e)
        {
            saveTraitsP2();
        }

        private void lblSaveP3_Click(object sender, EventArgs e)
        {
            saveTraitsP3();
        }

        private void lblSaveP4_Click(object sender, EventArgs e)
        {
            saveTraitsP4();
        }



        private void lblSaveAll_Click(object sender, EventArgs e)
        {

            saveTraitsP1();
            saveTraitsP2();
            saveTraitsP3();
            saveTraitsP4();

        }

        #region "player 1 color events"

        private void txtPrimaryP1_Click(object sender, EventArgs e)
        {
            txtClick(clrDialog, txtPrimaryP1);
        }

        private void txtPrimaryP1_Enter(object sender, EventArgs e)
        {
            txtEnter(txtPrimaryP1);
        }



        private void txtSecondaryP1_Click(object sender, EventArgs e)
        {
            txtClick(clrDialog, txtSecondaryP1);
        }

        private void txtSecondaryP1_Enter(object sender, EventArgs e)
        {
            txtEnter(txtSecondaryP1);
        }



        private void txtVisorP1_Click(object sender, EventArgs e)
        {
            txtClick(clrDialog, txtVisorP1);
        }

        private void txtVisorP1_Enter(object sender, EventArgs e)
        {
            txtEnter(txtVisorP1);
        }



        private void txtLightsP1_Click(object sender, EventArgs e)
        {
            txtClick(clrDialog, txtLightsP1);
        }

        private void txtLightsP1_Enter(object sender, EventArgs e)
        {
            txtEnter(txtLightsP1);
        }



        private void txtHoloP1_Click(object sender, EventArgs e)
        {
            txtClick(clrDialog, txtHoloP1);
        }

        private void txtHoloP1_Enter(object sender, EventArgs e)
        {
            txtEnter(txtHoloP1);
        }

        #endregion

        #region "player 2 color events"

        private void txtPrimaryP2_Click(object sender, EventArgs e)
        {
            txtClick(clrDialog, txtPrimaryP2);
        }

        private void txtPrimaryP2_Enter(object sender, EventArgs e)
        {
            txtEnter(txtPrimaryP2);
        }



        private void txtSecondaryP2_Click(object sender, EventArgs e)
        {
            txtClick(clrDialog, txtSecondaryP2);
        }

        private void txtSecondaryP2_Enter(object sender, EventArgs e)
        {
            txtEnter(txtSecondaryP2);
        }



        private void txtVisorP2_Click(object sender, EventArgs e)
        {
            txtClick(clrDialog, txtVisorP2);
        }

        private void txtVisorP2_Enter(object sender, EventArgs e)
        {
            txtEnter(txtVisorP2);
        }



        private void txtLightsP2_Click(object sender, EventArgs e)
        {
            txtClick(clrDialog, txtLightsP2);
        }

        private void txtLightsP2_Enter(object sender, EventArgs e)
        {
            txtEnter(txtLightsP2);
        }



        private void txtHoloP2_Click(object sender, EventArgs e)
        {
            txtClick(clrDialog, txtHoloP2);
        }

        private void txtHoloP2_Enter(object sender, EventArgs e)
        {
            txtEnter(txtHoloP2);
        }

        #endregion

        #region "player 3 color events"

        private void txtPrimaryP3_Click(object sender, EventArgs e)
        {
            txtClick(clrDialog, txtPrimaryP3);
        }

        private void txtPrimaryP3_Enter(object sender, EventArgs e)
        {
            txtEnter(txtPrimaryP3);
        }



        private void txtSecondaryP3_Click(object sender, EventArgs e)
        {
            txtClick(clrDialog, txtSecondaryP3);
        }

        private void txtSecondaryP3_Enter(object sender, EventArgs e)
        {
            txtEnter(txtSecondaryP3);
        }



        private void txtVisorP3_Click(object sender, EventArgs e)
        {
            txtClick(clrDialog, txtVisorP3);
        }

        private void txtVisorP3_Enter(object sender, EventArgs e)
        {
            txtEnter(txtVisorP3);
        }



        private void txtLightsP3_Click(object sender, EventArgs e)
        {
            txtClick(clrDialog, txtLightsP3);
        }

        private void txtLightsP3_Enter(object sender, EventArgs e)
        {
            txtEnter(txtLightsP3);
        }



        private void txtHoloP3_Click(object sender, EventArgs e)
        {
            txtClick(clrDialog, txtHoloP3);
        }

        private void txtHoloP3_Enter(object sender, EventArgs e)
        {
            txtEnter(txtHoloP3);
        }

        #endregion

        #region "player 4 color events"

        private void txtPrimaryP4_Click(object sender, EventArgs e)
        {
            txtClick(clrDialog, txtPrimaryP4);
        }

        private void txtPrimaryP4_Enter(object sender, EventArgs e)
        {
            txtEnter(txtPrimaryP4);
        }



        private void txtSecondaryP4_Click(object sender, EventArgs e)
        {
            txtClick(clrDialog, txtSecondaryP4);
        }

        private void txtSecondaryP4_Enter(object sender, EventArgs e)
        {
            txtEnter(txtSecondaryP4);
        }



        private void txtVisorP4_Click(object sender, EventArgs e)
        {
            txtClick(clrDialog, txtVisorP4);
        }

        private void txtVisorP4_Enter(object sender, EventArgs e)
        {
            txtEnter(txtVisorP4);
        }



        private void txtLightsP4_Click(object sender, EventArgs e)
        {
            txtClick(clrDialog, txtLightsP4);
        }

        private void txtLightsP4_Enter(object sender, EventArgs e)
        {
            txtEnter(txtLightsP4);
        }



        private void txtHoloP4_Click(object sender, EventArgs e)
        {
            txtClick(clrDialog, txtHoloP4);
        }

        private void txtHoloP4_Enter(object sender, EventArgs e)
        {
            txtEnter(txtHoloP4);
        }

        #endregion

        /// <summary>
        /// sets the selected textbox's backcolor to the color chosen by the user in the color dialog box.
        /// </summary>
        /// <param name="cd"></param>
        /// <param name="txt"></param>
        static void txtClick(ColorDialog cd, TextBox txt)
        {

            if (cd.ShowDialog() == DialogResult.OK)
            {

                txt.BackColor = cd.Color;

            }

        }

        /// <summary>
        /// Handles the entering and exiting of a selected textbox.
        /// </summary>
        /// <param name="txt"></param>
        static void txtEnter(TextBox txt)
        {

            txt.Enabled = false;
            txt.Enabled = true;

        }

        #region "mouse methods"

        private void lblBack_MouseEnter(object sender, EventArgs e)
        {
            lblBack.BackColor = Color.FromArgb(25, 25, 25);
        }

        private void lblBack_MouseLeave(object sender, EventArgs e)
        {
            lblBack.BackColor = Color.FromArgb(35, 35, 35);
        }

        private void lblBack_MouseHover(object sender, EventArgs e)
        {
            tipDefault.Show("Back to the main menu.", this.lblBack);
        }



        private void lblSaveAll_MouseEnter(object sender, EventArgs e)
        {
            lblSaveAll.BackColor = Color.FromArgb(25, 25, 25);
        }

        private void lblSaveAll_MouseLeave(object sender, EventArgs e)
        {
            lblSaveAll.BackColor = Color.FromArgb(35, 35, 35);
        }

        private void lblSaveAll_MouseHover(object sender, EventArgs e)
        {
            tipDefault.Show("Saves all player profiles at once.", this.lblSaveAll);
        }



        private void lblClearP1_MouseEnter(object sender, EventArgs e)
        {
            lblClearP1.BackColor = Color.FromArgb(25, 25, 25);
        }

        private void lblClearP1_MouseLeave(object sender, EventArgs e)
        {
            lblClearP1.BackColor = Color.FromArgb(35, 35, 35);
        }

        private void lblClearP1_MouseHover(object sender, EventArgs e)
        {
            tipDefault.Show("Gives you the option to clear or delete player 1's profile.", this.lblClearP1);
        }

        private void lblLoadP1_MouseEnter(object sender, EventArgs e)
        {
            lblLoadP1.BackColor = Color.FromArgb(25, 25, 25);
        }

        private void lblLoadP1_MouseLeave(object sender, EventArgs e)
        {
            lblLoadP1.BackColor = Color.FromArgb(35, 35, 35);
        }

        private void lblLoadP1_MouseHover(object sender, EventArgs e)
        {
            tipDefault.Show("Loads a .ref file from within the profiles folder of your HOSS installation folder as player 1's profile.", this.lblLoadP1);
        }
        
        private void lblSaveP1_MouseEnter(object sender, EventArgs e)
        {
            lblSaveP1.BackColor = Color.FromArgb(25, 25, 25);
        }

        private void lblSaveP1_MouseLeave(object sender, EventArgs e)
        {
            lblSaveP1.BackColor = Color.FromArgb(35, 35, 35);
        }

        private void lblSaveP1_MouseHover(object sender, EventArgs e)
        {
            tipDefault.Show("Saves player 1's profile as .hop and .ref files within the profiles folder of your HOSS installation folder.", this.lblSaveP1);
        }



        private void lblClearP2_MouseEnter(object sender, EventArgs e)
        {
            lblClearP2.BackColor = Color.FromArgb(25, 25, 25);
        }

        private void lblClearP2_MouseLeave(object sender, EventArgs e)
        {
            lblClearP2.BackColor = Color.FromArgb(35, 35, 35);
        }

        private void lblClearP2_MouseHover(object sender, EventArgs e)
        {
            tipDefault.Show("Gives you the option to clear or delete player 2's profile.", this.lblClearP2);
        }

        private void lblLoadP2_MouseEnter(object sender, EventArgs e)
        {
            lblLoadP2.BackColor = Color.FromArgb(25, 25, 25);
        }

        private void lblLoadP2_MouseLeave(object sender, EventArgs e)
        {
            lblLoadP2.BackColor = Color.FromArgb(35, 35, 35);
        }

        private void lblLoadP2_MouseHover(object sender, EventArgs e)
        {
            tipDefault.Show("Loads a .ref file from within the profiles folder of your HOSS installation folder as player 2's profile.", this.lblLoadP2);
        }
        
        private void lblSaveP2_MouseEnter(object sender, EventArgs e)
        {
            lblSaveP2.BackColor = Color.FromArgb(25, 25, 25);
        }

        private void lblSaveP2_MouseLeave(object sender, EventArgs e)
        {
            lblSaveP2.BackColor = Color.FromArgb(35, 35, 35);
        }

        private void lblSaveP2_MouseHover(object sender, EventArgs e)
        {
            tipDefault.Show("Saves player 2's profile as .hop and .ref files within the profiles folder of your HOSS installation folder.", this.lblSaveP2);
        }



        private void lblClearP3_MouseEnter(object sender, EventArgs e)
        {
            lblClearP3.BackColor = Color.FromArgb(25, 25, 25);
        }

        private void lblClearP3_MouseLeave(object sender, EventArgs e)
        {
            lblClearP3.BackColor = Color.FromArgb(35, 35, 35);
        }

        private void lblClearP3_MouseHover(object sender, EventArgs e)
        {
            tipDefault.Show("Gives you the option to clear or delete player 3's profile.", this.lblClearP3);
        }

        private void lblLoadP3_MouseEnter(object sender, EventArgs e)
        {
            lblLoadP3.BackColor = Color.FromArgb(25, 25, 25);
        }

        private void lblLoadP3_MouseLeave(object sender, EventArgs e)
        {
            lblLoadP3.BackColor = Color.FromArgb(35, 35, 35);
        }

        private void lblLoadP3_MouseHover(object sender, EventArgs e)
        {
            tipDefault.Show("Loads a .ref file from within the profiles folder of your HOSS installation folder as player 3's profile.", this.lblLoadP3);
        }
        
        private void lblSaveP3_MouseEnter(object sender, EventArgs e)
        {
            lblSaveP3.BackColor = Color.FromArgb(25, 25, 25);
        }

        private void lblSaveP3_MouseLeave(object sender, EventArgs e)
        {
            lblSaveP3.BackColor = Color.FromArgb(35, 35, 35);
        }

        private void lblSaveP3_MouseHover(object sender, EventArgs e)
        {
            tipDefault.Show("Saves player 3's profile as .hop and .ref files within the profiles folder of your HOSS installation folder.", this.lblSaveP3);
        }



        private void lblClearP4_MouseEnter(object sender, EventArgs e)
        {
            lblClearP4.BackColor = Color.FromArgb(25, 25, 25);
        }

        private void lblClearP4_MouseLeave(object sender, EventArgs e)
        {
            lblClearP4.BackColor = Color.FromArgb(35, 35, 35);
        }

        private void lblClearP4_MouseHover(object sender, EventArgs e)
        {
            tipDefault.Show("Gives you the option to clear or delete player 4's profile.", this.lblClearP4);
        }

        private void lblLoadP4_MouseEnter(object sender, EventArgs e)
        {
            lblLoadP4.BackColor = Color.FromArgb(25, 25, 25);
        }

        private void lblLoadP4_MouseLeave(object sender, EventArgs e)
        {
            lblLoadP4.BackColor = Color.FromArgb(35, 35, 35);
        }

        private void lblLoadP4_MouseHover(object sender, EventArgs e)
        {
            tipDefault.Show("Loads a .ref file from within the profiles folder of your HOSS installation folder as player 4's profile.", this.lblLoadP4);
        }
        
        private void lblSaveP4_MouseEnter(object sender, EventArgs e)
        {
            lblSaveP4.BackColor = Color.FromArgb(25, 25, 25);
        }

        private void lblSaveP4_MouseLeave(object sender, EventArgs e)
        {
            lblSaveP4.BackColor = Color.FromArgb(35, 35, 35);
        }

        private void lblSaveP4_MouseHover(object sender, EventArgs e)
        {
            tipDefault.Show("Saves player 4's profile as .hop and .ref files within the profiles folder of your HOSS installation folder.", this.lblSaveP4);
        }

        #endregion

        /// <summary>
        /// Changes a selected line of text in a file to a new string.
        /// </summary>
        /// <param name="directoryWithFileName"></param>
        /// <param name="lineToEdit"></param>
        /// <param name="newText"></param>
        private void lineChange(string directoryWithFileName, int lineToEdit, string newText)
        {
            
            string[] arrLine = File.ReadAllLines(directoryWithFileName);
            arrLine[lineToEdit - 1] = newText;
            File.WriteAllLines(directoryWithFileName, arrLine);

        }

        #region "profile clearing methods"
        
        private void clearTraitsP1()
        {
            
            DialogResult clear = MessageBox.Show("Are you sure you want to clear this profile's settings?", "Halo Online Split Screen", MessageBoxButtons.YesNo);
            
            if (clear == DialogResult.Yes)
            {
                
                if (System.IO.File.Exists(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".ref"))
                {
                    
                    DialogResult delete = MessageBox.Show("A saved profile exists with this name, do you want to delete it?", "Halo Online Split Screen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                    if (delete == DialogResult.Yes)
                    {

                        System.IO.File.Delete(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop");
                        System.IO.File.Delete(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".ref");

                        txtNameP1.Text = "";
                        cbxWeaponP1.SelectedIndex = -1;

                        cbxHelmetP1.SelectedIndex = -1;
                        cbxChestP1.SelectedIndex = -1;
                        cbxShouldersP1.SelectedIndex = -1;
                        cbxArmsP1.SelectedIndex = -1;
                        cbxLegsP1.SelectedIndex = -1;

                        txtPrimaryP1.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                        txtSecondaryP1.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                        txtVisorP1.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                        txtLightsP1.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                        txtHoloP1.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);

                        lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 1, "");

                        Console.WriteLine("Successfully cleared P1's profile and deleted its files.");
                        MessageBox.Show("Successfully cleared P1's profile and deleted its files.", "Halo Online Split Screen");

                    }
                    else
                    {

                        txtNameP1.Text = "";
                        cbxWeaponP1.SelectedIndex = -1;

                        cbxHelmetP1.SelectedIndex = -1;
                        cbxChestP1.SelectedIndex = -1;
                        cbxShouldersP1.SelectedIndex = -1;
                        cbxArmsP1.SelectedIndex = -1;
                        cbxLegsP1.SelectedIndex = -1;

                        txtPrimaryP1.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                        txtSecondaryP1.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                        txtVisorP1.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                        txtLightsP1.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                        txtHoloP1.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);

                        lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 1, "");

                        Console.WriteLine("Successfully cleared P1's profile but did not delete its files.");
                        MessageBox.Show("Successfully cleared P1's profile but did not delete its files.", "Halo Online Split Screen");

                    }

                } else
                {

                    txtNameP1.Text = "";
                    cbxWeaponP1.SelectedIndex = -1;

                    cbxHelmetP1.SelectedIndex = -1;
                    cbxChestP1.SelectedIndex = -1;
                    cbxShouldersP1.SelectedIndex = -1;
                    cbxArmsP1.SelectedIndex = -1;
                    cbxLegsP1.SelectedIndex = -1;

                    txtPrimaryP1.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                    txtSecondaryP1.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                    txtVisorP1.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                    txtLightsP1.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                    txtHoloP1.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);

                    lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 1, "");

                    Console.WriteLine("Successfully cleared P1's profile.");
                    MessageBox.Show("Successfully cleared P1's profile.", "Halo Online Split Screen");

                }

            } else
            {

                MessageBox.Show("Did not clear P1's profile.", "Halo Online Split Screen");

            }

        }

        private void clearTraitsP2()
        {

            DialogResult clear = MessageBox.Show("Are you sure you want to clear this profile's settings?", "Halo Online Split Screen", MessageBoxButtons.YesNo);

            if (clear == DialogResult.Yes)
            {

                if (System.IO.File.Exists(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".ref"))
                {

                    DialogResult delete = MessageBox.Show("A saved profile exists with this name, do you want to delete it?", "Halo Online Split Screen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                    if (delete == DialogResult.Yes)
                    {

                        System.IO.File.Delete(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop");
                        System.IO.File.Delete(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".ref");

                        txtNameP2.Text = "";
                        cbxWeaponP2.SelectedIndex = -1;

                        cbxHelmetP2.SelectedIndex = -1;
                        cbxChestP2.SelectedIndex = -1;
                        cbxShouldersP2.SelectedIndex = -1;
                        cbxArmsP2.SelectedIndex = -1;
                        cbxLegsP2.SelectedIndex = -1;

                        txtPrimaryP2.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                        txtSecondaryP2.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                        txtVisorP2.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                        txtLightsP2.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                        txtHoloP2.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);

                        lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 2, "");

                        Console.WriteLine("Successfully cleared P2's profile and deleted its files.");
                        MessageBox.Show("Successfully cleared P2's profile and deleted its files.", "Halo Online Split Screen");

                    }
                    else
                    {

                        txtNameP2.Text = "";
                        cbxWeaponP2.SelectedIndex = -1;

                        cbxHelmetP2.SelectedIndex = -1;
                        cbxChestP2.SelectedIndex = -1;
                        cbxShouldersP2.SelectedIndex = -1;
                        cbxArmsP2.SelectedIndex = -1;
                        cbxLegsP2.SelectedIndex = -1;

                        txtPrimaryP2.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                        txtSecondaryP2.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                        txtVisorP2.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                        txtLightsP2.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                        txtHoloP2.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);

                        lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 2, "");

                        Console.WriteLine("Successfully cleared P2's profile but did not delete its files.");
                        MessageBox.Show("Successfully cleared P2's profile but did not delete its files.", "Halo Online Split Screen");

                    }

                }
                else
                {

                    txtNameP2.Text = "";
                    cbxWeaponP2.SelectedIndex = -1;

                    cbxHelmetP2.SelectedIndex = -1;
                    cbxChestP2.SelectedIndex = -1;
                    cbxShouldersP2.SelectedIndex = -1;
                    cbxArmsP2.SelectedIndex = -1;
                    cbxLegsP2.SelectedIndex = -1;

                    txtPrimaryP2.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                    txtSecondaryP2.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                    txtVisorP2.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                    txtLightsP2.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                    txtHoloP2.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);

                    lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 2, "");

                    Console.WriteLine("Successfully cleared P2's profile.");
                    MessageBox.Show("Successfully cleared P2's profile.", "Halo Online Split Screen");

                }

            }
            else
            {

                MessageBox.Show("Did not clear P2's profile.", "Halo Online Split Screen");

            }

        }

        private void clearTraitsP3()
        {

            DialogResult clear = MessageBox.Show("Are you sure you want to clear this profile's settings?", "Halo Online Split Screen", MessageBoxButtons.YesNo);

            if (clear == DialogResult.Yes)
            {

                if (System.IO.File.Exists(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".ref"))
                {

                    DialogResult delete = MessageBox.Show("A saved profile exists with this name, do you want to delete it?", "Halo Online Split Screen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                    if (delete == DialogResult.Yes)
                    {

                        System.IO.File.Delete(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop");
                        System.IO.File.Delete(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".ref");

                        txtNameP3.Text = "";
                        cbxWeaponP3.SelectedIndex = -1;

                        cbxHelmetP3.SelectedIndex = -1;
                        cbxChestP3.SelectedIndex = -1;
                        cbxShouldersP3.SelectedIndex = -1;
                        cbxArmsP3.SelectedIndex = -1;
                        cbxLegsP3.SelectedIndex = -1;

                        txtPrimaryP3.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                        txtSecondaryP3.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                        txtVisorP3.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                        txtLightsP3.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                        txtHoloP3.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);

                        lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 3, "");

                        Console.WriteLine("Successfully cleared P3's profile and deleted its files.");
                        MessageBox.Show("Successfully cleared P3's profile and deleted its files.", "Halo Online Split Screen");

                    }
                    else
                    {

                        txtNameP3.Text = "";
                        cbxWeaponP3.SelectedIndex = -1;

                        cbxHelmetP3.SelectedIndex = -1;
                        cbxChestP3.SelectedIndex = -1;
                        cbxShouldersP3.SelectedIndex = -1;
                        cbxArmsP3.SelectedIndex = -1;
                        cbxLegsP3.SelectedIndex = -1;

                        txtPrimaryP3.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                        txtSecondaryP3.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                        txtVisorP3.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                        txtLightsP3.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                        txtHoloP3.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);

                        lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 3, "");

                        Console.WriteLine("Successfully cleared P3's profile but did not delete its files.");
                        MessageBox.Show("Successfully cleared P3's profile but did not delete its files.", "Halo Online Split Screen");

                    }

                }
                else
                {

                    txtNameP3.Text = "";
                    cbxWeaponP3.SelectedIndex = -1;

                    cbxHelmetP3.SelectedIndex = -1;
                    cbxChestP3.SelectedIndex = -1;
                    cbxShouldersP3.SelectedIndex = -1;
                    cbxArmsP3.SelectedIndex = -1;
                    cbxLegsP3.SelectedIndex = -1;

                    txtPrimaryP3.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                    txtSecondaryP3.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                    txtVisorP3.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                    txtLightsP3.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                    txtHoloP3.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);

                    lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 3, "");

                    Console.WriteLine("Successfully cleared P3's profile.");
                    MessageBox.Show("Successfully cleared P3's profile.", "Halo Online Split Screen");

                }

            }
            else
            {

                MessageBox.Show("Did not clear P3's profile.", "Halo Online Split Screen");

            }

        }
        
        private void clearTraitsP4()
        {

            DialogResult clear = MessageBox.Show("Are you sure you want to clear this profile's settings?", "Halo Online Split Screen", MessageBoxButtons.YesNo);

            if (clear == DialogResult.Yes)
            {

                if (System.IO.File.Exists(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".ref"))
                {

                    DialogResult delete = MessageBox.Show("A saved profile exists with this name, do you want to delete it?", "Halo Online Split Screen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                    if (delete == DialogResult.Yes)
                    {

                        System.IO.File.Delete(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop");
                        System.IO.File.Delete(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".ref");

                        txtNameP4.Text = "";
                        cbxWeaponP4.SelectedIndex = -1;

                        cbxHelmetP4.SelectedIndex = -1;
                        cbxChestP4.SelectedIndex = -1;
                        cbxShouldersP4.SelectedIndex = -1;
                        cbxArmsP4.SelectedIndex = -1;
                        cbxLegsP4.SelectedIndex = -1;

                        txtPrimaryP4.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                        txtSecondaryP4.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                        txtVisorP4.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                        txtLightsP4.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                        txtHoloP4.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);

                        lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 4, "");

                        Console.WriteLine("Successfully cleared P4's profile and deleted its files.");
                        MessageBox.Show("Successfully cleared P4's profile and deleted its files.", "Halo Online Split Screen");

                    }
                    else
                    {

                        txtNameP4.Text = "";
                        cbxWeaponP4.SelectedIndex = -1;

                        cbxHelmetP4.SelectedIndex = -1;
                        cbxChestP4.SelectedIndex = -1;
                        cbxShouldersP4.SelectedIndex = -1;
                        cbxArmsP4.SelectedIndex = -1;
                        cbxLegsP4.SelectedIndex = -1;

                        txtPrimaryP4.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                        txtSecondaryP4.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                        txtVisorP4.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                        txtLightsP4.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                        txtHoloP4.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);

                        lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 4, "");

                        Console.WriteLine("Successfully cleared P4's profile but did not delete its files.");
                        MessageBox.Show("Successfully cleared P4's profile but did not delete its files.", "Halo Online Split Screen");

                    }

                }
                else
                {

                    txtNameP4.Text = "";
                    cbxWeaponP4.SelectedIndex = -1;

                    cbxHelmetP4.SelectedIndex = -1;
                    cbxChestP4.SelectedIndex = -1;
                    cbxShouldersP4.SelectedIndex = -1;
                    cbxArmsP4.SelectedIndex = -1;
                    cbxLegsP4.SelectedIndex = -1;

                    txtPrimaryP4.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                    txtSecondaryP4.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                    txtVisorP4.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                    txtLightsP4.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);
                    txtHoloP4.BackColor = Color.FromArgb(red: 40, green: 40, blue: 40);

                    lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 4, "");

                    Console.WriteLine("Successfully cleared P4's profile.");
                    MessageBox.Show("Successfully cleared P4's profile.", "Halo Online Split Screen");

                }

            }
            else
            {

                MessageBox.Show("Did not clear P4's profile.", "Halo Online Split Screen");

            }

        }

        #endregion

        #region "profile loading methods"
        
        private void loadTraitsWithoutFileDialogP1()
        {
            
            if (Properties.Settings.Default.P1Name != "")
            {

                if (System.IO.File.Exists(Properties.Settings.Default.installationDirectory + "\\profiles\\" + Properties.Settings.Default.P1Name + ".ref"))
                {

                    StreamReader sr;

                    sr = new StreamReader(Properties.Settings.Default.installationDirectory + "\\profiles\\" + Properties.Settings.Default.P1Name + ".ref");

                    txtNameP1.Text = sr.ReadLine();
                    cbxWeaponP1.Text = sr.ReadLine();

                    cbxHelmetP1.Text = sr.ReadLine();
                    cbxChestP1.Text = sr.ReadLine();
                    cbxShouldersP1.Text = sr.ReadLine();
                    cbxArmsP1.Text = sr.ReadLine();
                    cbxLegsP1.Text = sr.ReadLine();

                    string clrPrimary = sr.ReadLine();
                    string clrSecondary = sr.ReadLine();
                    string clrVisor = sr.ReadLine();
                    string clrLights = sr.ReadLine();
                    string clrHolo = sr.ReadLine();

                    txtPrimaryP1.BackColor = Color.FromArgb(red: Convert.ToInt32(clrPrimary.Substring(0, clrPrimary.IndexOf(" ", 0))),
                                                            green: Convert.ToInt32(clrPrimary.Substring(clrPrimary.IndexOf(" ", 0) + 1, clrPrimary.LastIndexOf(" ") - clrPrimary.IndexOf(" ", 0) - 1)),
                                                            blue: Convert.ToInt32(clrPrimary.Substring(clrPrimary.LastIndexOf(" ") + 1)));

                    txtSecondaryP1.BackColor = Color.FromArgb(red: Convert.ToInt32(clrSecondary.Substring(0, clrSecondary.IndexOf(" ", 0))),
                                                            green: Convert.ToInt32(clrSecondary.Substring(clrSecondary.IndexOf(" ", 0) + 1, clrSecondary.LastIndexOf(" ") - clrSecondary.IndexOf(" ", 0) - 1)),
                                                            blue: Convert.ToInt32(clrSecondary.Substring(clrSecondary.LastIndexOf(" ") + 1)));

                    txtVisorP1.BackColor = Color.FromArgb(red: Convert.ToInt32(clrVisor.Substring(0, clrVisor.IndexOf(" ", 0))),
                                                            green: Convert.ToInt32(clrVisor.Substring(clrVisor.IndexOf(" ", 0) + 1, clrVisor.LastIndexOf(" ") - clrVisor.IndexOf(" ", 0) - 1)),
                                                            blue: Convert.ToInt32(clrVisor.Substring(clrVisor.LastIndexOf(" ") + 1)));

                    txtLightsP1.BackColor = Color.FromArgb(red: Convert.ToInt32(clrLights.Substring(0, clrLights.IndexOf(" ", 0))),
                                                            green: Convert.ToInt32(clrLights.Substring(clrLights.IndexOf(" ", 0) + 1, clrLights.LastIndexOf(" ") - clrLights.IndexOf(" ", 0) - 1)),
                                                            blue: Convert.ToInt32(clrLights.Substring(clrLights.LastIndexOf(" ") + 1)));

                    txtHoloP1.BackColor = Color.FromArgb(red: Convert.ToInt32(clrHolo.Substring(0, clrHolo.IndexOf(" ", 0))),
                                                            green: Convert.ToInt32(clrHolo.Substring(clrHolo.IndexOf(" ", 0) + 1, clrHolo.LastIndexOf(" ") - clrHolo.IndexOf(" ", 0) - 1)),
                                                            blue: Convert.ToInt32(clrHolo.Substring(clrHolo.LastIndexOf(" ") + 1)));

                    lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 1, txtNameP1.Text);
                    Console.WriteLine("Successfully loaded " + txtNameP1.Text + "'s profile as P1.");

                    sr.Close();

                } else
                {

                    Console.WriteLine("Could not load " + Properties.Settings.Default.P1Name + "'s profile. The file(s) must have gone bye bye...");
                    MessageBox.Show("Could not load " + Properties.Settings.Default.P1Name + "'s profile. The file(s) must have gone bye bye...", "Halo Online Split Screen");

                }
                
            }

        }

        private void loadTraitsWithoutFileDialogP2()
        {

            if (Properties.Settings.Default.P2Name != "")
            {

                if (System.IO.File.Exists(Properties.Settings.Default.installationDirectory + "\\profiles\\" + Properties.Settings.Default.P2Name + ".ref"))
                {

                    StreamReader sr;

                    sr = new StreamReader(Properties.Settings.Default.installationDirectory + "\\profiles\\" + Properties.Settings.Default.P2Name + ".ref");

                    txtNameP2.Text = sr.ReadLine();
                    cbxWeaponP2.Text = sr.ReadLine();

                    cbxHelmetP2.Text = sr.ReadLine();
                    cbxChestP2.Text = sr.ReadLine();
                    cbxShouldersP2.Text = sr.ReadLine();
                    cbxArmsP2.Text = sr.ReadLine();
                    cbxLegsP2.Text = sr.ReadLine();

                    string clrPrimary = sr.ReadLine();
                    string clrSecondary = sr.ReadLine();
                    string clrVisor = sr.ReadLine();
                    string clrLights = sr.ReadLine();
                    string clrHolo = sr.ReadLine();

                    txtPrimaryP2.BackColor = Color.FromArgb(red: Convert.ToInt32(clrPrimary.Substring(0, clrPrimary.IndexOf(" ", 0))),
                                                            green: Convert.ToInt32(clrPrimary.Substring(clrPrimary.IndexOf(" ", 0) + 1, clrPrimary.LastIndexOf(" ") - clrPrimary.IndexOf(" ", 0) - 1)),
                                                            blue: Convert.ToInt32(clrPrimary.Substring(clrPrimary.LastIndexOf(" ") + 1)));

                    txtSecondaryP2.BackColor = Color.FromArgb(red: Convert.ToInt32(clrSecondary.Substring(0, clrSecondary.IndexOf(" ", 0))),
                                                            green: Convert.ToInt32(clrSecondary.Substring(clrSecondary.IndexOf(" ", 0) + 1, clrSecondary.LastIndexOf(" ") - clrSecondary.IndexOf(" ", 0) - 1)),
                                                            blue: Convert.ToInt32(clrSecondary.Substring(clrSecondary.LastIndexOf(" ") + 1)));

                    txtVisorP2.BackColor = Color.FromArgb(red: Convert.ToInt32(clrVisor.Substring(0, clrVisor.IndexOf(" ", 0))),
                                                            green: Convert.ToInt32(clrVisor.Substring(clrVisor.IndexOf(" ", 0) + 1, clrVisor.LastIndexOf(" ") - clrVisor.IndexOf(" ", 0) - 1)),
                                                            blue: Convert.ToInt32(clrVisor.Substring(clrVisor.LastIndexOf(" ") + 1)));

                    txtLightsP2.BackColor = Color.FromArgb(red: Convert.ToInt32(clrLights.Substring(0, clrLights.IndexOf(" ", 0))),
                                                            green: Convert.ToInt32(clrLights.Substring(clrLights.IndexOf(" ", 0) + 1, clrLights.LastIndexOf(" ") - clrLights.IndexOf(" ", 0) - 1)),
                                                            blue: Convert.ToInt32(clrLights.Substring(clrLights.LastIndexOf(" ") + 1)));

                    txtHoloP2.BackColor = Color.FromArgb(red: Convert.ToInt32(clrHolo.Substring(0, clrHolo.IndexOf(" ", 0))),
                                                            green: Convert.ToInt32(clrHolo.Substring(clrHolo.IndexOf(" ", 0) + 1, clrHolo.LastIndexOf(" ") - clrHolo.IndexOf(" ", 0) - 1)),
                                                            blue: Convert.ToInt32(clrHolo.Substring(clrHolo.LastIndexOf(" ") + 1)));

                    lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 2, txtNameP2.Text);
                    Console.WriteLine("Successfully loaded " + txtNameP2.Text + "'s profile as P2.");

                    sr.Close();

                }
                else
                {

                    Console.WriteLine("Could not load " + Properties.Settings.Default.P2Name + "'s profile. The file(s) must have gone bye bye...");
                    MessageBox.Show("Could not load " + Properties.Settings.Default.P2Name + "'s profile. The file(s) must have gone bye bye...", "Halo Online Split Screen");

                }

            }

        }

        private void loadTraitsWithoutFileDialogP3()
        {

            if (Properties.Settings.Default.P3Name != "")
            {

                if (System.IO.File.Exists(Properties.Settings.Default.installationDirectory + "\\profiles\\" + Properties.Settings.Default.P3Name + ".ref"))
                {

                    StreamReader sr;

                    sr = new StreamReader(Properties.Settings.Default.installationDirectory + "\\profiles\\" + Properties.Settings.Default.P3Name + ".ref");

                    txtNameP3.Text = sr.ReadLine();
                    cbxWeaponP3.Text = sr.ReadLine();

                    cbxHelmetP3.Text = sr.ReadLine();
                    cbxChestP3.Text = sr.ReadLine();
                    cbxShouldersP3.Text = sr.ReadLine();
                    cbxArmsP3.Text = sr.ReadLine();
                    cbxLegsP3.Text = sr.ReadLine();

                    string clrPrimary = sr.ReadLine();
                    string clrSecondary = sr.ReadLine();
                    string clrVisor = sr.ReadLine();
                    string clrLights = sr.ReadLine();
                    string clrHolo = sr.ReadLine();

                    txtPrimaryP3.BackColor = Color.FromArgb(red: Convert.ToInt32(clrPrimary.Substring(0, clrPrimary.IndexOf(" ", 0))),
                                                            green: Convert.ToInt32(clrPrimary.Substring(clrPrimary.IndexOf(" ", 0) + 1, clrPrimary.LastIndexOf(" ") - clrPrimary.IndexOf(" ", 0) - 1)),
                                                            blue: Convert.ToInt32(clrPrimary.Substring(clrPrimary.LastIndexOf(" ") + 1)));

                    txtSecondaryP3.BackColor = Color.FromArgb(red: Convert.ToInt32(clrSecondary.Substring(0, clrSecondary.IndexOf(" ", 0))),
                                                            green: Convert.ToInt32(clrSecondary.Substring(clrSecondary.IndexOf(" ", 0) + 1, clrSecondary.LastIndexOf(" ") - clrSecondary.IndexOf(" ", 0) - 1)),
                                                            blue: Convert.ToInt32(clrSecondary.Substring(clrSecondary.LastIndexOf(" ") + 1)));

                    txtVisorP3.BackColor = Color.FromArgb(red: Convert.ToInt32(clrVisor.Substring(0, clrVisor.IndexOf(" ", 0))),
                                                            green: Convert.ToInt32(clrVisor.Substring(clrVisor.IndexOf(" ", 0) + 1, clrVisor.LastIndexOf(" ") - clrVisor.IndexOf(" ", 0) - 1)),
                                                            blue: Convert.ToInt32(clrVisor.Substring(clrVisor.LastIndexOf(" ") + 1)));

                    txtLightsP3.BackColor = Color.FromArgb(red: Convert.ToInt32(clrLights.Substring(0, clrLights.IndexOf(" ", 0))),
                                                            green: Convert.ToInt32(clrLights.Substring(clrLights.IndexOf(" ", 0) + 1, clrLights.LastIndexOf(" ") - clrLights.IndexOf(" ", 0) - 1)),
                                                            blue: Convert.ToInt32(clrLights.Substring(clrLights.LastIndexOf(" ") + 1)));

                    txtHoloP3.BackColor = Color.FromArgb(red: Convert.ToInt32(clrHolo.Substring(0, clrHolo.IndexOf(" ", 0))),
                                                            green: Convert.ToInt32(clrHolo.Substring(clrHolo.IndexOf(" ", 0) + 1, clrHolo.LastIndexOf(" ") - clrHolo.IndexOf(" ", 0) - 1)),
                                                            blue: Convert.ToInt32(clrHolo.Substring(clrHolo.LastIndexOf(" ") + 1)));

                    lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 3, txtNameP3.Text);
                    Console.WriteLine("Successfully loaded " + txtNameP3.Text + "'s profile as P3.");

                    sr.Close();

                }
                else
                {

                    Console.WriteLine("Could not load " + Properties.Settings.Default.P3Name + "'s profile. The file(s) must have gone bye bye...");
                    MessageBox.Show("Could not load " + Properties.Settings.Default.P3Name + "'s profile. The file(s) must have gone bye bye...", "Halo Online Split Screen");

                }

            }

        }

        private void loadTraitsWithoutFileDialogP4()
        {

            if (Properties.Settings.Default.P4Name != "")
            {

                if (System.IO.File.Exists(Properties.Settings.Default.installationDirectory + "\\profiles\\" + Properties.Settings.Default.P4Name + ".ref"))
                {

                    StreamReader sr;

                    sr = new StreamReader(Properties.Settings.Default.installationDirectory + "\\profiles\\" + Properties.Settings.Default.P4Name + ".ref");

                    txtNameP4.Text = sr.ReadLine();
                    cbxWeaponP4.Text = sr.ReadLine();

                    cbxHelmetP4.Text = sr.ReadLine();
                    cbxChestP4.Text = sr.ReadLine();
                    cbxShouldersP4.Text = sr.ReadLine();
                    cbxArmsP4.Text = sr.ReadLine();
                    cbxLegsP4.Text = sr.ReadLine();

                    string clrPrimary = sr.ReadLine();
                    string clrSecondary = sr.ReadLine();
                    string clrVisor = sr.ReadLine();
                    string clrLights = sr.ReadLine();
                    string clrHolo = sr.ReadLine();

                    txtPrimaryP4.BackColor = Color.FromArgb(red: Convert.ToInt32(clrPrimary.Substring(0, clrPrimary.IndexOf(" ", 0))),
                                                            green: Convert.ToInt32(clrPrimary.Substring(clrPrimary.IndexOf(" ", 0) + 1, clrPrimary.LastIndexOf(" ") - clrPrimary.IndexOf(" ", 0) - 1)),
                                                            blue: Convert.ToInt32(clrPrimary.Substring(clrPrimary.LastIndexOf(" ") + 1)));

                    txtSecondaryP4.BackColor = Color.FromArgb(red: Convert.ToInt32(clrSecondary.Substring(0, clrSecondary.IndexOf(" ", 0))),
                                                            green: Convert.ToInt32(clrSecondary.Substring(clrSecondary.IndexOf(" ", 0) + 1, clrSecondary.LastIndexOf(" ") - clrSecondary.IndexOf(" ", 0) - 1)),
                                                            blue: Convert.ToInt32(clrSecondary.Substring(clrSecondary.LastIndexOf(" ") + 1)));

                    txtVisorP4.BackColor = Color.FromArgb(red: Convert.ToInt32(clrVisor.Substring(0, clrVisor.IndexOf(" ", 0))),
                                                            green: Convert.ToInt32(clrVisor.Substring(clrVisor.IndexOf(" ", 0) + 1, clrVisor.LastIndexOf(" ") - clrVisor.IndexOf(" ", 0) - 1)),
                                                            blue: Convert.ToInt32(clrVisor.Substring(clrVisor.LastIndexOf(" ") + 1)));

                    txtLightsP4.BackColor = Color.FromArgb(red: Convert.ToInt32(clrLights.Substring(0, clrLights.IndexOf(" ", 0))),
                                                            green: Convert.ToInt32(clrLights.Substring(clrLights.IndexOf(" ", 0) + 1, clrLights.LastIndexOf(" ") - clrLights.IndexOf(" ", 0) - 1)),
                                                            blue: Convert.ToInt32(clrLights.Substring(clrLights.LastIndexOf(" ") + 1)));

                    txtHoloP4.BackColor = Color.FromArgb(red: Convert.ToInt32(clrHolo.Substring(0, clrHolo.IndexOf(" ", 0))),
                                                            green: Convert.ToInt32(clrHolo.Substring(clrHolo.IndexOf(" ", 0) + 1, clrHolo.LastIndexOf(" ") - clrHolo.IndexOf(" ", 0) - 1)),
                                                            blue: Convert.ToInt32(clrHolo.Substring(clrHolo.LastIndexOf(" ") + 1)));

                    lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 4, txtNameP4.Text);
                    Console.WriteLine("Successfully loaded " + txtNameP4.Text + "'s profile as P4.");

                    sr.Close();

                }
                else
                {

                    Console.WriteLine("Could not load " + Properties.Settings.Default.P4Name + "'s profile. The file(s) must have gone bye bye...");
                    MessageBox.Show("Could not load " + Properties.Settings.Default.P4Name + "'s profile. The file(s) must have gone bye bye...", "Halo Online Split Screen");

                }

            }

        }

        private void loadTraitsP1()
        {

            OpenFileDialog selectProfile = new OpenFileDialog();
            selectProfile.Filter = "Reference Files (*.ref)|*.ref";
            selectProfile.Multiselect = false;
            selectProfile.Title = "Select .ref file to load";
            selectProfile.InitialDirectory = Properties.Settings.Default.installationDirectory + "\\profiles";
            StreamReader sr;

            if (selectProfile.CheckFileExists == true)
            {

                if (cbxArmsP1.Text == "" && cbxChestP1.Text == "" && cbxHelmetP1.Text == "" && cbxLegsP1.Text == "" && cbxShouldersP1.Text == "" && txtNameP1.Text == "" && cbxWeaponP1.Text == "")
                {
                    
                    if (selectProfile.ShowDialog() == DialogResult.OK)
                    {
                        
                        sr = new StreamReader(selectProfile.FileName);

                        txtNameP1.Text = sr.ReadLine();
                        cbxWeaponP1.Text = sr.ReadLine();

                        cbxHelmetP1.Text = sr.ReadLine();
                        cbxChestP1.Text = sr.ReadLine();
                        cbxShouldersP1.Text = sr.ReadLine();
                        cbxArmsP1.Text = sr.ReadLine();
                        cbxLegsP1.Text = sr.ReadLine();

                        string clrPrimary = sr.ReadLine();
                        string clrSecondary = sr.ReadLine();
                        string clrVisor = sr.ReadLine();
                        string clrLights = sr.ReadLine();
                        string clrHolo = sr.ReadLine();

                        Console.WriteLine("--clrPrimary--");
                        Console.WriteLine("red: " + clrPrimary.Substring(0, clrPrimary.IndexOf(" ", 0)));
                        Console.WriteLine("green: " + clrPrimary.Substring(clrPrimary.IndexOf(" ", 0) + 1, clrPrimary.LastIndexOf(" ") - clrPrimary.IndexOf(" ", 0) - 1));
                        Console.WriteLine("blue: " + clrPrimary.Substring(clrPrimary.LastIndexOf(" ") + 1));

                        Console.WriteLine("--clrSecondary--");
                        Console.WriteLine("red: " + clrSecondary.Substring(0, clrSecondary.IndexOf(" ", 0)));
                        Console.WriteLine("green: " + clrSecondary.Substring(clrSecondary.IndexOf(" ", 0) + 1, clrSecondary.LastIndexOf(" ") - clrSecondary.IndexOf(" ", 0) - 1));
                        Console.WriteLine("blue: " + clrSecondary.Substring(clrSecondary.LastIndexOf(" ") + 1));

                        Console.WriteLine("--clrVisor--");
                        Console.WriteLine("red: " + clrVisor.Substring(0, clrVisor.IndexOf(" ", 0)));
                        Console.WriteLine("green: " + clrVisor.Substring(clrVisor.IndexOf(" ", 0) + 1, clrVisor.LastIndexOf(" ") - clrVisor.IndexOf(" ", 0) - 1));
                        Console.WriteLine("blue: " + clrVisor.Substring(clrVisor.LastIndexOf(" ") + 1));
                        
                        Console.WriteLine("--clrLights--");
                        Console.WriteLine("red: " + clrLights.Substring(0, clrLights.IndexOf(" ", 0)));
                        Console.WriteLine("green: " + clrLights.Substring(clrLights.IndexOf(" ", 0) + 1, clrLights.LastIndexOf(" ") - clrLights.IndexOf(" ", 0) - 1));
                        Console.WriteLine("blue: " + clrLights.Substring(clrLights.LastIndexOf(" ") + 1));

                        Console.WriteLine("--clrHolo--");
                        Console.WriteLine("red: " + clrHolo.Substring(0, clrHolo.IndexOf(" ", 0)));
                        Console.WriteLine("green: " + clrHolo.Substring(clrHolo.IndexOf(" ", 0) + 1, clrHolo.LastIndexOf(" ") - clrHolo.IndexOf(" ", 0) - 1));
                        Console.WriteLine("blue: " + clrHolo.Substring(clrHolo.LastIndexOf(" ") + 1));

                        txtPrimaryP1.BackColor = Color.FromArgb(red: Convert.ToInt32(clrPrimary.Substring(0, clrPrimary.IndexOf(" ", 0))),
                                                                green: Convert.ToInt32(clrPrimary.Substring(clrPrimary.IndexOf(" ", 0) + 1, clrPrimary.LastIndexOf(" ") - clrPrimary.IndexOf(" ", 0) - 1)),
                                                                blue: Convert.ToInt32(clrPrimary.Substring(clrPrimary.LastIndexOf(" ") + 1)));

                        txtSecondaryP1.BackColor = Color.FromArgb(red: Convert.ToInt32(clrSecondary.Substring(0, clrSecondary.IndexOf(" ", 0))),
                                                                green: Convert.ToInt32(clrSecondary.Substring(clrSecondary.IndexOf(" ", 0) + 1, clrSecondary.LastIndexOf(" ") - clrSecondary.IndexOf(" ", 0) - 1)),
                                                                blue: Convert.ToInt32(clrSecondary.Substring(clrSecondary.LastIndexOf(" ") + 1)));

                        txtVisorP1.BackColor = Color.FromArgb(red: Convert.ToInt32(clrVisor.Substring(0, clrVisor.IndexOf(" ", 0))),
                                                                green: Convert.ToInt32(clrVisor.Substring(clrVisor.IndexOf(" ", 0) + 1, clrVisor.LastIndexOf(" ") - clrVisor.IndexOf(" ", 0) - 1)),
                                                                blue: Convert.ToInt32(clrVisor.Substring(clrVisor.LastIndexOf(" ") + 1)));

                        txtLightsP1.BackColor = Color.FromArgb(red: Convert.ToInt32(clrLights.Substring(0, clrLights.IndexOf(" ", 0))),
                                                                green: Convert.ToInt32(clrLights.Substring(clrLights.IndexOf(" ", 0) + 1, clrLights.LastIndexOf(" ") - clrLights.IndexOf(" ", 0) - 1)),
                                                                blue: Convert.ToInt32(clrLights.Substring(clrLights.LastIndexOf(" ") + 1)));

                        txtHoloP1.BackColor = Color.FromArgb(red: Convert.ToInt32(clrHolo.Substring(0, clrHolo.IndexOf(" ", 0))),
                                                                green: Convert.ToInt32(clrHolo.Substring(clrHolo.IndexOf(" ", 0) + 1, clrHolo.LastIndexOf(" ") - clrHolo.IndexOf(" ", 0) - 1)),
                                                                blue: Convert.ToInt32(clrHolo.Substring(clrHolo.LastIndexOf(" ") + 1)));
                        
                        lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 1, txtNameP1.Text);
                        Console.WriteLine("Successfully loaded " + txtNameP1.Text + "'s profile as P1.");
                        MessageBox.Show("Successfully loaded " + txtNameP1.Text + "'s profile as P1.", "Halo Online Split Screen");

                        sr.Close();

                    } else
                    {

                        Console.WriteLine("Did not load a selected profile.");
                        MessageBox.Show("Did not load a selected profile.", "Halo Online Split Screen");

                    }

                } else
                {

                    DialogResult overwrite = MessageBox.Show("Some if not all of P1's parameters have already been filled out. Are you sure you want to overwrite these with the profile of your choice?", "Halo Online Split Screen", MessageBoxButtons.YesNo);

                    if (overwrite == DialogResult.Yes)
                    {

                        if (selectProfile.ShowDialog() == DialogResult.OK)
                        {
                            
                            sr = new StreamReader(selectProfile.FileName);

                            txtNameP1.Text = sr.ReadLine();
                            cbxWeaponP1.Text = sr.ReadLine();

                            cbxHelmetP1.Text = sr.ReadLine();
                            cbxChestP1.Text = sr.ReadLine();
                            cbxShouldersP1.Text = sr.ReadLine();
                            cbxArmsP1.Text = sr.ReadLine();
                            cbxLegsP1.Text = sr.ReadLine();

                            string clrPrimary = sr.ReadLine();
                            string clrSecondary = sr.ReadLine();
                            string clrVisor = sr.ReadLine();
                            string clrLights = sr.ReadLine();
                            string clrHolo = sr.ReadLine();

                            Console.WriteLine("--clrPrimary--");
                            Console.WriteLine("red: " + clrPrimary.Substring(0, clrPrimary.IndexOf(" ", 0)));
                            Console.WriteLine("green: " + clrPrimary.Substring(clrPrimary.IndexOf(" ", 0) + 1, clrPrimary.LastIndexOf(" ") - clrPrimary.IndexOf(" ", 0) - 1));
                            Console.WriteLine("blue: " + clrPrimary.Substring(clrPrimary.LastIndexOf(" ") + 1));

                            Console.WriteLine("--clrSecondary--");
                            Console.WriteLine("red: " + clrSecondary.Substring(0, clrSecondary.IndexOf(" ", 0)));
                            Console.WriteLine("green: " + clrSecondary.Substring(clrSecondary.IndexOf(" ", 0) + 1, clrSecondary.LastIndexOf(" ") - clrSecondary.IndexOf(" ", 0) - 1));
                            Console.WriteLine("blue: " + clrSecondary.Substring(clrSecondary.LastIndexOf(" ") + 1));

                            Console.WriteLine("--clrVisor--");
                            Console.WriteLine("red: " + clrVisor.Substring(0, clrVisor.IndexOf(" ", 0)));
                            Console.WriteLine("green: " + clrVisor.Substring(clrVisor.IndexOf(" ", 0) + 1, clrVisor.LastIndexOf(" ") - clrVisor.IndexOf(" ", 0) - 1));
                            Console.WriteLine("blue: " + clrVisor.Substring(clrVisor.LastIndexOf(" ") + 1));

                            Console.WriteLine("--clrLights--");
                            Console.WriteLine("red: " + clrLights.Substring(0, clrLights.IndexOf(" ", 0)));
                            Console.WriteLine("green: " + clrLights.Substring(clrLights.IndexOf(" ", 0) + 1, clrLights.LastIndexOf(" ") - clrLights.IndexOf(" ", 0) - 1));
                            Console.WriteLine("blue: " + clrLights.Substring(clrLights.LastIndexOf(" ") + 1));

                            Console.WriteLine("--clrHolo--");
                            Console.WriteLine("red: " + clrHolo.Substring(0, clrHolo.IndexOf(" ", 0)));
                            Console.WriteLine("green: " + clrHolo.Substring(clrHolo.IndexOf(" ", 0) + 1, clrHolo.LastIndexOf(" ") - clrHolo.IndexOf(" ", 0) - 1));
                            Console.WriteLine("blue: " + clrHolo.Substring(clrHolo.LastIndexOf(" ") + 1));

                            txtPrimaryP1.BackColor = Color.FromArgb(red: Convert.ToInt32(clrPrimary.Substring(0, clrPrimary.IndexOf(" ", 0))),
                                                                    green: Convert.ToInt32(clrPrimary.Substring(clrPrimary.IndexOf(" ", 0) + 1, clrPrimary.LastIndexOf(" ") - clrPrimary.IndexOf(" ", 0) - 1)),
                                                                    blue: Convert.ToInt32(clrPrimary.Substring(clrPrimary.LastIndexOf(" ") + 1)));

                            txtSecondaryP1.BackColor = Color.FromArgb(red: Convert.ToInt32(clrSecondary.Substring(0, clrSecondary.IndexOf(" ", 0))),
                                                                    green: Convert.ToInt32(clrSecondary.Substring(clrSecondary.IndexOf(" ", 0) + 1, clrSecondary.LastIndexOf(" ") - clrSecondary.IndexOf(" ", 0) - 1)),
                                                                    blue: Convert.ToInt32(clrSecondary.Substring(clrSecondary.LastIndexOf(" ") + 1)));

                            txtVisorP1.BackColor = Color.FromArgb(red: Convert.ToInt32(clrVisor.Substring(0, clrVisor.IndexOf(" ", 0))),
                                                                    green: Convert.ToInt32(clrVisor.Substring(clrVisor.IndexOf(" ", 0) + 1, clrVisor.LastIndexOf(" ") - clrVisor.IndexOf(" ", 0) - 1)),
                                                                    blue: Convert.ToInt32(clrVisor.Substring(clrVisor.LastIndexOf(" ") + 1)));

                            txtLightsP1.BackColor = Color.FromArgb(red: Convert.ToInt32(clrLights.Substring(0, clrLights.IndexOf(" ", 0))),
                                                                    green: Convert.ToInt32(clrLights.Substring(clrLights.IndexOf(" ", 0) + 1, clrLights.LastIndexOf(" ") - clrLights.IndexOf(" ", 0) - 1)),
                                                                    blue: Convert.ToInt32(clrLights.Substring(clrLights.LastIndexOf(" ") + 1)));

                            txtHoloP1.BackColor = Color.FromArgb(red: Convert.ToInt32(clrHolo.Substring(0, clrHolo.IndexOf(" ", 0))),
                                                                    green: Convert.ToInt32(clrHolo.Substring(clrHolo.IndexOf(" ", 0) + 1, clrHolo.LastIndexOf(" ") - clrHolo.IndexOf(" ", 0) - 1)),
                                                                    blue: Convert.ToInt32(clrHolo.Substring(clrHolo.LastIndexOf(" ") + 1)));

                            lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 1, txtNameP1.Text);
                            Console.WriteLine("Successfully loaded " + txtNameP1.Text + "'s profile as P1.");
                            MessageBox.Show("Successfully loaded " + txtNameP1.Text + "'s profile as P1.", "Halo Online Split Screen");

                            sr.Close();

                        } else
                        {

                            Console.WriteLine("Did not load a selected profile.");
                            MessageBox.Show("Did not load a selected profile.", "Halo Online Split Screen");

                        }

                    } else
                    {

                        Console.WriteLine("Did not load a selected profile.");
                        MessageBox.Show("Did not load a selected profile.", "Halo Online Split Screen");

                    }

                }

            }

            selectProfile.Dispose();

        }

        private void loadTraitsP2()
        {

            OpenFileDialog selectProfile = new OpenFileDialog();
            selectProfile.Filter = "Reference Files (*.ref)|*.ref";
            selectProfile.Multiselect = false;
            selectProfile.Title = "Select .ref file to load";
            selectProfile.InitialDirectory = Properties.Settings.Default.installationDirectory + "\\profiles";
            StreamReader sr;

            if (selectProfile.CheckFileExists == true)
            {

                if (cbxArmsP2.Text == "" && cbxChestP2.Text == "" && cbxHelmetP2.Text == "" && cbxLegsP2.Text == "" && cbxShouldersP2.Text == "" && txtNameP2.Text == "" && cbxWeaponP2.Text == "")
                {

                    if (selectProfile.ShowDialog() == DialogResult.OK)
                    {

                        sr = new StreamReader(selectProfile.FileName);

                        txtNameP2.Text = sr.ReadLine();
                        cbxWeaponP2.Text = sr.ReadLine();

                        cbxHelmetP2.Text = sr.ReadLine();
                        cbxChestP2.Text = sr.ReadLine();
                        cbxShouldersP2.Text = sr.ReadLine();
                        cbxArmsP2.Text = sr.ReadLine();
                        cbxLegsP2.Text = sr.ReadLine();

                        string clrPrimary = sr.ReadLine();
                        string clrSecondary = sr.ReadLine();
                        string clrVisor = sr.ReadLine();
                        string clrLights = sr.ReadLine();
                        string clrHolo = sr.ReadLine();

                        Console.WriteLine("--clrPrimary--");
                        Console.WriteLine("red: " + clrPrimary.Substring(0, clrPrimary.IndexOf(" ", 0)));
                        Console.WriteLine("green: " + clrPrimary.Substring(clrPrimary.IndexOf(" ", 0) + 1, clrPrimary.LastIndexOf(" ") - clrPrimary.IndexOf(" ", 0) - 1));
                        Console.WriteLine("blue: " + clrPrimary.Substring(clrPrimary.LastIndexOf(" ") + 1));

                        Console.WriteLine("--clrSecondary--");
                        Console.WriteLine("red: " + clrSecondary.Substring(0, clrSecondary.IndexOf(" ", 0)));
                        Console.WriteLine("green: " + clrSecondary.Substring(clrSecondary.IndexOf(" ", 0) + 1, clrSecondary.LastIndexOf(" ") - clrSecondary.IndexOf(" ", 0) - 1));
                        Console.WriteLine("blue: " + clrSecondary.Substring(clrSecondary.LastIndexOf(" ") + 1));

                        Console.WriteLine("--clrVisor--");
                        Console.WriteLine("red: " + clrVisor.Substring(0, clrVisor.IndexOf(" ", 0)));
                        Console.WriteLine("green: " + clrVisor.Substring(clrVisor.IndexOf(" ", 0) + 1, clrVisor.LastIndexOf(" ") - clrVisor.IndexOf(" ", 0) - 1));
                        Console.WriteLine("blue: " + clrVisor.Substring(clrVisor.LastIndexOf(" ") + 1));

                        Console.WriteLine("--clrLights--");
                        Console.WriteLine("red: " + clrLights.Substring(0, clrLights.IndexOf(" ", 0)));
                        Console.WriteLine("green: " + clrLights.Substring(clrLights.IndexOf(" ", 0) + 1, clrLights.LastIndexOf(" ") - clrLights.IndexOf(" ", 0) - 1));
                        Console.WriteLine("blue: " + clrLights.Substring(clrLights.LastIndexOf(" ") + 1));

                        Console.WriteLine("--clrHolo--");
                        Console.WriteLine("red: " + clrHolo.Substring(0, clrHolo.IndexOf(" ", 0)));
                        Console.WriteLine("green: " + clrHolo.Substring(clrHolo.IndexOf(" ", 0) + 1, clrHolo.LastIndexOf(" ") - clrHolo.IndexOf(" ", 0) - 1));
                        Console.WriteLine("blue: " + clrHolo.Substring(clrHolo.LastIndexOf(" ") + 1));

                        txtPrimaryP2.BackColor = Color.FromArgb(red: Convert.ToInt32(clrPrimary.Substring(0, clrPrimary.IndexOf(" ", 0))),
                                                                green: Convert.ToInt32(clrPrimary.Substring(clrPrimary.IndexOf(" ", 0) + 1, clrPrimary.LastIndexOf(" ") - clrPrimary.IndexOf(" ", 0) - 1)),
                                                                blue: Convert.ToInt32(clrPrimary.Substring(clrPrimary.LastIndexOf(" ") + 1)));

                        txtSecondaryP2.BackColor = Color.FromArgb(red: Convert.ToInt32(clrSecondary.Substring(0, clrSecondary.IndexOf(" ", 0))),
                                                                green: Convert.ToInt32(clrSecondary.Substring(clrSecondary.IndexOf(" ", 0) + 1, clrSecondary.LastIndexOf(" ") - clrSecondary.IndexOf(" ", 0) - 1)),
                                                                blue: Convert.ToInt32(clrSecondary.Substring(clrSecondary.LastIndexOf(" ") + 1)));

                        txtVisorP2.BackColor = Color.FromArgb(red: Convert.ToInt32(clrVisor.Substring(0, clrVisor.IndexOf(" ", 0))),
                                                                green: Convert.ToInt32(clrVisor.Substring(clrVisor.IndexOf(" ", 0) + 1, clrVisor.LastIndexOf(" ") - clrVisor.IndexOf(" ", 0) - 1)),
                                                                blue: Convert.ToInt32(clrVisor.Substring(clrVisor.LastIndexOf(" ") + 1)));

                        txtLightsP2.BackColor = Color.FromArgb(red: Convert.ToInt32(clrLights.Substring(0, clrLights.IndexOf(" ", 0))),
                                                                green: Convert.ToInt32(clrLights.Substring(clrLights.IndexOf(" ", 0) + 1, clrLights.LastIndexOf(" ") - clrLights.IndexOf(" ", 0) - 1)),
                                                                blue: Convert.ToInt32(clrLights.Substring(clrLights.LastIndexOf(" ") + 1)));

                        txtHoloP2.BackColor = Color.FromArgb(red: Convert.ToInt32(clrHolo.Substring(0, clrHolo.IndexOf(" ", 0))),
                                                                green: Convert.ToInt32(clrHolo.Substring(clrHolo.IndexOf(" ", 0) + 1, clrHolo.LastIndexOf(" ") - clrHolo.IndexOf(" ", 0) - 1)),
                                                                blue: Convert.ToInt32(clrHolo.Substring(clrHolo.LastIndexOf(" ") + 1)));

                        lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 2, txtNameP2.Text);
                        Console.WriteLine("Successfully loaded " + txtNameP2.Text + "'s profile as P2.");
                        MessageBox.Show("Successfully loaded " + txtNameP2.Text + "'s profile as P2.", "Halo Online Split Screen");

                        sr.Close();

                    }
                    else
                    {

                        Console.WriteLine("Did not load a selected profile.");
                        MessageBox.Show("Did not load a selected profile.", "Halo Online Split Screen");

                    }

                }
                else
                {

                    DialogResult overwrite = MessageBox.Show("Some if not all of P2's parameters have already been filled out. Are you sure you want to overwrite these with the profile of your choice?", "Halo Online Split Screen", MessageBoxButtons.YesNo);

                    if (overwrite == DialogResult.Yes)
                    {

                        if (selectProfile.ShowDialog() == DialogResult.OK)
                        {

                            sr = new StreamReader(selectProfile.FileName);

                            txtNameP2.Text = sr.ReadLine();
                            cbxWeaponP2.Text = sr.ReadLine();

                            cbxHelmetP2.Text = sr.ReadLine();
                            cbxChestP2.Text = sr.ReadLine();
                            cbxShouldersP2.Text = sr.ReadLine();
                            cbxArmsP2.Text = sr.ReadLine();
                            cbxLegsP2.Text = sr.ReadLine();

                            string clrPrimary = sr.ReadLine();
                            string clrSecondary = sr.ReadLine();
                            string clrVisor = sr.ReadLine();
                            string clrLights = sr.ReadLine();
                            string clrHolo = sr.ReadLine();

                            Console.WriteLine("--clrPrimary--");
                            Console.WriteLine("red: " + clrPrimary.Substring(0, clrPrimary.IndexOf(" ", 0)));
                            Console.WriteLine("green: " + clrPrimary.Substring(clrPrimary.IndexOf(" ", 0) + 1, clrPrimary.LastIndexOf(" ") - clrPrimary.IndexOf(" ", 0) - 1));
                            Console.WriteLine("blue: " + clrPrimary.Substring(clrPrimary.LastIndexOf(" ") + 1));

                            Console.WriteLine("--clrSecondary--");
                            Console.WriteLine("red: " + clrSecondary.Substring(0, clrSecondary.IndexOf(" ", 0)));
                            Console.WriteLine("green: " + clrSecondary.Substring(clrSecondary.IndexOf(" ", 0) + 1, clrSecondary.LastIndexOf(" ") - clrSecondary.IndexOf(" ", 0) - 1));
                            Console.WriteLine("blue: " + clrSecondary.Substring(clrSecondary.LastIndexOf(" ") + 1));

                            Console.WriteLine("--clrVisor--");
                            Console.WriteLine("red: " + clrVisor.Substring(0, clrVisor.IndexOf(" ", 0)));
                            Console.WriteLine("green: " + clrVisor.Substring(clrVisor.IndexOf(" ", 0) + 1, clrVisor.LastIndexOf(" ") - clrVisor.IndexOf(" ", 0) - 1));
                            Console.WriteLine("blue: " + clrVisor.Substring(clrVisor.LastIndexOf(" ") + 1));

                            Console.WriteLine("--clrLights--");
                            Console.WriteLine("red: " + clrLights.Substring(0, clrLights.IndexOf(" ", 0)));
                            Console.WriteLine("green: " + clrLights.Substring(clrLights.IndexOf(" ", 0) + 1, clrLights.LastIndexOf(" ") - clrLights.IndexOf(" ", 0) - 1));
                            Console.WriteLine("blue: " + clrLights.Substring(clrLights.LastIndexOf(" ") + 1));

                            Console.WriteLine("--clrHolo--");
                            Console.WriteLine("red: " + clrHolo.Substring(0, clrHolo.IndexOf(" ", 0)));
                            Console.WriteLine("green: " + clrHolo.Substring(clrHolo.IndexOf(" ", 0) + 1, clrHolo.LastIndexOf(" ") - clrHolo.IndexOf(" ", 0) - 1));
                            Console.WriteLine("blue: " + clrHolo.Substring(clrHolo.LastIndexOf(" ") + 1));

                            txtPrimaryP2.BackColor = Color.FromArgb(red: Convert.ToInt32(clrPrimary.Substring(0, clrPrimary.IndexOf(" ", 0))),
                                                                    green: Convert.ToInt32(clrPrimary.Substring(clrPrimary.IndexOf(" ", 0) + 1, clrPrimary.LastIndexOf(" ") - clrPrimary.IndexOf(" ", 0) - 1)),
                                                                    blue: Convert.ToInt32(clrPrimary.Substring(clrPrimary.LastIndexOf(" ") + 1)));

                            txtSecondaryP2.BackColor = Color.FromArgb(red: Convert.ToInt32(clrSecondary.Substring(0, clrSecondary.IndexOf(" ", 0))),
                                                                    green: Convert.ToInt32(clrSecondary.Substring(clrSecondary.IndexOf(" ", 0) + 1, clrSecondary.LastIndexOf(" ") - clrSecondary.IndexOf(" ", 0) - 1)),
                                                                    blue: Convert.ToInt32(clrSecondary.Substring(clrSecondary.LastIndexOf(" ") + 1)));

                            txtVisorP2.BackColor = Color.FromArgb(red: Convert.ToInt32(clrVisor.Substring(0, clrVisor.IndexOf(" ", 0))),
                                                                    green: Convert.ToInt32(clrVisor.Substring(clrVisor.IndexOf(" ", 0) + 1, clrVisor.LastIndexOf(" ") - clrVisor.IndexOf(" ", 0) - 1)),
                                                                    blue: Convert.ToInt32(clrVisor.Substring(clrVisor.LastIndexOf(" ") + 1)));

                            txtLightsP2.BackColor = Color.FromArgb(red: Convert.ToInt32(clrLights.Substring(0, clrLights.IndexOf(" ", 0))),
                                                                    green: Convert.ToInt32(clrLights.Substring(clrLights.IndexOf(" ", 0) + 1, clrLights.LastIndexOf(" ") - clrLights.IndexOf(" ", 0) - 1)),
                                                                    blue: Convert.ToInt32(clrLights.Substring(clrLights.LastIndexOf(" ") + 1)));

                            txtHoloP2.BackColor = Color.FromArgb(red: Convert.ToInt32(clrHolo.Substring(0, clrHolo.IndexOf(" ", 0))),
                                                                    green: Convert.ToInt32(clrHolo.Substring(clrHolo.IndexOf(" ", 0) + 1, clrHolo.LastIndexOf(" ") - clrHolo.IndexOf(" ", 0) - 1)),
                                                                    blue: Convert.ToInt32(clrHolo.Substring(clrHolo.LastIndexOf(" ") + 1)));

                            lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 2, txtNameP2.Text);
                            Console.WriteLine("Successfully loaded " + txtNameP2.Text + "'s profile as P2.");
                            MessageBox.Show("Successfully loaded " + txtNameP2.Text + "'s profile as P2.", "Halo Online Split Screen");

                            sr.Close();

                        }
                        else
                        {

                            Console.WriteLine("Did not load a selected profile.");
                            MessageBox.Show("Did not load a selected profile.", "Halo Online Split Screen");

                        }

                    }
                    else
                    {

                        Console.WriteLine("Did not load a selected profile.");
                        MessageBox.Show("Did not load a selected profile.", "Halo Online Split Screen");

                    }

                }

            }

            selectProfile.Dispose();

        }

        private void loadTraitsP3()
        {

            OpenFileDialog selectProfile = new OpenFileDialog();
            selectProfile.Filter = "Reference Files (*.ref)|*.ref";
            selectProfile.Multiselect = false;
            selectProfile.Title = "Select .ref file to load";
            selectProfile.InitialDirectory = Properties.Settings.Default.installationDirectory + "\\profiles";
            StreamReader sr;

            if (selectProfile.CheckFileExists == true)
            {

                if (cbxArmsP3.Text == "" && cbxChestP3.Text == "" && cbxHelmetP3.Text == "" && cbxLegsP3.Text == "" && cbxShouldersP3.Text == "" && txtNameP3.Text == "" && cbxWeaponP3.Text == "")
                {

                    if (selectProfile.ShowDialog() == DialogResult.OK)
                    {

                        sr = new StreamReader(selectProfile.FileName);

                        txtNameP3.Text = sr.ReadLine();
                        cbxWeaponP3.Text = sr.ReadLine();

                        cbxHelmetP3.Text = sr.ReadLine();
                        cbxChestP3.Text = sr.ReadLine();
                        cbxShouldersP3.Text = sr.ReadLine();
                        cbxArmsP3.Text = sr.ReadLine();
                        cbxLegsP3.Text = sr.ReadLine();

                        string clrPrimary = sr.ReadLine();
                        string clrSecondary = sr.ReadLine();
                        string clrVisor = sr.ReadLine();
                        string clrLights = sr.ReadLine();
                        string clrHolo = sr.ReadLine();

                        Console.WriteLine("--clrPrimary--");
                        Console.WriteLine("red: " + clrPrimary.Substring(0, clrPrimary.IndexOf(" ", 0)));
                        Console.WriteLine("green: " + clrPrimary.Substring(clrPrimary.IndexOf(" ", 0) + 1, clrPrimary.LastIndexOf(" ") - clrPrimary.IndexOf(" ", 0) - 1));
                        Console.WriteLine("blue: " + clrPrimary.Substring(clrPrimary.LastIndexOf(" ") + 1));

                        Console.WriteLine("--clrSecondary--");
                        Console.WriteLine("red: " + clrSecondary.Substring(0, clrSecondary.IndexOf(" ", 0)));
                        Console.WriteLine("green: " + clrSecondary.Substring(clrSecondary.IndexOf(" ", 0) + 1, clrSecondary.LastIndexOf(" ") - clrSecondary.IndexOf(" ", 0) - 1));
                        Console.WriteLine("blue: " + clrSecondary.Substring(clrSecondary.LastIndexOf(" ") + 1));

                        Console.WriteLine("--clrVisor--");
                        Console.WriteLine("red: " + clrVisor.Substring(0, clrVisor.IndexOf(" ", 0)));
                        Console.WriteLine("green: " + clrVisor.Substring(clrVisor.IndexOf(" ", 0) + 1, clrVisor.LastIndexOf(" ") - clrVisor.IndexOf(" ", 0) - 1));
                        Console.WriteLine("blue: " + clrVisor.Substring(clrVisor.LastIndexOf(" ") + 1));

                        Console.WriteLine("--clrLights--");
                        Console.WriteLine("red: " + clrLights.Substring(0, clrLights.IndexOf(" ", 0)));
                        Console.WriteLine("green: " + clrLights.Substring(clrLights.IndexOf(" ", 0) + 1, clrLights.LastIndexOf(" ") - clrLights.IndexOf(" ", 0) - 1));
                        Console.WriteLine("blue: " + clrLights.Substring(clrLights.LastIndexOf(" ") + 1));

                        Console.WriteLine("--clrHolo--");
                        Console.WriteLine("red: " + clrHolo.Substring(0, clrHolo.IndexOf(" ", 0)));
                        Console.WriteLine("green: " + clrHolo.Substring(clrHolo.IndexOf(" ", 0) + 1, clrHolo.LastIndexOf(" ") - clrHolo.IndexOf(" ", 0) - 1));
                        Console.WriteLine("blue: " + clrHolo.Substring(clrHolo.LastIndexOf(" ") + 1));

                        txtPrimaryP3.BackColor = Color.FromArgb(red: Convert.ToInt32(clrPrimary.Substring(0, clrPrimary.IndexOf(" ", 0))),
                                                                green: Convert.ToInt32(clrPrimary.Substring(clrPrimary.IndexOf(" ", 0) + 1, clrPrimary.LastIndexOf(" ") - clrPrimary.IndexOf(" ", 0) - 1)),
                                                                blue: Convert.ToInt32(clrPrimary.Substring(clrPrimary.LastIndexOf(" ") + 1)));

                        txtSecondaryP3.BackColor = Color.FromArgb(red: Convert.ToInt32(clrSecondary.Substring(0, clrSecondary.IndexOf(" ", 0))),
                                                                green: Convert.ToInt32(clrSecondary.Substring(clrSecondary.IndexOf(" ", 0) + 1, clrSecondary.LastIndexOf(" ") - clrSecondary.IndexOf(" ", 0) - 1)),
                                                                blue: Convert.ToInt32(clrSecondary.Substring(clrSecondary.LastIndexOf(" ") + 1)));

                        txtVisorP3.BackColor = Color.FromArgb(red: Convert.ToInt32(clrVisor.Substring(0, clrVisor.IndexOf(" ", 0))),
                                                                green: Convert.ToInt32(clrVisor.Substring(clrVisor.IndexOf(" ", 0) + 1, clrVisor.LastIndexOf(" ") - clrVisor.IndexOf(" ", 0) - 1)),
                                                                blue: Convert.ToInt32(clrVisor.Substring(clrVisor.LastIndexOf(" ") + 1)));

                        txtLightsP3.BackColor = Color.FromArgb(red: Convert.ToInt32(clrLights.Substring(0, clrLights.IndexOf(" ", 0))),
                                                                green: Convert.ToInt32(clrLights.Substring(clrLights.IndexOf(" ", 0) + 1, clrLights.LastIndexOf(" ") - clrLights.IndexOf(" ", 0) - 1)),
                                                                blue: Convert.ToInt32(clrLights.Substring(clrLights.LastIndexOf(" ") + 1)));

                        txtHoloP3.BackColor = Color.FromArgb(red: Convert.ToInt32(clrHolo.Substring(0, clrHolo.IndexOf(" ", 0))),
                                                                green: Convert.ToInt32(clrHolo.Substring(clrHolo.IndexOf(" ", 0) + 1, clrHolo.LastIndexOf(" ") - clrHolo.IndexOf(" ", 0) - 1)),
                                                                blue: Convert.ToInt32(clrHolo.Substring(clrHolo.LastIndexOf(" ") + 1)));

                        lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 3, txtNameP3.Text);
                        Console.WriteLine("Successfully loaded " + txtNameP3.Text + "'s profile as P3.");
                        MessageBox.Show("Successfully loaded " + txtNameP3.Text + "'s profile as P3.", "Halo Online Split Screen");

                        sr.Close();

                    }
                    else
                    {

                        Console.WriteLine("Did not load a selected profile.");
                        MessageBox.Show("Did not load a selected profile.", "Halo Online Split Screen");

                    }

                }
                else
                {

                    DialogResult overwrite = MessageBox.Show("Some if not all of P3's parameters have already been filled out. Are you sure you want to overwrite these with the profile of your choice?", "Halo Online Split Screen", MessageBoxButtons.YesNo);

                    if (overwrite == DialogResult.Yes)
                    {

                        if (selectProfile.ShowDialog() == DialogResult.OK)
                        {

                            sr = new StreamReader(selectProfile.FileName);

                            txtNameP3.Text = sr.ReadLine();
                            cbxWeaponP3.Text = sr.ReadLine();

                            cbxHelmetP3.Text = sr.ReadLine();
                            cbxChestP3.Text = sr.ReadLine();
                            cbxShouldersP3.Text = sr.ReadLine();
                            cbxArmsP3.Text = sr.ReadLine();
                            cbxLegsP3.Text = sr.ReadLine();

                            string clrPrimary = sr.ReadLine();
                            string clrSecondary = sr.ReadLine();
                            string clrVisor = sr.ReadLine();
                            string clrLights = sr.ReadLine();
                            string clrHolo = sr.ReadLine();

                            Console.WriteLine("--clrPrimary--");
                            Console.WriteLine("red: " + clrPrimary.Substring(0, clrPrimary.IndexOf(" ", 0)));
                            Console.WriteLine("green: " + clrPrimary.Substring(clrPrimary.IndexOf(" ", 0) + 1, clrPrimary.LastIndexOf(" ") - clrPrimary.IndexOf(" ", 0) - 1));
                            Console.WriteLine("blue: " + clrPrimary.Substring(clrPrimary.LastIndexOf(" ") + 1));

                            Console.WriteLine("--clrSecondary--");
                            Console.WriteLine("red: " + clrSecondary.Substring(0, clrSecondary.IndexOf(" ", 0)));
                            Console.WriteLine("green: " + clrSecondary.Substring(clrSecondary.IndexOf(" ", 0) + 1, clrSecondary.LastIndexOf(" ") - clrSecondary.IndexOf(" ", 0) - 1));
                            Console.WriteLine("blue: " + clrSecondary.Substring(clrSecondary.LastIndexOf(" ") + 1));

                            Console.WriteLine("--clrVisor--");
                            Console.WriteLine("red: " + clrVisor.Substring(0, clrVisor.IndexOf(" ", 0)));
                            Console.WriteLine("green: " + clrVisor.Substring(clrVisor.IndexOf(" ", 0) + 1, clrVisor.LastIndexOf(" ") - clrVisor.IndexOf(" ", 0) - 1));
                            Console.WriteLine("blue: " + clrVisor.Substring(clrVisor.LastIndexOf(" ") + 1));

                            Console.WriteLine("--clrLights--");
                            Console.WriteLine("red: " + clrLights.Substring(0, clrLights.IndexOf(" ", 0)));
                            Console.WriteLine("green: " + clrLights.Substring(clrLights.IndexOf(" ", 0) + 1, clrLights.LastIndexOf(" ") - clrLights.IndexOf(" ", 0) - 1));
                            Console.WriteLine("blue: " + clrLights.Substring(clrLights.LastIndexOf(" ") + 1));

                            Console.WriteLine("--clrHolo--");
                            Console.WriteLine("red: " + clrHolo.Substring(0, clrHolo.IndexOf(" ", 0)));
                            Console.WriteLine("green: " + clrHolo.Substring(clrHolo.IndexOf(" ", 0) + 1, clrHolo.LastIndexOf(" ") - clrHolo.IndexOf(" ", 0) - 1));
                            Console.WriteLine("blue: " + clrHolo.Substring(clrHolo.LastIndexOf(" ") + 1));

                            txtPrimaryP3.BackColor = Color.FromArgb(red: Convert.ToInt32(clrPrimary.Substring(0, clrPrimary.IndexOf(" ", 0))),
                                                                    green: Convert.ToInt32(clrPrimary.Substring(clrPrimary.IndexOf(" ", 0) + 1, clrPrimary.LastIndexOf(" ") - clrPrimary.IndexOf(" ", 0) - 1)),
                                                                    blue: Convert.ToInt32(clrPrimary.Substring(clrPrimary.LastIndexOf(" ") + 1)));

                            txtSecondaryP3.BackColor = Color.FromArgb(red: Convert.ToInt32(clrSecondary.Substring(0, clrSecondary.IndexOf(" ", 0))),
                                                                    green: Convert.ToInt32(clrSecondary.Substring(clrSecondary.IndexOf(" ", 0) + 1, clrSecondary.LastIndexOf(" ") - clrSecondary.IndexOf(" ", 0) - 1)),
                                                                    blue: Convert.ToInt32(clrSecondary.Substring(clrSecondary.LastIndexOf(" ") + 1)));

                            txtVisorP3.BackColor = Color.FromArgb(red: Convert.ToInt32(clrVisor.Substring(0, clrVisor.IndexOf(" ", 0))),
                                                                    green: Convert.ToInt32(clrVisor.Substring(clrVisor.IndexOf(" ", 0) + 1, clrVisor.LastIndexOf(" ") - clrVisor.IndexOf(" ", 0) - 1)),
                                                                    blue: Convert.ToInt32(clrVisor.Substring(clrVisor.LastIndexOf(" ") + 1)));

                            txtLightsP3.BackColor = Color.FromArgb(red: Convert.ToInt32(clrLights.Substring(0, clrLights.IndexOf(" ", 0))),
                                                                    green: Convert.ToInt32(clrLights.Substring(clrLights.IndexOf(" ", 0) + 1, clrLights.LastIndexOf(" ") - clrLights.IndexOf(" ", 0) - 1)),
                                                                    blue: Convert.ToInt32(clrLights.Substring(clrLights.LastIndexOf(" ") + 1)));

                            txtHoloP3.BackColor = Color.FromArgb(red: Convert.ToInt32(clrHolo.Substring(0, clrHolo.IndexOf(" ", 0))),
                                                                    green: Convert.ToInt32(clrHolo.Substring(clrHolo.IndexOf(" ", 0) + 1, clrHolo.LastIndexOf(" ") - clrHolo.IndexOf(" ", 0) - 1)),
                                                                    blue: Convert.ToInt32(clrHolo.Substring(clrHolo.LastIndexOf(" ") + 1)));

                            lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 3, txtNameP3.Text);
                            Console.WriteLine("Successfully loaded " + txtNameP3.Text + "'s profile as P3.");
                            MessageBox.Show("Successfully loaded " + txtNameP3.Text + "'s profile as P3.", "Halo Online Split Screen");

                            sr.Close();

                        }
                        else
                        {

                            Console.WriteLine("Did not load a selected profile.");
                            MessageBox.Show("Did not load a selected profile.", "Halo Online Split Screen");

                        }

                    }
                    else
                    {

                        Console.WriteLine("Did not load a selected profile.");
                        MessageBox.Show("Did not load a selected profile.", "Halo Online Split Screen");

                    }

                }

            }

            selectProfile.Dispose();

        }

        private void loadTraitsP4()
        {

            OpenFileDialog selectProfile = new OpenFileDialog();
            selectProfile.Filter = "Reference Files (*.ref)|*.ref";
            selectProfile.Multiselect = false;
            selectProfile.Title = "Select .ref file to load";
            selectProfile.InitialDirectory = Properties.Settings.Default.installationDirectory + "\\profiles";
            StreamReader sr;

            if (selectProfile.CheckFileExists == true)
            {

                if (cbxArmsP4.Text == "" && cbxChestP4.Text == "" && cbxHelmetP4.Text == "" && cbxLegsP4.Text == "" && cbxShouldersP4.Text == "" && txtNameP4.Text == "" && cbxWeaponP4.Text == "")
                {

                    if (selectProfile.ShowDialog() == DialogResult.OK)
                    {

                        sr = new StreamReader(selectProfile.FileName);

                        txtNameP4.Text = sr.ReadLine();
                        cbxWeaponP4.Text = sr.ReadLine();

                        cbxHelmetP4.Text = sr.ReadLine();
                        cbxChestP4.Text = sr.ReadLine();
                        cbxShouldersP4.Text = sr.ReadLine();
                        cbxArmsP4.Text = sr.ReadLine();
                        cbxLegsP4.Text = sr.ReadLine();

                        string clrPrimary = sr.ReadLine();
                        string clrSecondary = sr.ReadLine();
                        string clrVisor = sr.ReadLine();
                        string clrLights = sr.ReadLine();
                        string clrHolo = sr.ReadLine();

                        Console.WriteLine("--clrPrimary--");
                        Console.WriteLine("red: " + clrPrimary.Substring(0, clrPrimary.IndexOf(" ", 0)));
                        Console.WriteLine("green: " + clrPrimary.Substring(clrPrimary.IndexOf(" ", 0) + 1, clrPrimary.LastIndexOf(" ") - clrPrimary.IndexOf(" ", 0) - 1));
                        Console.WriteLine("blue: " + clrPrimary.Substring(clrPrimary.LastIndexOf(" ") + 1));

                        Console.WriteLine("--clrSecondary--");
                        Console.WriteLine("red: " + clrSecondary.Substring(0, clrSecondary.IndexOf(" ", 0)));
                        Console.WriteLine("green: " + clrSecondary.Substring(clrSecondary.IndexOf(" ", 0) + 1, clrSecondary.LastIndexOf(" ") - clrSecondary.IndexOf(" ", 0) - 1));
                        Console.WriteLine("blue: " + clrSecondary.Substring(clrSecondary.LastIndexOf(" ") + 1));

                        Console.WriteLine("--clrVisor--");
                        Console.WriteLine("red: " + clrVisor.Substring(0, clrVisor.IndexOf(" ", 0)));
                        Console.WriteLine("green: " + clrVisor.Substring(clrVisor.IndexOf(" ", 0) + 1, clrVisor.LastIndexOf(" ") - clrVisor.IndexOf(" ", 0) - 1));
                        Console.WriteLine("blue: " + clrVisor.Substring(clrVisor.LastIndexOf(" ") + 1));

                        Console.WriteLine("--clrLights--");
                        Console.WriteLine("red: " + clrLights.Substring(0, clrLights.IndexOf(" ", 0)));
                        Console.WriteLine("green: " + clrLights.Substring(clrLights.IndexOf(" ", 0) + 1, clrLights.LastIndexOf(" ") - clrLights.IndexOf(" ", 0) - 1));
                        Console.WriteLine("blue: " + clrLights.Substring(clrLights.LastIndexOf(" ") + 1));

                        Console.WriteLine("--clrHolo--");
                        Console.WriteLine("red: " + clrHolo.Substring(0, clrHolo.IndexOf(" ", 0)));
                        Console.WriteLine("green: " + clrHolo.Substring(clrHolo.IndexOf(" ", 0) + 1, clrHolo.LastIndexOf(" ") - clrHolo.IndexOf(" ", 0) - 1));
                        Console.WriteLine("blue: " + clrHolo.Substring(clrHolo.LastIndexOf(" ") + 1));

                        txtPrimaryP4.BackColor = Color.FromArgb(red: Convert.ToInt32(clrPrimary.Substring(0, clrPrimary.IndexOf(" ", 0))),
                                                                green: Convert.ToInt32(clrPrimary.Substring(clrPrimary.IndexOf(" ", 0) + 1, clrPrimary.LastIndexOf(" ") - clrPrimary.IndexOf(" ", 0) - 1)),
                                                                blue: Convert.ToInt32(clrPrimary.Substring(clrPrimary.LastIndexOf(" ") + 1)));

                        txtSecondaryP4.BackColor = Color.FromArgb(red: Convert.ToInt32(clrSecondary.Substring(0, clrSecondary.IndexOf(" ", 0))),
                                                                green: Convert.ToInt32(clrSecondary.Substring(clrSecondary.IndexOf(" ", 0) + 1, clrSecondary.LastIndexOf(" ") - clrSecondary.IndexOf(" ", 0) - 1)),
                                                                blue: Convert.ToInt32(clrSecondary.Substring(clrSecondary.LastIndexOf(" ") + 1)));

                        txtVisorP4.BackColor = Color.FromArgb(red: Convert.ToInt32(clrVisor.Substring(0, clrVisor.IndexOf(" ", 0))),
                                                                green: Convert.ToInt32(clrVisor.Substring(clrVisor.IndexOf(" ", 0) + 1, clrVisor.LastIndexOf(" ") - clrVisor.IndexOf(" ", 0) - 1)),
                                                                blue: Convert.ToInt32(clrVisor.Substring(clrVisor.LastIndexOf(" ") + 1)));

                        txtLightsP4.BackColor = Color.FromArgb(red: Convert.ToInt32(clrLights.Substring(0, clrLights.IndexOf(" ", 0))),
                                                                green: Convert.ToInt32(clrLights.Substring(clrLights.IndexOf(" ", 0) + 1, clrLights.LastIndexOf(" ") - clrLights.IndexOf(" ", 0) - 1)),
                                                                blue: Convert.ToInt32(clrLights.Substring(clrLights.LastIndexOf(" ") + 1)));

                        txtHoloP4.BackColor = Color.FromArgb(red: Convert.ToInt32(clrHolo.Substring(0, clrHolo.IndexOf(" ", 0))),
                                                                green: Convert.ToInt32(clrHolo.Substring(clrHolo.IndexOf(" ", 0) + 1, clrHolo.LastIndexOf(" ") - clrHolo.IndexOf(" ", 0) - 1)),
                                                                blue: Convert.ToInt32(clrHolo.Substring(clrHolo.LastIndexOf(" ") + 1)));

                        lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 4, txtNameP4.Text);
                        Console.WriteLine("Successfully loaded " + txtNameP4.Text + "'s profile as P4.");
                        MessageBox.Show("Successfully loaded " + txtNameP4.Text + "'s profile as P4.", "Halo Online Split Screen");

                        sr.Close();

                    }
                    else
                    {

                        Console.WriteLine("Did not load a selected profile.");
                        MessageBox.Show("Did not load a selected profile.", "Halo Online Split Screen");

                    }

                }
                else
                {

                    DialogResult overwrite = MessageBox.Show("Some if not all of P4's parameters have already been filled out. Are you sure you want to overwrite these with the profile of your choice?", "Halo Online Split Screen", MessageBoxButtons.YesNo);

                    if (overwrite == DialogResult.Yes)
                    {

                        if (selectProfile.ShowDialog() == DialogResult.OK)
                        {

                            sr = new StreamReader(selectProfile.FileName);

                            txtNameP4.Text = sr.ReadLine();
                            cbxWeaponP4.Text = sr.ReadLine();

                            cbxHelmetP4.Text = sr.ReadLine();
                            cbxChestP4.Text = sr.ReadLine();
                            cbxShouldersP4.Text = sr.ReadLine();
                            cbxArmsP4.Text = sr.ReadLine();
                            cbxLegsP4.Text = sr.ReadLine();

                            string clrPrimary = sr.ReadLine();
                            string clrSecondary = sr.ReadLine();
                            string clrVisor = sr.ReadLine();
                            string clrLights = sr.ReadLine();
                            string clrHolo = sr.ReadLine();

                            Console.WriteLine("--clrPrimary--");
                            Console.WriteLine("red: " + clrPrimary.Substring(0, clrPrimary.IndexOf(" ", 0)));
                            Console.WriteLine("green: " + clrPrimary.Substring(clrPrimary.IndexOf(" ", 0) + 1, clrPrimary.LastIndexOf(" ") - clrPrimary.IndexOf(" ", 0) - 1));
                            Console.WriteLine("blue: " + clrPrimary.Substring(clrPrimary.LastIndexOf(" ") + 1));

                            Console.WriteLine("--clrSecondary--");
                            Console.WriteLine("red: " + clrSecondary.Substring(0, clrSecondary.IndexOf(" ", 0)));
                            Console.WriteLine("green: " + clrSecondary.Substring(clrSecondary.IndexOf(" ", 0) + 1, clrSecondary.LastIndexOf(" ") - clrSecondary.IndexOf(" ", 0) - 1));
                            Console.WriteLine("blue: " + clrSecondary.Substring(clrSecondary.LastIndexOf(" ") + 1));

                            Console.WriteLine("--clrVisor--");
                            Console.WriteLine("red: " + clrVisor.Substring(0, clrVisor.IndexOf(" ", 0)));
                            Console.WriteLine("green: " + clrVisor.Substring(clrVisor.IndexOf(" ", 0) + 1, clrVisor.LastIndexOf(" ") - clrVisor.IndexOf(" ", 0) - 1));
                            Console.WriteLine("blue: " + clrVisor.Substring(clrVisor.LastIndexOf(" ") + 1));

                            Console.WriteLine("--clrLights--");
                            Console.WriteLine("red: " + clrLights.Substring(0, clrLights.IndexOf(" ", 0)));
                            Console.WriteLine("green: " + clrLights.Substring(clrLights.IndexOf(" ", 0) + 1, clrLights.LastIndexOf(" ") - clrLights.IndexOf(" ", 0) - 1));
                            Console.WriteLine("blue: " + clrLights.Substring(clrLights.LastIndexOf(" ") + 1));

                            Console.WriteLine("--clrHolo--");
                            Console.WriteLine("red: " + clrHolo.Substring(0, clrHolo.IndexOf(" ", 0)));
                            Console.WriteLine("green: " + clrHolo.Substring(clrHolo.IndexOf(" ", 0) + 1, clrHolo.LastIndexOf(" ") - clrHolo.IndexOf(" ", 0) - 1));
                            Console.WriteLine("blue: " + clrHolo.Substring(clrHolo.LastIndexOf(" ") + 1));

                            txtPrimaryP4.BackColor = Color.FromArgb(red: Convert.ToInt32(clrPrimary.Substring(0, clrPrimary.IndexOf(" ", 0))),
                                                                    green: Convert.ToInt32(clrPrimary.Substring(clrPrimary.IndexOf(" ", 0) + 1, clrPrimary.LastIndexOf(" ") - clrPrimary.IndexOf(" ", 0) - 1)),
                                                                    blue: Convert.ToInt32(clrPrimary.Substring(clrPrimary.LastIndexOf(" ") + 1)));

                            txtSecondaryP4.BackColor = Color.FromArgb(red: Convert.ToInt32(clrSecondary.Substring(0, clrSecondary.IndexOf(" ", 0))),
                                                                    green: Convert.ToInt32(clrSecondary.Substring(clrSecondary.IndexOf(" ", 0) + 1, clrSecondary.LastIndexOf(" ") - clrSecondary.IndexOf(" ", 0) - 1)),
                                                                    blue: Convert.ToInt32(clrSecondary.Substring(clrSecondary.LastIndexOf(" ") + 1)));

                            txtVisorP4.BackColor = Color.FromArgb(red: Convert.ToInt32(clrVisor.Substring(0, clrVisor.IndexOf(" ", 0))),
                                                                    green: Convert.ToInt32(clrVisor.Substring(clrVisor.IndexOf(" ", 0) + 1, clrVisor.LastIndexOf(" ") - clrVisor.IndexOf(" ", 0) - 1)),
                                                                    blue: Convert.ToInt32(clrVisor.Substring(clrVisor.LastIndexOf(" ") + 1)));

                            txtLightsP4.BackColor = Color.FromArgb(red: Convert.ToInt32(clrLights.Substring(0, clrLights.IndexOf(" ", 0))),
                                                                    green: Convert.ToInt32(clrLights.Substring(clrLights.IndexOf(" ", 0) + 1, clrLights.LastIndexOf(" ") - clrLights.IndexOf(" ", 0) - 1)),
                                                                    blue: Convert.ToInt32(clrLights.Substring(clrLights.LastIndexOf(" ") + 1)));

                            txtHoloP4.BackColor = Color.FromArgb(red: Convert.ToInt32(clrHolo.Substring(0, clrHolo.IndexOf(" ", 0))),
                                                                    green: Convert.ToInt32(clrHolo.Substring(clrHolo.IndexOf(" ", 0) + 1, clrHolo.LastIndexOf(" ") - clrHolo.IndexOf(" ", 0) - 1)),
                                                                    blue: Convert.ToInt32(clrHolo.Substring(clrHolo.LastIndexOf(" ") + 1)));

                            lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 4, txtNameP4.Text);
                            Console.WriteLine("Successfully loaded " + txtNameP4.Text + "'s profile as P4.");
                            MessageBox.Show("Successfully loaded " + txtNameP4.Text + "'s profile as P4.", "Halo Online Split Screen");

                            sr.Close();

                        }
                        else
                        {

                            Console.WriteLine("Did not load a selected profile.");
                            MessageBox.Show("Did not load a selected profile.", "Halo Online Split Screen");

                        }

                    }
                    else
                    {

                        Console.WriteLine("Did not load a selected profile.");
                        MessageBox.Show("Did not load a selected profile.", "Halo Online Split Screen");

                    }

                }

            }

            selectProfile.Dispose();

        }

        #endregion

        #region "profile saving methods"

        private void saveTraitsP1()
        {

            if (cbxArmsP1.Text != "" && cbxChestP1.Text != "" && cbxHelmetP1.Text != "" && cbxLegsP1.Text != "" && cbxShouldersP1.Text != "" && txtNameP1.Text != "" && cbxWeaponP1.Text != "")
            {

                if ((File.Exists(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop")) && (File.Exists(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".ref")))
                {

                    DialogResult overwrite = MessageBox.Show(txtNameP1.Text + ".hop and " + txtNameP1.Text + ".ref files already exist in your HOSS profiles folder. Would you like to overwrite them?", "Halo Online Split Screen", MessageBoxButtons.YesNo);

                    if (overwrite == DialogResult.Yes)
                    {

                        File.Delete(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop");
                        File.Delete(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".ref");
                        File.Copy(Properties.Settings.Default.haloOnlineDirectory + "\\dewrito_prefs.cfg", Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop");

                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 18, "Player.Name " + "\"" + txtNameP1.Text + "\"");
                        switch (cbxWeaponP1.SelectedIndex)
                        {
                            case 0:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"assault rifle\"");
                                break;
                            case 1:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_2\"");
                                break;
                            case 2:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_3\"");
                                break;
                            case 3:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_5\"");
                                break;
                            case 4:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_6\"");
                                break;
                            case 5:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"battle_rifle\"");
                                break;
                            case 6:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_1\"");
                                break;
                            case 7:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_2\"");
                                break;
                            case 8:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_3\"");
                                break;
                            case 9:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_4\"");
                                break;
                            case 10:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_5\"");
                                break;
                            case 11:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_6\"");
                                break;
                            case 12:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine\"");
                                break;
                            case 13:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_1\"");
                                break;
                            case 14:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_2\"");
                                break;
                            case 15:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_3\"");
                                break;
                            case 16:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_4\"");
                                break;
                            case 17:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_5\"");
                                break;
                            case 18:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_6\"");
                                break;
                            case 19:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr\"");
                                break;
                            case 20:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_1\"");
                                break;
                            case 21:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_2\"");
                                break;
                            case 22:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_3\"");
                                break;
                            case 23:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_4\"");
                                break;
                            case 24:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_5\"");
                                break;
                            case 25:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_6\"");
                                break;
                            case 26:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"plasma_rifle\"");
                                break;
                            case 27:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"plasma_rifle_variant_6\"");
                                break;
                            case 28:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg\"");
                                break;
                            case 29:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_1\"");
                                break;
                            case 30:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_2\"");
                                break;
                            case 31:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_4\"");
                                break;
                            case 32:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_6\"");
                                break;
                        }

                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 8, "Player.Armor.Helmet " + "\"" + cbxHelmetP1.Text.ToLower() + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 7, "Player.Armor.Chest " + "\"" + cbxChestP1.Text.ToLower() + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 11, "Player.Armor.Shoulders " + "\"" + cbxShouldersP1.Text.ToLower() + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 6, "Player.Armor.Arms " + "\"" + cbxArmsP1.Text.ToLower() + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 9, "Player.Armor.Legs " + "\"" + cbxLegsP1.Text.ToLower() + "\"");

                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 12, "Player.Colors.Primary " + "\"#" + txtPrimaryP1.BackColor.R.ToString("X2") + txtPrimaryP1.BackColor.G.ToString("X2") + txtPrimaryP1.BackColor.B.ToString("X2") + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 13, "Player.Colors.Secondary " + "\"#" + txtSecondaryP1.BackColor.R.ToString("X2") + txtSecondaryP1.BackColor.G.ToString("X2") + txtSecondaryP1.BackColor.B.ToString("X2") + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 14, "Player.Colors.Visor " + "\"#" + txtVisorP1.BackColor.R.ToString("X2") + txtVisorP1.BackColor.G.ToString("X2") + txtVisorP1.BackColor.B.ToString("X2") + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 15, "Player.Colors.Lights " + "\"#" + txtLightsP1.BackColor.R.ToString("X2") + txtLightsP1.BackColor.G.ToString("X2") + txtLightsP1.BackColor.B.ToString("X2") + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 16, "Player.Colors.Holo " + "\"#" + txtHoloP1.BackColor.R.ToString("X2") + txtHoloP1.BackColor.G.ToString("X2") + txtHoloP1.BackColor.B.ToString("X2") + "\"");

                        FileStream tmp = File.Create(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".ref");

                        StreamWriter sw = new StreamWriter(tmp);

                        sw.WriteLine(txtNameP1.Text);
                        sw.WriteLine(cbxWeaponP1.Text);

                        sw.WriteLine(cbxHelmetP1.Text);
                        sw.WriteLine(cbxChestP1.Text);
                        sw.WriteLine(cbxShouldersP1.Text);
                        sw.WriteLine(cbxArmsP1.Text);
                        sw.WriteLine(cbxLegsP1.Text);

                        sw.WriteLine(txtPrimaryP1.BackColor.R.ToString() + " " + txtPrimaryP1.BackColor.G.ToString() + " " + txtPrimaryP1.BackColor.B.ToString());
                        sw.WriteLine(txtSecondaryP1.BackColor.R.ToString() + " " + txtSecondaryP1.BackColor.G.ToString() + " " + txtSecondaryP1.BackColor.B.ToString());
                        sw.WriteLine(txtVisorP1.BackColor.R.ToString() + " " + txtVisorP1.BackColor.G.ToString() + " " + txtVisorP1.BackColor.B.ToString());
                        sw.WriteLine(txtLightsP1.BackColor.R.ToString() + " " + txtLightsP1.BackColor.G.ToString() + " " + txtLightsP1.BackColor.B.ToString());
                        sw.Write(txtHoloP1.BackColor.R.ToString() + " " + txtHoloP1.BackColor.G.ToString() + " " + txtHoloP1.BackColor.B.ToString());

                        sw.Close();
                        tmp.Close();
                        
                        lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 1, txtNameP1.Text);
                        Console.WriteLine("Successfully saved " + txtNameP1.Text + ".hop and " + txtNameP1.Text + ".ref to '" + Properties.Settings.Default.installationDirectory + "\\profiles'.");
                        MessageBox.Show("Successfully saved " + txtNameP1.Text + ".hop and " + txtNameP1.Text + ".ref to '" + Properties.Settings.Default.installationDirectory + "\\profiles'.", "Halo Online Split Screen");

                        GameMethods.setDewritoPrefsFileAsHOPFile(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 1);
                        updatePlayerSettingsIngame();

                    }
                    else
                    {

                        Console.WriteLine("Did not save " + txtNameP1.Text + ".hop to '" + Properties.Settings.Default.installationDirectory + "\\profiles'.");

                    }

                }
                else
                {

                    File.Copy(Properties.Settings.Default.haloOnlineDirectory + "\\dewrito_prefs.cfg", Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop");

                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 18, "Player.Name " + "\"" + txtNameP1.Text + "\"");
                    switch (cbxWeaponP1.SelectedIndex)
                    {
                        case 0:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"assault rifle\"");
                            break;
                        case 1:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_2\"");
                            break;
                        case 2:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_3\"");
                            break;
                        case 3:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_5\"");
                            break;
                        case 4:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_6\"");
                            break;
                        case 5:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"battle_rifle\"");
                            break;
                        case 6:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_1\"");
                            break;
                        case 7:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_2\"");
                            break;
                        case 8:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_3\"");
                            break;
                        case 9:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_4\"");
                            break;
                        case 10:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_5\"");
                            break;
                        case 11:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_6\"");
                            break;
                        case 12:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine\"");
                            break;
                        case 13:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_1\"");
                            break;
                        case 14:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_2\"");
                            break;
                        case 15:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_3\"");
                            break;
                        case 16:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_4\"");
                            break;
                        case 17:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_5\"");
                            break;
                        case 18:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_6\"");
                            break;
                        case 19:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr\"");
                            break;
                        case 20:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_1\"");
                            break;
                        case 21:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_2\"");
                            break;
                        case 22:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_3\"");
                            break;
                        case 23:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_4\"");
                            break;
                        case 24:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_5\"");
                            break;
                        case 25:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_6\"");
                            break;
                        case 26:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"plasma_rifle\"");
                            break;
                        case 27:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"plasma_rifle_variant_6\"");
                            break;
                        case 28:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg\"");
                            break;
                        case 29:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_1\"");
                            break;
                        case 30:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_2\"");
                            break;
                        case 31:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_4\"");
                            break;
                        case 32:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_6\"");
                            break;
                    }

                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 8, "Player.Armor.Helmet " + "\"" + cbxHelmetP1.Text.ToLower() + "\"");
                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 7, "Player.Armor.Chest " + "\"" + cbxChestP1.Text.ToLower() + "\"");
                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 11, "Player.Armor.Shoulders " + "\"" + cbxShouldersP1.Text.ToLower() + "\"");
                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 6, "Player.Armor.Arms " + "\"" + cbxArmsP1.Text.ToLower() + "\"");
                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 9, "Player.Armor.Legs " + "\"" + cbxLegsP1.Text.ToLower() + "\"");

                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 12, "Player.Colors.Primary " + "\"#" + txtPrimaryP1.BackColor.R.ToString("X2") + txtPrimaryP1.BackColor.G.ToString("X2") + txtPrimaryP1.BackColor.B.ToString("X2") + "\"");
                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 13, "Player.Colors.Secondary " + "\"#" + txtSecondaryP1.BackColor.R.ToString("X2") + txtSecondaryP1.BackColor.G.ToString("X2") + txtSecondaryP1.BackColor.B.ToString("X2") + "\"");
                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 14, "Player.Colors.Visor " + "\"#" + txtVisorP1.BackColor.R.ToString("X2") + txtVisorP1.BackColor.G.ToString("X2") + txtVisorP1.BackColor.B.ToString("X2") + "\"");
                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 15, "Player.Colors.Lights " + "\"#" + txtLightsP1.BackColor.R.ToString("X2") + txtLightsP1.BackColor.G.ToString("X2") + txtLightsP1.BackColor.B.ToString("X2") + "\"");
                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 16, "Player.Colors.Holo " + "\"#" + txtHoloP1.BackColor.R.ToString("X2") + txtHoloP1.BackColor.G.ToString("X2") + txtHoloP1.BackColor.B.ToString("X2") + "\"");

                    FileStream tmp = File.Create(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".ref");

                    StreamWriter sw = new StreamWriter(tmp);

                    sw.WriteLine(txtNameP1.Text);
                    sw.WriteLine(cbxWeaponP1.Text);

                    sw.WriteLine(cbxHelmetP1.Text);
                    sw.WriteLine(cbxChestP1.Text);
                    sw.WriteLine(cbxShouldersP1.Text);
                    sw.WriteLine(cbxArmsP1.Text);
                    sw.WriteLine(cbxLegsP1.Text);

                    sw.WriteLine(txtPrimaryP1.BackColor.R.ToString() + " " + txtPrimaryP1.BackColor.G.ToString() + " " + txtPrimaryP1.BackColor.B.ToString());
                    sw.WriteLine(txtSecondaryP1.BackColor.R.ToString() + " " + txtSecondaryP1.BackColor.G.ToString() + " " + txtSecondaryP1.BackColor.B.ToString());
                    sw.WriteLine(txtVisorP1.BackColor.R.ToString() + " " + txtVisorP1.BackColor.G.ToString() + " " + txtVisorP1.BackColor.B.ToString());
                    sw.WriteLine(txtLightsP1.BackColor.R.ToString() + " " + txtLightsP1.BackColor.G.ToString() + " " + txtLightsP1.BackColor.B.ToString());
                    sw.Write(txtHoloP1.BackColor.R.ToString() + " " + txtHoloP1.BackColor.G.ToString() + " " + txtHoloP1.BackColor.B.ToString());

                    sw.Close();
                    tmp.Close();
                    
                    lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 1, txtNameP1.Text);
                    Console.WriteLine("Successfully saved " + txtNameP1.Text + ".hop and " + txtNameP1.Text + ".ref to '" + Properties.Settings.Default.installationDirectory + "\\profiles'.");
                    MessageBox.Show("Successfully saved " + txtNameP1.Text + ".hop and " + txtNameP1.Text + ".ref to '" + Properties.Settings.Default.installationDirectory + "\\profiles'.", "Halo Online Split Screen");

                    GameMethods.setDewritoPrefsFileAsHOPFile(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP1.Text + ".hop", 1);
                    updatePlayerSettingsIngame();

                }

            }
            else
            {

                MessageBox.Show("Please make sure all required fields for P1 have been filled out", "Halo Online Split Screen");

            }

        }

        private void saveTraitsP2()
        {

            if (cbxArmsP2.Text != "" && cbxChestP2.Text != "" && cbxHelmetP2.Text != "" && cbxLegsP2.Text != "" && cbxShouldersP2.Text != "" && txtNameP2.Text != "" && cbxWeaponP2.Text != "")
            {

                if ((File.Exists(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop")) && (File.Exists(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".ref")))
                {

                    DialogResult overwrite = MessageBox.Show(txtNameP2.Text + ".hop and " + txtNameP2.Text + ".ref files already exist in your HOSS profiles folder. Would you like to overwrite them?", "Halo Online Split Screen", MessageBoxButtons.YesNo);

                    if (overwrite == DialogResult.Yes)
                    {

                        File.Delete(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop");
                        File.Delete(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".ref");
                        File.Copy(Properties.Settings.Default.haloOnlineDirectory + "\\dewrito_prefs.cfg", Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop");

                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 18, "Player.Name " + "\"" + txtNameP2.Text + "\"");
                        switch (cbxWeaponP2.SelectedIndex)
                        {
                            case 0:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"assault rifle\"");
                                break;
                            case 1:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_2\"");
                                break;
                            case 2:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_3\"");
                                break;
                            case 3:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_5\"");
                                break;
                            case 4:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_6\"");
                                break;
                            case 5:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"battle_rifle\"");
                                break;
                            case 6:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_1\"");
                                break;
                            case 7:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_2\"");
                                break;
                            case 8:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_3\"");
                                break;
                            case 9:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_4\"");
                                break;
                            case 10:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_5\"");
                                break;
                            case 11:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_6\"");
                                break;
                            case 12:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine\"");
                                break;
                            case 13:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_1\"");
                                break;
                            case 14:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_2\"");
                                break;
                            case 15:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_3\"");
                                break;
                            case 16:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_4\"");
                                break;
                            case 17:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_5\"");
                                break;
                            case 18:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_6\"");
                                break;
                            case 19:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr\"");
                                break;
                            case 20:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_1\"");
                                break;
                            case 21:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_2\"");
                                break;
                            case 22:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_3\"");
                                break;
                            case 23:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_4\"");
                                break;
                            case 24:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_5\"");
                                break;
                            case 25:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_6\"");
                                break;
                            case 26:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"plasma_rifle\"");
                                break;
                            case 27:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"plasma_rifle_variant_6\"");
                                break;
                            case 28:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg\"");
                                break;
                            case 29:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_1\"");
                                break;
                            case 30:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_2\"");
                                break;
                            case 31:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_4\"");
                                break;
                            case 32:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_6\"");
                                break;
                        }

                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 8, "Player.Armor.Helmet " + "\"" + cbxHelmetP2.Text.ToLower() + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 7, "Player.Armor.Chest " + "\"" + cbxChestP2.Text.ToLower() + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 11, "Player.Armor.Shoulders " + "\"" + cbxShouldersP2.Text.ToLower() + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 6, "Player.Armor.Arms " + "\"" + cbxArmsP2.Text.ToLower() + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 9, "Player.Armor.Legs " + "\"" + cbxLegsP2.Text.ToLower() + "\"");

                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 12, "Player.Colors.Primary " + "\"#" + txtPrimaryP2.BackColor.R.ToString("X2") + txtPrimaryP2.BackColor.G.ToString("X2") + txtPrimaryP2.BackColor.B.ToString("X2") + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 13, "Player.Colors.Secondary " + "\"#" + txtSecondaryP2.BackColor.R.ToString("X2") + txtSecondaryP2.BackColor.G.ToString("X2") + txtSecondaryP2.BackColor.B.ToString("X2") + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 14, "Player.Colors.Visor " + "\"#" + txtVisorP2.BackColor.R.ToString("X2") + txtVisorP2.BackColor.G.ToString("X2") + txtVisorP2.BackColor.B.ToString("X2") + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 15, "Player.Colors.Lights " + "\"#" + txtLightsP2.BackColor.R.ToString("X2") + txtLightsP2.BackColor.G.ToString("X2") + txtLightsP2.BackColor.B.ToString("X2") + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 16, "Player.Colors.Holo " + "\"#" + txtHoloP2.BackColor.R.ToString("X2") + txtHoloP2.BackColor.G.ToString("X2") + txtHoloP2.BackColor.B.ToString("X2") + "\"");

                        FileStream tmp = File.Create(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".ref");

                        StreamWriter sw = new StreamWriter(tmp);

                        sw.WriteLine(txtNameP2.Text);
                        sw.WriteLine(cbxWeaponP2.Text);

                        sw.WriteLine(cbxHelmetP2.Text);
                        sw.WriteLine(cbxChestP2.Text);
                        sw.WriteLine(cbxShouldersP2.Text);
                        sw.WriteLine(cbxArmsP2.Text);
                        sw.WriteLine(cbxLegsP2.Text);

                        sw.WriteLine(txtPrimaryP2.BackColor.R.ToString() + " " + txtPrimaryP2.BackColor.G.ToString() + " " + txtPrimaryP2.BackColor.B.ToString());
                        sw.WriteLine(txtSecondaryP2.BackColor.R.ToString() + " " + txtSecondaryP2.BackColor.G.ToString() + " " + txtSecondaryP2.BackColor.B.ToString());
                        sw.WriteLine(txtVisorP2.BackColor.R.ToString() + " " + txtVisorP2.BackColor.G.ToString() + " " + txtVisorP2.BackColor.B.ToString());
                        sw.WriteLine(txtLightsP2.BackColor.R.ToString() + " " + txtLightsP2.BackColor.G.ToString() + " " + txtLightsP2.BackColor.B.ToString());
                        sw.Write(txtHoloP2.BackColor.R.ToString() + " " + txtHoloP2.BackColor.G.ToString() + " " + txtHoloP2.BackColor.B.ToString());

                        sw.Close();
                        tmp.Close();

                        lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 2, txtNameP2.Text);
                        Console.WriteLine("Successfully saved " + txtNameP2.Text + ".hop and " + txtNameP2.Text + ".ref to '" + Properties.Settings.Default.installationDirectory + "\\profiles'.");
                        MessageBox.Show("Successfully saved " + txtNameP2.Text + ".hop and " + txtNameP2.Text + ".ref to '" + Properties.Settings.Default.installationDirectory + "\\profiles'.", "Halo Online Split Screen");
                        
                    }
                    else
                    {

                        Console.WriteLine("Did not save " + txtNameP2.Text + ".hop to '" + Properties.Settings.Default.installationDirectory + "\\profiles'.");

                    }

                }
                else
                {

                    File.Copy(Properties.Settings.Default.haloOnlineDirectory + "\\dewrito_prefs.cfg", Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop");


                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 18, "Player.Name " + "\"" + txtNameP2.Text + "\"");
                    switch (cbxWeaponP2.SelectedIndex)
                    {
                        case 0:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"assault rifle\"");
                            break;
                        case 1:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_2\"");
                            break;
                        case 2:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_3\"");
                            break;
                        case 3:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_5\"");
                            break;
                        case 4:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_6\"");
                            break;
                        case 5:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"battle_rifle\"");
                            break;
                        case 6:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_1\"");
                            break;
                        case 7:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_2\"");
                            break;
                        case 8:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_3\"");
                            break;
                        case 9:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_4\"");
                            break;
                        case 10:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_5\"");
                            break;
                        case 11:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_6\"");
                            break;
                        case 12:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine\"");
                            break;
                        case 13:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_1\"");
                            break;
                        case 14:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_2\"");
                            break;
                        case 15:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_3\"");
                            break;
                        case 16:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_4\"");
                            break;
                        case 17:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_5\"");
                            break;
                        case 18:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_6\"");
                            break;
                        case 19:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr\"");
                            break;
                        case 20:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_1\"");
                            break;
                        case 21:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_2\"");
                            break;
                        case 22:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_3\"");
                            break;
                        case 23:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_4\"");
                            break;
                        case 24:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_5\"");
                            break;
                        case 25:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_6\"");
                            break;
                        case 26:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"plasma_rifle\"");
                            break;
                        case 27:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"plasma_rifle_variant_6\"");
                            break;
                        case 28:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg\"");
                            break;
                        case 29:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_1\"");
                            break;
                        case 30:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_2\"");
                            break;
                        case 31:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_4\"");
                            break;
                        case 32:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_6\"");
                            break;
                    }

                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 8, "Player.Armor.Helmet " + "\"" + cbxHelmetP2.Text.ToLower() + "\"");
                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 7, "Player.Armor.Chest " + "\"" + cbxChestP2.Text.ToLower() + "\"");
                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 11, "Player.Armor.Shoulders " + "\"" + cbxShouldersP2.Text.ToLower() + "\"");
                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 6, "Player.Armor.Arms " + "\"" + cbxArmsP2.Text.ToLower() + "\"");
                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 9, "Player.Armor.Legs " + "\"" + cbxLegsP2.Text.ToLower() + "\"");

                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 12, "Player.Colors.Primary " + "\"#" + txtPrimaryP2.BackColor.R.ToString("X2") + txtPrimaryP2.BackColor.G.ToString("X2") + txtPrimaryP2.BackColor.B.ToString("X2") + "\"");
                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 13, "Player.Colors.Secondary " + "\"#" + txtSecondaryP2.BackColor.R.ToString("X2") + txtSecondaryP2.BackColor.G.ToString("X2") + txtSecondaryP2.BackColor.B.ToString("X2") + "\"");
                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 14, "Player.Colors.Visor " + "\"#" + txtVisorP2.BackColor.R.ToString("X2") + txtVisorP2.BackColor.G.ToString("X2") + txtVisorP2.BackColor.B.ToString("X2") + "\"");
                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 15, "Player.Colors.Lights " + "\"#" + txtLightsP2.BackColor.R.ToString("X2") + txtLightsP2.BackColor.G.ToString("X2") + txtLightsP2.BackColor.B.ToString("X2") + "\"");
                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".hop", 16, "Player.Colors.Holo " + "\"#" + txtHoloP2.BackColor.R.ToString("X2") + txtHoloP2.BackColor.G.ToString("X2") + txtHoloP2.BackColor.B.ToString("X2") + "\"");

                    FileStream tmp = File.Create(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP2.Text + ".ref");

                    StreamWriter sw = new StreamWriter(tmp);

                    sw.WriteLine(txtNameP2.Text);
                    sw.WriteLine(cbxWeaponP2.Text);

                    sw.WriteLine(cbxHelmetP2.Text);
                    sw.WriteLine(cbxChestP2.Text);
                    sw.WriteLine(cbxShouldersP2.Text);
                    sw.WriteLine(cbxArmsP2.Text);
                    sw.WriteLine(cbxLegsP2.Text);

                    sw.WriteLine(txtPrimaryP2.BackColor.R.ToString() + " " + txtPrimaryP2.BackColor.G.ToString() + " " + txtPrimaryP2.BackColor.B.ToString());
                    sw.WriteLine(txtSecondaryP2.BackColor.R.ToString() + " " + txtSecondaryP2.BackColor.G.ToString() + " " + txtSecondaryP2.BackColor.B.ToString());
                    sw.WriteLine(txtVisorP2.BackColor.R.ToString() + " " + txtVisorP2.BackColor.G.ToString() + " " + txtVisorP2.BackColor.B.ToString());
                    sw.WriteLine(txtLightsP2.BackColor.R.ToString() + " " + txtLightsP2.BackColor.G.ToString() + " " + txtLightsP2.BackColor.B.ToString());
                    sw.Write(txtHoloP2.BackColor.R.ToString() + " " + txtHoloP2.BackColor.G.ToString() + " " + txtHoloP2.BackColor.B.ToString());

                    sw.Close();
                    tmp.Close();

                    lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 2, txtNameP2.Text);
                    Console.WriteLine("Successfully saved " + txtNameP2.Text + ".hop and " + txtNameP2.Text + ".ref to '" + Properties.Settings.Default.installationDirectory + "\\profiles'.");
                    MessageBox.Show("Successfully saved " + txtNameP2.Text + ".hop and " + txtNameP2.Text + ".ref to '" + Properties.Settings.Default.installationDirectory + "\\profiles'.", "Halo Online Split Screen");
                    
                }

            }
            else
            {

                MessageBox.Show("Please make sure all required fields for P2 have been filled out", "Halo Online Split Screen");

            }

        }

        private void saveTraitsP3()
        {

            if (cbxArmsP3.Text != "" && cbxChestP3.Text != "" && cbxHelmetP3.Text != "" && cbxLegsP3.Text != "" && cbxShouldersP3.Text != "" && txtNameP3.Text != "" && cbxWeaponP3.Text != "")
            {

                if ((File.Exists(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop")) && (File.Exists(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".ref")))
                {

                    DialogResult overwrite = MessageBox.Show(txtNameP3.Text + ".hop and " + txtNameP3.Text + ".ref files already exist in your HOSS profiles folder. Would you like to overwrite them?", "Halo Online Split Screen", MessageBoxButtons.YesNo);

                    if (overwrite == DialogResult.Yes)
                    {

                        File.Delete(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop");
                        File.Delete(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".ref");
                        File.Copy(Properties.Settings.Default.haloOnlineDirectory + "\\dewrito_prefs.cfg", Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop");

                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 18, "Player.Name " + "\"" + txtNameP3.Text + "\"");
                        switch (cbxWeaponP3.SelectedIndex)
                        {
                            case 0:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"assault rifle\"");
                                break;
                            case 1:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_2\"");
                                break;
                            case 2:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_3\"");
                                break;
                            case 3:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_5\"");
                                break;
                            case 4:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_6\"");
                                break;
                            case 5:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"battle_rifle\"");
                                break;
                            case 6:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_1\"");
                                break;
                            case 7:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_2\"");
                                break;
                            case 8:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_3\"");
                                break;
                            case 9:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_4\"");
                                break;
                            case 10:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_5\"");
                                break;
                            case 11:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_6\"");
                                break;
                            case 12:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine\"");
                                break;
                            case 13:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_1\"");
                                break;
                            case 14:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_2\"");
                                break;
                            case 15:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_3\"");
                                break;
                            case 16:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_4\"");
                                break;
                            case 17:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_5\"");
                                break;
                            case 18:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_6\"");
                                break;
                            case 19:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr\"");
                                break;
                            case 20:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_1\"");
                                break;
                            case 21:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_2\"");
                                break;
                            case 22:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_3\"");
                                break;
                            case 23:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_4\"");
                                break;
                            case 24:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_5\"");
                                break;
                            case 25:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_6\"");
                                break;
                            case 26:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"plasma_rifle\"");
                                break;
                            case 27:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"plasma_rifle_variant_6\"");
                                break;
                            case 28:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg\"");
                                break;
                            case 29:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_1\"");
                                break;
                            case 30:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_2\"");
                                break;
                            case 31:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_4\"");
                                break;
                            case 32:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_6\"");
                                break;
                        }

                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 8, "Player.Armor.Helmet " + "\"" + cbxHelmetP3.Text.ToLower() + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 7, "Player.Armor.Chest " + "\"" + cbxChestP3.Text.ToLower() + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 11, "Player.Armor.Shoulders " + "\"" + cbxShouldersP3.Text.ToLower() + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 6, "Player.Armor.Arms " + "\"" + cbxArmsP3.Text.ToLower() + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 9, "Player.Armor.Legs " + "\"" + cbxLegsP3.Text.ToLower() + "\"");

                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 12, "Player.Colors.Primary " + "\"#" + txtPrimaryP3.BackColor.R.ToString("X2") + txtPrimaryP3.BackColor.G.ToString("X2") + txtPrimaryP3.BackColor.B.ToString("X2") + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 13, "Player.Colors.Secondary " + "\"#" + txtSecondaryP3.BackColor.R.ToString("X2") + txtSecondaryP3.BackColor.G.ToString("X2") + txtSecondaryP3.BackColor.B.ToString("X2") + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 14, "Player.Colors.Visor " + "\"#" + txtVisorP3.BackColor.R.ToString("X2") + txtVisorP3.BackColor.G.ToString("X2") + txtVisorP3.BackColor.B.ToString("X2") + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 15, "Player.Colors.Lights " + "\"#" + txtLightsP3.BackColor.R.ToString("X2") + txtLightsP3.BackColor.G.ToString("X2") + txtLightsP3.BackColor.B.ToString("X2") + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 16, "Player.Colors.Holo " + "\"#" + txtHoloP3.BackColor.R.ToString("X2") + txtHoloP3.BackColor.G.ToString("X2") + txtHoloP3.BackColor.B.ToString("X2") + "\"");

                        FileStream tmp = File.Create(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".ref");

                        StreamWriter sw = new StreamWriter(tmp);

                        sw.WriteLine(txtNameP3.Text);
                        sw.WriteLine(cbxWeaponP3.Text);

                        sw.WriteLine(cbxHelmetP3.Text);
                        sw.WriteLine(cbxChestP3.Text);
                        sw.WriteLine(cbxShouldersP3.Text);
                        sw.WriteLine(cbxArmsP3.Text);
                        sw.WriteLine(cbxLegsP3.Text);

                        sw.WriteLine(txtPrimaryP3.BackColor.R.ToString() + " " + txtPrimaryP3.BackColor.G.ToString() + " " + txtPrimaryP3.BackColor.B.ToString());
                        sw.WriteLine(txtSecondaryP3.BackColor.R.ToString() + " " + txtSecondaryP3.BackColor.G.ToString() + " " + txtSecondaryP3.BackColor.B.ToString());
                        sw.WriteLine(txtVisorP3.BackColor.R.ToString() + " " + txtVisorP3.BackColor.G.ToString() + " " + txtVisorP3.BackColor.B.ToString());
                        sw.WriteLine(txtLightsP3.BackColor.R.ToString() + " " + txtLightsP3.BackColor.G.ToString() + " " + txtLightsP3.BackColor.B.ToString());
                        sw.Write(txtHoloP3.BackColor.R.ToString() + " " + txtHoloP3.BackColor.G.ToString() + " " + txtHoloP3.BackColor.B.ToString());

                        sw.Close();
                        tmp.Close();

                        lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 3, txtNameP3.Text);
                        Console.WriteLine("Successfully saved " + txtNameP3.Text + ".hop and " + txtNameP3.Text + ".ref to '" + Properties.Settings.Default.installationDirectory + "\\profiles'.");
                        MessageBox.Show("Successfully saved " + txtNameP3.Text + ".hop and " + txtNameP3.Text + ".ref to '" + Properties.Settings.Default.installationDirectory + "\\profiles'.", "Halo Online Split Screen");
                        
                    }
                    else
                    {

                        Console.WriteLine("Did not save " + txtNameP3.Text + ".hop to '" + Properties.Settings.Default.installationDirectory + "\\profiles'.");

                    }

                }
                else
                {

                    File.Copy(Properties.Settings.Default.haloOnlineDirectory + "\\dewrito_prefs.cfg", Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop");

                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 18, "Player.Name " + "\"" + txtNameP3.Text + "\"");
                    switch (cbxWeaponP3.SelectedIndex)
                    {
                        case 0:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"assault rifle\"");
                            break;
                        case 1:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_2\"");
                            break;
                        case 2:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_3\"");
                            break;
                        case 3:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_5\"");
                            break;
                        case 4:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_6\"");
                            break;
                        case 5:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"battle_rifle\"");
                            break;
                        case 6:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_1\"");
                            break;
                        case 7:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_2\"");
                            break;
                        case 8:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_3\"");
                            break;
                        case 9:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_4\"");
                            break;
                        case 10:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_5\"");
                            break;
                        case 11:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_6\"");
                            break;
                        case 12:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine\"");
                            break;
                        case 13:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_1\"");
                            break;
                        case 14:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_2\"");
                            break;
                        case 15:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_3\"");
                            break;
                        case 16:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_4\"");
                            break;
                        case 17:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_5\"");
                            break;
                        case 18:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_6\"");
                            break;
                        case 19:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr\"");
                            break;
                        case 20:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_1\"");
                            break;
                        case 21:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_2\"");
                            break;
                        case 22:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_3\"");
                            break;
                        case 23:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_4\"");
                            break;
                        case 24:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_5\"");
                            break;
                        case 25:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_6\"");
                            break;
                        case 26:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"plasma_rifle\"");
                            break;
                        case 27:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"plasma_rifle_variant_6\"");
                            break;
                        case 28:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg\"");
                            break;
                        case 29:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_1\"");
                            break;
                        case 30:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_2\"");
                            break;
                        case 31:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_4\"");
                            break;
                        case 32:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_6\"");
                            break;
                    }

                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 8, "Player.Armor.Helmet " + "\"" + cbxHelmetP3.Text.ToLower() + "\"");
                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 7, "Player.Armor.Chest " + "\"" + cbxChestP3.Text.ToLower() + "\"");
                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 11, "Player.Armor.Shoulders " + "\"" + cbxShouldersP3.Text.ToLower() + "\"");
                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 6, "Player.Armor.Arms " + "\"" + cbxArmsP3.Text.ToLower() + "\"");
                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 9, "Player.Armor.Legs " + "\"" + cbxLegsP3.Text.ToLower() + "\"");

                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 12, "Player.Colors.Primary " + "\"#" + txtPrimaryP3.BackColor.R.ToString("X2") + txtPrimaryP3.BackColor.G.ToString("X2") + txtPrimaryP3.BackColor.B.ToString("X2") + "\"");
                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 13, "Player.Colors.Secondary " + "\"#" + txtSecondaryP3.BackColor.R.ToString("X2") + txtSecondaryP3.BackColor.G.ToString("X2") + txtSecondaryP3.BackColor.B.ToString("X2") + "\"");
                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 14, "Player.Colors.Visor " + "\"#" + txtVisorP3.BackColor.R.ToString("X2") + txtVisorP3.BackColor.G.ToString("X2") + txtVisorP3.BackColor.B.ToString("X2") + "\"");
                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 15, "Player.Colors.Lights " + "\"#" + txtLightsP3.BackColor.R.ToString("X2") + txtLightsP3.BackColor.G.ToString("X2") + txtLightsP3.BackColor.B.ToString("X2") + "\"");
                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".hop", 16, "Player.Colors.Holo " + "\"#" + txtHoloP3.BackColor.R.ToString("X2") + txtHoloP3.BackColor.G.ToString("X2") + txtHoloP3.BackColor.B.ToString("X2") + "\"");

                    FileStream tmp = File.Create(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP3.Text + ".ref");

                    StreamWriter sw = new StreamWriter(tmp);

                    sw.WriteLine(txtNameP3.Text);
                    sw.WriteLine(cbxWeaponP3.Text);

                    sw.WriteLine(cbxHelmetP3.Text);
                    sw.WriteLine(cbxChestP3.Text);
                    sw.WriteLine(cbxShouldersP3.Text);
                    sw.WriteLine(cbxArmsP3.Text);
                    sw.WriteLine(cbxLegsP3.Text);

                    sw.WriteLine(txtPrimaryP3.BackColor.R.ToString() + " " + txtPrimaryP3.BackColor.G.ToString() + " " + txtPrimaryP3.BackColor.B.ToString());
                    sw.WriteLine(txtSecondaryP3.BackColor.R.ToString() + " " + txtSecondaryP3.BackColor.G.ToString() + " " + txtSecondaryP3.BackColor.B.ToString());
                    sw.WriteLine(txtVisorP3.BackColor.R.ToString() + " " + txtVisorP3.BackColor.G.ToString() + " " + txtVisorP3.BackColor.B.ToString());
                    sw.WriteLine(txtLightsP3.BackColor.R.ToString() + " " + txtLightsP3.BackColor.G.ToString() + " " + txtLightsP3.BackColor.B.ToString());
                    sw.Write(txtHoloP3.BackColor.R.ToString() + " " + txtHoloP3.BackColor.G.ToString() + " " + txtHoloP3.BackColor.B.ToString());

                    sw.Close();
                    tmp.Close();

                    lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 3, txtNameP3.Text);
                    Console.WriteLine("Successfully saved " + txtNameP3.Text + ".hop and " + txtNameP3.Text + ".ref to '" + Properties.Settings.Default.installationDirectory + "\\profiles'.");
                    MessageBox.Show("Successfully saved " + txtNameP3.Text + ".hop and " + txtNameP3.Text + ".ref to '" + Properties.Settings.Default.installationDirectory + "\\profiles'.", "Halo Online Split Screen");
                    
                }

            }
            else
            {

                MessageBox.Show("Please make sure all required fields for P3 have been filled out", "Halo Online Split Screen");

            }

        }

        private void saveTraitsP4()
        {

            if (cbxArmsP4.Text != "" && cbxChestP4.Text != "" && cbxHelmetP4.Text != "" && cbxLegsP4.Text != "" && cbxShouldersP4.Text != "" && txtNameP4.Text != "" && cbxWeaponP4.Text != "")
            {

                if ((File.Exists(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop")) && (File.Exists(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".ref")))
                {

                    DialogResult overwrite = MessageBox.Show(txtNameP4.Text + ".hop and " + txtNameP4.Text + ".ref files already exist in your HOSS profiles folder. Would you like to overwrite them?", "Halo Online Split Screen", MessageBoxButtons.YesNo);

                    if (overwrite == DialogResult.Yes)
                    {

                        File.Delete(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop");
                        File.Delete(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".ref");
                        File.Copy(Properties.Settings.Default.haloOnlineDirectory + "\\dewrito_prefs.cfg", Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop");

                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 18, "Player.Name " + "\"" + txtNameP4.Text + "\"");
                        switch (cbxWeaponP4.SelectedIndex)
                        {
                            case 0:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"assault rifle\"");
                                break;
                            case 1:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_2\"");
                                break;
                            case 2:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_3\"");
                                break;
                            case 3:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_5\"");
                                break;
                            case 4:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_6\"");
                                break;
                            case 5:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"battle_rifle\"");
                                break;
                            case 6:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_1\"");
                                break;
                            case 7:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_2\"");
                                break;
                            case 8:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_3\"");
                                break;
                            case 9:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_4\"");
                                break;
                            case 10:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_5\"");
                                break;
                            case 11:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_6\"");
                                break;
                            case 12:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine\"");
                                break;
                            case 13:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_1\"");
                                break;
                            case 14:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_2\"");
                                break;
                            case 15:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_3\"");
                                break;
                            case 16:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_4\"");
                                break;
                            case 17:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_5\"");
                                break;
                            case 18:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_6\"");
                                break;
                            case 19:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr\"");
                                break;
                            case 20:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_1\"");
                                break;
                            case 21:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_2\"");
                                break;
                            case 22:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_3\"");
                                break;
                            case 23:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_4\"");
                                break;
                            case 24:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_5\"");
                                break;
                            case 25:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_6\"");
                                break;
                            case 26:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"plasma_rifle\"");
                                break;
                            case 27:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"plasma_rifle_variant_6\"");
                                break;
                            case 28:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg\"");
                                break;
                            case 29:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_1\"");
                                break;
                            case 30:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_2\"");
                                break;
                            case 31:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_4\"");
                                break;
                            case 32:
                                lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_6\"");
                                break;
                        }

                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 8, "Player.Armor.Helmet " + "\"" + cbxHelmetP4.Text.ToLower() + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 7, "Player.Armor.Chest " + "\"" + cbxChestP4.Text.ToLower() + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 11, "Player.Armor.Shoulders " + "\"" + cbxShouldersP4.Text.ToLower() + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 6, "Player.Armor.Arms " + "\"" + cbxArmsP4.Text.ToLower() + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 9, "Player.Armor.Legs " + "\"" + cbxLegsP4.Text.ToLower() + "\"");

                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 12, "Player.Colors.Primary " + "\"#" + txtPrimaryP4.BackColor.R.ToString("X2") + txtPrimaryP4.BackColor.G.ToString("X2") + txtPrimaryP4.BackColor.B.ToString("X2") + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 13, "Player.Colors.Secondary " + "\"#" + txtSecondaryP4.BackColor.R.ToString("X2") + txtSecondaryP4.BackColor.G.ToString("X2") + txtSecondaryP4.BackColor.B.ToString("X2") + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 14, "Player.Colors.Visor " + "\"#" + txtVisorP4.BackColor.R.ToString("X2") + txtVisorP4.BackColor.G.ToString("X2") + txtVisorP4.BackColor.B.ToString("X2") + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 15, "Player.Colors.Lights " + "\"#" + txtLightsP4.BackColor.R.ToString("X2") + txtLightsP4.BackColor.G.ToString("X2") + txtLightsP4.BackColor.B.ToString("X2") + "\"");
                        lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 16, "Player.Colors.Holo " + "\"#" + txtHoloP4.BackColor.R.ToString("X2") + txtHoloP4.BackColor.G.ToString("X2") + txtHoloP4.BackColor.B.ToString("X2") + "\"");

                        FileStream tmp = File.Create(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".ref");

                        StreamWriter sw = new StreamWriter(tmp);

                        sw.WriteLine(txtNameP4.Text);
                        sw.WriteLine(cbxWeaponP4.Text);

                        sw.WriteLine(cbxHelmetP4.Text);
                        sw.WriteLine(cbxChestP4.Text);
                        sw.WriteLine(cbxShouldersP4.Text);
                        sw.WriteLine(cbxArmsP4.Text);
                        sw.WriteLine(cbxLegsP4.Text);

                        sw.WriteLine(txtPrimaryP4.BackColor.R.ToString() + " " + txtPrimaryP4.BackColor.G.ToString() + " " + txtPrimaryP4.BackColor.B.ToString());
                        sw.WriteLine(txtSecondaryP4.BackColor.R.ToString() + " " + txtSecondaryP4.BackColor.G.ToString() + " " + txtSecondaryP4.BackColor.B.ToString());
                        sw.WriteLine(txtVisorP4.BackColor.R.ToString() + " " + txtVisorP4.BackColor.G.ToString() + " " + txtVisorP4.BackColor.B.ToString());
                        sw.WriteLine(txtLightsP4.BackColor.R.ToString() + " " + txtLightsP4.BackColor.G.ToString() + " " + txtLightsP4.BackColor.B.ToString());
                        sw.Write(txtHoloP4.BackColor.R.ToString() + " " + txtHoloP4.BackColor.G.ToString() + " " + txtHoloP4.BackColor.B.ToString());

                        sw.Close();
                        tmp.Close();

                        lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 4, txtNameP4.Text);
                        Console.WriteLine("Successfully saved " + txtNameP4.Text + ".hop and " + txtNameP4.Text + ".ref to '" + Properties.Settings.Default.installationDirectory + "\\profiles'.");
                        MessageBox.Show("Successfully saved " + txtNameP4.Text + ".hop and " + txtNameP4.Text + ".ref to '" + Properties.Settings.Default.installationDirectory + "\\profiles'.", "Halo Online Split Screen");
                        
                    }
                    else
                    {

                        Console.WriteLine("Did not save " + txtNameP4.Text + ".hop to '" + Properties.Settings.Default.installationDirectory + "\\profiles'.");

                    }

                }
                else
                {

                    File.Copy(Properties.Settings.Default.haloOnlineDirectory + "\\dewrito_prefs.cfg", Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop");

                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 18, "Player.Name " + "\"" + txtNameP4.Text + "\"");
                    switch (cbxWeaponP4.SelectedIndex)
                    {
                        case 0:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"assault rifle\"");
                            break;
                        case 1:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_2\"");
                            break;
                        case 2:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_3\"");
                            break;
                        case 3:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_5\"");
                            break;
                        case 4:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"ar_variant_6\"");
                            break;
                        case 5:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"battle_rifle\"");
                            break;
                        case 6:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_1\"");
                            break;
                        case 7:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_2\"");
                            break;
                        case 8:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_3\"");
                            break;
                        case 9:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_4\"");
                            break;
                        case 10:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_5\"");
                            break;
                        case 11:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"br_variant_6\"");
                            break;
                        case 12:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine\"");
                            break;
                        case 13:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_1\"");
                            break;
                        case 14:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_2\"");
                            break;
                        case 15:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_3\"");
                            break;
                        case 16:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_4\"");
                            break;
                        case 17:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_5\"");
                            break;
                        case 18:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"covenant_carbine_variant_6\"");
                            break;
                        case 19:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr\"");
                            break;
                        case 20:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_1\"");
                            break;
                        case 21:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_2\"");
                            break;
                        case 22:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_3\"");
                            break;
                        case 23:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_4\"");
                            break;
                        case 24:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_5\"");
                            break;
                        case 25:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"dmr_variant_6\"");
                            break;
                        case 26:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"plasma_rifle\"");
                            break;
                        case 27:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"plasma_rifle_variant_6\"");
                            break;
                        case 28:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg\"");
                            break;
                        case 29:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_1\"");
                            break;
                        case 30:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_2\"");
                            break;
                        case 31:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_4\"");
                            break;
                        case 32:
                            lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 17, "Player.RenderWeapon " + "\"smg_variant_6\"");
                            break;
                    }

                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 8, "Player.Armor.Helmet " + "\"" + cbxHelmetP4.Text.ToLower() + "\"");
                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 7, "Player.Armor.Chest " + "\"" + cbxChestP4.Text.ToLower() + "\"");
                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 11, "Player.Armor.Shoulders " + "\"" + cbxShouldersP4.Text.ToLower() + "\"");
                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 6, "Player.Armor.Arms " + "\"" + cbxArmsP4.Text.ToLower() + "\"");
                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 9, "Player.Armor.Legs " + "\"" + cbxLegsP4.Text.ToLower() + "\"");

                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 12, "Player.Colors.Primary " + "\"#" + txtPrimaryP4.BackColor.R.ToString("X2") + txtPrimaryP4.BackColor.G.ToString("X2") + txtPrimaryP4.BackColor.B.ToString("X2") + "\"");
                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 13, "Player.Colors.Secondary " + "\"#" + txtSecondaryP4.BackColor.R.ToString("X2") + txtSecondaryP4.BackColor.G.ToString("X2") + txtSecondaryP4.BackColor.B.ToString("X2") + "\"");
                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 14, "Player.Colors.Visor " + "\"#" + txtVisorP4.BackColor.R.ToString("X2") + txtVisorP4.BackColor.G.ToString("X2") + txtVisorP4.BackColor.B.ToString("X2") + "\"");
                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 15, "Player.Colors.Lights " + "\"#" + txtLightsP4.BackColor.R.ToString("X2") + txtLightsP4.BackColor.G.ToString("X2") + txtLightsP4.BackColor.B.ToString("X2") + "\"");
                    lineChange(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".hop", 16, "Player.Colors.Holo " + "\"#" + txtHoloP4.BackColor.R.ToString("X2") + txtHoloP4.BackColor.G.ToString("X2") + txtHoloP4.BackColor.B.ToString("X2") + "\"");

                    FileStream tmp = File.Create(Properties.Settings.Default.installationDirectory + "\\profiles\\" + txtNameP4.Text + ".ref");

                    StreamWriter sw = new StreamWriter(tmp);

                    sw.WriteLine(txtNameP4.Text);
                    sw.WriteLine(cbxWeaponP4.Text);

                    sw.WriteLine(cbxHelmetP4.Text);
                    sw.WriteLine(cbxChestP4.Text);
                    sw.WriteLine(cbxShouldersP4.Text);
                    sw.WriteLine(cbxArmsP4.Text);
                    sw.WriteLine(cbxLegsP4.Text);

                    sw.WriteLine(txtPrimaryP4.BackColor.R.ToString() + " " + txtPrimaryP4.BackColor.G.ToString() + " " + txtPrimaryP4.BackColor.B.ToString());
                    sw.WriteLine(txtSecondaryP4.BackColor.R.ToString() + " " + txtSecondaryP4.BackColor.G.ToString() + " " + txtSecondaryP4.BackColor.B.ToString());
                    sw.WriteLine(txtVisorP4.BackColor.R.ToString() + " " + txtVisorP4.BackColor.G.ToString() + " " + txtVisorP4.BackColor.B.ToString());
                    sw.WriteLine(txtLightsP4.BackColor.R.ToString() + " " + txtLightsP4.BackColor.G.ToString() + " " + txtLightsP4.BackColor.B.ToString());
                    sw.Write(txtHoloP4.BackColor.R.ToString() + " " + txtHoloP4.BackColor.G.ToString() + " " + txtHoloP4.BackColor.B.ToString());

                    sw.Close();
                    tmp.Close();

                    lineChange(Properties.Settings.Default.installationDirectory + "\\bin\\HOSS.cfg", 4, txtNameP4.Text);
                    Console.WriteLine("Successfully saved " + txtNameP4.Text + ".hop and " + txtNameP4.Text + ".ref to '" + Properties.Settings.Default.installationDirectory + "\\profiles'.");
                    MessageBox.Show("Successfully saved " + txtNameP4.Text + ".hop and " + txtNameP4.Text + ".ref to '" + Properties.Settings.Default.installationDirectory + "\\profiles'.", "Halo Online Split Screen");
                    
                }

            }
            else
            {

                MessageBox.Show("Please make sure all required fields for P4 have been filled out", "Halo Online Split Screen");

            }

        }

        #endregion

        private void frmProfiles_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.S)
            {

                if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                {

                    if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                    {

                        saveTraitsP1();
                        saveTraitsP2();
                        saveTraitsP3();
                        saveTraitsP4();

                    }

                }

            }
            
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.R)
            {

                loadTraitsWithoutFileDialogP1();
                loadTraitsWithoutFileDialogP2();
                loadTraitsWithoutFileDialogP3();
                loadTraitsWithoutFileDialogP4();

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

            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.M)
            {

                frmMain main = new frmMain(Bounds.Left, Bounds.Top);
                main.Show();
                appExit = false;
                this.Close();

            }

        }

        private void frmProfiles_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (appExit == true)
            {

                Application.Exit();

            }

        }

    }

}
