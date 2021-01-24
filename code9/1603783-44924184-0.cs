    bool isDoPathFindingRunning = false;
    IEnumerator = doPathFinding();
    
    private void Awake() {
    	pathFinding = doPathfinding();
    }
    
    private void WhereeverYouStartCoroutine() {
    	if (!isDoPathFindingRunning)
    		StartCoroutine(pathFinding);
    }
    
    public IEnumerator doPathfinding() {
    	isDoPathFindingRunning = true;
        // Do your stuff
    	isDoPathFindingRunning = false;
    }
