    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine.UI;
    using UnityEngine.Events;
    
    public class DynamicScrollView : MonoBehaviour 
    {
    	public GameObject Prefab;
    	public Transform Container;
    	public List<string> files = new List<string>();
    
    	void Start()
    	{
    //		files =  // LOAD FILE NAMES HERE.
    
    		for (int i = 0; i < files.Count; i++)
    		{
    			GameObject go = Instantiate(Prefab);
    			go.GetComponentInChildren<Text>().text = files[i];
    			go.transform.SetParent(Container);
    			go.transform.localPosition = Vector3.zero;
    			go.transform.localScale = Vector3.one;
    			int j = i;
    			go.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(j));
    		}
    	}
    
    
    
    	public void OnButtonClick(int index)
    	{
    		string file = files[index];
    
    		Debug.Log(file);
    		// Process file here...
    	}
    }
