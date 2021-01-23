      using (OracleConnection dbconn = new OracleConnection(connStr))
        {
          try {
            DataSet userDataset = new DataSet();
            var strQuery = "SELECT * from LIMS_SAMPLE_RESULTS_VW where ROOM = :ROOM and DOB > :DOB_GT and DOB < :DOB_LT and STATUS_TYPE= :STATUS_TYPE ";
    
            var returnObject = new { data = new OracleDataTableJsonResponse(connStr, strQuery, prms.ToArray()) };
            var response = Request.CreateResponse(HttpStatusCode.OK, returnObject, MediaTypeHeaderValue.Parse("application/json"));
            ContentDispositionHeaderValue contentDisposition = null;
            if (ContentDispositionHeaderValue.TryParse("inline; filename=TGSData.json", out contentDisposition))
            {
                response.Content.Headers.ContentDisposition = contentDisposition;
            }
            return response;
          }
          catch (Exception ex)
          {
              var returnObj = new { error = ex.Message } ;
              var response = Request.CreateResponse(HttpStatusCode.BadRequest, returnObj, MediaTypeHeaderValue.Parse("application/json"));
            ContentDispositionHeaderValue contentDisposition = null;
            if (ContentDispositionHeaderValue.TryParse("inline; filename=error.json", out contentDisposition))
            {
                response.Content.Headers.ContentDisposition = contentDisposition;
            }
            return response;
          }
        }
