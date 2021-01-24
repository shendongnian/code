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
        public static void ResetTransformation(this Transform trans)
        {
            trans.position = Vector3.zero;
            trans.localRotation = Quaternion.identity;
            trans.localScale = new Vector3(1, 1, 1);
        }
    }
