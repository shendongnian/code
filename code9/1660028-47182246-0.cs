        public List<Invoice> CreateInvoices(IEnumerable<Ticket> selectedTickets)
        {
            // Group tickets by company id
            return selectedTickets.GroupBy(ticket => ticket.CompanyId)
                // Convert grouping into new Invoice objects
                .Select(g => new Invoice
                {
                    // Build invoice object
                    CompanyId = g.Key,
                    // Build invoice lines
                    InvoiceLines = g.Select(line => new InvoiceLine() {Title = line.Title}).ToList()
                }).ToList();
        }
