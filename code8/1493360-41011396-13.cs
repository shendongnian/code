    if (Input.GetKeyDown (KeyCode.O)) {
			arrayOrderedCombatants = new int[turnOrder[0].Value + 1];
			Debug.Log ("This is arrayOrderedCombatants Length: " + arrayOrderedCombatants.Length);
			foreach (var number in turnOrder) {				
				if (number.Value < min)
					min = number.Value;		
			}
			Debug.Log ("This is min result in random combat order: " + min);
			for (int i=0; i < arrayOrderedCombatants.Length; i++)
				arrayOrderedCombatants[i] = min -1;
			foreach (var combatant in turnOrder) {
				if (combatant.Value >= 0) {
					arrayOrderedCombatants [combatant.Value] = combatant.Value;
				}
			}
			max = turnOrder [0].Value;
			while (max >= min)
				IterateThroughTurnOrderPositions ();
		}
