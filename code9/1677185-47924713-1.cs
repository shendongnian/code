    for (int i = 0; i < allComponents.Count; i++)
    {
        //Loop through each blacklisted Component and see if it is present
        for (int j = 0; j < blacklistedComponents.Length; j++)
        {
            if (allComponents[i].GetType() == blacklistedComponents[j])
            {
                Debug.Log("Found Blacklisted Component: " + targetComponents[i].GetType().Name);
                Debug.Log("Removing Blacklisted Component");
                //Destroy Component
                DestroyImmediate(allComponents[i]);
    
                Debug.LogWarning("This component is now destroyed");
            }
        }
    }
