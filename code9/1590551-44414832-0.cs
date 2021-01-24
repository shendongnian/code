    try
        {
                     
            using (MyEntities myEntity = new MyEntities())
            {
                var result = from s in Carriers
                             join ent in CoreEnt on s.CoreEntID equals ent.CoreEntID                       
                             where s.NeedsTransfer == True
                             select s;
            }
            return result;
        }
        catch (Exception ex)
        {
            return result;
        }
