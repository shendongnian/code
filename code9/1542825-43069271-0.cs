     public TestViewModel()
        {
            language = new List<Languages>() {new Languages{Name="English",Code="en-GB"},
                                                                  {new Languages{Name="Welsh", Code="cy-GB"}}};
            //SelectedLanguage = language.FirstOrDefault();
            //PreviousLanguage = selectedLanguage;
        }
