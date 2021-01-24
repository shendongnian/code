    GridImageColumn customerImageColumn = new GridImageColumn();
    customerImageColumn.MappingName = "CustomerImage";
    customerImageColumn.HeaderText = "Image";
    
    // Model class - The type of the “CustomerImage” should be UIImage
    public UIImage CustomerImage  
    {
        get
        {
            return customerImage;
        }
        set
        {
            customerImage = value;
        }
    }
    
    // Repository class – the image should be set to the “CustomerImage” property as highlighted
    public List<OrderInfo> GetBankDetails(int count)
    {
        List<OrderInfo> bankDetails = new List<OrderInfo>();
    
        for (int i = 1; i <= count; i++)
        {
            var ord = new OrderInfo()
            {
                CustomerID = i,
                BranchNo = BranchNo[random.Next(15)],
                Current = CurrentBalance[random.Next(15)],
                Savings = Savings[random.Next(15)],
                CustomerName = Customers[random.Next(15)],
                BalanceScale = random.Next(1, 100),
                IsOpen = ((i % random.Next(1, 10) > 2) ? true : false),
                CustomerImage = Imagehelper.ToUIImage(new ImageMapStream(LoadResource("Image1.png").ToArray())),
                Transactions = random.Next(80)
            };
            bankDetails.Add(ord);
        }
        return bankDetails;
    }
