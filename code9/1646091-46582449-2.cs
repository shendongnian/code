    public void OnInit([GeneratedEnum] OperationResult status)
    {
        if (status.Equals(OperationResult.Success))
        {
            foreach (var locale in speaker.AvailableLanguages)
            {
                Log.Debug(TAG, locale.Language); // review all the languages available
                if (locale.Language == "pl")
                    speaker.SetLanguage(locale);
            }
            speaker.Speak("jak się masz?", QueueMode.Flush, null, null);
        }
        else
            Log.Error(TAG, status.ToString());
    }
