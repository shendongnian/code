    using UnityEngine;
    using UnityEngine.UI;
    public class MyClass : MonoBehavior {
        public void ButtonClicked() {
            Transform t = transform.GetChild(0); //Panel
            Transform ta = t.FindChild("SubPanela");
            Text txt1 = ta.FindChild("Text1").GetComponent<Text>();
            Transform tb = t.FindChild("SubPanelb");
            Text txt1 = ta.FindChild("Text2").GetComponent<Text>();
        }
    }
