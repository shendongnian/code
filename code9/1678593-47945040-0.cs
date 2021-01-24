    public class SlowLabel:Label
    {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer(); // Ticks now and then
        
        IEnumerator<char> text = null; // holds the characters that still need to show up
        
        static Random r = new Random(); // guarantee randomness
        
        public SlowLabel()
        {
            timer.Interval = r.Next(30,60);       // when is the next tick
            timer.Enabled = false;                // let's not start now
            timer.Tick += (s,e) => {              // do one character
                base.Text += text.Current;        // Current has charactwer to Add
                timer.Interval = r.Next(30,60);   // random next run 
                timer.Enabled = text.MoveNext();  // or we stop if no more charcters
            };
        }
       
        public override string Text 
        {
           set
           {
              text = value.GetEnumerator();       // get the charcters to process
              base.Text = String.Empty;           // start empty
              timer.Enabled = text.MoveNext();    // tell the timer to start 
           }
        }
    }
