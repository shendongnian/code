    public class DieScript: MonoBehaviour
    {
        private Manager manager;
        public void StartDeathProcess(Manager manager)
        {
            this.manager = manager;
            StartCoroutine(DieAsync(manager));
        }
        private IEnumerator DieAsync(Manager manager)
        {
            yield return new WaitForSeconds(timer);
            Destroy(this.gameObject);
        }
        public void Dmaage() // This is register as listener for death of the object
        {
             this.manager.PropagateDeath(this);
             Destroy(this.gameObject);
        }
    }
    
    public class Manager:MonoBehaviour
    {
        private List<DieScript> die;
        void InitiateKill(int i)  
        {
            die[i].StartDeathProcess(this);
        }
    }
