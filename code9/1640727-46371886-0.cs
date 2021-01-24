    class Exemys {
    
        public static string ConnectAndGetMessage() {
            // Here your code! ;)
            return mensaje;
        }
    }
    class FormWithLabel {
    
        private void FormWithLabel_Load(object sender, System.EventArgs e)
        {
            MyLabel.text = Exemys.ConnectAndGetMessage();
        }
    }
