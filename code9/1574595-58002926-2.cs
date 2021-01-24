        public async Task<bool> RegisterAsync(Registration registration, ILambdaContext context)
        {
            await RegisterHelper(registration);
            return true;
        }
        public async Task<User> CreateUserAsync(User newUser, ILambdaContext context)
        {
            return await CreateUserHelper(newUser);
        }
