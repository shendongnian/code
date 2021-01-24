    using System;
    using UnityEngine;
    public class TestA
    {
    	[RuntimeInitializeOnLoadMethod]
    	private static void OnInit()
    	{
    		Debug.Log("TEST A - This does NOT print in Standalone");
    	}
    }
