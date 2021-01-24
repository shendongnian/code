    private ConcurrentDictionary<Attack, bool> _sheduledAttacks;
    private ConcurrentDictionary<Attack, bool> _activeAttacks;
    private void RemoveSheduledAttack(Attack attack)
    {
        var dummyValue = false
        _sheduledAttacks.TryRemove(attack, out dummyValue);
    }
    private void AddActiveAttack(Attack attack)
    {
        _activeAttacks.TryAdd(attack, false);
    }
