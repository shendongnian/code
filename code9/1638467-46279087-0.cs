    public class Form1 : Form
    {
        private Timer updateTimer;
    
        public Form1()
        {
            updateTimer = new Timer();
            updateTimer.Tick += new EventHandler(FixedUpdate);
            updateTimer.Interval = 30000; //Time in miliseconds (30 seconds)
            updateTimer.Start();
        }
        
        private void FixedUpdate(object sender, EventArgs e)
        {
            //Destroy your form first time it thicks after N time
        }
    }
