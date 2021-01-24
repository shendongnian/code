        /// <summary>
        /// Get the base table query for this entity, with user policy applied
        /// </summary>
        /// <returns>Default IQueryable reference to use in this controller</returns>
        protected Task<IQueryable<TEntity>> GetQuery()
        {
            var dbQuery = this.GetEntityQuery();
            return this.ApplyUserPolicy(dbQuery);
        }
		/// <summary>
        /// Inheriting classes MUST override this method to include standard related tables to the DB query
        /// </summary>
        /// <returns></returns>
        protected abstract DbQuery<TEntity> GetEntityQuery();
		/// <summary>
        /// Apply default user policy to the DBQuery that will be used by actions on this controller.
        /// </summary>
        /// <remarks>
        /// Allow inheriting classes to implement or override the DBQuery before it is parsed to an IQueryable, note that you cannot easily add include statements once it is IQueryable
        /// </remarks>
        /// <param name="dataTable">DbQuery to parse</param>
        /// <param name="tokenParameters">Security and Context Token variables that you can apply if you want to</param>
        /// <returns></returns>
        protected virtual IQueryable<TEntity> ApplyUserPolicy(DbQuery<TEntity> dataTable, System.Collections.Specialized.NameValueCollection tokenParameters)
        {
            // TODO: Implement default user policy filtering - like filter by tenant or customer.
                        
            return dataTable;
        }
