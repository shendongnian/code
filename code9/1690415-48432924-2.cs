    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                var webBrowser = new WebBrowser();
    
                webBrowser.DocumentCompleted += (s, ea) =>
                {
                    var mydoc = webBrowser.Document;
                    var gonFromJS = mydoc.InvokeScript("eval", new object[] { "JSON.stringify(gon.books_jsonarray)" }).ToString();
                    var gonObject = JsonConvert.DeserializeObject<List<Books>>(gonFromJS);
                };
    
                var myurl = "http://localhost/test.html";
                webBrowser.Navigate(myurl);
            }
    
            private class Books
            {
                public string Title { get; set; }
                public List<string> Authors { get; set; }
                public int Edition { get; set; }
                public int Year { get; set; }
            }
        }
    }
