    public partial class Form1 : Form
    {
        public Player Tom { get; private set; }
        public Player Dan { get; private set; }
    
        this.Tom = new Player()
        {
            name = "Tom",
            goals = 5
        };
    
        this.Dan = new Player()
        {
            name = "Dan",
            goals = 7
        };    
        // The rest of your code
    }
