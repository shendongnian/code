        script.Events = new UnityEvent(); // Only create the UnityEvent instance once
        UnityAction methodDelegate = System.Delegate.CreateDelegate (typeof(UnityAction), audioSource, "Play") as UnityAction;
        UnityEventTools.AddPersistentListener (script.Events, methodDelegate);
    
        UnityAction<string> methodDelegateString = System.Delegate.CreateDelegate(typeof(UnityAction<string>), Selection.activeGameObject.GetComponent<Animator>(), "Play") as UnityAction<string>;
        UnityEventTools.AddStringPersistentListener(script.Events, methodDelegateString, "lala");
