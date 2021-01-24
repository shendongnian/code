     public int GetMaxConfiguratableColumns()
            {
                PaymentHeader PaymentHeader = new PaymentHeader();
                int max = typeof(PaymentHeader)
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                    .Select(x => (int)x.GetValue(PaymentHeader)).Max();
                return max;
            } 
