    public void Save(MyModel m)
    {
        using (var conn = Databases.DB)
        {
            var d = new DynamicParameters(new
            {
                m.Name
            });
            conn.Execute("INTRANET__CreateTicket", d, commandType: CommandType.StoredProcedure);
            //send push notifications in BackgroundThread
            Thread sendInBackground = new Thread(new ParametrizedThreadStart(SendRaisedTicketNotifications));
            sendInBackground.IsBackground = true;
            sendInBackground.Start(m);
        }
     }
    private void SendRaisedTicketNotifications(NewAmbercatTicketView t)
    {
		//Send push notifications
		var sub = new Subscritption();
		var people = UserRepository.List();
		foreach (var person in people)
		foreach (var sub in UserPushRepository.List().Where(x => x.PersonId == person.PersonId && x.Subscribed))
		{
			var notification = new PushNotification("Some content")
			notification.SendPushNotification(sub);
		}
     } 
