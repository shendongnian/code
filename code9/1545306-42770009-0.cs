        public FSCServerLocator(string location)
        {
            //parameter filtering
            userLocation = location;
            if (string.IsNullOrWhiteSpace(userLocation))
            {
                throw new Exception("No location included at initialization");
            }
        }
