namespace Halo_Online_Split_Screen
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblTop = new System.Windows.Forms.Label();
            this.lblBlakeBoris = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblBlocker1 = new System.Windows.Forms.Label();
            this.lblBlocker2 = new System.Windows.Forms.Label();
            this.lblBlocker3 = new System.Windows.Forms.Label();
            this.lblBlocker4 = new System.Windows.Forms.Label();
            this.lblBlocker5 = new System.Windows.Forms.Label();
            this.lblLaunch = new System.Windows.Forms.Label();
            this.lblProfiles = new System.Windows.Forms.Label();
            this.lblExit = new System.Windows.Forms.Label();
            this.lblRightTitle = new System.Windows.Forms.Label();
            this.txtRight = new System.Windows.Forms.TextBox();
            this.tipDefault = new System.Windows.Forms.ToolTip(this.components);
            this.lblAmtInstances = new System.Windows.Forms.Label();
            this.lblScreen1 = new System.Windows.Forms.Label();
            this.lblScreen2 = new System.Windows.Forms.Label();
            this.lblScreen3 = new System.Windows.Forms.Label();
            this.lblScreen4 = new System.Windows.Forms.Label();
            this.lblKeyboardControlsP1 = new System.Windows.Forms.Label();
            this.chkCloseLauncherAfterLaunch = new System.Windows.Forms.CheckBox();
            this.lblCloseLauncherAfterLaunch = new System.Windows.Forms.Label();
            this.lblSaveSettings = new System.Windows.Forms.Label();
            this.cbxScreen1 = new System.Windows.Forms.ComboBox();
            this.cbxScreen2 = new System.Windows.Forms.ComboBox();
            this.cbxScreen4 = new System.Windows.Forms.ComboBox();
            this.cbxScreen3 = new System.Windows.Forms.ComboBox();
            this.cbxAmtInstances = new System.Windows.Forms.ComboBox();
            this.chkKeyboardControlsP1 = new System.Windows.Forms.CheckBox();
            this.chkVSync = new System.Windows.Forms.CheckBox();
            this.lblVSync = new System.Windows.Forms.Label();
            this.chkFullscreen = new System.Windows.Forms.CheckBox();
            this.lblFullscreen = new System.Windows.Forms.Label();
            this.lblGraphicsSetting = new System.Windows.Forms.Label();
            this.cbxGraphicSetting = new System.Windows.Forms.ComboBox();
            this.lblTimeBtwnLaunches = new System.Windows.Forms.Label();
            this.txtTimeBtwnLaunches = new System.Windows.Forms.TextBox();
            this.lblReloadPlayerFiles = new System.Windows.Forms.Label();
            this.wkrLoading = new System.ComponentModel.BackgroundWorker();
            this.chkAntiAliasing = new System.Windows.Forms.CheckBox();
            this.lblAntiAliasing = new System.Windows.Forms.Label();
            this.chkConsoleMode = new System.Windows.Forms.CheckBox();
            this.lblConsoleMode = new System.Windows.Forms.Label();
            this.lblConsoleModeOrientation = new System.Windows.Forms.Label();
            this.cbxConsoleModeOrientation = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblTop
            // 
            this.lblTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblTop.Font = new System.Drawing.Font("Franklin Gothic Medium", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblTop.Location = new System.Drawing.Point(0, 0);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(679, 56);
            this.lblTop.TabIndex = 1;
            this.lblTop.Text = "Halo Online Split Screen Configuration";
            this.lblTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBlakeBoris
            // 
            this.lblBlakeBoris.AutoSize = true;
            this.lblBlakeBoris.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlakeBoris.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblBlakeBoris.Location = new System.Drawing.Point(1, 58);
            this.lblBlakeBoris.Name = "lblBlakeBoris";
            this.lblBlakeBoris.Size = new System.Drawing.Size(106, 20);
            this.lblBlakeBoris.TabIndex = 6;
            this.lblBlakeBoris.Text = "By: Blake Boris";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblVersion.Location = new System.Drawing.Point(567, 58);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(113, 20);
            this.lblVersion.TabIndex = 7;
            this.lblVersion.Text = "Version: 0.2.1.4";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblBlocker1
            // 
            this.lblBlocker1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblBlocker1.Font = new System.Drawing.Font("Franklin Gothic Medium", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlocker1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblBlocker1.Location = new System.Drawing.Point(1, 81);
            this.lblBlocker1.Name = "lblBlocker1";
            this.lblBlocker1.Size = new System.Drawing.Size(678, 10);
            this.lblBlocker1.TabIndex = 8;
            this.lblBlocker1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBlocker2
            // 
            this.lblBlocker2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblBlocker2.Font = new System.Drawing.Font("Franklin Gothic Medium", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlocker2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblBlocker2.Location = new System.Drawing.Point(215, 91);
            this.lblBlocker2.Name = "lblBlocker2";
            this.lblBlocker2.Size = new System.Drawing.Size(10, 367);
            this.lblBlocker2.TabIndex = 9;
            this.lblBlocker2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBlocker3
            // 
            this.lblBlocker3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblBlocker3.Font = new System.Drawing.Font("Franklin Gothic Medium", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlocker3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblBlocker3.Location = new System.Drawing.Point(453, 91);
            this.lblBlocker3.Name = "lblBlocker3";
            this.lblBlocker3.Size = new System.Drawing.Size(10, 367);
            this.lblBlocker3.TabIndex = 10;
            this.lblBlocker3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBlocker4
            // 
            this.lblBlocker4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblBlocker4.Font = new System.Drawing.Font("Franklin Gothic Medium", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlocker4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblBlocker4.Location = new System.Drawing.Point(220, 206);
            this.lblBlocker4.Name = "lblBlocker4";
            this.lblBlocker4.Size = new System.Drawing.Size(237, 10);
            this.lblBlocker4.TabIndex = 11;
            this.lblBlocker4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBlocker5
            // 
            this.lblBlocker5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblBlocker5.Font = new System.Drawing.Font("Franklin Gothic Medium", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlocker5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblBlocker5.Location = new System.Drawing.Point(220, 330);
            this.lblBlocker5.Name = "lblBlocker5";
            this.lblBlocker5.Size = new System.Drawing.Size(237, 10);
            this.lblBlocker5.TabIndex = 12;
            this.lblBlocker5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLaunch
            // 
            this.lblLaunch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblLaunch.Font = new System.Drawing.Font("Franklin Gothic Medium", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLaunch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblLaunch.Location = new System.Drawing.Point(224, 91);
            this.lblLaunch.Name = "lblLaunch";
            this.lblLaunch.Size = new System.Drawing.Size(230, 115);
            this.lblLaunch.TabIndex = 13;
            this.lblLaunch.Text = "Launch";
            this.lblLaunch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLaunch.Click += new System.EventHandler(this.lblLaunch_Click);
            this.lblLaunch.MouseEnter += new System.EventHandler(this.lblLaunch_MouseEnter);
            this.lblLaunch.MouseLeave += new System.EventHandler(this.lblLaunch_MouseLeave);
            this.lblLaunch.MouseHover += new System.EventHandler(this.lblLaunch_MouseHover);
            // 
            // lblProfiles
            // 
            this.lblProfiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblProfiles.Font = new System.Drawing.Font("Franklin Gothic Medium", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfiles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblProfiles.Location = new System.Drawing.Point(224, 216);
            this.lblProfiles.Name = "lblProfiles";
            this.lblProfiles.Size = new System.Drawing.Size(230, 114);
            this.lblProfiles.TabIndex = 14;
            this.lblProfiles.Text = "Profiles";
            this.lblProfiles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProfiles.Click += new System.EventHandler(this.lblProfiles_Click);
            this.lblProfiles.MouseEnter += new System.EventHandler(this.lblProfiles_MouseEnter);
            this.lblProfiles.MouseLeave += new System.EventHandler(this.lblProfiles_MouseLeave);
            this.lblProfiles.MouseHover += new System.EventHandler(this.lblProfiles_MouseHover);
            // 
            // lblExit
            // 
            this.lblExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblExit.Font = new System.Drawing.Font("Franklin Gothic Medium", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblExit.Location = new System.Drawing.Point(224, 340);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(230, 118);
            this.lblExit.TabIndex = 15;
            this.lblExit.Text = "Exit";
            this.lblExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            this.lblExit.MouseEnter += new System.EventHandler(this.lblExit_MouseEnter);
            this.lblExit.MouseLeave += new System.EventHandler(this.lblExit_MouseLeave);
            this.lblExit.MouseHover += new System.EventHandler(this.lblExit_MouseHover);
            // 
            // lblRightTitle
            // 
            this.lblRightTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblRightTitle.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRightTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblRightTitle.Location = new System.Drawing.Point(463, 91);
            this.lblRightTitle.Name = "lblRightTitle";
            this.lblRightTitle.Size = new System.Drawing.Size(216, 38);
            this.lblRightTitle.TabIndex = 16;
            this.lblRightTitle.Text = "Recent Changes";
            this.lblRightTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRight
            // 
            this.txtRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtRight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRight.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtRight.Location = new System.Drawing.Point(463, 129);
            this.txtRight.Multiline = true;
            this.txtRight.Name = "txtRight";
            this.txtRight.ReadOnly = true;
            this.txtRight.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRight.Size = new System.Drawing.Size(217, 329);
            this.txtRight.TabIndex = 17;
            this.txtRight.TabStop = false;
            this.txtRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.txtChangelog_MouseMove);
            // 
            // tipDefault
            // 
            this.tipDefault.AutomaticDelay = 1000;
            // 
            // lblAmtInstances
            // 
            this.lblAmtInstances.AutoSize = true;
            this.lblAmtInstances.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmtInstances.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblAmtInstances.Location = new System.Drawing.Point(3, 102);
            this.lblAmtInstances.Name = "lblAmtInstances";
            this.lblAmtInstances.Size = new System.Drawing.Size(146, 20);
            this.lblAmtInstances.TabIndex = 18;
            this.lblAmtInstances.Text = "Amount of instances:";
            this.lblAmtInstances.MouseEnter += new System.EventHandler(this.lblAmtInstances_MouseEnter);
            this.lblAmtInstances.MouseLeave += new System.EventHandler(this.lblAmtInstances_MouseLeave);
            // 
            // lblScreen1
            // 
            this.lblScreen1.AutoSize = true;
            this.lblScreen1.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScreen1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblScreen1.Location = new System.Drawing.Point(4, 211);
            this.lblScreen1.Name = "lblScreen1";
            this.lblScreen1.Size = new System.Drawing.Size(31, 20);
            this.lblScreen1.TabIndex = 21;
            this.lblScreen1.Text = "S1:";
            this.lblScreen1.MouseEnter += new System.EventHandler(this.lblScreen1_MouseEnter);
            this.lblScreen1.MouseLeave += new System.EventHandler(this.lblScreen1_MouseLeave);
            // 
            // lblScreen2
            // 
            this.lblScreen2.AutoSize = true;
            this.lblScreen2.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScreen2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblScreen2.Location = new System.Drawing.Point(4, 235);
            this.lblScreen2.Name = "lblScreen2";
            this.lblScreen2.Size = new System.Drawing.Size(31, 20);
            this.lblScreen2.TabIndex = 22;
            this.lblScreen2.Text = "S2:";
            this.lblScreen2.MouseEnter += new System.EventHandler(this.lblScreen2_MouseEnter);
            this.lblScreen2.MouseLeave += new System.EventHandler(this.lblScreen2_MouseLeave);
            // 
            // lblScreen3
            // 
            this.lblScreen3.AutoSize = true;
            this.lblScreen3.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScreen3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblScreen3.Location = new System.Drawing.Point(108, 212);
            this.lblScreen3.Name = "lblScreen3";
            this.lblScreen3.Size = new System.Drawing.Size(31, 20);
            this.lblScreen3.TabIndex = 23;
            this.lblScreen3.Text = "S3:";
            this.lblScreen3.MouseEnter += new System.EventHandler(this.lblScreen3_MouseEnter);
            this.lblScreen3.MouseLeave += new System.EventHandler(this.lblScreen3_MouseLeave);
            // 
            // lblScreen4
            // 
            this.lblScreen4.AutoSize = true;
            this.lblScreen4.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScreen4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblScreen4.Location = new System.Drawing.Point(108, 236);
            this.lblScreen4.Name = "lblScreen4";
            this.lblScreen4.Size = new System.Drawing.Size(31, 20);
            this.lblScreen4.TabIndex = 24;
            this.lblScreen4.Text = "S4:";
            this.lblScreen4.MouseEnter += new System.EventHandler(this.lblScreen4_MouseEnter);
            this.lblScreen4.MouseLeave += new System.EventHandler(this.lblScreen4_MouseLeave);
            // 
            // lblKeyboardControlsP1
            // 
            this.lblKeyboardControlsP1.AutoSize = true;
            this.lblKeyboardControlsP1.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeyboardControlsP1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblKeyboardControlsP1.Location = new System.Drawing.Point(2, 347);
            this.lblKeyboardControlsP1.Name = "lblKeyboardControlsP1";
            this.lblKeyboardControlsP1.Size = new System.Drawing.Size(189, 20);
            this.lblKeyboardControlsP1.TabIndex = 29;
            this.lblKeyboardControlsP1.Text = "Keyboard controls screen 1:";
            this.lblKeyboardControlsP1.MouseEnter += new System.EventHandler(this.lblKeyboardControlsP1_MouseEnter);
            this.lblKeyboardControlsP1.MouseLeave += new System.EventHandler(this.lblKeyboardControlsP1_MouseLeave);
            // 
            // chkCloseLauncherAfterLaunch
            // 
            this.chkCloseLauncherAfterLaunch.AutoSize = true;
            this.chkCloseLauncherAfterLaunch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.chkCloseLauncherAfterLaunch.Location = new System.Drawing.Point(193, 378);
            this.chkCloseLauncherAfterLaunch.Name = "chkCloseLauncherAfterLaunch";
            this.chkCloseLauncherAfterLaunch.Size = new System.Drawing.Size(15, 14);
            this.chkCloseLauncherAfterLaunch.TabIndex = 31;
            this.chkCloseLauncherAfterLaunch.UseVisualStyleBackColor = false;
            this.chkCloseLauncherAfterLaunch.MouseEnter += new System.EventHandler(this.chkCloseLauncherAfterLaunch_MouseEnter);
            this.chkCloseLauncherAfterLaunch.MouseLeave += new System.EventHandler(this.chkCloseLauncherAfterLaunch_MouseLeave);
            // 
            // lblCloseLauncherAfterLaunch
            // 
            this.lblCloseLauncherAfterLaunch.AutoSize = true;
            this.lblCloseLauncherAfterLaunch.BackColor = System.Drawing.Color.Transparent;
            this.lblCloseLauncherAfterLaunch.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCloseLauncherAfterLaunch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblCloseLauncherAfterLaunch.Location = new System.Drawing.Point(2, 374);
            this.lblCloseLauncherAfterLaunch.Name = "lblCloseLauncherAfterLaunch";
            this.lblCloseLauncherAfterLaunch.Size = new System.Drawing.Size(191, 20);
            this.lblCloseLauncherAfterLaunch.TabIndex = 32;
            this.lblCloseLauncherAfterLaunch.Text = "Close launcher after launch:";
            this.lblCloseLauncherAfterLaunch.MouseEnter += new System.EventHandler(this.lblCloseLauncherAfterLaunch_MouseEnter);
            this.lblCloseLauncherAfterLaunch.MouseLeave += new System.EventHandler(this.lblCloseLauncherAfterLaunch_MouseLeave);
            // 
            // lblSaveSettings
            // 
            this.lblSaveSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblSaveSettings.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaveSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblSaveSettings.Location = new System.Drawing.Point(0, 426);
            this.lblSaveSettings.Name = "lblSaveSettings";
            this.lblSaveSettings.Size = new System.Drawing.Size(108, 31);
            this.lblSaveSettings.TabIndex = 37;
            this.lblSaveSettings.Text = "Save Settings";
            this.lblSaveSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSaveSettings.Click += new System.EventHandler(this.lblSaveSettings_Click);
            this.lblSaveSettings.MouseEnter += new System.EventHandler(this.lblSaveSettings_MouseEnter);
            this.lblSaveSettings.MouseLeave += new System.EventHandler(this.lblSaveSettings_MouseLeave);
            this.lblSaveSettings.MouseHover += new System.EventHandler(this.lblSaveSettings_MouseHover);
            // 
            // cbxScreen1
            // 
            this.cbxScreen1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cbxScreen1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxScreen1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxScreen1.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxScreen1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbxScreen1.FormattingEnabled = true;
            this.cbxScreen1.Items.AddRange(new object[] {
            "1920x1080",
            "1680x945",
            "1600x900",
            "1440x810",
            "1365x768",
            "1360x765",
            "1280x720",
            "1152x648",
            "1024x576",
            "800x450",
            "720x405",
            "640x360"});
            this.cbxScreen1.Location = new System.Drawing.Point(38, 211);
            this.cbxScreen1.Name = "cbxScreen1";
            this.cbxScreen1.Size = new System.Drawing.Size(62, 23);
            this.cbxScreen1.TabIndex = 38;
            this.cbxScreen1.TabStop = false;
            this.cbxScreen1.MouseEnter += new System.EventHandler(this.cbxScreen1_MouseEnter);
            this.cbxScreen1.MouseLeave += new System.EventHandler(this.cbxScreen1_MouseLeave);
            // 
            // cbxScreen2
            // 
            this.cbxScreen2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cbxScreen2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxScreen2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxScreen2.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxScreen2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbxScreen2.FormattingEnabled = true;
            this.cbxScreen2.Items.AddRange(new object[] {
            "1920x1080",
            "1680x945",
            "1600x900",
            "1440x810",
            "1365x768",
            "1360x765",
            "1280x720",
            "1152x648",
            "1024x576",
            "800x450",
            "720x405",
            "640x360"});
            this.cbxScreen2.Location = new System.Drawing.Point(38, 233);
            this.cbxScreen2.Name = "cbxScreen2";
            this.cbxScreen2.Size = new System.Drawing.Size(62, 23);
            this.cbxScreen2.TabIndex = 39;
            this.cbxScreen2.TabStop = false;
            this.cbxScreen2.MouseEnter += new System.EventHandler(this.cbxScreen2_MouseEnter);
            this.cbxScreen2.MouseLeave += new System.EventHandler(this.cbxScreen2_MouseLeave);
            // 
            // cbxScreen4
            // 
            this.cbxScreen4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cbxScreen4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxScreen4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxScreen4.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxScreen4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbxScreen4.FormattingEnabled = true;
            this.cbxScreen4.Items.AddRange(new object[] {
            "1920x1080",
            "1680x945",
            "1600x900",
            "1440x810",
            "1365x768",
            "1360x765",
            "1280x720",
            "1152x648",
            "1024x576",
            "800x450",
            "720x405",
            "640x360"});
            this.cbxScreen4.Location = new System.Drawing.Point(143, 233);
            this.cbxScreen4.Name = "cbxScreen4";
            this.cbxScreen4.Size = new System.Drawing.Size(62, 23);
            this.cbxScreen4.TabIndex = 41;
            this.cbxScreen4.TabStop = false;
            this.cbxScreen4.MouseEnter += new System.EventHandler(this.cbxScreen4_MouseEnter);
            this.cbxScreen4.MouseLeave += new System.EventHandler(this.cbxScreen4_MouseLeave);
            // 
            // cbxScreen3
            // 
            this.cbxScreen3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cbxScreen3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxScreen3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxScreen3.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxScreen3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbxScreen3.FormattingEnabled = true;
            this.cbxScreen3.Items.AddRange(new object[] {
            "1920x1080",
            "1680x945",
            "1600x900",
            "1440x810",
            "1365x768",
            "1360x765",
            "1280x720",
            "1152x648",
            "1024x576",
            "800x450",
            "720x405",
            "640x360"});
            this.cbxScreen3.Location = new System.Drawing.Point(143, 211);
            this.cbxScreen3.Name = "cbxScreen3";
            this.cbxScreen3.Size = new System.Drawing.Size(62, 23);
            this.cbxScreen3.TabIndex = 40;
            this.cbxScreen3.TabStop = false;
            this.cbxScreen3.MouseEnter += new System.EventHandler(this.cbxScreen3_MouseEnter);
            this.cbxScreen3.MouseLeave += new System.EventHandler(this.cbxScreen3_MouseLeave);
            // 
            // cbxAmtInstances
            // 
            this.cbxAmtInstances.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cbxAmtInstances.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAmtInstances.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxAmtInstances.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxAmtInstances.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbxAmtInstances.FormattingEnabled = true;
            this.cbxAmtInstances.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cbxAmtInstances.Location = new System.Drawing.Point(152, 100);
            this.cbxAmtInstances.Name = "cbxAmtInstances";
            this.cbxAmtInstances.Size = new System.Drawing.Size(53, 23);
            this.cbxAmtInstances.TabIndex = 42;
            this.cbxAmtInstances.TabStop = false;
            this.cbxAmtInstances.MouseEnter += new System.EventHandler(this.cbxAmtInstances_MouseEnter);
            this.cbxAmtInstances.MouseLeave += new System.EventHandler(this.cbxAmtInstances_MouseLeave);
            // 
            // chkKeyboardControlsP1
            // 
            this.chkKeyboardControlsP1.AutoSize = true;
            this.chkKeyboardControlsP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.chkKeyboardControlsP1.Location = new System.Drawing.Point(193, 351);
            this.chkKeyboardControlsP1.Name = "chkKeyboardControlsP1";
            this.chkKeyboardControlsP1.Size = new System.Drawing.Size(15, 14);
            this.chkKeyboardControlsP1.TabIndex = 43;
            this.chkKeyboardControlsP1.UseVisualStyleBackColor = false;
            this.chkKeyboardControlsP1.MouseEnter += new System.EventHandler(this.chkKeyboardControlsP1_MouseEnter);
            this.chkKeyboardControlsP1.MouseLeave += new System.EventHandler(this.chkKeyboardControlsP1_MouseLeave);
            // 
            // chkVSync
            // 
            this.chkVSync.AutoSize = true;
            this.chkVSync.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.chkVSync.Location = new System.Drawing.Point(193, 298);
            this.chkVSync.Name = "chkVSync";
            this.chkVSync.Size = new System.Drawing.Size(15, 14);
            this.chkVSync.TabIndex = 47;
            this.chkVSync.UseVisualStyleBackColor = false;
            this.chkVSync.MouseEnter += new System.EventHandler(this.chkVSync_MouseEnter);
            this.chkVSync.MouseLeave += new System.EventHandler(this.chkVSync_MouseLeave);
            // 
            // lblVSync
            // 
            this.lblVSync.AutoSize = true;
            this.lblVSync.BackColor = System.Drawing.Color.Transparent;
            this.lblVSync.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVSync.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblVSync.Location = new System.Drawing.Point(2, 294);
            this.lblVSync.Name = "lblVSync";
            this.lblVSync.Size = new System.Drawing.Size(174, 20);
            this.lblVSync.TabIndex = 46;
            this.lblVSync.Text = "Launch with vertical sync:";
            this.lblVSync.MouseEnter += new System.EventHandler(this.lblVSync_MouseEnter);
            this.lblVSync.MouseLeave += new System.EventHandler(this.lblVSync_MouseLeave);
            // 
            // chkFullscreen
            // 
            this.chkFullscreen.AutoSize = true;
            this.chkFullscreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.chkFullscreen.Location = new System.Drawing.Point(193, 132);
            this.chkFullscreen.Name = "chkFullscreen";
            this.chkFullscreen.Size = new System.Drawing.Size(15, 14);
            this.chkFullscreen.TabIndex = 45;
            this.chkFullscreen.UseVisualStyleBackColor = false;
            this.chkFullscreen.CheckStateChanged += new System.EventHandler(this.chkFullscreen_CheckStateChanged);
            this.chkFullscreen.MouseEnter += new System.EventHandler(this.chkFullscreen_MouseEnter);
            this.chkFullscreen.MouseLeave += new System.EventHandler(this.chkFullscreen_MouseLeave);
            // 
            // lblFullscreen
            // 
            this.lblFullscreen.AutoSize = true;
            this.lblFullscreen.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullscreen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblFullscreen.Location = new System.Drawing.Point(2, 127);
            this.lblFullscreen.Name = "lblFullscreen";
            this.lblFullscreen.Size = new System.Drawing.Size(143, 20);
            this.lblFullscreen.TabIndex = 44;
            this.lblFullscreen.Text = "Launch in fullscreen:";
            this.lblFullscreen.MouseEnter += new System.EventHandler(this.lblFullscreen_MouseEnter);
            this.lblFullscreen.MouseLeave += new System.EventHandler(this.lblFullscreen_MouseLeave);
            // 
            // lblGraphicsSetting
            // 
            this.lblGraphicsSetting.AutoSize = true;
            this.lblGraphicsSetting.BackColor = System.Drawing.Color.Transparent;
            this.lblGraphicsSetting.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGraphicsSetting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblGraphicsSetting.Location = new System.Drawing.Point(2, 269);
            this.lblGraphicsSetting.Name = "lblGraphicsSetting";
            this.lblGraphicsSetting.Size = new System.Drawing.Size(126, 20);
            this.lblGraphicsSetting.TabIndex = 48;
            this.lblGraphicsSetting.Text = "Graphics settings:";
            this.lblGraphicsSetting.MouseEnter += new System.EventHandler(this.lblGraphicsSetting_MouseEnter);
            this.lblGraphicsSetting.MouseLeave += new System.EventHandler(this.lblGraphicsSetting_MouseLeave);
            // 
            // cbxGraphicSetting
            // 
            this.cbxGraphicSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cbxGraphicSetting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGraphicSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxGraphicSetting.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxGraphicSetting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbxGraphicSetting.FormattingEnabled = true;
            this.cbxGraphicSetting.Items.AddRange(new object[] {
            "Low",
            "Medium",
            "High"});
            this.cbxGraphicSetting.Location = new System.Drawing.Point(152, 266);
            this.cbxGraphicSetting.Name = "cbxGraphicSetting";
            this.cbxGraphicSetting.Size = new System.Drawing.Size(53, 23);
            this.cbxGraphicSetting.TabIndex = 49;
            this.cbxGraphicSetting.TabStop = false;
            this.cbxGraphicSetting.MouseEnter += new System.EventHandler(this.cbxGraphicSetting_MouseEnter);
            this.cbxGraphicSetting.MouseLeave += new System.EventHandler(this.cbxGraphicSetting_MouseLeave);
            // 
            // lblTimeBtwnLaunches
            // 
            this.lblTimeBtwnLaunches.AutoSize = true;
            this.lblTimeBtwnLaunches.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeBtwnLaunches.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblTimeBtwnLaunches.Location = new System.Drawing.Point(3, 401);
            this.lblTimeBtwnLaunches.Name = "lblTimeBtwnLaunches";
            this.lblTimeBtwnLaunches.Size = new System.Drawing.Size(166, 20);
            this.lblTimeBtwnLaunches.TabIndex = 50;
            this.lblTimeBtwnLaunches.Text = "Seconds amid launches:";
            this.lblTimeBtwnLaunches.MouseEnter += new System.EventHandler(this.lblTimeBtwnLaunches_MouseEnter);
            this.lblTimeBtwnLaunches.MouseLeave += new System.EventHandler(this.lblTimeBtwnLaunches_MouseLeave);
            // 
            // txtTimeBtwnLaunches
            // 
            this.txtTimeBtwnLaunches.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtTimeBtwnLaunches.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeBtwnLaunches.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTimeBtwnLaunches.Location = new System.Drawing.Point(172, 401);
            this.txtTimeBtwnLaunches.MaxLength = 3;
            this.txtTimeBtwnLaunches.Name = "txtTimeBtwnLaunches";
            this.txtTimeBtwnLaunches.Size = new System.Drawing.Size(34, 20);
            this.txtTimeBtwnLaunches.TabIndex = 51;
            this.txtTimeBtwnLaunches.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimeBtwnLaunches_KeyPress);
            this.txtTimeBtwnLaunches.MouseEnter += new System.EventHandler(this.txtTimeBtwnLaunches_MouseEnter);
            this.txtTimeBtwnLaunches.MouseLeave += new System.EventHandler(this.txtTimeBtwnLaunches_MouseLeave);
            // 
            // lblReloadPlayerFiles
            // 
            this.lblReloadPlayerFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblReloadPlayerFiles.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReloadPlayerFiles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblReloadPlayerFiles.Location = new System.Drawing.Point(108, 426);
            this.lblReloadPlayerFiles.Name = "lblReloadPlayerFiles";
            this.lblReloadPlayerFiles.Size = new System.Drawing.Size(107, 31);
            this.lblReloadPlayerFiles.TabIndex = 52;
            this.lblReloadPlayerFiles.Text = "Reload HOSS";
            this.lblReloadPlayerFiles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblReloadPlayerFiles.Click += new System.EventHandler(this.lblReloadPlayerFiles_Click);
            this.lblReloadPlayerFiles.MouseEnter += new System.EventHandler(this.lblReloadPlayerFiles_MouseEnter);
            this.lblReloadPlayerFiles.MouseLeave += new System.EventHandler(this.lblReloadPlayerFiles_MouseLeave);
            this.lblReloadPlayerFiles.MouseHover += new System.EventHandler(this.lblReloadPlayerFiles_MouseHover);
            // 
            // wkrLoading
            // 
            this.wkrLoading.WorkerReportsProgress = true;
            this.wkrLoading.WorkerSupportsCancellation = true;
            this.wkrLoading.DoWork += new System.ComponentModel.DoWorkEventHandler(this.wkrLoading_DoWork);
            this.wkrLoading.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.wkrLoading_ProgressChanged);
            this.wkrLoading.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.wkrLoading_RunWorkerCompleted);
            // 
            // chkAntiAliasing
            // 
            this.chkAntiAliasing.AutoSize = true;
            this.chkAntiAliasing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.chkAntiAliasing.Location = new System.Drawing.Point(193, 325);
            this.chkAntiAliasing.Name = "chkAntiAliasing";
            this.chkAntiAliasing.Size = new System.Drawing.Size(15, 14);
            this.chkAntiAliasing.TabIndex = 54;
            this.chkAntiAliasing.UseVisualStyleBackColor = false;
            this.chkAntiAliasing.MouseEnter += new System.EventHandler(this.chkAntiAliasing_MouseEnter);
            this.chkAntiAliasing.MouseLeave += new System.EventHandler(this.chkAntiAliasing_MouseLeave);
            // 
            // lblAntiAliasing
            // 
            this.lblAntiAliasing.AutoSize = true;
            this.lblAntiAliasing.BackColor = System.Drawing.Color.Transparent;
            this.lblAntiAliasing.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAntiAliasing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblAntiAliasing.Location = new System.Drawing.Point(2, 321);
            this.lblAntiAliasing.Name = "lblAntiAliasing";
            this.lblAntiAliasing.Size = new System.Drawing.Size(174, 20);
            this.lblAntiAliasing.TabIndex = 53;
            this.lblAntiAliasing.Text = "Launch with anti aliasing:";
            this.lblAntiAliasing.MouseEnter += new System.EventHandler(this.lblAntiAliasing_MouseEnter);
            this.lblAntiAliasing.MouseLeave += new System.EventHandler(this.lblAntiAliasing_MouseLeave);
            // 
            // chkConsoleMode
            // 
            this.chkConsoleMode.AutoSize = true;
            this.chkConsoleMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.chkConsoleMode.Location = new System.Drawing.Point(193, 155);
            this.chkConsoleMode.Name = "chkConsoleMode";
            this.chkConsoleMode.Size = new System.Drawing.Size(15, 14);
            this.chkConsoleMode.TabIndex = 56;
            this.chkConsoleMode.UseVisualStyleBackColor = false;
            this.chkConsoleMode.CheckStateChanged += new System.EventHandler(this.chkConsoleMode_CheckStateChanged);
            this.chkConsoleMode.MouseEnter += new System.EventHandler(this.chkConsoleMode_MouseEnter);
            this.chkConsoleMode.MouseLeave += new System.EventHandler(this.chkConsoleMode_MouseLeave);
            // 
            // lblConsoleMode
            // 
            this.lblConsoleMode.AutoSize = true;
            this.lblConsoleMode.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsoleMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblConsoleMode.Location = new System.Drawing.Point(2, 152);
            this.lblConsoleMode.Name = "lblConsoleMode";
            this.lblConsoleMode.Size = new System.Drawing.Size(169, 20);
            this.lblConsoleMode.TabIndex = 55;
            this.lblConsoleMode.Text = "Launch in console mode:";
            this.lblConsoleMode.MouseEnter += new System.EventHandler(this.lblConsoleMode_MouseEnter);
            this.lblConsoleMode.MouseLeave += new System.EventHandler(this.lblConsoleMode_MouseLeave);
            // 
            // lblConsoleModeOrientation
            // 
            this.lblConsoleModeOrientation.AutoSize = true;
            this.lblConsoleModeOrientation.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsoleModeOrientation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblConsoleModeOrientation.Location = new System.Drawing.Point(2, 180);
            this.lblConsoleModeOrientation.Name = "lblConsoleModeOrientation";
            this.lblConsoleModeOrientation.Size = new System.Drawing.Size(133, 20);
            this.lblConsoleModeOrientation.TabIndex = 57;
            this.lblConsoleModeOrientation.Text = "Game orientations:";
            this.lblConsoleModeOrientation.MouseEnter += new System.EventHandler(this.lblConsoleModeOrientation_MouseEnter);
            this.lblConsoleModeOrientation.MouseLeave += new System.EventHandler(this.lblConsoleModeOrientation_MouseLeave);
            // 
            // cbxConsoleModeOrientation
            // 
            this.cbxConsoleModeOrientation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cbxConsoleModeOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxConsoleModeOrientation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxConsoleModeOrientation.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxConsoleModeOrientation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbxConsoleModeOrientation.FormattingEnabled = true;
            this.cbxConsoleModeOrientation.Items.AddRange(new object[] {
            "Horizontal\t",
            "Vertical"});
            this.cbxConsoleModeOrientation.Location = new System.Drawing.Point(152, 178);
            this.cbxConsoleModeOrientation.Name = "cbxConsoleModeOrientation";
            this.cbxConsoleModeOrientation.Size = new System.Drawing.Size(53, 23);
            this.cbxConsoleModeOrientation.TabIndex = 58;
            this.cbxConsoleModeOrientation.TabStop = false;
            this.cbxConsoleModeOrientation.MouseEnter += new System.EventHandler(this.cbxConsoleModeOrientation_MouseEnter);
            this.cbxConsoleModeOrientation.MouseLeave += new System.EventHandler(this.cbxConsoleModeOrientation_MouseLeave);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(680, 457);
            this.Controls.Add(this.cbxConsoleModeOrientation);
            this.Controls.Add(this.lblConsoleModeOrientation);
            this.Controls.Add(this.chkConsoleMode);
            this.Controls.Add(this.lblConsoleMode);
            this.Controls.Add(this.chkAntiAliasing);
            this.Controls.Add(this.lblAntiAliasing);
            this.Controls.Add(this.lblReloadPlayerFiles);
            this.Controls.Add(this.txtTimeBtwnLaunches);
            this.Controls.Add(this.lblTimeBtwnLaunches);
            this.Controls.Add(this.cbxGraphicSetting);
            this.Controls.Add(this.lblGraphicsSetting);
            this.Controls.Add(this.chkVSync);
            this.Controls.Add(this.lblVSync);
            this.Controls.Add(this.chkFullscreen);
            this.Controls.Add(this.lblFullscreen);
            this.Controls.Add(this.chkKeyboardControlsP1);
            this.Controls.Add(this.cbxAmtInstances);
            this.Controls.Add(this.cbxScreen4);
            this.Controls.Add(this.cbxScreen3);
            this.Controls.Add(this.cbxScreen2);
            this.Controls.Add(this.cbxScreen1);
            this.Controls.Add(this.lblSaveSettings);
            this.Controls.Add(this.lblCloseLauncherAfterLaunch);
            this.Controls.Add(this.chkCloseLauncherAfterLaunch);
            this.Controls.Add(this.lblKeyboardControlsP1);
            this.Controls.Add(this.lblScreen4);
            this.Controls.Add(this.lblScreen3);
            this.Controls.Add(this.lblScreen2);
            this.Controls.Add(this.lblScreen1);
            this.Controls.Add(this.lblAmtInstances);
            this.Controls.Add(this.txtRight);
            this.Controls.Add(this.lblRightTitle);
            this.Controls.Add(this.lblExit);
            this.Controls.Add(this.lblProfiles);
            this.Controls.Add(this.lblLaunch);
            this.Controls.Add(this.lblBlocker5);
            this.Controls.Add(this.lblBlocker4);
            this.Controls.Add(this.lblBlocker3);
            this.Controls.Add(this.lblBlocker2);
            this.Controls.Add(this.lblBlocker1);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblBlakeBoris);
            this.Controls.Add(this.lblTop);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Halo Online Split Screen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.Label lblBlakeBoris;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblBlocker1;
        private System.Windows.Forms.Label lblBlocker2;
        private System.Windows.Forms.Label lblBlocker3;
        private System.Windows.Forms.Label lblBlocker4;
        private System.Windows.Forms.Label lblBlocker5;
        private System.Windows.Forms.Label lblLaunch;
        private System.Windows.Forms.Label lblProfiles;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Label lblRightTitle;
        private System.Windows.Forms.TextBox txtRight;
        private System.Windows.Forms.ToolTip tipDefault;
        private System.Windows.Forms.Label lblAmtInstances;
        private System.Windows.Forms.Label lblScreen1;
        private System.Windows.Forms.Label lblScreen2;
        private System.Windows.Forms.Label lblScreen3;
        private System.Windows.Forms.Label lblScreen4;
        private System.Windows.Forms.Label lblKeyboardControlsP1;
        private System.Windows.Forms.CheckBox chkCloseLauncherAfterLaunch;
        private System.Windows.Forms.Label lblCloseLauncherAfterLaunch;
        private System.Windows.Forms.Label lblSaveSettings;
        private System.Windows.Forms.ComboBox cbxScreen1;
        private System.Windows.Forms.ComboBox cbxScreen2;
        private System.Windows.Forms.ComboBox cbxScreen4;
        private System.Windows.Forms.ComboBox cbxScreen3;
        private System.Windows.Forms.ComboBox cbxAmtInstances;
        private System.Windows.Forms.CheckBox chkKeyboardControlsP1;
        private System.Windows.Forms.CheckBox chkVSync;
        private System.Windows.Forms.Label lblVSync;
        private System.Windows.Forms.CheckBox chkFullscreen;
        private System.Windows.Forms.Label lblFullscreen;
        private System.Windows.Forms.Label lblGraphicsSetting;
        private System.Windows.Forms.ComboBox cbxGraphicSetting;
        private System.Windows.Forms.Label lblTimeBtwnLaunches;
        private System.Windows.Forms.TextBox txtTimeBtwnLaunches;
        private System.Windows.Forms.Label lblReloadPlayerFiles;
        private System.ComponentModel.BackgroundWorker wkrLoading;
        private System.Windows.Forms.CheckBox chkAntiAliasing;
        private System.Windows.Forms.Label lblAntiAliasing;
        private System.Windows.Forms.CheckBox chkConsoleMode;
        private System.Windows.Forms.Label lblConsoleMode;
        private System.Windows.Forms.Label lblConsoleModeOrientation;
        private System.Windows.Forms.ComboBox cbxConsoleModeOrientation;
    }
}