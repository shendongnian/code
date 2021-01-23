    public bool IsFabricMember(string wwn)
    {
        if (MemberSwitches.Any(x => x.Value.HasWWN(wwn))) { return true; }
        else { return false; }
    }
