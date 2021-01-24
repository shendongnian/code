            var myDestList = mySourceList.OrderBy(i => i.Date).ThenBy(i => i.ProviderID)
                .GroupBy(x => new {x.ProviderID, x.Date})
                .Select((grp, idx) => new {GroupId = idx+1, GroupCount = grp.Count(), Items = grp})
                .SelectMany(newgrp => newgrp.Items.DefaultIfEmpty(), (g, i) => new { Date=i.Date, ProviderID = i.ProviderID, GroupID = (g.GroupCount == 1 ? 0 : g.GroupId)})
                .OrderBy(i => i.Date).ThenBy(i=>i.ProviderID)
                .ToList();
