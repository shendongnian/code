    public class Main : Form {
 
        public void Whatever() {
            ...
            new Helpers( this ).HelperMethod();
        }
    }
    public class Helpers {
 
        private Form Form { get; set; }
        public Helpers( Form form ) {
            this.Form = form;
        }
        public void HelperMethod() {
            ...
            this.Form.Controls.Find
        }
    }
