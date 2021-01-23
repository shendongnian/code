    void OnEnable()
    {
        SceneView.onSceneGUIDelegate += this.OnSceneMouseOver;
    }
    
    void OnSceneMouseOver(SceneView view)
     {
      Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
      RaycastHit hit;
      //And add switch Event.current.type for checking Mouse click and switch tiles
      if (Physics.Raycast (ray, out hit, 100f)) 
      {
       Debug.DrawRay (ray.origin, hit.transform.position, Color.blue, 5f);
       Debug.Log (hit.transform.name);
       Debug.Log (hit.transform.position);
      }
     }
