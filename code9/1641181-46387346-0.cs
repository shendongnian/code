    [Authorize]
            [Route("Add_User")]
    
            public HttpResponseMessage PostUsers1([FromBody] tbl_users Users)
            {
                using (var context = new UsersEntities())
                {
                    var response = context.spInsUsers(Users.user_name, Users.first_name, Users.last_name, Users.mobile_no,
                        Users.email, Users.user_pic, Users.strowner, DateTime.Now);
    
                    var message = Request.CreateResponse(HttpStatusCode.Created, Users);
                    message.Headers.Location = new Uri(Request.RequestUri +
                        response.ToString());
    
                    return message;
    
                }
    
            }
