    class Exemys {
    
        public static string ConnectAndGetMessage() {
            // Here your code! ;)
            return mensaje;
        }
    }
    class FormWithTextbox {
    
        private void FormWithLabel_Load(object sender, System.EventArgs e)
        {
            Textbox1.Text = Exemys.ConnectAndGetMessage();
        }
    }
