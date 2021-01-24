    using System.Collections.Generic;
    using UnityEngine;
    public class SomeMono : MonoBehaviour
    {
        private List<GameObject> _controlledGOs = new List<GameObject>();
        private List<float> _loggedZs = new List<float>();
        
        void YokEtme()
        {
            int x = Random.Range(35, 0);       
            a = objeler [x];
            
            a.GetComponent<Rigidbody>().useGravity = true;
            
            _controlledGOs.Add(a);
            _loggedZs.Add(a.GetComponent<Transform>().position);
        }
        void SetGravityForGameObjects()
        {
            for (var i = 0; i < 5; i++)
                YokEtme();
            StartCoroutine()
        }
        IEnumerator bekleme ()
        {
            yield return new WaitForSeconds (9);
            for (var i = 0; i < _controlledGOs.Count; i++)
            {
               var a = _controlledGOs[a];
               a.GetComponent<Rigidbody>().useGravity = false;
               a.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
               a.transform.position= _loggedZs[i];
               a.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
               Debug.Log (a);
            }
        }
    }
