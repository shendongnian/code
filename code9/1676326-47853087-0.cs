    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using System.Drawing;
    
    namespace TextBox
    {
        class Revision
        {
            public string Text { get; set; }
            public int CoursorPosition { get; set; }
        }
    
        class MyForm : Form
        {
            static RichTextBox box = new RichTextBox();
            static List<Revision> revisions = new List<Revision>();
            static bool loading = false;
            
            static void MakeRevision()
            {
                if (loading)
                    return;
                
                revisions.Add(new Revision
                {
                    Text = box.Text,
                    CoursorPosition = box.SelectionStart
                });
            }
    
            public MyForm()
            {
    
                var buttonBack = new Button()
                {
                    Location = new Point(0, 0),
                    Size = new Size(ClientSize.Width, 30),
                    Text = "Back"
                };
    
                box.Size = new Size(ClientSize.Width, 100);
                box.Multiline = true;
                box.Location = new Point(0, buttonBack.Bottom);
                box.TextChanged += (sender, args) => MakeRevision();
                box.MouseDown += (sender, args) => MakeRevision();
    
                Controls.Add(buttonBack);
                Controls.Add(box);
    
                buttonBack.Click += (sender, args) =>
                {
                    loading = true;
                    box.Text = revisions.Last().ToString();
                    revisions.RemoveAt(revisions.IndexOf(revisions.Last()));
                    loading = false;
                };
            }
    
            public static void Main()
            {
                var form = new MyForm();
                Application.Run(form);
            }
        }
    }
