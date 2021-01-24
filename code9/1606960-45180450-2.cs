            Regex regex = new Regex("<(?<tag>[a-zA-Z]+?)>(?<html>.+)</\\1>", RegexOptions.Compiled);
            using (System.IO.StreamReader sr = new System.IO.StreamReader("./figure.htm", Encoding.UTF8))
            {
                string html = sr.ReadToEnd();
                int i = 1;
                string newHtml = regex.Replace(html, new MatchEvaluator((m) =>
                {
                    string tag = m.Groups["tag"].Value;
                    string text = m.Groups["html"].Value;
                    if (tag.ToLower() == "figcaption")
                    {
                        return $"<{tag}>Fig. {i++} - {text}</{tag}>";
                    }
                    return m.Value;
                }));
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter("./figure1.htm", false, Encoding.UTF8))
                {
                    sw.Write(newHtml);
                    sw.Flush();
                }
            }
