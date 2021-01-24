            var sortedReports = new List<Report>();
            foreach (var r in reports)
            {
                var newList = r.Nets.Where(n => n.NetStatus.Equals("New")).OrderBy(n => n.NetId).ToList();
                var upatedList = r.Nets.Where(n => n.NetStatus.Equals("Updated")).OrderBy(n => n.NetId).ToList();
                var IgnoredList = r.Nets.Where(n => n.NetStatus.Equals("Ignored")).OrderBy(n => n.NetId).ToList();
                if (newList.Count > 0)
                {
                    sortedReports.Add(r);
                }
                else if (upatedList.Count > 0)
                {
                    sortedReports.Add(r);
                }
                else
                {
                    sortedReports.Add(r);
                }
            }
