    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class EventManager
    {
        private static Dictionary<string, Func<IEnumerator>> eventDictionary;
    
        private static EventManager eventManager;
        static EventManager()
        {
            eventDictionary = new Dictionary<string, Func<IEnumerator>>();
        }
    
        public static void StartListening(string eventName, Func<IEnumerator> listener)
        {
            Func<IEnumerator> thisEvent;
            if (eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                //Add more event to the existing one
                thisEvent += listener;
    
                //Update the Dictionary
                eventDictionary[eventName] = thisEvent;
            }
            else
            {
                //Add event to the Dictionary for the first time
                thisEvent += listener;
                eventDictionary.Add(eventName, thisEvent);
            }
        }
    
        public static void StopListening(string eventName, Func<IEnumerator> listener)
        {
            if (eventManager == null) return;
            Func<IEnumerator> thisEvent;
            if (eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                //Remove event from the existing one
                thisEvent -= listener;
    
                //Update the Dictionary
                eventDictionary[eventName] = thisEvent;
            }
        }
    
        public static void TriggerEvent(MonoBehaviour mb,string eventName)
        {
            if(mb == null) { throw new ArgumentNullException(); }
            Func<IEnumerator> thisEvent = null;
            if (eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                mb.StartCoroutine(thisEvent());
            }
        }
    }
