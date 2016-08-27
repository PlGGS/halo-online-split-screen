using System;
using System.Drawing;
using System.Windows.Forms;

namespace Halo_Online_Split_Screen
{
    public partial class frmLoading : Form
    {

        /// <summary>
        /// Gets or sets the value of the Message displayed on the form.
        /// </summary>
        public string Message
        {

            get { return lblMessage.Text; }
            set { lblMessage.Text = value; }

        }

        /// <summary>
        /// Gets or sets the progress bar's progress.
        /// </summary>
        public int ProgressValue
        {
            get { return barLoading.Value; }
            set { barLoading.Value = value; }

        }

        public frmLoading()
        {

            this.ControlBox = false;
            InitializeComponent();

        }

        private void frmLoading_Load(object sender, EventArgs e)
        {

            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - this.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2 - this.Bounds.Height / 2);

        }

        public event EventHandler<EventArgs> Canceled;
        private void lblCancel_Click(object sender, EventArgs e)
        {
            
            Canceled?.Invoke(this, e);

        }
        
        private void lblCancel_MouseEnter(object sender, EventArgs e)
        {

            lblCancel.BackColor = Color.FromArgb(25, 25, 25);

        }

        private void lblCancel_MouseLeave(object sender, EventArgs e)
        {

            lblCancel.BackColor = Color.FromArgb(35, 35, 35);

        }

        private void lblCancel_MouseHover(object sender, EventArgs e)
        {

            tipDefault.Show("Cancels the operations and closes the application.", this.lblCancel);

        }
        
    }

}
