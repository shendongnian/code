        private string GetPropertiesString(Properties properties)
        {
            StringBuilder test = new StringBuilder();
            foreach (Property property in properties)
            {
                try
                {
                    test.AppendLine(property.Name + ":=" + property.Value.ToString());
                    Console.WriteLine(property.Name + ":=" + property.Value.ToString());
                }
                catch (Exception ex)
                {
                    var x = ex.Message;
                }
            }
            return test.ToString();
        }
        private void MenuItemCallback(object sender, EventArgs e)
        {
            DTE2 dte2 = Package.GetGlobalService(typeof(DTE)) as DTE2;
            var sol = dte2.Solution;
            var projs = sol.Projects;
            foreach (var proj in sol)
            {
                var project = proj as Project;
                var rows = project.ConfigurationManager.ConfigurationRowNames as IEnumerable<object>;
                foreach (var row in rows)
                {
                    var config = project.ConfigurationManager.ConfigurationRow(row.ToString()).Item(1) as Configuration;
                    string configs = GetPropertiesString(config.Properties);
                }
            }
        }
