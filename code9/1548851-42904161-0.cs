    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine.UI;
    using UnityEngine;
    
    public class CanvasMgr : MonoBehaviour {
   
        private static CanvasMgr instance = null;
        public static CanvasMgr Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CanvasMgr();
                }
                return instance;
            }
        }
        [SerializeField]
        private GameObject defultUI;
        [SerializeField]
        private GameObject upgradeUI;
    
        public GameObject UpgradeUI { get => upgradeUI; set => upgradeUI = value; }
        public GameObject DefultUI { get => defultUI; set => defultUI = value; }
    
        public void Refresh () { 
            if (ValueHolder.upgrademenuopen){
                DefultUI.SetActive (false);
                UpgradeUI.SetActive (true);
            }
            if(!ValueHolder.upgrademenuopen){
                DefultUI.SetActive (true);
                UpgradeUI.SetActive (false);
            }
        }
    }`
