       private void OnEnable()
    {
        _tabs = GetComponentsInChildren<Toggle>();
        
        // Loop through the toggles to add listeners.
        for (int i = 0; i < _tabs.Length; i++)
        {
            int idx = i;
            _tabs[idx].onValueChanged.AddListener(delegate
            {
                TabClickHandler(_tabs[idx]);
            });
        }
    }
    private void OnDisable()
    {
        // Loop through toggles to remove listeners...
        for (int i = 0; i < _tabs.Length; i++)
        {
            // As mentioned above, you need a local variable to pass to the delegate.
            int idx = i;
            _tabs[idx].onValueChanged.RemoveListener(delegate
            {
                TabClickHandler(_tabs[idx]);
            });
        }
    }
    public void TabClickHandler(Toggle tab)
    {
        // State changes are handled here which includes the previous toggle being set to off.  Therefore, filter for only the isOn == true state changes
        if (tab.isOn)
            Debug.Log("Tab: " + tab.name + "  isOn State:" + tab.isOn);
        // Do any stuff you want here.  You now can identify the tab. In my case it was to start the load process for a different inventory classification list.
    }
