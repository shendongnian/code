    foreach(Transform gObject in GetComponentsInChildren<Transform>()){
       if(gObject.tag == "car")
       {
          modelsList.Add(gObject.gameObject);
       }
    }
