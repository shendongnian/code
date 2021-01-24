    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System;
    
    public class SimpleParticle : MonoBehaviour, IEditableGO
    {
        [HideInInspector]
        public float Duration, Distance, Size, Speed;
        [HideInInspector]
        public Vector3 Direction;
    
        float traveledDistance;
        float birth;
    
        public static Action<SimpleParticle> ConstructorGenerator(float duration, float distance, float size, float speed, Vector3 direction)
        {
            Action<SimpleParticle> action = (simpleParticle) => {
                simpleParticle.Duration = duration;
                simpleParticle.Distance = distance;
                simpleParticle.Size = size;
                simpleParticle.Direction = direction;
                simpleParticle.Speed = speed;
            };
            return action;
        }
    
    
        public void CustomStart()
        {
            birth = Time.time;
        }
    
        // Update is called once per frame
        void Update()
        {
            float deltaDist =  Speed * Time.deltaTime;
            traveledDistance += deltaDist;
            transform.position += Direction * deltaDist;
    
            if(Time.time - birth > Duration)
                Destroy(this.gameObject);
        }
    }
