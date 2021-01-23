    public class DefaultController : ApiController
        {
            public HttpResponseMessage GetCarses()
            {
                List<Cars> carList = new List<Cars>();
                carList.Add(new Cars
                {
                    carName = "a",
                    carRating = "b",
                    carYear = "c"
                });
                carList.Add(new Cars
                {
                    carName = "d",
                    carRating = "e",
                    carYear = "f"
                });
                return Request.CreateResponse(HttpStatusCode.OK, carList); ;
            } 
        }
