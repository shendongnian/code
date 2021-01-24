    public abstract class SurveyViewPage<TModel> : System.Web.Mvc.WebViewPage<TModel>
    {
        public string Phrases(string Phrase)
        {
            return SomeHelper.Phrases(Phrase);
        }
    }
    
    public static class SomeHelper
    {
    	public static string Phrases(string Phrase)
        {
            List<MultilanguagePhrasesVM> List_Multilanguage = StaticCacheLocaleStringResource.CheckForCachedPhrases();
            var PhraseValue = List_Multilanguage.Where(m => m.LanguagePhrase == Phrase).FirstOrDefault();
    
            if (PhraseValue == null)
            {
                return Phrase;
            }
            else
            {
                return PhraseValue.LanguagePhrase_Value;
            }
        }
    }
