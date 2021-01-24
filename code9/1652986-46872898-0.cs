    EventTrigger trigger =Game_Controller.Database [indexi, indexj].Nute_M.GetComponent<EventTrigger> ();
    EventTrigger.Entry entry;
    foreach(var etEntry in trigger.triggers)
    {
        if (etEntry.eventID == EventTriggerType.PointerClick)
        {
            entry = etEntry;
        }
    }
    entry.eventID = EventTriggerType.PointerClick;
    entry.callback.RemoveAllListeners ();
    trigger.triggers.Add (entry);
