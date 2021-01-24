	public async Task<List<SomeModel>> SomeMethod2(DateTime? fromDate, DateTime? toDate) {
		var totals = _db.Clients.Select(client => new {
			client.Username,
			payments = _db.Payments.Where(pay => pay.ClientId == client.Id).Where(p =>
				DateTime.Compare(p.TradeDate, (DateTime)fromDate) >= 0 &&
				DateTime.Compare(p.TradeDate, (DateTime)toDate) <= 0)
		}).Select(cwp => new SomeModel {
			Username = cwp.Username,
			Bcf = cwp.payments.Sum(),
			Ecn += cwp.payments.Ecn.Sum(),
			Ecbt += cwp.payments.Ecbt.Sum(),
			OpenGl += cwp.payments.OpenGl.Sum(),
			JeyK += cwp.payments.JeyK.Sum()
		}
		return await totals.ToListAsync();
	}
