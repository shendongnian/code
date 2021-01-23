    //You have to fill this variable (e.g. in constructor) with a reference to the object of you form
    public Form3 refF3;    
       
    public void test() {
         foreach (Control ctrl in refF3.Controls) {
                if (ctrl.GetType() == typeof(Button) && ((Button)ctrl).Tag == tagcheck) {
                    ((Button)ctrl).BackgroundImage = Properties.Resources.inactive;
                {
          }
    }
 
