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
                Console.WriteLine(tabControl.SelectedIndex.ToString());
                if (e.KeyCode == Keys.Left)
                {
                    if (tabControl.TabIndex > 0)
                        tabControl.TabIndex  -= 1;
                }
                else if (e.KeyCode == Keys.Right)
                {
                    int numberOfPages = tabControl.TabPages.Count;
                    if (tabControl.TabIndex < numberOfPages - 1)
                        tabControl.TabIndex  += 1;
                    
                }
            }
        }
    }
