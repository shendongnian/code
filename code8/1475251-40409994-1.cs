        using System.Collections;
    using UnityEngine;
    
    public class EnnemyAI : MonoBehaviour
    {
        public float AttackDamage = 1.0f;
        public float AttackSpeed = 1.0f;
        public float AttackRange = 1.0f;
    
        private bool isPlayerInSight;
        private GameObject target;
        private NavMeshAgent agent;
    
    
        // Use this for initialization
        void Start ()
        {
            target = GameObject.FindGameObjectWithTag("Player");
            agent = GetComponent<NavMeshAgent>();
    
            StartCoroutine(AttackLoop());
        }
    	
    	// Update is called once per frame
    	void Update ()
        {
            if (isPlayerInSight)
            {
                agent.destination = target.transform.position;
            }
        }
    
        IEnumerator AttackLoop()
        {
            while (true)
            {
                //I don't know your attacking logic, so lets say they can attack in a 1 unit range
                while (Vector3.Distance(target.transform.position, this.transform.position) <= AttackRange)
                {
           
         Attack();
                yield return new WaitForSeconds(AttackSpeed);
            }
            yield return 0;
        }
    }
    void Attack()
    {
        target.GetComponent<PlayerHealth>().TakeDamage(AttackDamage);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerInSight = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerInSight = false;
        }
    }
