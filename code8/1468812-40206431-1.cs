    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
    public partial class Form1 : Form
    {
        bool m_CloseApp = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {if (m_CloseApp == false) { 
           e.Cancel = true;
        this.WindowState = FormWindowState.Minimized;
        }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_CloseApp = true;
            this.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.WindowState = FormWindowState.Minimized;
        }
    }
    }
