    using UnityEngine;
    using System.Reflection;
    using UnityEngine.SceneManagement;
    using System;
     
     public class StopAutoAddVuforia : MonoBehaviour
     {
         private void Awake() {
             // https://forum.unity.com/threads/use-ar-camera-vuforia-core-in-individual-scene-not-entire-project.498489/
             try {
                 EventInfo evSceneLoaded = typeof(SceneManager).GetEvent("sceneLoaded");
                 Type tDelegate = evSceneLoaded.EventHandlerType;
     
                 MethodInfo attachHandler = typeof(Vuforia.VuforiaRuntime).GetMethod("AttachVuforiaToMainCamera", BindingFlags.NonPublic | BindingFlags.Instance);
     
                 Delegate d = Delegate.CreateDelegate(typeof(UnityEngine.Events.UnityAction<Scene, LoadSceneMode>), Vuforia.VuforiaRuntime.Instance, attachHandler);
                 SceneManager.sceneLoaded -= d as UnityEngine.Events.UnityAction<Scene, LoadSceneMode>;
             } catch (Exception e) {
                 Debug.LogError("Cant remove the AttachVuforiaToMainCamera action. Exception " + e.Message);
             }
     
             Destroy(this);
         }
     }
