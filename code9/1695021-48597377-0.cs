    else if (reg == "OCE" && sum != null)
                {
                    var regOCE = RiotSharp.Misc.Region.oce;
                   summoner = api.GetSummonerByName(regOCE, sum);
                    MessageBox.Show(summoner.Id.ToString());
    
                }
