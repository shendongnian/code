        private int oldLength = 0;
		private void Update()
		{
			GameObject[] TeleportationBooths = GameObject.FindGameObjectsWithTag("Teleportation Booth");
			int newLenght = TeleportationBooths.Length;
			if (newLenght > 0 && newLenght != oldLength)
			{
				GeneratePatrolPoints(TeleportationBooths);
				oldLength = newLenght;
			}
		}
		public GameObject[] GeneratePatrolPoints(GameObject[] TeleportationBooths)
		{
			patrolPoints = new PatrolData[TeleportationBooths.Length];
			for (int i = 0; i < patrolPoints.Length; i++)
			{
				patrolPoints[i] = new PatrolData();
				patrolPoints[i].target = TeleportationBooths[i].transform;
				patrolPoints[i].minDistance = 30f;
				patrolPoints[i].lingerDuration = 3f;
				patrolPoints[i].desiredHeight = 20f;
				patrolPoints[i].flightSmoothTime = 10f;
				patrolPoints[i].maxFlightspeed = 10f;
				patrolPoints[i].flightAcceleration = 3f;
				patrolPoints[i].levelingSmoothTime = 0.5f;
				patrolPoints[i].maxLevelingSpeed = 10000f;
				patrolPoints[i].levelingAcceleration = 2f;
			}
			return TeleportationBooths;
		}
