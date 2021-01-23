    public void deleteFromDatabase(List<CashDenomination> denom_list)
    {
        if (!denom_list[0].IsValid) // If this object is not in the realm, do nothing.
            return;
        var realm = Realm.GetInstance(config);
        using (var transaction = realm.BeginWrite())
        {
            realm.Remove(denom_list[0]);
            transaction.Commit();
        }
    }
