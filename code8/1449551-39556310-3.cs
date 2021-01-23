    public class EntityDto {
        public int ticketAmount {get; set;}
        public DateTime loggedDate {get; set;}
    }
    ...
    public string GetNewTickets()
    {
        var entities = new List<EntityDto>();
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("Select LoggedDate, count(ID) as ticketAmount from Tickets WHERE LoggedDate >=dateadd(day,datediff(day,0,GetDate())- 7,0) AND State = '1' group by LoggedDate"))
            {
                var ticketAmount = 0;
                var loggedDate = DateTime.Now;
                var ActualloggedDate = string.Empty;
                var convertedLoggedDate = string.Empty;
    
                var test = string.Empty;
    
                cmd.Connection = con;
                con.Open();
                var reader = cmd.ExecuteReader();
    
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ticketAmount = (int)reader["ticketAmount"];
                        //Convert to JSON format
                        loggedDate = (DateTime)reader["LoggedDate"];
                        ActualloggedDate = JsonConvert.SerializeObject(loggedDate, new IsoDateTimeConverter());
                        convertedLoggedDate = ActualloggedDate.Substring(1, ActualloggedDate.Length - 4);
                        var entity = new EntityDto
                         {
                             ticketAmount = ticketAmount,
                             loggedDate = convertedLoggedDate,
                         };
                        entites.Add(entity);
                    }
                }
                
            }            
        }
        var json = serializer.Serialize(entities);
        return json;
    }
