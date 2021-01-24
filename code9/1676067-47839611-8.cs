    public interface ISpecialMethod{
        void SpecialMethod();
    }
    public class SpecialPanel :Panel, ISpecialMethod {
        public void SpecialMethod() {
            /* custom logic*/
        }
    }
    private void button_click(object sender, System.EventArgs e)
    {
        var pnl = sender as ISpecialMethod ;
        if (pnl != null)
            pnl.SpecialMethod();
    }
