name = Regex.Replace(name, @"([A-Z])([A-Z]+|[a-z0-9_]+)($|[A-Z]\w*)",
            m =>
            {
                return m.Groups[1].Value.ToLower() + m.Groups[2].Value.ToLower() + m.Groups[3].Value;
            });
