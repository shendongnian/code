        public FSCServerLocator(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                throw new Exception("No location included at initialization");
            }
            //parameter filtering
            userLocation = location;
        }
