    private static T GetsDetails<T>(XNode content)
    {
        if(typeof(T) == typeof(ProjectDetails)){
            var element = content.XPathSelectElement("document/employee/projects/project");
            return (T)new Projects
            {
                Id = element.GetElementAsString("id"),
                Price = element.GetElementAsString("price"),
                Product = element.GetElementAsString("product")
            };
        }
        else if(typeof(T) == typeof(ProfessionalDetails){ ... } 
        else if (...) {...}
    }
