    void TextToSpeech.IOnInitListener.OnInit(OperationResult status)
        {
            // if we get an error, default to the default language
            if (status == OperationResult.Error)
                textToSpeech.SetLanguage(Java.Util.Locale.Default);
            // if the listener is ok, set the lang
            if (status == OperationResult.Success)
            {
                langAvailable = new List<string> { "Default" };
                localesAvailable = Java.Util.Locale.GetAvailableLocales().ToList();
                foreach (var locale in localesAvailable)
                {
                    LanguageAvailableResult res = textToSpeech.IsLanguageAvailable(locale);
                    switch (res)
                    {
                        case LanguageAvailableResult.Available:
                            langAvailable.Add(locale.DisplayLanguage);
                            break;
                        case LanguageAvailableResult.CountryAvailable:
                            langAvailable.Add(locale.DisplayLanguage);
                            break;
                        case LanguageAvailableResult.CountryVarAvailable:
                            langAvailable.Add(locale.DisplayLanguage);
                            break;
                    }
                }
                langAvailable = langAvailable.OrderBy(t => t).Distinct().ToList();
                var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, langAvailable);
                spinLanguages.Adapter = adapter;
                textToSpeech.SetLanguage(lang);
            }
        }
