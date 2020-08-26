using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ECoS
{
    public partial class FeedbackForm : Form
    {
        private bool like;

        public FeedbackForm(bool like)
        {
            InitializeComponent();
            this.like = like;
            if (like)
            {
                this.mainLabel.Text = "What did you like?";
                this.pictureBox3.Image = global::ECoS.Properties.Resources.IconLike_256;
            }
            else
            {
                this.mainLabel.Text = "Is there something we can do better?";
                this.pictureBox3.Image = global::ECoS.Properties.Resources.IconDislike_256;
            }

            this.updateUI();
        }

        private void updateUI()
        {
            string emptyPattern = @"^\s*$";
            Regex emptyRegex = new Regex(emptyPattern);
            bool isBodyEmpty = emptyRegex.IsMatch(this.mainTextBox.Text);

            string emailPattern = @"^[\w\.\+\-]+@[\w\-]+\.[\w\.\-]+$";
            Regex emailRegex = new Regex(emailPattern);
            bool isEmailValid = emailRegex.IsMatch(this.emailTextBox.Text);

            this.sendButton.Enabled = !isBodyEmpty && isEmailValid;
        }

        private void mainTextBox_TextChanged(object sender, EventArgs e)
        {
            this.updateUI();
        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            this.updateUI();
        }
    }
}
