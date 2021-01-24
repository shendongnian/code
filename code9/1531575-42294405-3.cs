    // Code to read templateText here
    
    Template.NamingConvention = new CSharpNamingConvention();
    Template template = Template.Parse(templateText);
    
    // Code to read values
    
    PersonTemplateInfo personTemplateInfo = new PersonTemplateInfo
    {
        Name = name,
        Feeling = feeling
    };
    
    string parsedText = template.Render(Hash.FromAnonymousObject(new {personTemplateInfo = personTemplateInfo }));
