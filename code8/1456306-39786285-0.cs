    public static List<string> FetchImgsFromSource(string htmlSource)
            {
                List<string> listOfImgdata = new List<string>();
                string regexImgSrc = @"<img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>";
                MatchCollection matchesImgSrc = Regex.Matches(htmlSource, regexImgSrc, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                foreach (Match m in matchesImgSrc)
                {
                    string href = m.Groups[1].Value;
                    links.Add(href);
                }
                return listOfImgdata;
            }
