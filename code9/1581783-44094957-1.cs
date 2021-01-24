        public static IQueryable<T> customersWhere<T>(IQueryable<T> 
        customerWhere, 
        Expression<Func<T, bool>> predicate)
        {
           customerWhere = customerWhere.Where(predicate);
            return customerWhere;
        }
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>()
           {
               new Customer(){name="Name1", type ="Type1"},
               new Customer(){name="Name2", type ="Type2"},
               new Customer(){name="Name2", type ="Type1"}
           };
            List<CustomerWithComment> customerWithComment = new List<CustomerWithComment>()
           {
               new CustomerWithComment(){comment = "Customer1", customer = new Customer(){name="Name2", type ="Type2"}},
               new CustomerWithComment(){comment = "Customer2", customer = new Customer(){name="Name1", type ="Type1"}},
               new CustomerWithComment(){comment = "Customer3", customer = new Customer(){name="Name1", type ="Type1"}}
           };
            string customerType = "Type1";
            Expression<Func<Customer, bool>> predicate = i => i.type ==customerType;
            var listcustomer = customers.Select(c => c).AsQueryable();
            listcustomer = customersWhere<Customer>(listcustomer, predicate);
            Expression<Func<CustomerWithComment, bool>> customerWithCommentExpression = i => i.customer.type ==customerType;
            var commentsResult = customerWithComment.Select(c => c).AsQueryable();
            commentsResult = customersWhere<CustomerWithComment>(commentsResult, customerWithCommentExpression);
            Console.Read();
        }
