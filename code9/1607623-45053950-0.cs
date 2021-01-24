        public bool HasHistory( Guid id )
        {
            var history = GetHistory( id );
            var check1 = false;
            var check2 = false;
            return history.Any( x =>
            {
                check1 = check1 || x.State == 0;
                check2 = check2 || x.State > 0;
                return check1 && check2;
            } );
        }
