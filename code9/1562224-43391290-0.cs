    var query = from oh in _context.Set<order_header>()
                where oh.customer == accountNo
                select new
                {
                    oh,
                    oh.route_details,
                    oh.customer,
                    // other navigation properties to include
                    route_details = from rd in oh.route_details
                                    // your child table filtering here
                                    select new
                                    {
                                        rd,
                                        rd.route_code,
                                        // other child nav properties to include
                                    }
                };
    
    return query.AsEnumerable().Select(m => m.oh).ToList();
