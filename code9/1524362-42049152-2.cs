    public partial class TBCompanyEntities
    {
     
        public void SaveChanges(object o)
        {
            try
            {
                var propertyInfo = o.GetType().GetProperty("DTUpdated");
                // This hasn't been tested by me yet - will test and update if need changes
                if(propertyInfo != null)
                    propertyInfo.SetValue(o, Convert.ChangeType(DateTime.UtcNow, propertyInfo.PropertyType), null);
            }
            catch (Exception ex)
            {
                //  Logging.Log.Error(ex);
            }
            base.SaveChanges();
        }
    }
