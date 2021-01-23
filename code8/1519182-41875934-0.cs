        public async Task RegisterUserAsync(UserRegisterModel model)
        {
            var store = DataAccessFactory.Authentication();
    
            //check if unique email
            if(await store.EmailExist(model.Email))
                throw new ValidationException($"Email {model.Email} is already registered.");
    
            await store.RegisterAsync(model);
        }
