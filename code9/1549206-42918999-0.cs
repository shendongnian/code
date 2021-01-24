	IObservable<Customer> GetCustomers(string url)
	{
		Func<JObject, IObservable<Customer>> createCustomers = jo => { ... };
		return Observable.Create<Customer>(o =>
		{
			var final_url = url + "\\customers";
			return
				Observable
					.While(
						() => final_url != url,
						Observable
							.Using(
								() => new HttpClient(),
								client =>
									from x in Observable.FromAsync(() => client.GetAsync(final_url))
									from y in Observable.Start(() =>
									{
										x.EnsureSuccessStatusCode();
										return x;
									})
									from z in Observable.FromAsync(() => y.Content.ReadAsStringAsync())
									from w in Observable.Start(() =>
									{
										var j = JObject.Parse(z);
										final_url = url + j.Property("nextRecords").Value;
										return createCustomers(j);
									})
									from v in w
									select v))
					.Subscribe(o);
		});
	}
