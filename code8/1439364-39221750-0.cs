    public void reportAchievement(string identifier, float percentComplete)
    {
        var achievement;
        try
        {
            achievement = new GKAchievement(identifier);
        }
        finally
        {
           // do nothing
        }
    
        if(achievement != null)
        {
            achievement.percentComplete = percentComplete;
            GKAchievement.reportAchievements( new GKAchievement[]{achivement}, (e) => {
                if (error != nil)
                {
                    Console.WriteLine("Error in reporting achievements: %0", error);
                }
            });
        }
    }
