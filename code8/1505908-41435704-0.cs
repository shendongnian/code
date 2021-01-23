            using (var ms = new MemoryStream())
            {
                ze.Extract(ms);
                ms.Position = 0;
                using (var sr = new StreamReader(ms))
                {
                    bool adding = false;
                    string startTag = "<someTag>";
                    string endTag = "</someTag>";
                    StringBuilder text = new StringBuilder();
                    while (sr.Peek() >= 0)
                    {
                        string tmp = sr.ReadLine();
                        if (!adding && tmp.Contains(startTag))
                        {
                            adding = true;
                        }
                        if (adding)
                        {
                            text.Append(tmp);
                        }
                        if (tmp.Contains(endTag))
                            break;
                    }
                    xmlText = text.ToString();
                }
            }
