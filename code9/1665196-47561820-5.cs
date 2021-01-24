    using UnityEngine;
    using System.Collections;
    using System.Runtime.InteropServices;
    
    public class CallNativeCode : MonoBehaviour
    {    
        [DllImport("SharedObject1")]
        private static extern float Foopluginmethod();
    
        void OnGUI ()
    	{
            // This Line should display "Foopluginmethod: 10"
            GUI.Label(new Rect(15, 125, 450, 100), "Foopluginmethod: " + Foopluginmethod());
        }
    }
