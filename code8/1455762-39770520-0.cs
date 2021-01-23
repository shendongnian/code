            string longestName = "";
            comboBox1.Items.Add("aaa ddd ddd");
            comboBox1.Items.Add("aaa");
            comboBox1.Items.Add("aaa ff");
            comboBox1.Items.Add("aaa x");
            foreach (string possibleDate in comboBox1.Items)
            {
                int stringLength = possibleDate.Length;
                if (stringLength > longestName.Length)
                    longestName = possibleDate;
            }
            Console.WriteLine(longestName);
            //or:
            string longest = comboBox1.Items.Cast<string>().OrderByDescending(a => a.Length).FirstOrDefault();
