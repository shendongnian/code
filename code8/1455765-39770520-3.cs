            foreach (MyClass possibleDate in comboBox1.Items)
            {
                int stringLength = comboBox1.GetItemText(possibleDate).Length;
                if (stringLength > longestName.Length)
                    longestName = comboBox1.GetItemText(possibleDate);
            }
