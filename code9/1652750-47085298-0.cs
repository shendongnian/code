       //Whatever code 
       // Only part-route necessary.
       [Route("add")]
       [HttpPost]
       public HttpResponseMessage Add(Message item)
       {
           using(var ctx = new dbContext())
           {
                // add new message using EF. snip
            }
       }
       // Like before 
       [Route("check")]
       [HttpPost]
       public HttpResponseMessage Check(DateTime date)
       {
           using (var ctx = new dbContext())
           {
               // check if any messages after param date
               // snip
           }
        }
    }
