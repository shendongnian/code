            int howMany = 1000000;
            Color c1 = Color.Red;
            Color c2 = Color.Green;
            string c3 = "FF0000";
            string c4 = "00FF00";
            // Compare using Color object
            long startLoop1 = DateTime.Now.Ticks;
            for (int i = 0; i < howMany; i++)
            {
                bool response = ColorChanged1(c1, c2);
            }
            long endLoop1 = DateTime.Now.Ticks;
            // Compare strings
            long startLoop2 = DateTime.Now.Ticks;
            for (int i = 0; i < howMany; i++)
            {
                bool response = ColorChanged2(c3, c4);
            }
            long endLoop2 = DateTime.Now.Ticks;
            TimeSpan ts1 = new TimeSpan(startLoop1 - endLoop1);
            TimeSpan ts2 = new TimeSpan(startLoop2 - endLoop2);
            string result = "";
            result += "Compare Color objects" + Environment.NewLine;
            result += "Total seconds: " + ts1.TotalSeconds.ToString() + Environment.NewLine;
            result += "" + Environment.NewLine;
            result += "Compare strings " + Environment.NewLine;
            result += "Total seconds: " + ts2.TotalSeconds.ToString() + Environment.NewLine;
            this.textBox1.Text = result;
        }
        bool ColorChanged1(Color a, Color b)
        {
            return a.ToArgb() != b.ToArgb();
        }
        bool ColorChanged2(string a, string b)
        {
            return a != b;
        }
