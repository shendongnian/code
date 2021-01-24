    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement; // <<<<<< ADD THIS.
    
    
    public class Button_1 : MonoBehaviour
    {
     public GameObject MultiTarget_1, NameOfScene,Multi_Target_2,Multi_Target_1;
    
     public void Button_Click()
     {
        Debug.Log("Hello, World!");
        HideAll();
          MultiTarget_1.SetActive(true);
    
        }
    
         public void Button_Click2()
         {
        Debug.Log("Hello, World!");
        HideAll();
        NameOfScene.SetActive(true);
    
       }
    
       public void Button_Click3()
      {
        Debug.Log("Hello, World!");
        HideAll();
        Multi_Target_2.SetActive(true);
    
      }
    
      public void Button_String(string msg)
     {
      Debug.Log("Hello, All!");
        HideAll();
        Multi_Target_1.SetActive(true);
    
     }
     //call this to hide all
     public void HideAll(){
        MultiTarget_1.SetActive(false);
        NameOfScene.SetActive(false);
        Multi_Target_2.SetActive(false);
        Multi_Target_1.SetActive(false);
     }
    }
