    [InternalServerErrorFilter]
        [HttpPost]
        public HttpResponseMessage API([FromBody] int roomID)
        {
            HttpResponseMessage msg = null;
            SqlCommand comm = Common.Shared.ConnectDB();
    
            try
            {
                List<Models.room> room = room(comm, roomID);
                msg = Request.CreateResponse(HttpStatusCode.OK, room);
            }
            catch (SqlException ex)
            {
               throw new CustomSqlException(comm);
            }
            finally
            {
                comm.Connection.Close();
            }
            return msg;
        }
