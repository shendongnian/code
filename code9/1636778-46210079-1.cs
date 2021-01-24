    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    
    namespace StackAnswer
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void GetTextButton_Click(object sender, System.EventArgs e)
            {
                var source = File.ReadAllLines("C:\\Users\\User\\Desktop\\Test.txt");
    
                MainListBox.Items.Clear();
    
                List<string> result = new List<string>();
                for (int i = 0; i < source.Length; i++)
                {
                    if (source[i].StartsWith("D")
                        && !source[i - 1].StartsWith("D"))
                    {
                        result.Add(source[i - 2]);
                        result.Add(source[i - 1]);
                        result.Add(source[i]);
                    }
                    else if (source[i].StartsWith("D"))
                    {
                        result.Add(source[i]);
                    }
                }
                MainListBox.Items.AddRange(result.ToArray());
            }
        }
    }
