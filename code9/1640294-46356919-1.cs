    public IEnumerable<Customers> getCustomersById(string id){
    
            var isAuthenticated = tokenAuthorization.validateToken(access_token);
            if (isAuthenticated)
            {
                List<Customers> customers = new List<Customers>();
                Customers customer = null;
                customer = new Customers();
                customer.kunnr = id;
                customer.name = "John Doe";
                customers.Add(customer);
                return customers;
            }else
            {
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(string.Format("No person with ID = {0}", id)),
                ReasonPhrase = "Person ID Not Found"
            }
            throw new HttpResponseException(resp);
        }
        return item;
    }
