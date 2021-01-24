    public class MyClass
    {
        //You need somewhere to put the sales range thats selected
        public string SelectedSalesRange { get; set; }
        public System.Web.Mvc.SelectList SaleRange = new System.Web.Mvc.SelectList(new[]
            {
                //Note that I have removed the "Default" item
                //And the Selected=False (since the default value of a bool is false)
                new System.Web.Mvc.SelectListItem { Text = "7 days", Value = "7" },
                new System.Web.Mvc.SelectListItem  {Text = "14 days", Value = "14" },
                new System.Web.Mvc.SelectListItem { Text = "21 days", Value = "21" },
                new System.Web.Mvc.SelectListItem  { Text = "30 days", Value = "30" },
            }, "Value", "Text");
    }
