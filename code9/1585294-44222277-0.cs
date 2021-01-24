    using UnityEngine;
    using System;
    
    public class InstantiateObjects : MonoBehaviour {
    
        public ObjectsToInst[] objectsToInstantiate;
    
        [Serializable]
        public struct ObjectsToInst
        {
            public GameObject objectToInstantiate;
            public Terrain terrain;
            public float yOffset;
            public int numberOfObjectsToCreate;
            public bool parent;
            public bool randomScale;
            public float setRandScaleXMin, setRandScaleXMax;
            public float setTandScaleYMin, setTandScaleYMax;
            public float setTandScaleZMin, setRandScaleZMax;
        }
    }
