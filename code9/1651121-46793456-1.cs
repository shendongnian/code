    public class Main : Form {
 
        public void Whatever() {
            ...
            new Helpers().HelperMethod( this );
        }
    }
    public class Helpers {
 
        public void HelperMethod( Form form ) {
            ...
            form.Controls.Find
        }
    }
