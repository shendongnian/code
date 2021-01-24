    List<Ticket> tickets = new List<Ticket>()
                {
                    new Ticket(){
                        TicketType="Standard",
                        Quantity =1,
                        Amout= 8.5M
                    },
                    new Ticket(){
                        TicketType="Standard",
                        Quantity =1,
                        Amout= 8.5M
                    },
                    new Ticket(){
                        TicketType="Student",
                        Quantity =1,
                        Amout= 6.5M
                    },
                    new Ticket(){
                        TicketType="Student",
                        Quantity =1,
                        Amout= 6.5M
                    },
                    new Ticket(){
                        TicketType="Senior",
                        Quantity =1,
                        Amout=4M
                    },
                };
    
                var groupTicket = tickets.GroupBy(p => p.TicketType).Select(t => new
                {
                    TicketType = t.Key,
                    Quantity = t.Sum(x => x.Quantity),
                    Amount = t.Sum(x => x.Amout)
                }).ToList();
