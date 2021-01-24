    try
    {
    /* --> */ if (priceTier != null && _desiredTurnTime < Math.Abs(priceTier.TurnTimes[0]))
    {
    return String.Format(CadFramework.Rm.GetString("TurnTimeTooSoon"), priceTier.TurnTimes[0]);
    }
