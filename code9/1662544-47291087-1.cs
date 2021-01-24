    class BlinkMe
    {
        public static Label BlinkedLabel;
        public static int milisec = 500;
        public delegate void BlinkDel();
        public static bool IsBlinking { get; set; } = true;
        public static void Blink()
        {
    
            while (IsBlinking)
            {
                System.Threading.Thread.Sleep(milisec);
                BlinkedLabel.Invoke(new BlinkDel(DoBLink));
            }
        }
    
        public static void DoBLink()
        {
            if (BlinkedLabel.BackColor != Color.Yellow)
            {
                BlinkedLabel.BackColor = Color.Yellow;
            }
            else
            {
                BlinkedLabel.BackColor = Color.Green;
            }
        }
    }
