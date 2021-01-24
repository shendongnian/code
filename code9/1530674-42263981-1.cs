    public class TestClass
    {
        public void myLoop()
        {
            for (int i = 1; i <= 1000; i++)
            {
                // show value of i to label
                form1.label1.Text = i.ToString();
                // allow message pumping to redraw the label
                Application.DoEvents();
                // pause long enough to see it before the next one happens
                System.Threading.Thread.Sleep(100);
            }
        }
    }
