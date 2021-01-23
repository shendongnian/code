    public partial class Form1 : Form
    {
        // this is just to make the code work 
        List<int> zeichnungen = Enumerable.Range(0, 19).ToList();
        private int count;
        public int Count
        {
            get { return count; }
            set
            {
                // if you are inside the bounds
                if (value >= 0 && value <= 19)
                {
                    count = value;
                    // enable the forward and backward button
                    switchButtons();
                }
                else
                {   // you are out of bounds, so check at which side
                    // and enable accordingly
                    manageButtons(value);
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
        }
        
