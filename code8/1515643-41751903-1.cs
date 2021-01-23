    public class Form1 : Form {
        
        protected override void OnLoad(...) {
            
            Program.Form2.Show();
            
        }
        
        private void Button1_Click(...) {
            
            Program.Form2.TextBox1.Text = this.textBox1.Text;
        }
    }
    
