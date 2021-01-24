    public class Red 
    {
        public TextBox TxtName {get; set; }
    }
    public static class ReusableMethods
    {
        public void WireUp(Red red)
        {
             red.TxtName.Leave += txtName_Leave;
        }
        private void txtName_Leave(object sender, EventArgs e)
        {
            //Do something here
        }
    }
 
    //some other code
    var red1 = new Red() { TxtName = new TextBox() };
    var red2 = new Red() { TxtName = new TextBox() };
    ReusableMethods.WireUp(red1);
    ReusableMethods.WireUp(red2);
