    void findTheSameTileGroupIDAndChangeColor(GameObject selectedObj)
    {
        //Get the TileScript attached to the selectedObj
        TileScript selectedTileScript = selectedObj.GetComponent<TileScript>();
    
        //Loop through all GameObject in the array
        for (int i = 0; i < tilesArray.Length; i++)
        {
            /* 
               Make sure this is NOT selectedObj since we've arleady 
               changed its Material in OnObjectSelection function
            */
            if (selectedObj != tilesArray[i])
            {
                //Get TileScript attached to the current Tile loop
                TileScript tileLoop = tilesArray[i].GetComponent<TileScript>();
                //Check if selectedObj and the current loop tileGroupID matches
                if (selectedTileScript.tileGroupID == tileLoop.tileGroupID)
                {
                    //It matches! Now, change it's color
                    selectedObj.GetComponent<MeshRenderer>().material = tileSelectedMaterial;
                }
            }
        }
    }
