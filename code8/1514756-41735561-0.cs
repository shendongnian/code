        public void Update( List<Data> data, List<RefCodes> refCodes )
        {
            List<RefCodes> differences = refCodes
                .Where( r => data.Any( d => r.old_code == d.code ) )
                .ToList();
            differences.ForEach( ( RefCodes item ) =>
             {
                 Data element = data.FirstOrDefault( d => d.code == item.old_code );
                 element.code = item.new_code;
                 element.name = item.new_name;
             } );
        }
