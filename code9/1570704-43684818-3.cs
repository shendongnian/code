    public class CustomFormData
    {
        private System.Web.HttpContext Context;
        private String CookieName
        {
            get { return "EmberCookie"; }
        }
        private readonly System.Collections.ArrayList l_QSItems
            //  Initialize with enough nulls to accomodate the largest enum value as an index.
            = new System.Collections.ArrayList(new object[(int)enu.QS.additional_actuals_month_id + 1]);
        //  readonly modifier not allowed here. Not needed either. 
        //  Same as on CookieName
        private int MaxStringSize
        {
            get
            {
                return 10;
            }
        }
        protected string this[enu.QS index]
        {
            get
            {
                try
                {
                    //  index is an enum. It won't implicitly cast to int as in 
                    //  C/C++ (or, I infer, VB.NET), but an explicit cast is fine. 
                    return l_QSItems[(int)index].ToString();
                }
                catch (Exception ex)
                {
                    return "";
                }
            }
            set
            {
                ValidateStringSize(index.ToString(), value);
                l_QSItems[(int)index] = value;
            }
        }
        //  name[] would be an array of strings, we only want just one string. 
        private void ValidateStringSize(string name, string value)
        {
            if (value != null && value.Length > this.MaxStringSize)
            {
                throw new System.Security.SecurityException(string.Format("{0} contains value larger than allowed length of {1}.  Size was {2} char(s).", name, this.MaxStringSize, value.Length));
            }
        }
    }
