    static TextTemplateTypeEnum GetTemplate(string client,ReasonEnum reason)
    {
        string reasonString = Enum.GetName(typeof(ReasonEnum), reason);
        string enumToSearch = reasonString + client;
        var template = Enum.GetNames(typeof(TextTemplateTypeEnum))
                    .Where(x => x.Contains(enumToSearch))
                    .OrderByDescending(o => o.Substring(o.Length - 1, 1))
                    .FirstOrDefault();
        if (template == null)
        {
            template = Enum.GetNames(typeof(TextTemplateTypeEnum))
                            .Where(x => x.StartsWith(reasonString) && x[reasonString.Length]=='V')
                            .OrderByDescending(o => o.Substring(o.Length - 2, 2))
                            .FirstOrDefault();
        }
        return (TextTemplateTypeEnum)Enum.Parse(typeof(TextTemplateTypeEnum), template);
    }
