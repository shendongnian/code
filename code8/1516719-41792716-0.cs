        public static void Update_Calls()
		{
			for (int i = 0; i < callsForUpdate.Count; i++)
			{
				callsForUpdate.ElementAt(i)();
			}
			callsForUpdate.Clear();
		}
