     // take all BillingHistoryDetails
    var groups = ApiBillingHistory.BillingHistoryDetails
        // group them into groups of items with the same Id
       .GroupBy(
            // Key of the group is this same Id
            historyDetail => historyDetail.Id,
            // elements of the group:
            // group all payment types of the history detail
            // into subgroups of items with the same Description
            historyDetail => historyDetail.PaymentTypes.GroupBy( 
                    // Key of subgroup: the Description                                  
                    paymentType => payMentType.Description,
                    // elements of the gorup = the Principal
                    // of the paymentTypes with this description
                    paymentType => paymentType.Principal), 
                 // now we have sub groups of Principals from all paymentTypes
                 // with a Description equal to the sub group.
                 // convert every sub Group into one PaymentType:
                 .Select(subGroup => new PaymentType()
                 {
                     Description = subGroup.Key,
                     Principal = subGroup.Sum(),
                 }))
           // so now we have Groups
           // with a Key historyDetail.Id
           // and as elements the list of PaymentTypes
           // where each payMentType contains the Description and the sum of all
           // payment types with this description
           // convert to billingHistoryDetails:
           .Select(mainGroup => new BillingHistoryDetails
           {
              // Id is the Key of the group
              Id = mainGroup.Key,
              // PaymentType is the list of created PaymentTypes
              PaymentType = mainGroup.ToList(),
           });
   
            
