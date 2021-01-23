            public Task UpdateAsync(UserModel model)
        {
            return Task.Factory.StartNew(() =>
            {
               var user = _dbContext.User.Find(x => x.id == model.id);
            
                user.Password = model.Password;
                _dbContext.SaveChanges();
            });
        }
