        private void mainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            System.Windows.Point thepnt = new System.Windows.Point();
            thepnt = e.GetPosition(myElement1);
            if (((thepnt.X<=100)|| (thepnt.X > myElement1.Width)) || (thepnt.Y < 100))
            {
               //do something...
            }
            else
            {
               //do something else....
            }
        }
