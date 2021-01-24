    void OnTrackingFound(){
       TrackerObject[] trackers = FindObjectsOfType<TrackerObject>()
       foreach(var t in trackers){ t.SetOff();}
       this.gameObject.GetComponent<TrackerObject>().SetOn();
    }
