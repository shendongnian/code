      using UnityEngine.SceneManagement;
     
      void OnEnable() 
      {
          SceneManager.sceneLoaded += OnSceneLoaded;
      }
     
      void OnDisable() 
      {
          SceneManager.sceneLoaded -= OnSceneLoaded;
      }
     
      private void OnSceneLoaded(Scene scene, LoadSceneMode mode) 
      {
          // all objects are loaded, call other methods
      }
