    OriginalText.Select(ot=> new OriginalText {
       TextValue = ot.CustomText.Any()? ot.CustomText.FirstOrDefault().TextValue:ot.TextValue,
       ID = ot.ID,
       LanguageId = ot.LanguageId,
       Key = ot.Key
    });
