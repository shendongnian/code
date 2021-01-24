    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class EventManager : MonoBehaviour
    {
        private Dictionary<string, List<Func<IEnumerator>>> eventDictionary;
    
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
                eventDictionary = new Dictionary<string, List<Func<IEnumerator>>>();
            }
        }
        public void StartListening(string eventName, Func<IEnumerator> listener)
        {
            List<Func<IEnumerator>> thisEvent;
            if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.Add(listener);
            }
            else
            {
                instance.eventDictionary.Add(eventName, new List<Func<IEnumerator>>() { listener });
            }
        }
    
        public void StopListening(string eventName, Func<IEnumerator> listener)
        {
            if (eventManager == null) return;
            List<Func<IEnumerator>> thisEvent;
            if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.Remove(listener);
            }
        }
    
        public void TriggerEvent(string eventName)
        {
    
            List<Func<IEnumerator>> thisEvent = null;
            if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                for (int i = thisEvent.Count -1 ; i >= 0; i--)
                {
                    if(thisEvent[i] == null)
                    { 
                         thisEvent.RemoveAt(i);
                         continue; 
                    }
                    StartCoroutine(thisEvent[i]());
                }
            }
        }
    }
