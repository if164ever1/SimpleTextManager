using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WFA_Menu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;
        }

        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("chrome.exe");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.Enabled)
            {
                FileManager.SaveFile(textBox1.Text, listBox1.SelectedItem.ToString(), true);
                ClearMethod();
            }
            else
                EnterName();
           
        }
        
        public void EnterName()
        {
            groupBox1.Enabled = true;
            groupBox1.Visible = true;
            textBox2.Enabled = true;
            MessageBox.Show("Enter NAme");
        }

        void ClearMethod()
        {
            textBox2.Clear();
            textBox2.Enabled = false;
            textBox1.Clear();
            textBox1.Enabled = false;
            groupBox1.Visible = false;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                FileManager.SaveFile(textBox1.Text, textBox2.Text + ".txt", false);
                ClearMethod();
            }
            else
            {
                MessageBox.Show("Enter name");
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetFilesName();
            listBox1.Enabled = true;
            listBox1.Visible = true;
        }

        void GetFilesName()
        {
            listBox1.Items.Clear();

            listBox1.Items.AddRange(FileManager.GetFiles());
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string buff = listBox1.SelectedItem.ToString();
            if (!String.IsNullOrEmpty(buff))
            {
                textBox1.Text = FileManager.OpenFile(buff);

                textBox1.Enabled = true;
            }
        }
    }
}
