    IEnumerable<Client> clients = .... // your clients collection
    IEnumerable<Customer> customers = .... // your customers collection
    var relatedClients = from cst in customers
                         join cli in clients on cst.CustomerID equals cli.Customer_custID
                         where cst.CustomerID == 0 // your customerID
                         select cli;
