    context.AllianceReputationRankings
       .Where(p => p.Date == rank.Date && p.Alliance== rank.Alliance && p.World == rank.World)
            .Select(pl =>  new AllianceReputationRank
            {
                Date = pl.Date,
                World = pl.World,
                Alliance = pl.Alliance,
                Reputation = pl.Reputation * 1m
            }
        ).FirstOrDefault();
