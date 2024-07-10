using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TextEditor
{
    public partial class Form1 : Form
    {
        private bool isTextChanged = false;

        public Form1()
        {
            InitializeComponent();
            richTextBox1.TextChanged += RichTextBox1_TextChanged;
            this.FormClosing += Form1_FormClosing;
        }



        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            if (isTextChanged && ConfirmUnsavedChanges())
            {
                return;
            }

            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Title = "Open a file";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Clear();
                using (StreamReader sr = new StreamReader(openfile.FileName))
                {
                    richTextBox1.Text = sr.ReadToEnd();
                    sr.Close();
                }
                isTextChanged = false;
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Title = "Save a file";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                StreamWriter txtoutput = new StreamWriter(savefile.FileName);
                txtoutput.Write(richTextBox1.Text);
                txtoutput.Close();
                isTextChanged = false;
            }
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newToolStripButton.PerformClick();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newToolStripButton.PerformClick();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveToolStripButton.PerformClick();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            isTextChanged = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isTextChanged)
            {
                var result = MessageBox.Show("You have unsaved changes. Do you really want to exit without saving?","Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    e.Cancel = true; 
                }
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            if (isTextChanged && ConfirmUnsavedChanges())
            {
                return;
            }
            richTextBox1.Clear();
            isTextChanged = false;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isTextChanged && ConfirmUnsavedChanges())
            {
                return;
            }
            Application.Exit();
        }
        private bool ConfirmUnsavedChanges()
        {
            var result = MessageBox.Show("You have unsaved changes. Do you really want to exit without saving?","Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return result == DialogResult.No;
        }
    }
}
