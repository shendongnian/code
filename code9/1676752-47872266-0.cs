        /// <summary>
        /// List all users
        /// </summary>
        /// <param name="search">String to search for in user IDs and names</param>
        /// <returns>An array of users</returns>
        /// <response code="200">OK</response>
        [ResponseType(typeof(IEnumerable<User>))]
        [Route("")]
        [HttpGet]
        public IHttpActionResult ListUsers([Optional]string search)
        {
            IEnumerable<User> users;
            var searchString = search == null ? string.Empty : search;
