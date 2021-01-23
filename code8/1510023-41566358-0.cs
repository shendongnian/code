    class MyService
    {
        public async Task<OperationResult<string, SomeEntity>> CreateManyAsync( IList<string> data, int chunkSize )
        {
            var succeded = new List<SomeEntity>( );
            var failed = new List<FailedOperation<string>>( );
            foreach ( var chunk in data.Select( ( dataItem, index ) => new { data = dataItem, chunk = index % chunkSize } ).GroupBy( c => c.chunk, c => c.data ) )
            {
                try
                {
                    succeded.AddRange( await InternalCreateManyAsync( chunk ) );
                    continue;
                }
                catch ( Exception )
                {
                    // we just eat this exception
                }
                foreach ( var singleItem in chunk )
                {
                    try
                    {
                        succeded.Add( await InternalCreateSingleAsync( singleItem ) );
                    }
                    catch ( Exception ex )
                    {
                        failed.Add( new FailedOperation<string>( singleItem, ex ) );
                    }
                }
            }
            return new OperationResult<string, SomeEntity> {
                Succeded = succeded,
                Failed = failed,
            };
        }
        private async Task<IList<SomeEntity>> InternalCreateManyAsync( IEnumerable<string> data )
        {
            var result = new List<SomeEntity>( );
            using ( var db = new MyCOntext( ) )
            {
                foreach ( var item in data )
                {
                    result.Add( AddSingleToContext( item, db ) );
                }
                await db.SaveChangesAsync( );
            }
            return result;
        }
        private async Task<SomeEntity> InternalCreateSingleAsync( string data )
        {
            using ( var db = new MyContext( ) )
            {
                var e = AddSingleToContext( data, db );
                await db.SaveChangesAsync( );
                return e;
            }
        }
        private SomeEntity AddSingleToContext( string data, MyContext context )
        {
            var entity = new SomeEntity { Data = data, };
            context.SomeEntities.Add( entity );
            return entity;
        }
    }
