        public void LoadData()
        {
            HttpClient lobj_HTTPClient = null;
            HttpResponseMessage lobj_HTTPResponse = null;
            string ls_Response = "";
            try
            {
                IsDataLoaded = false;
                string ls_WorkLanguageURI = ic_LanguagesAPIUrl;
                //Get the Days of the Week
                lobj_HTTPClient = new HttpClient(new NativeMessageHandler());
                lobj_HTTPClient.BaseAddress = new Uri(App.APIPrefix);
                lobj_HTTPClient.DefaultRequestHeaders.Accept.Clear();
                lobj_HTTPClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //This call will not work
                WebAPICaller lobj_APICaller = new WebAPICaller();
                ls_Response = lobj_APICaller.CallWebService(ls_WorkLanguageURI).Result;
                if (ls_Response.Trim().Length > 0)
                {
                    if (this.Items_ForList != null)
                        this.Items_ForList.Clear();
                    Items_ForList = JsonConvert.DeserializeObject<ObservableCollection<GBSLanguage_ForList>>(ls_Response);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                this.IsDataLoaded = true;
                NotifyPropertyChanged("GBSLanguages_ForList");
            }
        }
