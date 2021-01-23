     i.Mappings(m =>
                       m.Map<SearchItem>(map =>
                           map.AutoMap().Properties(p =>
                               p.Text(s => s.Name(n => n.Description).Analyzer("snowball"))
                               .Nested<SearchFilter>(
                               n=>n.Name(nn=>nn.Filters)
                                   .Properties(pr => pr
                                       .Keyword(t => t.Name(nn => nn.Attribute))
                                       .Keyword(t => t.Name(nn => nn.Group)))
                               )    
                               ))));
