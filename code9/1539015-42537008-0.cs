            if (!string.IsNullOrEmpty(options.English))
            {
                var s = options.English.Trim(); 
                query = query.Where(w => { return s.StartsWith("^") ? 
                    w.English.StartsWith(s.Substring(1)) : w.English.Contains(s); });
            }
