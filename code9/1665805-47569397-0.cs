        public Customer CreateCustomer(Customer customer)
        {
            ISession session = this.GetSession();
            using (var tx = session.BeginTransaction())
            {
                try
                {
                    this.GetSession().Save(customer);
                    tx.Commit();
                }
                catch(Exception e)
                {
                    tx.Rollback();
                }
            }
            return customer;
        }
