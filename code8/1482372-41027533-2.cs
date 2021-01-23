    MyScript myScriptInstance = FindObjectOfType<MyScript>();
    var go = new GameObject();
    var btn = go.AddComponent<Button>();
    
    var targetinfo = UnityEvent.GetValidMethodInfo(myScriptInstance,
    "OnButtonClick", new Type[] { typeof(GameObject) });
    
    UnityAction<GameObject> action = Delegate.CreateDelegate(typeof(UnityAction<GameObject>), myScriptInstance, targetinfo, false) as UnityAction<GameObject>;
    
    UnityEventTools.AddObjectPersistentListener<GameObject>(btn.onClick, action, go);
