        public virtual async Task<IList<My20FieldsDataRecord>> LoadMyList()
        {
            var results = await this.DataContext.TwentyFieldDataRecords
               .OrderByDescending(x => x.MyDate).ToListAsync().ConfigureAwait(false);
            return results;
        }	
