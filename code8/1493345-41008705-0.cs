    public partial class form2 : Form
    {
        private int _heroChoice;
        public int HeroChoosen
        {
            get { return _heroChoice; }
            set { _heroChoice = value; }
        }
        // constructor
        public form2(int selectedItem)
        {
           HeroChoosen = selectedItem;
           // Now you can use HeroChoosen 
        }
        // Rest of codes here
    }
