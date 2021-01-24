    public override TInner Select<TInner>(ushort id)
    {
        // UserModel is just a Class where I is an integer typed property
        UserModel.I = 2;
        object result = UserModel.I;
        return (TInner)Convert.ChangeType(result, typeof(TInner));
        throw new NotImplementedException();
    }
