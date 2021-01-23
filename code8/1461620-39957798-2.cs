    var query = from c in context.Sec_Questions
                where c.IsActive == true
                select new {
                    c.ID, 
                    c.QuestionType,
                    c.Title, 
                    c.ControlName,
                    c.IsNumberOnly,
                    c.Maxlenghth,
                    Options = c.Options.Select(o => new { o.ID, o.Title }),
                    c.IsMultiple,
                    c.ControlID,
                    c.HelpText,
                    c.IsRequired };
