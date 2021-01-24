            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                var words = s.Split(' ');
                var sb = new StringBuilder();
                var pw = 0d;
                foreach (var word in words)
                {
                    var lw = Math.Floor(g.MeasureString($"{sb.ToString()} {word}", f).Width / w);
                    if (lw != pw)
                    {
                        sb.Append($"{Environment.NewLine}{word} ");
                        pw = lw;
                    }
                    else
                    {
                        sb.Append($"{word} ");
                    }
                }
                return sb.ToString();
            }
