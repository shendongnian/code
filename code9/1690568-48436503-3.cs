            string text = "This is a printing test!";
            Font stringFont = new Font("Arial", 16);
            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                var sb = new StringBuilder();
                foreach (var c in text.ToArray())
                {
                    var l = g.MeasureString(sb.Append(c).ToString(), stringFont);
                    if (l.Width >= 100)
                    {
                        sb.Append(Environment.NewLine);
                    }
                    Console.WriteLine($"String: {sb.ToString()} Length: {l.Width.ToString()}");
                }
            }
