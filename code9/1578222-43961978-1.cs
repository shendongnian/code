    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            private List<string> _remove;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                length(_remove);
            }
    
            public List<string> noDup(List<string> myList)
            {
                var convert = myList.ConvertAll(i => i.ToLower());
                _remove = convertLower.Distinct().ToList();
                
            }
    
            public List<string> length(List<string> myList)
            {
                int i = int.Parse(lengthSearch.Text);
                List<string> temp = new List<string>();
    
                foreach (string item in myList)
                {
                    if (item.Length == i)
                    {
                        temp.Add(item);
                    }
                }
                searchResult.Text = string.Join(",", temp);
            }
        }
    }
