        var items = from item in table
                    group item by new { item.AlphabeticCode, item.Currency } into g
                    select new { Value = g.Key.AlphabeticCode, Text = g.Key.AlphabeticCode + " - " + g.Key.Currency }; 
         //Fluent or inline 
         table.
               GroupBy(i => new { i.AlphabeticCode, i.Currency }).
               Select(g => new { Value = g.Key.AlphabeticCode, Text = g.Key.AlphabeticCode + " - " + g.Key.Currency });
