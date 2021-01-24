    public class CardsPanel : Panel
    {
        const int CardWidth = 200;
        const int CardHeight = 150;
        public CardsViewModel ViewModel { get; set; }
        public CardsPanel()
        {
        }
        public CardsPanel(CardsViewModel viewModel)
        {
            ViewModel = viewModel;
            ViewModel.Cards.CollectionChanged += Cards_CollectionChanged;
        }
        private void Cards_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            DataBind();
        }
        public void DataBind()
        {
            SuspendLayout();
            Controls.Clear();
            
            for(int i = 0; i < ViewModel.Cards.Count; i++)
            {
                var newCtl = new CardControl(ViewModel.Cards[i]);
                newCtl.Rebind();
                SetCardControlLayout(newCtl, i);
                Controls.Add(newCtl);
            }
            ResumeLayout();
        }
        void SetCardControlLayout(CardControl ctl, int atIndex)
        {
            ctl.Width = CardWidth;
            ctl.Height = CardHeight;
            //calc visible column count
            int columnCount = Width / CardWidth;
            //calc the x index and y index.
            int xPos = (atIndex % columnCount) * CardWidth;
            int yPos = (atIndex / columnCount) * CardHeight;
            ctl.Location = new Point(xPos, yPos);
        }
    }
    public partial class CardControl : UserControl
    {
        public CardViewModel ViewModel { get; set; }
        public CardControl()
        {
            InitializeComponent();
        }
        public CardControl(CardViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
        }
        public void Rebind()
        {
            SuspendLayout();
            tbAge.Text = ViewModel.Age.ToString();
            tbAge.Name = ViewModel.Name;
            pbPicture.Image = ViewModel.Picture;
            ResumeLayout();
        }
    }
    public class CardsViewModel
    {
        public ObservableCollection<CardViewModel> Cards { get; set; }
    }
    public class CardViewModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Bitmap Picture { get; set; }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cardsPanel1.ViewModel = LoadSomeData();
            cardsPanel1.DataBind();
        }
        private CardsViewModel LoadSomeData()
        {
            ObservableCollection<CardViewModel> cards = new ObservableCollection<CardViewModel>();
            cards.Add(new CardViewModel()
            {
                Age = 1,
                Name = "Dan",
                Picture = new Bitmap(Image.FromFile("C:\\Users\\daniel.rayson\\Pictures\\CuteKitten1.jpg"))
            });
            cards.Add(new CardViewModel()
            {
                Age = 2,
                Name = "Gill",
                Picture = new Bitmap(Image.FromFile("C:\\Users\\daniel.rayson\\Pictures\\CuteKitten1.jpg"))
            });
            cards.Add(new CardViewModel()
            {
                Age = 3,
                Name = "Glyn",
                Picture = new Bitmap(Image.FromFile("C:\\Users\\daniel.rayson\\Pictures\\CuteKitten1.jpg"))
            });
            cards.Add(new CardViewModel()
            {
                Age = 4,
                Name = "Lorna",
                Picture = new Bitmap(Image.FromFile("C:\\Users\\daniel.rayson\\Pictures\\CuteKitten1.jpg"))
            });
            cards.Add(new CardViewModel()
            {
                Age = 5,
                Name = "Holly",
                Picture = new Bitmap(Image.FromFile("C:\\Users\\daniel.rayson\\Pictures\\CuteKitten1.jpg"))
            });            
            CardsViewModel VM = new CardsViewModel()
            {
                Cards = cards
            };
            return VM;
        }
    }
