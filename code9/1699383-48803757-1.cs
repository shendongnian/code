    using UnityEngine;
    using UnityEngine.SceneManagement;
    using System.Collections;
    public class ScenesManager : MonoBehaviour {	
        IEnumerator loadScene;
        public float loadingProgress;
        public void LoadScene(string levelName) {
    		loadScene = AsyncLoad(levelName);
    		StartCoroutine(loadScene);
    	}
    
    	private IEnumerator AsyncLoad(string levelName) {
    		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Single);
    		asyncLoad.allowSceneActivation = false;
    
    		while (!asyncLoad.isDone) {
    			loadingProgress = Mathf.Clamp01(asyncLoad.progress);
    			asyncLoad.allowSceneActivation = false;
    			if (asyncLoad.progress == 0.9f) {
    				asyncLoad.allowSceneActivation = true;
    			}
    			yield return null;
    		}
    	}
    }
