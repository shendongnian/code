    public class SecondLevelForm : Form
    {
        public SecondLevelForm(IProvider provider):base()
        {
             _data = provider.GetObject<MyEntity>();
        }
    }
