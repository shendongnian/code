    struct Verse
    {
        public int Number { get; private set; }
        public string Text { get; private set; }
        public Verse(int number, string text) : this() 
        {
          this.Number = number;
          this.Text = text;
        }
    }
