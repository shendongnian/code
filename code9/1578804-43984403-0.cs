    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication28
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                this.tabControl1.KeyDown +=new KeyEventHandler(Tab_KeyDown);
            }
            private void Tab_KeyDown(object sender, KeyEventArgs e)
            {
                TabControl tabControl = sender as TabControl;
                
                if (e.KeyCode == Keys.Left)
                {
                    if (tabControl.SelectedIndex > 0)
                        tabControl.SelectedIndex -= 1;
                }
                else if (e.KeyCode == Keys.Right)
                {
                    int numberOfPages = tabControl.TabPages.Count;
                    if (tabControl.SelectedIndex < numberOfPages - 1)
                        tabControl.SelectedIndex += 1;
                    
                }
            }
        }
    }
