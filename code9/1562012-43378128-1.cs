            string mainURL = "your url";
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load(mainURL);
            var tables = doc.DocumentNode.Descendants("table").Where(_ => _.Descendants("table").Any());//this will give you all tables which contain another table inside
            foreach (var table in tables)
            {
                var rows = table.ChildNodes.Where(_ => _.Name.Equals("tr"));//get all tr children (not grand children)
                foreach (var row in rows)
                {
                    for (int i = 0; i < row.ChildNodes.Count; i++)
                    {
                        if (row.ChildNodes[i].Name.Equals("td"))
                        {
                            //you can put your logic here, for eg i == 0, assign it to TeamID properties etc...
                        }
                        if (row.ChildNodes[i].Name.Equals("table"))
                        {
                            //here is your logic to handle nested table
                        }
                    }
                }
            }
