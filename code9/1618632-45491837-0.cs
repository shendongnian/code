    public partial class Form1 : Form
    {
        // Some text to display in a scrolling label
        private const string MarqueeText = 
            "Hello, this is a long string of text that I will show only a few characters at a time. ";
        private const int NumCharsToDisplay = 10; // The number of characters to display
        private int marqueeStart;                 // The start position of our text
        private Label lblMarquee;                 // The label that will show the text
        private void Form1_Load(object sender, EventArgs e)
        {
            // Add a label for displaying the marquee
            lblMarquee = new Label
            {
                Width = 12 * NumCharsToDisplay,
                Font = new Font(FontFamily.GenericMonospace, 12),
                Location = new Point {X = 0, Y = 0},
                Visible = true
            };
            Controls.Add(lblMarquee);
            // Add a timer to control our marquee and start it
            var timer = new System.Windows.Forms.Timer {Interval = 100};
            timer.Tick += Timer_Tick;
            timer.Start();            
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Figure out the length of text to display. 
            // If we're near the end of the string, then we display the last few characters
            // And the balance of characters are taken from the beginning of the string.
            var startLength = Math.Min(NumCharsToDisplay, MarqueeText.Length - marqueeStart);
            var endLength = NumCharsToDisplay - startLength;
            lblMarquee.Text = MarqueeText.Substring(marqueeStart, startLength);
            if (endLength > 0) lblMarquee.Text += MarqueeText.Substring(0, endLength);
            // Increment our start position
            marqueeStart++;
            // If we're at the end of the string, start back at the beginning
            if (marqueeStart > MarqueeText.Length) marqueeStart = 0;            
        }
        public Form1()
        {
            InitializeComponent();
        }
    }
