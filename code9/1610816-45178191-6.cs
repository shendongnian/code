            foreach (Assembly b in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type t in b.GetTypes())
                {
                    var a = Attribute.GetCustomAttribute(t, typeof(TemplateAttribute));
                    if (a != null)
                    {
                        var localType = t; //Avoid closure on loop variable
                        _templateList.Add(t.Name, () => Activator.CreateInstance(localType) as BaseTemplate);
                    }
                }
            }
