            PoissonFullTime obj = new PoissonFullTime();
            var propertyInfos = obj.GetType().GetProperties();
            foreach(var prop in propertyInfos)
            {
                prop.SetValue(obj, Math.Round((double)prop.GetValue(obj), 2));
            }
