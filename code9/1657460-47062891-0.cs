    using UnityEngine;
    using System;
    
    public class MyMonoBehaviour: MonoBehaviour
    {
    	public Func<bool> MyTest ;
        private void Update()
        {
            if( MyTest != null && MyTest() )
            {
                 Debug.Log("Success !");
            }
        }
    }
----
    using UnityEngine;
    
    public class MyOtherMonoBehaviour: MonoBehaviour
    {
    	public MyMonoBehaviour MyMonoBehaviour ;
        private void Start()
        {
            MyMonoBehaviour.MyTest = AmIHandsome ;
        }
        private bool AmIHandsome()
        {
            return true ;
        }
    }
