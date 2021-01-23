    public class MyListView : 
        System.Windows.Forms.ListView
    {
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.Style |= 0x8000; // LVS_NOSORTHEADER
                return cp;
            }
        }
    }
