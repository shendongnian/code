    var history = new APIBillingHistory {
        BillingHistoryDetails = new List<APIBillingHistoryDetails> {
             new APIBillingHistoryDetails {
                  BillId = "123",
                  PaymentType = new List<APIBillingHistoryPaymentType>{
                      new APIBillingHistoryPaymentType {
                         Description = "A",
                         Principal = 100
                      },
                      new APIBillingHistoryPaymentType {
                         Description = "B",
                         Principal = 200
                      }
                  }
             },
             new APIBillingHistoryDetails {
                  BillId = "123",
                  PaymentType=new List<APIBillingHistoryPaymentType>{
                      new APIBillingHistoryPaymentType {
                         Description = "A",
                         Principal = 150
                      },
                      new APIBillingHistoryPaymentType {
                         Description = "B",
                         Principal = 300
                      }
                  }
             }
         }
    };
