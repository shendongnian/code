    public class FloorManager:MonoBehaviour
        {
            public gameObject floorPrefab;
    
            private List<Floor> floors;
    
            void Start()
            {
                floors = new List<Floor>();
            }
    
            public void AddFloor()
            {
                //instantiate prefab // gameObject floorGo = Instantiate....
                Floor floorScript = floorGo.getComponent<Floor>();
                floors.Add(floorScript);
                floorScript.AddPoles();
    
            }
    
            public void RemoveFloor(Floor floor)
            {
                floors[floors.IndexOf(floor)].gameObject.Destory();
                floors.Remove(floor);
            }
        }
    
        public class Floor : MonoBehaviour
        {
    
            public gameObject polePrefab;
    
            public Pole [] poles = new Pole[4];
    
            public void AddPoles()
            {
                for (int i = 0; i < 4; i++)
                {
                    //instantiate prefab // gameObject poleGo = Instantiate....
                    
                    Pole poleScript = poleGo.getComponent<Pole>();
                    poles[i]=poleScript;
                }
            }
            
        }
    
        public class Pole : MonoBehaviour
        {
            //some logic here if needed...Destroy...Damage...
        }
