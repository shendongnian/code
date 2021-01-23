            YamlMappingNode mapping = (YamlMappingNode)yaml.Documents[0].RootNode;
            foreach (var entry in mapping.Children)
            {
                int categoryID = Int32.Parse(entry.Key.ToString());
                YamlMappingNode params = (YamlMappingNode)entry.Value;
                foreach (var param in params.Children)
                {
                    string paramName = param.Key.ToString();
                    // Assign value to parameter.
                    if(paramName == "name")
                        name = param.Value.ToString();
                }
            }
