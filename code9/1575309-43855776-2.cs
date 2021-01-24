     for(int i = 0; i < runtimeToggles.Length; i++)
     {
          runtimeToggles[i] = Instantiate(togglePrefab);
          // no-parameter version:
          runtimeToggles[i].onValueChanged.AddListener(delegate{ MyMethod(thatInteger); });
          // boolean parameter version:
          runtimeToggles[i].onValueChanged.AddListener(delegate (bool b){ MyMethod(thatInteger); });
     }
