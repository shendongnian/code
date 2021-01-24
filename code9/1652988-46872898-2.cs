    EventTrigger trigger =Game_Controller.Database [indexi, indexj].Nute_M.GetComponent<EventTrigger> ();
    List<EventTrigger.Entry> entriesToRemove = new List<EventTrigger.Entry>();
    //finding required entry by eventId
    foreach (var entry in trigger.triggers)
    {        
        if (entry.eventID == EventTriggerType.PointerClick)
        {
            //remove listener from entry
            entry.callback.RemoveAllListeners();
            //add entry to transitional list
            entriesToRemove.Add(entry);
        }
    }
    //remove all entries satisfied condition from triggerlist
    foreach(var entry in entriesToRemove)
    {
        trigger.triggers.Remove(entry);
    }
