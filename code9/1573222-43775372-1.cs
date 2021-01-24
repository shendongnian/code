    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    
    public class time : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    
        public float gazeTime = 2f;
        private float timer = 0f;
        private bool gazedAt = false;
    
        // Use this for initialization
        void Start () {
    
        }
        void Update(){
            if (gazedAt)
            {
                timer += Time.deltaTime;
                if (timer >= gazeTime)
                {
                    SceneManager.LoadScene("OtherSceneName");
                    timer = 0f;
                }
            }
        }
        public void ss(string scenetochangeto)
        {
            gameObject.SetActive (true);
        }
    
        public void OnPointerEnter(PointerEventData eventData)
        {
            //Debug.Log("pointer enter");
            gazedAt = true;
        }
    
        public void OnPointerExit(PointerEventData eventData)
        {
            //Debug.Log("pointer exit");
            gazedAt = false;
        }
    }
