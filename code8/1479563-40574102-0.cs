    public enum CategoryStatus
    {
        Active = 0,
        Inactive = 1
    }
    public static class CategoryStatusExtension
    {
        private static string[] localizedNames = new string[] { 
            Resources.Strings.CategoryStatus_Active,
            Resources.Strings.CategoryStatus_Inactive
        };
        public static string LocalizedName(this CategoryStatus self)
        {
            switch (self)
            {
                case CategoryStatus.Active:
                    return localizedNames[0];
                    break;
                case CategoryStatus.Inactive:
                    return localizedNames[1];
                    break;
            }
            return null;
            //int index = (int)self - 1;
            //return localizedNames[index];
        }
    }
