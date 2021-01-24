     [Queryable, BasicAuthentication]
        public IHttpActionResult GetOrders(ODataQueryOptions<App4Sales_Orders> opts)
        {
            else
            {     
                
                Error theError = new App4Sales_Error()
                {
                    Code = "1000",
                    Message = "Geen filter gespecificeerd"
                };
                return new ErrorResult(theError, Request);
                
            }
            return Ok(resultList);
        }
