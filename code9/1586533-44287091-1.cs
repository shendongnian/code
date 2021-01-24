    class StreamLoader : IStreamLoader
    {
        private readonly string _tempPath;
        public StreamLoader()
        {
        }
        public StreamLoader( string tempPath )
        {
            _tempPath = tempPath;
        }
        private string GetTempFileName()
        {
            string filename;
            if ( _tempPath == null )
            {
                filename = Path.GetTempFileName();
            }
            else
            {
                filename = Path.Combine( _tempPath, Guid.NewGuid().ToString() );
                using ( File.Create( filename ) )
                { }
            }
            return filename;
        }
        public async Task<Stream> GetStreamAsync( Uri uri )
        {
            Stream result;
            using ( var client = new HttpClient() )
            {
                var response = await client.GetAsync( uri ).ConfigureAwait( false );
                response.EnsureSuccessStatusCode();
                var filename = GetTempFileName();
                using ( var stream = File.OpenWrite( filename ) )
                {
                    await response.Content.CopyToAsync( stream );
                }
                result = new FileStream( 
                    path: filename, 
                    mode: FileMode.Open, 
                    access: FileAccess.Read, 
                    share: FileShare.None,
                    bufferSize: 4096, 
                    options: FileOptions.DeleteOnClose );
            }
            return result;
        }
    }
