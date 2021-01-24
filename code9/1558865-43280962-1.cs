    using (var db = new PaymentContext())
    {
		IEnumerable<BaseTable> filter = db.BaseTable.ApplyCancellationFilter(clause).ApplyTimeFilter(clause);
		var result = db.Payment.
					Join(
						filter,
						pay => new { pay.Key1, pay.Key2, pay.Key3, pay.Key4, pay.Key5 },
						bse => new { bse.Key1, bse.Key2, bse.Key3, bse.Key4, bse.Key5 },
						(pay, bse) => new { Payment = pay, BaseTable = bse }).
					Join(
						db.Type,
						pay => new { pay.Payment.TypeKey1, pay.Payment.TypeKey2 },
						typ => new { typ.TypeKey1, typ.TypeKey2 },
						(pay, typ) => new { name = typ.Description, amount = pay.Amount }).
					GroupBy(x => x.name).
					Select(y => new { name = y.Key, 
                                      count = y.Count(), 
                                      amount = y.Sum(z => z.amount)});
    }
