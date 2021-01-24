    private void Start () {
    	print("Hexagon started");
    
        //  set up vertices
    	vertices[(int)HexFacing.North] = new Vector3(0F, 1F, floor);
        vertices[(int)HexFacing.NorthEeast] = new Vector3(1F, .5F, floor);
        vertices[(int)HexFacing.SouthEast] = new Vector3(1F, -.5F, floor);
        vertices[(int)HexFacing.South] = new Vector3(0F, -1F, floor);
        vertices[(int)HexFacing.SouthWest] = new Vector3(-1F, -.5F, floor);
        vertices[(int)HexFacing.NorthWest] = new Vector3(-1F, .5F, floor);
    
        //  set up uv
    	uv[(int)HexFacing.North] = new Vector2(0.5F, 1);
        uv[(int)HexFacing.NorthEeast] = new Vector2(1, 0.75F);
        uv[(int)HexFacing.SouthEast] = new Vector2(1, 0.25F);
        uv[(int)HexFacing.South] = new Vector2(0.5F, 0);
        uv[(int)HexFacing.SouthWest] = new Vector2(0, 0.25F);
        uv[(int)HexFacing.NorthWest] = new Vector2(0, 0.75F);
    
    	SetUpMesh();
    }
