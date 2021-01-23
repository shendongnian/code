    using Newtonsoft.Json;
    using System;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                //InitializeComponent();
                var newsButton = new Button { Parent = this, Text = "Show" };
                newsButton.Click += NewsButton_Click;
            }
            private void NewsButton_Click(object sender, EventArgs e)
            {
                DialogResult result;
                do
                {
                    using (var newsForm = new NewsForm())
                        result = newsForm.ShowDialog();
                } while (result == DialogResult.OK);
            }
        }
        class NewsForm : Form
        {
            TextBox newsTextBox;
            MonthCalendar monthCalendar;
            Button continueButton;
            Button finishButton;
            Nachrichten_Felder news;
            public NewsForm()
            {
                Width = 400;
                newsTextBox = new TextBox { Parent = this, Multiline = true, Size = new Size(200, 200) };
                monthCalendar = new MonthCalendar { Parent = this, Location = new Point(220, 0), MaxSelectionCount = 1 };
                continueButton = new Button { Parent = this, Text = "Continue", Location = new Point(200, 220), DialogResult = DialogResult.OK };
                finishButton = new Button { Parent = this, Text = "Finish", Location = new Point(300, 220), DialogResult = DialogResult.Cancel };
                news = new Nachrichten_Felder();
                newsTextBox.DataBindings.Add("Text", news, "Nachrichten");
                monthCalendar.DataBindings.Add("SelectionStart", news, "Datum");
                this.FormClosing += NewsForm_FormClosing;
            }
        
            private void NewsForm_FormClosing(object sender, FormClosingEventArgs e)
            {
                string json = JsonConvert.SerializeObject(news, Formatting.Indented);
                File.AppendAllText(@"news.txt", json);
            }
        }
        class Nachrichten_Felder
        {
            public string Nachrichten { get; set; }
            public DateTime Datum { get; set; }
        }
    }
