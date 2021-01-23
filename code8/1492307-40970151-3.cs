        [ResponseType(typeof(IEnumerable<string>))]
        public async Task<IHttpActionResult> Get([FromUri] int[] idList)
        {
            var values = Enumerable.Range(1, 10);
            if (idList.Any()) // use optional filter e.g. pass to repository
                values = values.Where(i => idList.Contains(i));
            return Ok(values.Select(i => $"value{i}").ToList());
        }
    
