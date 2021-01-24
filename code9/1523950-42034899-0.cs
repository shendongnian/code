    using UnityEngine;
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
    
            Action thisEvent;
            if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent += listener;
            }
            else
            {
                thisEvent += listener;
                instance.eventDictionary.Add(eventName, thisEvent);
            }
        }
    
        public static void StopListening(string eventName, Action listener)
        {
            if (eventManager == null) return;
            Action thisEvent;
            if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent -= listener;
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
