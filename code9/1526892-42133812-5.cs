    using UnityEngine;
    public static class ExtensionMethods
    {
        public static void RemoveComponent<T>(this GameObject obj, bool immediate = false)
        {
            T component = obj.GetComponent<T>();
    
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
