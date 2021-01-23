    public class Form1 : Form {
       protected Form Sibling { get; set; }
       
       public Form1() {
          Sibling = new Form2(this);
       }
       protected override void OnLoad(...) {
          Sibling.Show();
       }
       
        private void Button1_Click(...) {
           Sibling.TextBox1.Text = this.textBox1.Text;
        }
    
       protected class Form2 : Form {
          protected Form Sibling { get; set; }
          
          public Form1 ( Form mySibling ) {
             Sibling = mySibling;
          }
          
           private void Button1_Click(...) {
              Sibling.TextBox1.Text = this.textBox1.Text;
           }
       } // Form2
    } // Form1
