            foreach (Assembly b in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type t in b.GetTypes().OfType<BaseTemplate>())
                {
                    var a = Attribute.GetCustomAttribute(t, typeof(TemplateAttribute));
                    if (a != null)
                    {
                        _templateList.Add(t.Name, () => Activator.CreateInstance(t) as BaseTemplate);
                    }
                }
            }
