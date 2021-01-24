    public IEnumerable<SearchResult> Search(int? orderId, string customer, string car, int? type, int? status, string sortBy = null)
    {
      var records = Orders;
      if(orderId!=null)
      {
        records=records.Where(x=>x.Id == orderId);
      }
      if(!string.IsNullOrWhiteSpace(customer))
      {
         records=records.Where(string.Format("{0} {1}", x.Customer.Name, x.Customer.Surname).Contains(customer));
      }
    .. and so on
                                   
    }
