        var document = new HtmlDocument();
        document.LoadHtml(firsturlpagesource);
        var cssTags = document.DocumentNode.SelectNodes("//link");
        if (cssTags != null)
        {
            urlcsscountlbl.Text = ""; //numbers of css
            urlcssdetailslbl.Text = ""; // url of css files
            int count = 0;
            foreach (var sitetag in cssTags)
            {
                if (sitetag.Attributes["href"] != null && sitetag.Attributes["href"].Value.Contains(".css"))
                {
                    count++;
                    firsturlcssdetailslbl.Text += sitetag.Attributes["href"].Value + "<br />";                
                }
            }
            urlcsscountlbl.Text = count.ToString();
        }
