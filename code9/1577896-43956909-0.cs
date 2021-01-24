    Ticket ticketBody = new Ticket
                {
                    ClientName = clientName,
                    ClientLocation = clientLocation,
                    TicketSource = ticketSource,
                    TicketType = ticketType,
                    Title = title,
                    Priority = priority,
                    Status = status,
                    Details = details,
                    OpenDate = Convert.ToString(openDate.ToString("MM/dd/yyyy HH:mm:ss")),
                    Queue = queue
                };
    
                List<Ticket> bodyList = new List<Ticket>();
                bodyList.Add(ticketBody);
