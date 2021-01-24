	public Ticket UpdateTicket(int id, string status, int customerId, int helpDeskStaffId, string problemDesc, string resolution, string followUpRequired, string followUpComplete, DateTime ticketDate, DateTime resolvedDate)
    {
        var ticket = new Ticket(id, status, customerId, helpDeskStaffId, problemDesc, resolution, followUpRequired, followUpComplete, ticketDate, resolvedDate);
       
		var connectString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;            
		var sql2 = "UPDATE Ticket SET Status = @Status, HelpDeskStaffId = @HelpDeskStaffId, ProblemDesc = @ProblemDesc, Resolution = @Resolution, FollowUpRequired = @FollowUpRequired, FollowUpComplete = @FollowUpComplete, TicketDate = @TicketDate, ResolvedDate = @ResolvedDate, CustomerId = @CustomerId WHERE TicketId=@id";
            
		using(var conn = new SqlConnection(connectString))
		{
			using(var cmd = new SqlCommand(sql2, conn))
			{
			cmd.Parameters.AddWithValue("@id", id);
			cmd.Parameters.AddWithValue("@Status", status);
			cmd.Parameters.AddWithValue("@HelpDeskStaffId", helpDeskStaffId);
			cmd.Parameters.AddWithValue("@ProblemDesc", problemDesc);
			cmd.Parameters.AddWithValue("@Resolution", resolution);
			cmd.Parameters.AddWithValue("@FollowUpRequired", followUpRequired);
			cmd.Parameters.AddWithValue("@FollowUpComplete", followUpComplete);
			cmd.Parameters.AddWithValue("@TicketDate", ticketDate);
			cmd.Parameters.AddWithValue("@ResolvedDate", resolvedDate);
			cmd.Parameters.AddWithValue("@CustomerId", customerId);
			try
			{
				conn.Open();
				cmd.ExecuteNonQuery();
			}
			catch (SqlException ex)
			{
				Console.Error.WriteLine(ex.Message);
			}
			}
		}
        return ticket;
    }
