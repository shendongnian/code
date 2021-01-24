    [DisplayFormat(DataFormatString = "{0:P2}")]
    public double SellThroughRate
    {
        get
        {
            double total = SuccessfulSellers + UnSuccessfulSeller;
            return total  == 0 ? 0 : SuccessfulSellers / total;
        }
    };
 
