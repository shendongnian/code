    using UnityEngine;
    public class example : MonoBehaviour {
        public Zebra[] ZebraGameObject = null;
        void RunZebra() {
            if (ZebraGameObject != null){
                for (int i=0; i<ZebraGameObject.Length; i++){
                    ZebraGameObject[i].RunIt();
                }
            }
        }
    }
