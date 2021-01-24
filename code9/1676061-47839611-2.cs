    public interface ISpecialMethod{
        void SpecialMethod();
    }
    public class SpecialPanel :Panel, ISpecialMethod {
        public void SpecialMethod() {
            /* custom logic*/
        }
    }
    void Main()
    {
        var pnl1 = new SpecialPanel ();
        pnl1.Click += button_click;
        var pnl2 = new SpecialPanel ();
        pnl2.Click += button_click;
        // fire the event, note that the panel instance is the sender
        pnl1.OnClick(null);
        pnl2.OnClick(null);
    }
    private void button_click(object sender, System.EventArgs e)
    {
        var pnl = sender as ISpecialMethod ;
        if (pnl != null)
            pnl.SpecialMethod();
    }
