    public class MyClass {
    
        [OLVColumn(Width = 150)]
        public DateTime When { get; set; }
    
        [OLVColumn(DisplayIndex = 5, Width = 75, TextAlign = HorizontalAlignment.Right)]
        public decimal Rate { get; set; }
    
        [OLVColumn("From", DisplayIndex=1, Width = 50, TextAlign = HorizontalAlignment.Center)]
        public string FromCurrency { get; set; }
    
        [OLVColumn("To", DisplayIndex = 3, Width = 50, TextAlign = HorizontalAlignment.Center)]
        public string ToCurrency { get; set; }
    
        [OLVColumn("Amount", DisplayIndex = 2, AspectToStringFormat = "{0:C}", Width = 75, TextAlign = HorizontalAlignment.Right)]
        public decimal FromValue { get; set; }
    
        [OLVColumn("Amount", DisplayIndex = 4, AspectToStringFormat = "{0:C}", Width = 75, TextAlign = HorizontalAlignment.Right)]
        public decimal ToValue { get; set; }
    
        [OLVColumn(IsVisible = false)]
        public string UserId { get; set; }
    }
