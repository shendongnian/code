    public class PlayerFollower : AI 
    {
        List<Collectable> possibleTargets = new List<Collectable>();
        Collectable target;    
    
        void OnTriggerEnter(Collider other)
        {
            Collectable collectable = other.GetComponent<Collectable>(); 
    
            if (collectable != null && !collectable.Collected)
            {
                possibleTargets.Add(collectable);
                SetNextTarget();
            }
        }
    
        public void Collect(Collectable collectable)
        {
            possibleTargets.Remove(collectable);
            SetNextTarget();
        }
    
        void SetNextTarget() 
        {
            target = null;
            for(int i = 0; i < possibleTargets.Count; i++)
                if(!possibleTargets[i].Collected)
                {
                    target = possibleTargets[i];
                    return;
                }
        }
    }
