using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class EventManager : MonoBehaviour
{
    private Dictionary<string, Action> eventDictionary;
    private static EventManager eventManager;
    public static EventManager instance
    {
        get
        {
            if (!eventManager)
            {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;
                if (!eventManager)
                {
                    Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                }
                else
                {
                    eventManager.Init();
                }
            }
            return eventManager;
        }
    }
    void Init()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, Action>();
        }
    }
    public static void StartListening(string eventName, Action listener)
    {
        if (instance.eventDictionary.ContainsKey(eventName))
        {
            instance.eventDictionary[eventName] += listener;
        }
        else
        {
            instance.eventDictionary.Add(eventName, listener);
        }
    }
    public static void StopListening(string eventName, Action listener)
    {
        if (instance.eventDictionary.ContainsKey(eventName))
        {
            instance.eventDictionary[eventName] -= listener;
        }
    }
    public static void TriggerEvent(string eventName)
    {
        Action thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }
}
Here is a link to a StackOverflow question I posted on this
https://stackoverflow.com/questions/59464245/why-do-i-get-a-clone-of-action-when-getting-from-dictionary
> When you call TryGetValue(eventName, out thisEvent) you are providing a reference to which the Dictionary will write the value. You are not getting a reference to what is inside the Dictionary (I mean, you are not getting a deep pointer to the Dictionary structure, meaning that assigning to it will NOT modify the Dictionary).
