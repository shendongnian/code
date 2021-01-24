    protected async void RadGridDellBlade_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
        {
            thing1 t1 = new thing1();
            BladeRunnerDataAccess td = new BladeRunnerDataAccess(t1);
            try
            {
                Image icon = (Image)e.Item.FindControl("Dell_imgIcon");
                BladeWorkstation blade = (BladeWorkstation)e.Item.DataItem;
                Ping pingSender = new Ping();
                TaskCompletionSource<PingReply> tcs = new TaskCompletionSource<PingReply>();
                pingSender.PingCompleted += (s, e) => tcs.SetResult(e.Reply);
                pingSender.SendAsync(blade.IPAddress, null);
                PingReply reply = await tcs.Task;
                switch (reply.Status)
                {
                    case IPStatus.Success:
                        icon.ImageUrl = "~/Images/GreenIcon.png";
                        break;
                    case IPStatus.TimedOut:
                        icon.ImageUrl = "~/Images/RedIcon.png";
                        break;
                    default:
                        icon.ImageUrl = "~/Images/GrayIcon.png";
                        break;
                }
                Image Dell_osbit = (Image)e.Item.FindControl("Dell_OSbit");
                switch (blade.BladeOSID)
                {
                    case 1:
                        Dell_osbit.ImageUrl = "~/Images/xp.png";
                        break;
                    case 2:
                        Dell_osbit.ImageUrl = "~/Images/32bit.png";
                        break;
                    case 3:
                        Dell_osbit.ImageUrl = "~/Images/64bit.png";
                        break;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                t1.Dispose();
            }
        }
    }
