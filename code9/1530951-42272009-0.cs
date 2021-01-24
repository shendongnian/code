    var smses = smsTable.GroupBy(x => x.CustomerId).Select(group =>
                             new
                             {
                                 CustomerId = group.Key,
                                 SmsCount = group.Count()
                             });
