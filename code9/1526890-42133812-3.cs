    using UnityEngine;
    public static class ExtensionMethods
    {
        public static void RemoveComponent<Component>(this GameObject obj, bool immediate = false)
        {
            Component component = obj.GetComponent<Component>();
    
            if (component != null)
            {
                if (immediate)
                {
                    Object.DestroyImmediate(component as Object, true);
                }
                else
                {
                    Object.Destroy(component as Object);
                }
    
            }
        }
    }
