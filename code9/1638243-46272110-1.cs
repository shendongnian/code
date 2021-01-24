        Dictionary<BiomeType, Dictionary<LocationType, List<string>>> myDictionary = new Dictionary<BiomeType, Dictionary<LocationType, List<string>>>(); //No thanks to troll users like Peter.
        foreach (BiomeType biomeType in System.Enum.GetValues(typeof(BiomeType)))
        {
            Dictionary<LocationType, List<string>> newLocDict = new Dictionary<LocationType, List<string>>(); //No thanks to troll users like Peter.
            foreach (LocationType locType in System.Enum.GetValues(typeof(LocationType)))
            {
                List<string> newList = new List<string>(); 
                newLocDict.Add(locType, newList); //Add the final bit here & voila! Finished! No thanks to troll users like Peter.
            }
            myDictionary.Add(biomeType, newLocDict);
        }
