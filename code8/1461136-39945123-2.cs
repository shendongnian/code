           protected override void OnCreate(Bundle bundle)
           {
           TextView txt = FindViewById<TextView>(Resource.Id.My);
            using (var ws = new WebSocket("ws://dragonsnest.far/Laputa"))
            {
                ws.OnError += (sender, e) =>
                {
                    txt.Text = e.Message;
                };
                ..........
            }  
