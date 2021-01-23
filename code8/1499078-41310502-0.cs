    public static void ResetItem()
        {
            using (var db = new GoalDataContext())
            {
                foreach (var item in db.Goals)
                    item.calorieToday = 0;
                foreach (var item2 in db.Calculations)
                {                    
                    item2.amount = 0;
                    db.Calculations.Remove(item2);
                }                   
                       
                db.SaveChanges();
            }
        }
