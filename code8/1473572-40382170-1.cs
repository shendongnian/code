    public virtual IdentityManagerResult SetPhone(TUser user, string phone)
    {
        var result = this.userManager.SetPhoneNumber(user.Id, phone);
        // [...]
    }
