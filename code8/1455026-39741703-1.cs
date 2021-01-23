    public static CustomPrincipal FromMember(MemberModel model)
    {
        return new CustomPrincipal()
        {
            Username = model.Username,
            ...
        }
    }
