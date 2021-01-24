    static void DeleteCampaign(int idOfCampaignToDelete)
        {
            using (var context = new DatabaseContext())
            {
                var campaignToDelete = context.Campaign.FirstOrDefault(c => c.Id == idOfCampaignToDelete);
                for (int i = 0; i < campaignToDelete.Users.Count; i++)
                {
                    campaignToDelete.Users[i].Campaign = context.Campaign.ElementAt(0);
                }
                context.Entry(campaignToDelete).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }
