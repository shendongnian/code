    public static class MyQueryExtension
    {
    	public static IQueryable<Answer> GetAnswersByLanguageCode(this IQueryable<Answer> query, string languageCode, string search)
    	{ 
    		return query.Where(w => (w.AnswerTranslations.Any(a => languageCode == a.LanguageCode)
    					 ? w.AnswerTranslations.FirstOrDefault(a => languageCode == a.LanguageCode).Label
    					 : w.AnswerTranslations.OrderBy(o => o.Language.Priority).FirstOrDefault().Label)
    					 .ToUpper().Replace(" ", "")
    						 .Contains(search))
    	}
    }
