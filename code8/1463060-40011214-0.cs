             foreach (var BookOrComp in ListBookOrComp)
            {
                foreach (string Key in dActions.Keys)
                {
                    for (int DP = 1; DP <= 21; DP++)
                    {
                        dActions[Key](); // <<<-- where are the parameters?
                    }
                }
            }
