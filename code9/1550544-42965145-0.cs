    protected override async void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.conversation_list_activity);
        listViewConversationList = FindViewById<ListView>(Resource.Id.listViewConversationPreview);
        await Task.Run(async() => {
			string url = ConstantManager.HOST;
			HttpClient oHttpClient = new HttpClient();
			string resultString = oHttpClient.GetAsStringAsync(new Uri(url));
			listConversationPreview = 
				Newtonsoft.Json.JsonConvert.DeserializeObject<List<ConversationPreview>>(resultString);
			ConversationAdapter adapter = new ConversationAdapter(this, listConversationPreview);
			RunOnUiThread(() => listViewConversationList.Adapter = adapter);
			listViewConversationList.ItemClick += listViewConversationList_ItemClick;
        }
    }
