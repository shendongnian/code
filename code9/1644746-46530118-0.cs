            TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {
                    LockDetailedStatus1 = "Meeting with Thomas",
                    LockDetailedStatus2 = "11:00 AM - 12:30 PM",
                    LockDetailedStatus3 = "Studio F",
                    TileWide = new TileBinding()
                    {
                    }
                }
            };
            var notification = new TileNotification(content.GetXml());
            TileUpdateManager.CreateTileUpdaterForApplication().Update(notification);
