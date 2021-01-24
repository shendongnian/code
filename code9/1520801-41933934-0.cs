            DateTime now = DateTime.Now;
            TimeSpan t = new TimeSpan(0, 0, 0, 5); // Spin for atleast 5 seconds
            DateTime end = now + t;
            
            while (DateTime.Now < end)
            {
                spin.animation();
            }
