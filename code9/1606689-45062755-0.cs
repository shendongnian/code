    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class CheckWalls : MonoBehaviour
    {
    	Renderer[] renderers;
    
    	void Awake ()
    	{
    		GameObject walls = GameObject.FindGameObjectWithTag ("Wall");
    		renderers = walls.GetComponentsInChildren<Renderer> ();
    	}
    	
    	void Update() 
    	{
    		OutputVisibleRenderers(renderers);
    	}
    
    	void OutputVisibleRenderers (Renderer[] renderers)
    	{
    		foreach (var renderer in renderers)
    		{
    			// output only the visible renderers' name
    			if (IsVisible(renderer)) 
    			{
    				Debug.Log (renderer.name + " is detected!");	
    			}			
    		}
    
    		Debug.Log ("--------------------------------------------------");
    	}
    
    	private bool IsVisible(Renderer renderer) 
    	{
    		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
    
    		if (GeometryUtility.TestPlanesAABB(planes , renderer.bounds))
    			return true;
    		else
    			return false;
    	}
    }
