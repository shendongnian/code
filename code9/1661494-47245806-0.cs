    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    /// <summary>
    /// Attach this script to objects that has a CanvasScaler component.
    /// 
    /// This makes sure the UI enlarges/shrinks when the device resolution changes.
    ///  
    /// scaleFactor = 1.333f * Screen.height / 640;
    /// Galuxy Notes 4: 2560X1440,  iphone 5s: (1136X640)
    ///         |                           |
    ///         v                           v
    /// scaleFactor = 3                 scaleFactor = 1        
    /// </summary>
    public class DynamicCanvasScaler : MonoBehaviour {
    	
    	void Start () {
            AdjustDynamicCanvasScalar();
        }
        /// <summary>
    	/// Canvas Scalar determins how large the UI elements are. On high resolution 
    	/// deveices, this value should be larger, to make sure it is clearly visible
    	/// and on low resolution devices, this should be kept smaller so that the UI
    	/// menus are not so big.
    	/// </summary>
    	private void AdjustDynamicCanvasScalar()
        {
            var cs = gameObject.GetComponent<CanvasScaler>();
            if (cs == null)
                Debug.LogError("Cannot find the canvas scalar");
            else
            { //Galuxy Notes 4: 2560X1440, iphone 5s: (1136X640)  
                cs.scaleFactor = 1.333f * Screen.height / 640;
                Debug.Log("----------" + "Canvas Scalar = " + cs.scaleFactor + " ----------");
            }
        }
    }
