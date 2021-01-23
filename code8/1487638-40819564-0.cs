     List<Songs> GloryDays = new List<Songs>();
     GloryDays.Add(new Songs { TrackName = "Shout Out to My Ex", TrackLength =200 });
     GloryDays.Add(new Songs { TrackName = "Touch", TrackLength = 161 });
     var result = GloryDays.Sum(t => t.TrackLength);
     textbox1.Text = result.ToString();
