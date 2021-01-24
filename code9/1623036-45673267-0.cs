    using System.Windows.Forms;
    
    namespace myform
    {
        class Program
        {
            static void Main(string[] args)
            {
                Form myform = new Form();
                Button mybutton = new Button()
                {
                    Text = "Hello",
                    Location = new System.Drawing.Point(10, 10)
                };
                mybutton.Click += (o, s) =>
                {
                    MessageBox.Show("world");
                };
    
                myform.Controls.Add(mybutton);
                myform.ShowDialog();
    
                while (myform.Created)
                {
    
                }
            }
        }
    }
