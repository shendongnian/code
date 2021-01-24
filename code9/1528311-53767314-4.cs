    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System;
    
    public class EditableGO<T> where T: IEditableGO
    {
        GameObject toInstantiate;
        Action<T> constructor;
    
        public EditableGO(Action<T> constructor, GameObject toInstantiate)
        {
            this.constructor = constructor;
            this.toInstantiate = toInstantiate;
        }
    
        public GameObject Instantiate(Vector3 position, Quaternion rotation, Transform parent = null)
        {
            GameObject instance;
            if(parent != null)
                instance = GameObject.Instantiate(toInstantiate, position, rotation, parent);
            else
                instance = GameObject.Instantiate(toInstantiate, position, rotation);
            
            T script = instance.GetComponent<T>();
            constructor(script);
            script.CustomStart();
    
            return instance;
        }
    }
