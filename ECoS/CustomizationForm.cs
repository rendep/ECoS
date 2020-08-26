using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECoS
{
    public partial class CustomizationForm : Form
    {
        private ECoSManager ecosManager = Globals.ThisAddIn.ecosManager;
        private CustomComment currentSelectedComment = null;
        private int currentSelectedIndex = -1;

        public Action formWillDisappear = null;

        public CustomizationForm()
        {
            InitializeComponent();
            this.updateListBox();
            this.updateUI();
        }

        private void updateListBox()
        {
            this.customizationListBox.Items.Clear();
            for (int i = 0; i < this.ecosManager.GetCustomCommentCount(); i++)
            {
                CustomComment customComment = ecosManager.GetCustomComment(i);
                this.customizationListBox.Items.Add(customComment.title);
            }
        }

        private void updateUI()
        {
            if (this.customizationListBox.SelectedIndex >= 0)
            {
                CustomComment selectedComment = ecosManager.GetCustomComment(this.customizationListBox.SelectedIndex);
                this.deleteButton.Enabled = true;
                this.titleTextBox.Enabled = true;
                this.titleTextBox.Text = selectedComment.title;
                this.commentTextBox.Enabled = true;
                this.commentTextBox.Text = selectedComment.comment;
                this.referenceTextBox.Enabled = true;
                this.referenceTextBox.Text = selectedComment.referenceURL;
            }
            else
            {
                this.deleteButton.Enabled = false;
                this.titleTextBox.Enabled = false;
                this.titleTextBox.Text = "";
                this.commentTextBox.Enabled = false;
                this.commentTextBox.Text = "";
                this.referenceTextBox.Enabled = false;
                this.referenceTextBox.Text = "";
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            CustomComment newComment = new CustomComment();
            newComment.title = this.ecosManager.getNewCustomCommentDefaultTitle();
            this.ecosManager.AddCustomComment(newComment);
            this.customizationListBox.Items.Add(newComment.title);
            this.customizationListBox.SelectedIndex = this.customizationListBox.Items.Count - 1;
            this.updateUI();
            this.titleTextBox.Focus();
            this.titleTextBox.SelectAll();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (this.customizationListBox.SelectedIndex >= 0)
            {
                int index = this.customizationListBox.SelectedIndex;
                this.ecosManager.RemoveCustomComment(index);
                this.customizationListBox.Items.RemoveAt(index);
                if (index >= 0 && index < this.customizationListBox.Items.Count)
                {
                    this.customizationListBox.SelectedIndex = index;
                }
                else if (index == this.customizationListBox.Items.Count)
                {
                    this.customizationListBox.SelectedIndex = index - 1;
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.ecosManager.saveToFile();
            if (this.formWillDisappear != null)
            {
                this.formWillDisappear();
            }
            this.Close();
        }

        private void customizationListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.customizationListBox.SelectedIndex >= 0)
            {
                this.currentSelectedComment = this.ecosManager.GetCustomComment(this.customizationListBox.SelectedIndex);
                this.currentSelectedIndex = this.customizationListBox.SelectedIndex;
            } else
            {
                this.currentSelectedComment = null;
                this.currentSelectedIndex = -1;
            }
            this.updateUI();
        }

        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.currentSelectedComment != null)
            {
                this.currentSelectedComment.title = this.titleTextBox.Text;
                this.customizationListBox.Items[this.currentSelectedIndex] = this.titleTextBox.Text;
                this.titleTextBox.Focus();
                this.titleTextBox.Select(this.titleTextBox.Text.Length, 0);
            }
        }

        private void commentTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.currentSelectedComment != null)
            {
                this.currentSelectedComment.comment = this.commentTextBox.Text;
            }
        }

        private void referenceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.currentSelectedComment != null)
            {
                this.currentSelectedComment.referenceURL = this.referenceTextBox.Text;
            }
        }

        private void CustomizationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.ecosManager.saveToFile();
            if (this.formWillDisappear != null)
            {
                this.formWillDisappear();
            }
        }
    }
}
