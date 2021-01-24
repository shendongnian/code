    public class TopLevelForm : Form
    {
        public TopLevelForm(IProvider provider):base()
        {
             _provider = provider;
        }
    
        private void ShowSecondForm()
        {
            var f2 = new SecondForm(provider);
            f2.Show();
        }
    }
