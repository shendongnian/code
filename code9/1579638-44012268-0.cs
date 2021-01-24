            List<String> finalList = new List<string>();
            bool insideHtml = false;
            StringBuilder sb = new StringBuilder();
            string[] test = "<div style=\"text - align:right; \">test1 <strong>test2 </div>".Split(' ');
            foreach (string t in test)
            {
                if (t.Contains("<"))
                {
                    sb.Append(" " + t);
                    insideHtml = true;
                    if (t.Contains(">"))
                    {
                        finalList.Add(sb.ToString());
                        sb.Clear();
                        insideHtml = false;
                    }
                }
                else if (t.Contains(">"))
                {
                    sb.Append(" " + t);
                    finalList.Add(sb.ToString());
                    sb.Clear();
                    insideHtml = false;
                }
                else
                {
                    if (insideHtml)
                    {
                        sb.Append(" " + t);
                    }
                    else
                    {
                        finalList.Add(t);
                    }
                }
            }
