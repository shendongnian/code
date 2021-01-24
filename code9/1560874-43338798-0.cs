    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    public class NodesGenerator : MonoBehaviour {
        public Button btnGenerate;
         private void Start()
         {
             Button btn = btnGenerate.GetComponent<Button>();
             btn.onClick.AddListener(TaskOnClick);
         }
         void Update()
         {
             if (Input.GetKeyDown(KeyCode.Escape))
             {
                 btnGenerate.gameObject.SetActive(!btnGenerate.gameObject.activeSelf);
             }
         }
         void TaskOnClick()
         {
             Debug.Log("You have clicked the button!");
         }
    }
