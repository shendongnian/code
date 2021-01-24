    public delegate void MyDelegate();
    void someFunc() {
        MyDelegate p = test1;
        Init(p);
    }
    public IEnumerator test1() {
        ...
    }
    public static void Init(MyDelegate param) {
        ...
        StartCoroutine(param());
    }
