    foreach (var language in installedLanguages)
    {
        if (savedItem.Language.Name != language.Name)
        {
            var otherLanguageItem = savedItem.Database.GetItem(savedItem.ID, language);
            if (otherLanguageItem.Versions.Count == 0)
            {
                otherLanguageItem.Versions.AddVersion();
            }
        }
    }
