    public static InstantGameworksObjectData ReadIgoObjct(BinaryReader pReader)
    {
    	var lOutput = new InstantGameworksObjectData();
    	
    	int lVersion = pReader.ReadInt32();		// Useful in case you ever want to change the format
    	
    	int lPositionCount = pReader.ReadInt32();	// Store the length of the Position array before the data so you can pre-allocate the array.
    	lOutput.Positions = new Position[lPositionCount];
    	for ( int lPositionIndex = 0 ; lPositionIndex < lPositionCount ; ++ lPositionIndex )
    	{
			lOutput.Positions[lPositionIndex] = new Position();
    		lOutput.Positions[lPositionIndex].X = pReader.ReadSingle();
    		lOutput.Positions[lPositionIndex].Y = pReader.ReadSingle();
    		lOutput.Positions[lPositionIndex].Z = pReader.ReadSingle();
			// or if you prefer...  lOutput.Positions[lPositionIndex] = Position.ReadPosition(pReader);
    	}
    	
    	int lTextureCoordinateCount = pReader.ReadInt32();
    	lOutput.TextureCoordinates = new TextureCoordinate[lPositionCount];
    	for ( int lTextureCoordinateIndex = 0 ; lTextureCoordinateIndex < lTextureCoordinateCount ; ++ lTextureCoordinateIndex )
    	{
			lOutput.TextureCoordinates[lTextureCoordinateIndex] = new TextureCoordinate();
     		lOutput.TextureCoordinates[lTextureCoordinateIndex].X = pReader.ReadSingle();
    		lOutput.TextureCoordinates[lTextureCoordinateIndex].Y = pReader.ReadSingle();
    		lOutput.TextureCoordinates[lTextureCoordinateIndex].Z = pReader.ReadSingle();
			// or if you prefer...  lOutput.TextureCoordinates[lTextureCoordinateIndex] = TextureCoordinate.ReadTextureCoordinate(pReader);
    	}
    
    	// ...
    }
