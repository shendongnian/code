    string elementString = element.Text;
                String[] subStrings = elementString.ToLower().Split(new[] { textBox2.Text.ToLower() }, StringSplitOptions.None);
                if (subStrings.Count() >= 2)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(subStrings[0]);
                    sb.Append("<color=#0193C6>" + textBox2.Text + "</color>");
                    sb.Append(subStrings[1]);
                    for (int i = 2; i < subStrings.Count(); i++)
                        sb.Append(textBox2.Text + subStrings[i]);
                    element.Text = sb.ToString();
                }
