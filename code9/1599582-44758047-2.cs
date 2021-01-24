    public class CompanyField : BoundField
    {
        protected override string FormatDataValue(object dataValue, bool encode)
        {
            var obj = dataValue as Company;
    
            if (obj != null)
            {
                return obj.Name;
            }
            else
            {
                return base.FormatDataValue(dataValue, encode);
            }
        }
    }
