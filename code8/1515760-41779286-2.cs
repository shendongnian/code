        public class DoDataTextBox
        {
            public static void AutoCompleteStringBuild(TextBox textBox)
            {
                string endResult = null;
                string replace = Reverse(textBox.Text).Replace(",", "");
                int count = 1;
                char[] value = replace.ToCharArray();
                foreach (var car in value)
                {
                    if (count % 3 == 0)
                    {
                        endResult = String.Concat(endResult, car);
                        if (value.Length != count)
                        {
                            endResult = String.Concat(endResult, ",");
                        }
                        count++;
                    }
                    else
                    {
                        endResult = String.Concat(endResult, car);
                        count++;
                    }
                }
                if (endResult == null) return;
                string textBoxResult = Reverse(endResult);
                textBox.Text = textBoxResult;
            }
            public static string Reverse(string stringVal)
            {
                char[] charArray = stringVal.ToCharArray();
                Array.Reverse(charArray);
                return new string(charArray);
            }
            public static void IsDeleteKey(TextBox textBox, KeyEventArgs e)
            {
                textBox.SelectionStart = e.Key == Key.Delete ? 0 : textBox.Text.Length;
            }
        } 
