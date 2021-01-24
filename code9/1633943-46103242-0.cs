    public Gameobject parent;
    private List<Gameobject> squadlist = new List<Gameobject>();
    
        void Start()
        {
              foreach (Transform child in parent.transform)
              {
                  if (child.tag == "Squad Member")
                      squadlist.Add(child.gameObject);
              }
        }
