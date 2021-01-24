    		private int findNoOfRaces(Place pPlace)
		{
			foreach (Place program in placeList)
			{
				foreach (string line in raceDetails)
				{
					string raceNoTotal = "";
					if (line.StartsWith(pTrack.Program + "="))
					{
						char delimiter = '=';
						string value = line;
						string[] raceSubstring = value.Split(delimiter);
						raceNoTotal = raceSubstring[1];
						for (int i = 1; i <= Convert.ToInt32(raceNoTotal); i++)
						{
							foreach (Pool nextPool in poolList)
							{
								listBox1.Items.Add(pTrack.Program + " " + " " + nextPool.poolName + " " +i);
							}
						}
						return Convert.ToInt32(raceNoTotal);
					}
				}
			}
			return -1;
		}
