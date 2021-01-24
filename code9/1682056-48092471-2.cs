    public Ticket GetTicket(int ticketId)
    {
        return this.ticketsRepository.GetById(ticketId);
    }
    
