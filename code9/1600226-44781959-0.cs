	class SpeedLimit
	{
		public int CaughtSpeeding(int speed, bool isBirthday)
		{
			var measuredSpeed = isBirthday
									? speed - 5
									: speed;
			if (measuredSpeed < 61)
			{
				return 0;
			}
			else if (measuredSpeed >= 61 &&
			         measuredSpeed <= 80)
			{
				return 1;
			}
			else
			{
				return 2;
			}
		}
	}
