    SearchResult result = service.search(new TransactionSearch()
        {
            basic = new TransactionSearchBasic()
            {
                type = new SearchEnumMultiSelectField() {
                    @operator = SearchEnumMultiSelectFieldOperator.anyOf,
                    operatorSpecified = true,
                    searchValue = new string[] { "_salesOrder" }
                },
                tranId = new SearchStringField()
                {
                    @operator = SearchStringFieldOperator.@is,
                    operatorSpecified = true,
                    searchValue = "SO364886"
                }
            }
        }
    );
    
    if(result.status.isSuccess && result.totalRecords == 1)
    {
        SalesOrder salesOrder = (SalesOrder)result.recordList[0];
        System.Console.WriteLine("Internal ID = " + salesOrder.internalId);
    } else
    {
        System.Console.WriteLine("Couldn't find sales order!");
    }
