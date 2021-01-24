    IList<string> all = new List<string>();
            foreach (var element in Gdriver.FindElements(By.ClassName("search-title")))
            {
                all.Add(element.Text);
                table.Rows.Add(element.Text);
            }
