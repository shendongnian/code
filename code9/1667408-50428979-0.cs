        public async static void SendMatchStats(ObservableCollection<MatchStat> matchstats, Match match, int matchstatsize, string path)
        {
            if (!client.IsConnected)
                client.Connect();
            await Task.Delay(80);
            try
            {
                var request = PutDataMapRequest.Create(path);
                var map = request.DataMap;
                MatchHelper mh = new MatchHelper();
                int cnt = 1;
                if (matchstatsize != 0)
                {
                    map.PutString("Device", device);
                    map.PutString("Item", "MatchStats");
                    map.PutString("Home", match.Home);
                    map.PutString("Date", match.MatchDate.Date.ToString());
                    map.PutString("Time", match.MatchTime.ToString());
                    map.PutString("MatchStatSize", matchstatsize.ToString());
                    map.PutString("Path", path);
                    foreach (MatchStat matchstat in matchstats)
                    {
                        map.PutString("ActionItem" + cnt.ToString(), matchstat.ActionItem);
                        map.PutString("ActionMin" + cnt.ToString(), matchstat.ActionMin.ToString());
                        map.PutString("Color" + cnt.ToString(), matchstat.Color);
                        //map.PutString("ColorSchemeId", matchstat.ColorSchemeId.ToString());
                        map.PutString("GuestScore" + cnt.ToString(), matchstat.GuestScore.ToString());
                        map.PutString("HomeScore" + cnt.ToString(), matchstat.HomeScore.ToString());
                        if (matchstat.PlayerName == null)
                            map.PutString("PlayerName" + cnt.ToString(), "");
                        else
                            map.PutString("PlayerName" + cnt.ToString(), matchstat.PlayerName.ToString());
                        cnt++;
                    }
                    map.PutLong("UpdatedAt", DateTime.UtcNow.Ticks);
                    await WearableClass.DataApi.PutDataItem(client, request.AsPutDataRequest());
                }
                request.SetUrgent();
                request.UnregisterFromRuntime();
            }
            catch
            { }
            finally
            {
                client.Disconnect();
            }
        }
