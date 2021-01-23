    private void MouseClicker()
        {
            int i = 0;
            while (true)
            {
                Thread.Sleep(100);
                while (threadStatus)
                {
                    if (repeatTimes)
                    {
                        while (startbutton.Enabled == false)
                        {
                            int x = Cursor.Position.X;
                            int y = Cursor.Position.Y;
                            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, x, y, 0, 0);
                        }
                    }
                    else if (randomInterval)
                    {
                        while (startbutton.Enabled == false)
                        {
                            int li = Convert.ToInt32(Math.Round(lowerintervalvalue.Value, 0));
                            int hi = Convert.ToInt32(Math.Round(higherintervalvalue.Value, 0));
                            int x = Cursor.Position.X;
                            int y = Cursor.Position.Y;
                            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, x, y, 0, 0);
                            Random rand = new Random();
                            Thread.Sleep(rand.Next(li, hi));
                        }
                    }
                }
            }
        }
