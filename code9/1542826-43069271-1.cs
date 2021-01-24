     private void ddlLanguage_SelectionChanged(object sender, RoutedEventArgs e)
        {
            #region Method body
            var indx = ddlLanguage.ItemsSource;
            string previousLang = "";
            foreach (var item in indx)
            {
                switch (ddlLanguage.SelectedIndex)
                {
                    case 0:
                        ddlLanguage.SelectedItem = "English";
                        vm.SelectedLanguage.Code = "en-GB";
                        previousLang = "cy-GB";
                         var currentResourceDictionary = (from d in BaseModel.Instance.ImportCatalog.ResourceDictionaryList
                                                             where d.Metadata.ContainsKey("Culture")
                                                             && d.Metadata["Culture"].ToString().Equals(vm.SelectedLanguage.Code)
                                                             select d).SingleOrDefault();
                           
                                if (currentResourceDictionary != null)
                                {
                                    var previousResourceDictionaryE = (from d in BaseModel.Instance.ImportCatalog.ResourceDictionaryList
                                                                       where d.Metadata.ContainsKey("Culture")
                                                                       && d.Metadata["Culture"].ToString().Equals(previousLang)
                                                                       select d).SingleOrDefault();
                                    if (previousResourceDictionaryE != null && previousResourceDictionaryE != currentResourceDictionary)
                                    {
                                        Application.Current.Resources.MergedDictionaries.Add(currentResourceDictionary.Value);
                                        CultureInfo cultureInfo = new CultureInfo(vm.SelectedLanguage.Code);
                                        Thread.CurrentThread.CurrentCulture = cultureInfo;
                                        Thread.CurrentThread.CurrentUICulture = cultureInfo;
                                        Application.Current.MainWindow.Language = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag);
                                        previousLang = vm.SelectedLanguage.Code;
                                    }
                                }
                           
                        
                      
                        break;
                    case 1:
                        ddlLanguage.SelectedItem = "Welsh";
                       
                            vm.SelectedLanguage.Code = "cy-GB";
                            previousLang = "en-GB";
                            var currentResourceDictionaryE = (from d in BaseModel.Instance.ImportCatalog.ResourceDictionaryList
                                                             where d.Metadata.ContainsKey("Culture")
                                                             && d.Metadata["Culture"].ToString().Equals(vm.SelectedLanguage.Code)
                                                             select d).SingleOrDefault();
                            if (currentResourceDictionaryE != null)
                            {
                                if (currentResourceDictionaryE != null)
                                {
                                    var previousResourceDictionaryE = (from d in BaseModel.Instance.ImportCatalog.ResourceDictionaryList
                                                                      where d.Metadata.ContainsKey("Culture")
                                                                      && d.Metadata["Culture"].ToString().Equals(previousLang)
                                                                      select d).SingleOrDefault();
                                    if (previousResourceDictionaryE != null && previousResourceDictionaryE != currentResourceDictionaryE)
                                    {
                                        Application.Current.Resources.MergedDictionaries.Add(currentResourceDictionaryE.Value);
                                        CultureInfo cultureInfo = new CultureInfo(vm.SelectedLanguage.Code);
                                        Thread.CurrentThread.CurrentCulture = cultureInfo;
                                        Thread.CurrentThread.CurrentUICulture = cultureInfo;
                                        Application.Current.MainWindow.Language = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag);
                                        previousLang = vm.SelectedLanguage.Code;
                                    }
                                }
                            }
                        
                     break;
                }
            }
           
           
            #endregion Method body
        }
