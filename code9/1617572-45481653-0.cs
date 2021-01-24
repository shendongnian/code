    public async void GetJSON()
            {
                try
                {
                    var client = new System.Net.Http.HttpClient();
                    var response = await client.GetAsync("http://x.x.x.x/xample.JSON");
                    string json = await response.Content.ReadAsStringAsync();
                    RootObject rootObject = new RootObject();
                    ListView listViewJson = new ListView();
                    if (json != "")
                    {
                        rootObject = JsonConvert.DeserializeObject<RootObject>(json);
                    }
                    DataTemplate template = new DataTemplate(typeof(TextCell));
                    template.SetBinding(TextCell.TextProperty, "id");
                    template.SetBinding(TextCell.DetailProperty, "fzg_kz");
                    listViewJson.ItemTemplate = template;
                    listViewJson.ItemsSource = rootObject.process;
                    Content = listViewJson;
                }
                catch (InvalidCastException e)
                {
                    throw e;
                }
                ProgressLoader.IsVisible = false;
            }
