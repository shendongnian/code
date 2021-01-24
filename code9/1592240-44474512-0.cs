    public GameObject myGameObject; //Attach gameobject in Unity Editor
    private MyClass myGameObjectClass;
    
    void Start() {
        myGameObjectClass = myGameObject.GetComponent<MyClass>();
        myGameObjectClass.MyProperty = 2;
        myGameObjectClass.MyMethod();
    }
