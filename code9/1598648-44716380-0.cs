    //Declare EventHandler outside of class
    public delegate void MyEventHandler(object source, Report r);
    
    public class UserControlA
    {
        public event MyEventHandler OnShowReport;
    
        private void btnShowReport_Click(object sender, Report r)
        {
             OnShowReport?.Invoke(this, this.Report);
        }
    }
