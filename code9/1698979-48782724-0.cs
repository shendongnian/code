    public class TextInput : Form
    {
        public TextBox TxtBox {
            get; private set;
        }
    
        public Control Container {
            get; private set;
        }
        
        public TextForm(Control c, int a, int b, int c, int d, string e)
        {
            this.Container = c;
            this.TxtBox = new TextBox();
    
            var txtBox1 = this.TxtBox;
            txtBox1.Visible = true;
            c.Controls.Add(txtBox1);
            txtBox1.Focus();
            txtBox1.Size = new Size(a, b);
            txtBox1.Location = new Point(c, d);
            txtBox1.Text = (e).ToString();
            txtBox1.Visible = true;
        }
    }
