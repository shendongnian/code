     // Modified select after the GroupBy clause 
    .Select(g =>
            new
            {
                message_count = g.Sum(c => c.Message_Count),
                message_cost = g.Sum(c => c.Customer_Price),
                Message_Sent_Date= g.Key
            });
