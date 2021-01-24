    private void MWebClient_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            RunOnUiThread(() =>
            {
                try
                {
                    string json = Encoding.UTF8.GetString(e.Result);
                    articles = JsonConvert.DeserializeObject<JavaList<RootObject>>(json);
                    mAdapter = new ArticleAdapterCostum(this, articles);
                    mListView.Adapter = mAdapter;
                }
                catch (Exception exception)
                {
                    Toast.MakeText(this, " Vueillez verifier votre connexion a internet puis reessayer ", ToastLength.Short).Show();
                }
            });
        }
