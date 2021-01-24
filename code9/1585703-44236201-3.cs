        public async Task<IHttpActionResult> PostAuthenticationData(long id, string password)
        {
            Consumer consumer = await db.Consumers.FindAsync(id);
    
            if (consumer == null)
            {
                return NotFound();
            }
    
            if(consumer.ConsumerPassword != password)
            {
                return BadRequest();
            }
    
            ConsumerSessionTokenLog consumerSessionTokenLog = await db.ConsumerSessionTokenLogs.FindAsync(id);
    
            if(consumerSessionTokenLog == null)
            {
                return NotFound(); 
            }
            else
            {
                string sessionToken = consumerSessionTokenLog.SessionToken;
            }
    
      /// here i need to return "sessionToken" and "consumer" object 
            return Ok(new MyReturType(consumer,sessionToken));
        }
