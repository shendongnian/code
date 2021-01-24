                engine.Evaluate("x<-c(1:10)");
                string[] text = engine.Evaluate("x").AsCharacter().ToArray();
                StringBuilder builder = new StringBuilder();
                foreach (string value in text)
                {
                    builder.Append(value);
                }
                richTextBox1.Text = builder.ToString();
