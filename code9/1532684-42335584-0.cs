    class UserControl1 {
        public string SomeCoolTextValue {
            get {
                return textBox2.Text;
            }
            set {
                textBox2.Text = value;
            }
        }
    }
    
    class Form1 {
        private void bunifuImageButton9_Click(object sender, EventArgs e) {
            userControl1.SomeCoolTextValue = "some new value";
        }
    }
