    // Load the recipe
                XDocument doc = XDocument.Load(@"C:\test\Recipes\Recipes.xml");
                string response = "420100-199";
    
                //Note If you know the result should contain 0 or 1 elements, you can use FirstOrDefault() instead of ToList();
                var results = (from c in doc.Descendants("recipe")
                               from f in c.Descendants("partnumber")
                               where Regex.IsMatch(response ,WildcardToRegex((string)f.Attribute("value")))
                               select c).ToList();
    
    
                if (results.Count == 0)
                {
                    MessageBox.Show("No Recipe Found  ");
                    return;
                }
    
                else if(results.Count > 1)
                {
                    MessageBox.Show("Error: More than 1 recipe matches the part number");
    
                }
    
                else
                {
                    textBox_recipe.Text = string.Format("{0}", results[0].Element("recipename").Attribute("value").Value);
                }
