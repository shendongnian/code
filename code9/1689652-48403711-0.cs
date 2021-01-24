       public IHttpActionResult Get([FromUri]string date)
       {
         DateTime dt = new DateTime();
         if (!DateTime.TryParse(date, null, System.Globalization.DateTimeStyles.RoundtripKind, out dt))
         {
              return BadRequest("incorrect input");
         }
       }
