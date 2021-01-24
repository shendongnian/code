        // audioSource.Play
        script.Events = new UnityEvent();
        UnityAction methodDelegate = System.Delegate.CreateDelegate (typeof(UnityAction), audioSource, "Play") as UnityAction;
        UnityEventTools.AddPersistentListener (script.Events, methodDelegate);
    
        // animator.Play(string) - its only add this animator
        script.Events = new UnityEvent();
        UnityAction<string> methodDelegateString = System.Delegate.CreateDelegate(typeof(UnityAction<string>), Selection.activeGameObject.GetComponent<Animator>(), "Play") as UnityAction<string>;
        UnityEventTools.AddStringPersistentListener(script.Events, methodDelegateString, "lala");
