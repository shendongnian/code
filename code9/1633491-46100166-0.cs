    public static class ViewExtensions
    {
        public static string GetControlName(this View view)
        {
            string controlName = "";
            if (view.Id > 0)
            {
                string fullResourceName = Application.Context.Resources.GetResourceName(view.Id)
                controlName = fullResourceName.Split('/')[1];
            }
            return controlName;
        }
    }
