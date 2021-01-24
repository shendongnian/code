        private void InsertMatchStats(Intent intent)
        {
            MatchHelper mh = new MatchHelper();
            Match match = mh.GetSpecificMatch(intent.GetStringExtra("Home"), DateTime.Parse(intent.GetStringExtra("Date")), TimeSpan.Parse(intent.GetStringExtra("Time")));
            int size = int.Parse(intent.GetStringExtra("MatchStatSize"));
            if (match != null)
            {
                for (int cnt = 1; cnt <= size; cnt++)
                {
                    MatchStat matchstat = new MatchStat
                    {
                        MatchId = match.Id,
                        ActionItem = intent.GetStringExtra("ActionItem" + cnt.ToString()),
                        ActionMin = int.Parse(intent.GetStringExtra("ActionMin" + cnt.ToString())),
                        Color = intent.GetStringExtra("Color" + cnt.ToString()),
                        //ColorSchemeId = int.Parse(intent.GetStringExtra("ColorSchemeId"));
                        GuestScore = int.Parse(intent.GetStringExtra("GuestScore" + cnt.ToString())),
                        HomeScore = int.Parse(intent.GetStringExtra("HomeScore" + cnt.ToString())),
                        PlayerName = intent.GetStringExtra("PlayerName" + cnt.ToString()),
                        Sync = true
                    };
                    if (matchstat.Color == null)
                        matchstat.Color = "#FFFFFF";
                    MatchStat checkMatchStat = mh.CheckMatchStat(matchstat.HomeScore, matchstat.GuestScore, matchstat.ActionItem, matchstat.MatchId);
                    if (checkMatchStat == null)
                        mh.InsertMatchStat(matchstat);
                    else
                    {
                        checkMatchStat.ActionMin = matchstat.ActionMin;
                        checkMatchStat.Color = matchstat.Color;
                        //checkMatchStat.ColorSchemeId = matchstat.ColorSchemeId;
                        checkMatchStat.PlayerName = matchstat.PlayerName;
                        mh.UpdateMatchStat(checkMatchStat);
                    }
                    Console.WriteLine("PutExtra " + intent.GetStringExtra("ActionMin" + cnt.ToString()) + " min " + intent.GetStringExtra("HomeScore" + cnt.ToString()) + "-" + intent.GetStringExtra("GuestScore" + cnt.ToString()));
                }
                SendBack(intent.GetStringExtra("Path"));
            }
        }
