    [Serializable]
    public class OrderSearchQuery
    {
        public enum SearchAttribute
        {
            OrderNumber,
            Location,
            Issuer,
            IncludeBreakable,
            Status,
            PackagingRequirement
        }
    
        public SearchAttribute? OrderSearchAttribute { get; set; }
    
        public string OrderNumber { get; set; }
        public string Location { get; set; }
        public string Issuer { get; set; }
        //And so on...
    
        private string SelectedItemName;
    
        private bool AvtivityConverter(string seletedItemname, string currentItemname)
        {
            return seletedItemname == currentItemname;
        }
    
        public IForm<OrderSearchQuery> BuildOrderAdvanceStepSearchForm()
        {
            return new FormBuilder<OrderSearchQuery>()
                .Field(new FieldReflector<OrderSearchQuery>(nameof(OrderSearchAttribute))
                    .SetNext((value, state) =>
                    {
                        var selection = (SearchAttribute)value;
                        SelectedItemName = selection.ToString();
                        return new NextStep();
                    }))
                 .Field(new FieldReflector<OrderSearchQuery>(nameof(OrderNumber))
                     .SetActive(state => AvtivityConverter(SelectedItemName, "OrderNumber")))
                 .Field(new FieldReflector<OrderSearchQuery>(nameof(Location))
                     .SetActive(state => AvtivityConverter(SelectedItemName, "Location")))
                 .Field(new FieldReflector<OrderSearchQuery>(nameof(Issuer))
                     .SetActive(state => AvtivityConverter(SelectedItemName, "Issuer")))
                 //and so on...
                 .Build();
        }
    }
