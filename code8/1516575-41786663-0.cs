    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private Card[] _cards;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                // build your array of cards
                Card[] cards =
                {
                    new Card
                    {
                        Path = "ace_heart.png",
                        Name = "Ace Of Hearts"
                    }
                    // etc ...
                };
    
                // load their bitmaps
                foreach (var card in cards)
                {
                    card.Bitmap = new Bitmap(card.Path);
                }
    
                // keep a reference
                _cards = cards;
            }
    
            private int GetRandomCardIndex(int seed)
            {
                var random = new Random(seed);
                var next = random.Next(52);
                return next;
            }
    
            private void Demo()
            {
                var cardIndex = GetRandomCardIndex(1234);
                var card = _cards[cardIndex];
                var cardName = card.Name; // there you are
                var cardBitmap = card.Bitmap;
            }
        }
    
        internal class Card
        {
            public Bitmap Bitmap;
            public string Name;
            public string Path;
        }
    }
