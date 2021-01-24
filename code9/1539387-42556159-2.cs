    [RoutePrefix("api")]
    public class TripsController: ApiController
    {
        #region Fields
        private readonly IQueryDispatcher _queryDispatcher;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TripsController"/> class
        /// </summary>
        /// <param name="queryDispatcher">Query Dispatcher</param>
        public TripsController(IQueryDispatcher queryDispatcher)
        {
            if (queryDispatcher == null)
                throw new ArgumentNullException(nameof(queryDispatcher));
            _queryDispatcher = queryDispatcher;
        }
        #endregion
        #region Actions
        [HttpGet]
        [Route("trips", Name = "TripList")]
        public IHttpActionResult Get([FromUri]TripsQuery query)
        {
            try
            {
                if (query == null)
                    return BadRequest();
                var result = _queryDispatcher.Dispatch<TripsQuery, TripsQueryResult>(query);
                HttpContext.Current.Response.Headers.AddPaginationHeader(query, result, new UrlHelper(Request), "TripList");
                return Ok(result);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
        [HttpGet]
        [Route("trips/{tripId}")]
        public IHttpActionResult Get([FromUri]TripDetailsQuery query)
        {
            try
            {
                var result = _queryDispatcher.Dispatch<TripDetailsQuery, TripDetailsQueryResult>(query);
                return Ok(result);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
        
        #endregion
    }
    [RoutePrefix("api")]
    public class StopsController: ApiController
    {
        #region Fields
        private readonly IQueryDispatcher _queryDispatcher;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="StopsController"/> class
        /// </summary>
        /// <param name="queryDispatcher">Query Dispatcher</param>
        public StopsController(IQueryDispatcher queryDispatcher)
        {
            if (queryDispatcher == null)
                throw new ArgumentNullException(nameof(queryDispatcher));
            _queryDispatcher = queryDispatcher;
        }
        #endregion
        [Route("trips/{tripId}/stops", Name = "StopList")]
        [HttpGet]
        public IHttpActionResult Get([FromUri]StopsQuery query)
        {
            try
            {
                if (query == null)
                    return BadRequest();
                var result = _queryDispatcher.Dispatch<StopsQuery, StopsQueryResult>(query);
                HttpContext.Current.Response.Headers.AddPaginationHeader(query, result, new UrlHelper(Request), "StopList");
                return Ok(result);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
        [Route("trips/{tripId}/stops/{stopId}")]
        [HttpGet]
        public IHttpActionResult Get([FromUri]StopDetailsQuery query)
        {
            try
            {
                if (query == null)
                    return BadRequest();
                var result = _queryDispatcher.Dispatch<StopDetailsQuery, StopDetailsQueryResult>(query);
                return Ok(result);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
