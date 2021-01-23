        public LoginResponse Login(LoginRequest request)
        {
            // Basic validation
            if (request == null)
                return new LoginResponse
                {
                    Success = false,
                    Message = "Empty Request"
                };
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                return new LoginResponse
                {
                    Success = false,
                    Message = "Username and/or password empty"
                };
            return dataAccess.Login(request);
        }
