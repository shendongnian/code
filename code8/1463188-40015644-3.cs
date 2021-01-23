    public void deleteFromDatabase(Realm realm, long cashDenominatorId)
    {
        realm.Write(() => 
        {
             var cashDenominator = realm.All<Person>().Where(c => c.Id == cashDenominatorId);
             Realm.RemoveRange<CashDenomination>(((RealmResults<CashDenomination>)cashDenominator));
        });
    }
