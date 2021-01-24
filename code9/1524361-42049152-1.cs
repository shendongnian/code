                using (var dbContext = new TBCompanyEntities())
                {
                    // Entity with DTUpdated
                    var notification = dbContext.NotificationArchives.First(s => s.iNotificationId == 1);
                    notification.bIsRead = true;
                    dbContext.SaveChanges(notification);
                    //Entity without DTUpdated
                    var asset = dbContext.Assets.First(s => s.iAssetId == 1);
                    asset.iDriverId = null;
                    dbContext.SaveChanges();
                }
