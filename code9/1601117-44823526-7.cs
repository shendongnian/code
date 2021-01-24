	private bool CanAddSystem()
	{
		return 
			!string.IsNullOrWhiteSpace(WeaponName)
			&& !string.IsNullOrWhiteSpace(WeaponLock)
			&& !string.IsNullOrWhiteSpace(WeaponDamage)
			&& !string.IsNullOrWhiteSpace(WeaponAttack);
	}
