    var myList = lists.GroupBy(l =>l.bankCode).Concat(lists.GroupBy(l=>l.fCode)).Select(l => new
        {
            groupCode = l.Key,
            plusMoney = l.Sum(k => k.Money > 0 ? k.Money : 0),
            negativeMoney = l.Sum(k => k.Money < 0 ? k.Money : 0)
        });
