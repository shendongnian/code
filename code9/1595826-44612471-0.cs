    public static class CustomerExtensions
    {
        public static IEnumerable<Customer> GetMultipleRow(this Customer cust)
        {
            yield return new Customer { CustomerID = cust.CustomerID, Mobile1 = cust.Mobile1, Family = cust.Family };
                                        /* Data for first mobile*/
            if (cust.Mobile2 != null)
                yield return new Customer { CustomerID = cust.CustomerID, Mobile1 = cust.Mobile2, Family = cust.Family };
                                            /* Data for second mobile*/
        }
    }
