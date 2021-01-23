    using Devdog.General;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class SafeZone : MonoBehaviour {
    
        protected vp_FPPlayerEventHandler m_Player = null;
        protected bool safe;
        protected Player player;
    
        // Use this for initialization
        void Start()
        {
            if (m_Player == null)
            {
                m_Player = GameObject.Find("Gringan").GetComponent<vp_FPPlayerEventHandler>();
            }
    
        }
    
        // Update is called once per frame
        void Update()
        {
    
        }
    
        /// <summary>
    	/// registers this component with the event handler (if any)
    	/// </summary>
    	protected virtual void OnEnable()
        {
            if (m_Player != null)
                m_Player.Register(this);
        }
    
        /// <summary>
        /// unregisters this component from the event handler (if any)
        /// </summary>
        protected virtual void OnDisable()
        {
            if (m_Player != null)
                m_Player.Unregister(this);
        }
    
        void OnTriggerEnter(Collider other)
        {
            if (player == null)
            {
                player = other.transform.parent.GetComponent<Player>(); // Player is in Devdog.General;
            }
    
            if (player != null)
            {
                print("Collision detected with trigger object "  + player.name);
                safe = true;
                m_Player.PlayerIsSafe.Send(safe);
            }
        }
    
        /*void OnTriggerStay(Collider other)
        {
           if (player == null)
            {
                player = other.transform.parent.GetComponent<Player>(); // Player is in Devdog.General;
            }
    
            if (p != null)
            {
                print("Still colliding with trigger object PLAYER " + p.name);
                safe = true;
                m_Player.PlayerIsSafe.Send(safe);
            }
        }*/
    
        void OnTriggerExit(Collider other)
        {
            if (player == null)
            {
                player = other.transform.parent.GetComponent<Player>(); // Player is in Devdog.General;
            }
    
            if (player != null)
            {
                print(gameObject.name + " and trigger object PLAYER " + player.name + " are no longer colliding");
                safe = false;
                m_Player.PlayerIsSafe.Send(safe);
            }
        }
    }
