    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Windows.Forms;    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private System.Windows.Forms.TextBox textBox1;
            private System.Windows.Forms.ListView listView1;
            private System.Windows.Forms.Button button1; 
   
            public Form1()
            {
                InitializeComponent();
            }   
 
            class MyListViewItem : ListViewItem
            {
                public int Index { get; set; }
            }  
            private void button1_Click(object sender, EventArgs e)
            {
                List<MyListViewItem> myList = new List<MyListViewItem>();
    
                FolderBrowserDialog result = new FolderBrowserDialog();
                if (result.ShowDialog() == DialogResult.OK)
                {
                    string[] files = Directory.GetFiles(result.SelectedPath);
                    foreach (string item in files)
                    {
                        int count = Regex.Matches(Regex.Escape(item.ToLower()), textBox1.Text.ToLower()).Count;
                        myList.Add(new MyListViewItem() { Text = item, Index = count });
                    }
                }
                
                List<ListViewItem> list = new List<ListViewItem>();
                foreach (var item in myList.OrderByDescending(m => m.Index).ToList())
                {
                    list.Add(new ListViewItem() { Text = item.Text });
                }
    
                listView1.Items.AddRange(list.ToArray());
            }
        }
    }
