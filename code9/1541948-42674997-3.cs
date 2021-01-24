	public class BackLinkApp : Application
	{
		readonly Realm realm;
		readonly IRealmCollection<MessageThread> allMessageThreads;
		readonly Button addMessageThread;
		readonly Button addMessageToThread;
		IRealmCollection<MessageThread> currentMessageThread;
		string currentMessageThreadPriKey;
		public BackLinkApp()
		{
			realm = Realm.GetInstance("backlinks.realm");
			allMessageThreads = (IRealmCollection<MessageThread>)realm.All<MessageThread>();
			var messageCell = new DataTemplate(typeof(TextCell));
			messageCell.SetBinding(TextCell.TextProperty, "Body");
			messageCell.SetBinding(TextCell.DetailProperty, "Guid");
			var messageListView = new ListView
			{
				ItemTemplate = messageCell,
			};
			var threadCell = new DataTemplate(typeof(TextCell));
			threadCell.SetBinding(TextCell.TextProperty, "Guid");
			var messageThreadListView = new ListView
			{
				ItemsSource = allMessageThreads,
				ItemTemplate = threadCell
			};
			messageThreadListView.ItemSelected += (sender, e) =>
			{
				currentMessageThreadPriKey = (messageThreadListView.SelectedItem as MessageThread).Guid;
				currentMessageThread = (IRealmCollection<MessageThread>)realm.All<MessageThread>().Where((messageThread) => messageThread.Guid == currentMessageThreadPriKey);
				messageListView.ItemsSource = currentMessageThread?.FirstOrDefault()?.Messages;
				addMessageToThread.IsEnabled = currentMessageThread?.Count() > 0;
			};
			addMessageThread = new Button { Text = "Add New MessageThread" };
			addMessageThread.Clicked += (sender, e) =>
			{
				realm.Write(() =>
				{
					var messageThread = new MessageThread { Guid = Guid.NewGuid().ToString() };
					realm.Add(messageThread);
				});
			};
			addMessageToThread = new Button { Text = "Add New Message to Thread", IsEnabled = false };
			addMessageToThread.Clicked += (sender, e) =>
			{
				realm.Write(() =>
				{
					currentMessageThread = (IRealmCollection<MessageThread>)realm.All<MessageThread>().Where((messageThread) => messageThread.Guid == currentMessageThreadPriKey);
					var counter = currentMessageThread.FirstOrDefault().Messages.Count() + 1;
					var message = new Message { Guid = Guid.NewGuid().ToString(), Body = $"StackoverFlow:{counter}" };
					currentMessageThread?.FirstOrDefault()?.Messages.Add(message);
				});
			};
			MainPage = new ContentPage
			{
				Content = new StackLayout
				{
					VerticalOptions = LayoutOptions.Center,
					Children = {
						addMessageThread, messageThreadListView, addMessageToThread, messageListView
					}
				}
			};
		}
	}
