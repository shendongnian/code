    try
        {
                     
            using (MyEntities myEntity = new MyEntities())
            {
                var result = (from s in Carriers
                             join ent in CoreEnt on s.CoreEntID equals ent.CoreEntID                       
                             where s.NeedsTransfer == True
                             select s).Single(); 
                //using Single()/FirstOrDefault() depends on what is the type of other objects. If it shows error to you than you can remove it
            }
            return result;
        }
        catch (Exception ex)
        {
            return result;
        }
