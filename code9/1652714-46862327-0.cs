    private static List<Team> rotateTeams(List<Team> teamsArray)
            {
                // capture last value in array 
                Team lastPosition = teamsArray[teamsArray.Count - 1];
                // create a smaller array to hold remaining values
                List<Team> smallerTeamArray = new List<Team>();
                for (int i = 0; i < smallerTeamArray.Count; i++)
                {
                    smallerTeamArray[i] = teamsArray[i];
                }
                // create a temporary smaller array to rotate values
                List<Team> tempTeamsArray = new List<Team>();
                // choose how many positions to rotate
                int rotate = 1;
                // populate temp array with rotated values
                for (int i = 0; i < smallerTeamArray.Count; i++)
                {
                    tempTeamsArray[i] = smallerTeamArray[(i + rotate) % smallerTeamArray.Count];
                }
                // repopulate larger array with values and positions from smaller temp array
                for (int i = 0; i < teamsArray.Count - 1; i++)
                {
                    teamsArray[i] = tempTeamsArray[i];
                }
                // add captured last value from above to final position in array
                teamsArray[teamsArray.Count - 1] = lastPosition;
                return teamsArray;
            }
