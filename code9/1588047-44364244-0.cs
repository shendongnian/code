            foreach (var item in ProductList)
            {
                var dict = new Dictionary<string, object>();
                dict["Name"] = item.Name;
                dict["Category"] = item.Category;
                dict["Region"] = item.Region;
                foreach (var i in item.PriceList)
                {
                    dict[i.Year] = i.Amount;
                }
                list.Add(dict);
            }
