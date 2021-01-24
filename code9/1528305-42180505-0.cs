    using UnityEngine;
    
    public static class ExtensionMethod
    {
        public static Object Instantiate(this Object thisObj, Object original, Vector3 position, Quaternion rotation, Transform parent, string message)
        {
            GameObject timeBox = Object.Instantiate(original, position, rotation, parent) as GameObject;
            MessageBox scr = timeBox.GetComponent<MessageBox>();
            scr.OnCreated(message);
            return timeBox;
        }
    }
