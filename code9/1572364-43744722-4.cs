        void t_Tick(object sender, EventArgs e)
        {
            foreach (var dateTime in _times)
            {
                TimeSpan ts = dateTime.Subtract(DateTime.Now);
                // etc..
            }
        }
