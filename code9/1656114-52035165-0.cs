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
     
                 MethodInfo attachHandler = typeof(Vuforia.VuforiaRuntime).GetMethod("AttachVuforiaToMainCamera", BindingFlags.NonPublic | BindingFlags.Static);
     
                 Delegate d = Delegate.CreateDelegate(tDelegate, attachHandler);
                 SceneManager.sceneLoaded -= d as UnityEngine.Events.UnityAction<Scene, LoadSceneMode>;
             } catch (Exception e) {
                 Debug.LogWarning("Cant remove the AttachVuforiaToMainCamera action. Execption:" + e.Message);
             }
     
             Destroy(this);
         }
     }
