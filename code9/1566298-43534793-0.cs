    using System;
    using UnityEngine;
    
    namespace UnityStandardAssets.Characters.ThirdPerson
    {
        [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
        [RequireComponent(typeof (ThirdPersonCharacter))]
        public class AICharacterControl : MonoBehaviour
        {
            public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
            public ThirdPersonCharacter character { get; private set; } // the character we are controlling
            public Transform start;
            public Transform end;
            
            private Transform target;
            private boolean forward = true;
        
            private void Start()
            {
                // get the components on the object we need ( should not be null due to require component so no need to check )
                agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
                character = GetComponent<ThirdPersonCharacter>();
        
                agent.updateRotation = false;
                agent.updatePosition = true;
            }
        
        
            private void Update()
            {
                if (target != null)
                    agent.SetDestination(target.position);
        
                if (agent.remainingDistance > agent.stoppingDistance)
                {
                    character.Move(agent.desiredVelocity, false, false);
                }
                else
                {
                    SetTarget(forward ? start : end);
                    forward = !forward;
                }
            }
        
            public void SetTarget(Transform target)
            {
                this.target = target;
            }
        }
    }
