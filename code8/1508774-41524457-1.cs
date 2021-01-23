    public class Movement : MonoBehaviour 
    {
        // You'll need a list of available targets
        public List<Transform> Targets;
        
        // The speed to move at
        public float Speed = 30;
  
        // A variable to keep track of the current target
        private int _currentTargetIndex = 0;
        public void Update()
        {
            // Get the current target
            var target = Targets[_currentTargetIndex];
            // Move towards it every frame
            transform.position = Vector3.MoveTowards(transform.position, target.position, Speed);
            // If the space bar was pressed this frame
            if(Input.GetKeyDown("space"))
            {
                // Select the next target
                _currentTargetIndex++;
                // If we've run out of targets, wrap around to the beginning 
                if(_currentTargetIndex >= Targets.Count) 
                {
                    _currentTargetIndex = 0;
                }
            } 
        }
    }
