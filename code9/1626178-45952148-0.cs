     long customerId = quotation.customerId;
                Customer customer = realm.All<Customer>().Where(c => c.customerId == customerId).FirstOrDefault();
                if (customer != null)
                {
                    String customerName = customer.customerName;
                    quotation.customerName = customerName;
                }
