        public MySqlConnection Connection
        {
            get {
                IsConnect();
                return connection; }
        }
