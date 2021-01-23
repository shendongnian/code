     var q = context.Items;
            if (!string.IsNullOrEmpty(make))
            {
                q = q.Where(m => m.make == make);
            }
            if (!string.IsNullOrEmpty(model))
            {
                q = q.Where(m => m.model == model);
            }
            //. . .
            var results = q.ToList();
