    using System;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.SceneManagement;
    public class LevelReset :MonoBehaviour , IPointerClickHandler
    {
       void Update(){
        if (Input.GetKeyDown("j"))
        {
          // reload the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
       }
    }
