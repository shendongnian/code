        return user.Roles
            .Select(r => r.Name).ToList<string>()
            .Select(str =>
            {
                QARoles qarole;
                bool success = System.Enum.TryParse(str, out qarole);
                return new { qarole, success };
            })
            .Where(pair => pair.success)
            .Select(pair => pair.qarole)
            .ToList();
