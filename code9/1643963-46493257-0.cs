    foreach (var r in reports)
        {
            var newList = r.Nets.Where(n => n.NetStatus.Equals("New")).OrderBy(n => n.NetId).ToList();
            var upatedList = r.Nets.Where(n => n.NetStatus.Equals("Updated")).OrderBy(n => n.NetId).ToList();
            var IgnoredList = r.Nets.Where(n => n.NetStatus.Equals("Ignored")).OrderBy(n => n.NetId).ToList();
            var result = newList.Concat(upatedList).Concat(IgnoredList);
        }
