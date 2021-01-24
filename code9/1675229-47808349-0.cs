    [DataContract(Name="transactionParamter")]
    public class TransactionParamter
        {
            [DataMember(Name= "orderId")]
            public string OrderId;
            [DataMember(Name= "orderDetails")]
            public string OrderDetails;
            [DataMember(Name= "orderSumTotal")]
            public double OrderSumTotal;
    }
