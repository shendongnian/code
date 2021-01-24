	public async Task<List<SomeModel>> SomeMethod(DateTime? fromDate, DateTime? toDate) {
		var totals = new List<SomeModel>();
		var clientswithpayments = _db.Clients.Select(client => new {
			client.Username,
			payments = await _db.Payments.Where(pay => pay.ClientId == client.Id).Where(p =>
				DateTime.Compare(p.TradeDate, (DateTime)fromDate) >= 0 &&
				DateTime.Compare(p.TradeDate, (DateTime)toDate) <= 0)
		}).ToListAsync();
		foreach (var client in clientswithpayments) {
			var totalsByCust = new SomeModel { Username = client.Username };
			foreach (var payment in client.payments) {
				totalByCust.Bcf += payment.Bcf;
				totalByCust.Ecn += payment.Ecn;
				totalByCust.Ecbt += payment.Ecbt;
				totalByCust.OpenGl += payment.OpenGl;
				totalByCust.JeyK += payment.JeyK;
			}
			totals.Add(totalByCust);
		}
		return totals;
	}
