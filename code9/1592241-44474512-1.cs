    public GameObject myGameObject; //Attach gameobject in Unity Editor
    private MyClass myGameObjectClass;
    
    void Start() {
        myGameObjectClass = myGameObject.GetComponent<MyClass>();
        //or you could use this
        //myGameObjectClass = myGameObject.GetComponent(typeof(MyClass)) as MyClass;
        myGameObjectClass.MyProperty = 2;
        myGameObjectClass.MyMethod();
    }
