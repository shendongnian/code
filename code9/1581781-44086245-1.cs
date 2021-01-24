    const string customerType = "Type1";
    var comments = new Comment[]
        {
            new Comment(),
            new Comment(),
            new Comment {Customer = new Customer()}
        }.AsQueryable();
    var customersResult = comments.Select(c => c.Customer).AsQueryable();
    customersResult = CustomersWhere(customersResult, customerType);
    var commentsResult = comments.Select(c => c).AsQueryable();
    commentsResult = commentsResult.Where(c => CustomerWhere( c.Customer, customerType ));
