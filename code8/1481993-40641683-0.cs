    public class DataController : ApiController
                {
                    [HttpGet]
                    public HttpResponseMessage Getdetails(string id,DateTime date_in)
                    {
                        if(id==string.Empty || id==null)
                        {
                          return "Id Value Should not Empty or Null";
                        }
                        if(!Regex.IsMatch(date_in, "^(([0-9])|([0-2][0-9])|([3][0-
                        1]))\-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)\-
                        \d{4}$"))
                        {
                          return "Invalid Date Format";
                        }
                        List<OracleParameter> prms = new List<OracleParameter>();
                        prms.Add(new OracleParameter("id", OracleDbType.Varchar2,
                        id, ParameterDirection.Input));
                        prms.Add(new OracleParameter("date_in", OracleDbType.Date, date_in, ParameterDirection.Input));
                           string connStr = ConfigurationManager.ConnectionStrings["DtConnection"].ConnectionString;
                        using (OracleConnection dbconn = new OracleConnection(connStr))
                        {
                            DataSet userDataset = new DataSet();
                            var strQuery = "SELECT * from SAMPLE where id = :id and date_in = :date_in ";
                            var returnObject = new { data = new OracleDataTableJsonResponse(connStr, strQuery, prms.ToArray()) };
                            var response = Request.CreateResponse(HttpStatusCode.OK, returnObject, MediaTypeHeaderValue.Parse("application/json"));
                            ContentDispositionHeaderValue contentDisposition = null;
                            if (ContentDispositionHeaderValue.TryParse("inline; filename=TGSData.json", out contentDisposition))
                            {
                                response.Content.Headers.ContentDisposition = contentDisposition;
                            }
                            return response;
                }
                }
