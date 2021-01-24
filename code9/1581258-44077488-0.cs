            public IEnumerable<SalesHeader> GetAllFullDocuments()
        {
            return SalesContext.SalesHeader.Include(sh => sh.SalesLines.Select(i => i.Item))
                                           .Include(sh => sh.SellToCustomer)
                                           .Include(sh => sh.BillToCustomer)
                                           .ToList();
        }
