    public class YourModel 
    {
        public bool ShowDiv { get; set; }
    }
    @Html.Partial("_ABCPartialView", new YourModel { ShowDiv = false });
