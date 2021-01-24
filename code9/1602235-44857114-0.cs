    public class Program
    {
    	public class GameObject{
    		public string name;
    	}
    	
       public class SetupWeapon {
    
            public int poolSize;
            public GameObject prefab;
    
            public SetupWeapon(int size, GameObject goPrefab) {
                this.poolSize = size;
                this.prefab = goPrefab;
            }
        }
    	
    	
    	    public int[] AttackIDs {
            get {
                var toArray = _weaponData.Select(a => a.Key).ToArray();
                return toArray;
            }
        }
        private int[] PoolSize {
            get {
                var toArray = _weaponData.Select(a => a.Value.poolSize).ToArray();
                return toArray;
            }
        }
        private GameObject[] Prefab {
            get {
                var toArray = _weaponData.Select(a => a.Value.prefab).ToArray();
                return toArray;
            }
        }
    	
    	public Dictionary<int, SetupWeapon> _weaponData = new Dictionary<int, SetupWeapon>();
        public void Start () {
    
            for (int i = 0; i < AttackIDs.Length; i++){
                Console.WriteLine(AttackIDs[i]); // works just fine
                Console.WriteLine(_weaponData[0].poolSize); // works just fine
                Console.WriteLine(_weaponData[0].prefab.name); // works just fine
                Console.WriteLine(PoolSize[0]); // NullReferenceException
                Console.WriteLine(Prefab[0].name); // NullReferenceException
            }
        }
    	
    	public static void Main()
    	{
    		var p = new Program();
    		p._weaponData.Add(0, new SetupWeapon(0, new GameObject(){ name = "0"}));
    		p._weaponData.Add(1, null);  // this will cause null exception
    		p._weaponData.Add(2, new SetupWeapon(2, null)); // this will not cause null exception
    
    		p.Start();
    		
    	}
    }
