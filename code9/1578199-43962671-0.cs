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
            public Form1()
            {
                InitializeComponent();
            }
            public Dictionary<string, int> occurrenceDictionary = new Dictionary<string, int>();
            public string functionOne(List<string> myList)
            {
                string maxKey = "";
                foreach (string item in myList)
                {
                    if (!occurrenceDictionary.ContainsKey(item))
                    {
                        occurrenceDictionary.Add(item, 1);
                    }
                    else
                    {
                        occurrenceDictionary[item]++;
                    }
                }
                return maxKey;
            }
            public int word_search(Dictionary<string, int> myDict)
            {
                if(myDict != null)
                {
                    if (myDict.ContainsKey(wordSearch.Text))
                    {
                        
                    }
                    else
                    {
                        
                    }
                }
                else
                {
                    
                }
                return 1;
             }
            private void buttonSearch_Click(object sender, EventArgs e)
            {
                occurrenceDictionary.Add("hello", 1);
            }
        }
    }
