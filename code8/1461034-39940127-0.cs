            List<string> ListMessage = new List<string>();
            ListMessage.Add("In order to bet 'High' press the 'ALT' Key and the 'H' key at the same time.");
            ListMessage.Add("In order to bet 'Low' press the 'ALT' Key and the 'L' key at the same time.");
            ListMessage.Add("In order to reduce the bet's value in half  press the 'ALT' Key and the 'H' key at the same time.");
            //Solution 1
            MessageBox.Show(string.Join(Environment.NewLine, ListMessage));
            //Solution 2 => Add using System.Linq
            MessageBox.Show(ListMessage.Aggregate((x, y) => x + Environment.NewLine + y));
