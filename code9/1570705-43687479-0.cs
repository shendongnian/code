    using System;
    
    public class CustomFormData
    {
    
        private readonly System.Web.HttpContext Context;
    
        private readonly System.Collections.ArrayList l_QSItems = new System.Collections.ArrayList();
        private string CookieName
        {
            get { return "EmberCookie"; }
        }
    
        private int MaxStringSize
        {
            get { return 10; }
        }
    
        protected string this[enu.QS index]
        {
            get
            {
                try
                {
                    return l_QSItems[index].ToString();
                }
                catch (Exception ex)
                {
                    return "";
                }
            }
            set
            {
                ValidateStringSize(index.ToString(), value);
                l_QSItems[index] = value;
                SaveCookie(index, value);
            }
        }
    
    
    
        private void ValidateStringSize(string name, string value)
        {
            if (value != null && value.Length > this.MaxStringSize)
            {
                throw new System.Security.SecurityException(string.Format("{0} contains value larger than allowed length of {1}.  Size was {2} char(s).", name, this.MaxStringSize, value.Length));
            }
        }
    }
