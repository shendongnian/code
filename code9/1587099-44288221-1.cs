        string runTest()
        {
            int howMany = 1000000;
            Color c1 = Color.Red;
            Color c2 = Color.Green;
            string c3 = "FF0000";
            string c4 = "00FF00";
            string result = "";
            Stopwatch sw = new Stopwatch();
            // Compare using Color object
            sw.Start();
            for (int i = 0; i < howMany; i++)
            {
                bool response = ColorChanged1(c1, c2);
            }
            sw.Stop();
            result += "Compare Color objects" + Environment.NewLine;
            result += "Elapsed: " + sw.Elapsed.ToString() + Environment.NewLine;
            result += "" + Environment.NewLine;
            // Compare strings
            sw.Reset();
            sw.Start();
            for (int i = 0; i < howMany; i++)
            {
                bool response = ColorChanged2(c3, c4);
            }
            sw.Stop();
            result += "Compare strings" + Environment.NewLine;
            result += "Elapsed: " + sw.Elapsed.ToString() + Environment.NewLine;
            result += "" + Environment.NewLine;
            return result;
        }
        bool ColorChanged1(Color a, Color b)
        {
            return a.ToArgb() != b.ToArgb();
        }
        bool ColorChanged2(string a, string b)
        {
            return a != b;
        }
