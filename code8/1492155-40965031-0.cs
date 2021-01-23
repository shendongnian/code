	var uids = listBox2.Item.Cast<String>().ToArray();
	var query =
		from uid in uids.ToObservable()
		from jsonstring in Observable.Start(() => GetEmails(uid, token))
		where jsonstring != null
		select new { uid, jsonstring };
	IDisposable subscription =
		query
			.ObserveOn(this)
			.Subscribe(x =>
			{
				label6.Text = " Current UID: " + listBox2.Items.IndexOf(x.uid);
				dynamic jsonResponse = JsonConvert.DeserializeObject(x.jsonstring);
				string idstt = jsonResponse["email"];
				if (idstt != null)
				{
					listBox3.Items.Add(idstt);
					label4.Text = "Total Emails: " + listBox3.Items.Count.ToString();
				}
			});
