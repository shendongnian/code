    var entry = this.myContext.Verifications.Add(new DbVerification()
            {
                UserId = model.UserId,
                Created = DateTimeOffset.UtcNow,
                Method = model.VerificationType
            });
    context.Entry(entry.Entity).Reference(p => p.User).Load();// Add this line
    entry.Entity.User.FirstName = "peanut";
