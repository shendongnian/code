        async Task<IdentityResult> IIdentityValidator<TUser>.ValidateAsync(TUser item)
        {
            var errors = new List<string>();
            // ...
            // Piece of code I have now added  
            var owner = await _manager.FindByNameAsync(item.UserName);
            if (owner != null && !EqualityComparer<string>.Default.Equals(owner.Id, item.Id))
            {
                errors.Add($"Username {item.UserName} is already taken");
            }
            // End of code I added            
            // ...
            return errors.Any()
                ? IdentityResult.Failed(errors.ToArray())
                : IdentityResult.Success;
        }
