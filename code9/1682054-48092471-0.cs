    public TicketEntity GetTicket(int ticketId)
    {
        Ticket persistanceModel = this.ticketsRepository.GetById(ticketId);
        TicketEntity domainModel = new TicketEntity(
            persistanceModel.Id,
            persistanceModel.Cost,
            persistanceModel.ExpiryDate);
        return domainModel;
    }
    
    public void SaveTicket(TicketEntity ticketEntity)
    {
        Ticket ticket = //Here, you have to map TicketEntity to Ticket
        this.ticketsRepository.Save(ticket);
    }
