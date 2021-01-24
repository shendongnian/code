        /// <summary>
        /// Check that User has permission to view the rows and the required role level
        /// </summary>
        /// <remarks>This applies to all queries on this controller</remarks>
        /// <param name="dataTable">Base DbQuery to parse</param>
        /// <returns></returns>
        protected override IQueryable<Machine> ApplyUserPolicy(DbQuery<Machine> dataTable)
        {
            // Apply base level policies, we only want to add further filtering conditions, we are not trying to circumvent base level security
            var query = base.ApplyUserPolicy(dataTable, tokenParameters);
                    
            // I am faking your CheckMachineAccess code, as I don't know what your logic is
            var role = GetUserRole();
            query = query.Where(m => m.MachineRole == role);
                    
            // additional rule... prehaps user is associated to a specific plant or site and con only access machines at that plant
            var plant = GetUserPlant();
            if (plant != null) // Maybe plant is optional, so admin users might not return a plant, as they can access all machines
            {
                query = query.Where(m => m.PlantId == plant.PlantId);
            }
                    
            return query;
        }
        
        [HttpGet]
        [ODataRoute("Machines")]
        [EnableQuery]
        public IQueryable<Machine> FilterMachines(ODataQueryOptions opts)
        {
            // Get the default query with security applied
            var expression = GetQuery();
                    
            // TODO: apply any additional queries specific to this endpoint, if there are any
                    
            return expression;
        }
        
        [HttpGet]
        [ODataRoute("Machine")]
        [EnableQuery] // so we can still apply $select and $expand
        [HttpGet]
        public SingleResult<Machine> GetMachine([FromODataUri] int key)
        { 
            // Get the default query with security applied
            var query = GetQuery();
            // Now filter for just this item by id
            query = query.Where(m => m.Id == key);
                         
            return SingleResult.Create(query);
        }
        
        
        [HttpGet]
        [ODataRoute("MachinesThatNeedService")]
        [EnableQuery]
        internal IQueryable<Machine> GetMachinesServiceDue(ODataQueryOptions opts)
        {
            // Get the default query with security applied
            var query = GetQuery();
            // apply the specific filter for this endpoint
            var lastValidServiceDate = DateTimeOffset.Now.Add(-TimeSpan.FromDays(60));
            query = query.Where(m => m.LastService < lastValidServiceDate);
            
            return query;
        }
