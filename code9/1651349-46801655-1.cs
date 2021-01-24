	class LivingBeing
	{
		public LivingBeing()
		{
			SetupVitals();
		}
		public IDictionary<VitalName, Vital> vitals;
		private void SetupVitals()
		{
			var vitalNames = Enum.GetValues(typeof(VitalName)) as VitalName[];
			vitals = vitalNames.ToDictionary(name => name, name => new Vital(name));
		}
		public void CastSpell(LivingBeing target, BlackMagic spellToCast)
		{
			switch (spellToCast.magicEffect)
			{
				case VitalModifier m:
					target.vitals[m.VitalToAdjust].currValue -= spellToCast.BaseDamage;
					break;
				default:
					throw new UnexpectedSpellEffectException();
			}
		}
	}
