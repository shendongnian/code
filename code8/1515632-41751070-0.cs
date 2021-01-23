    using UnityEngine;
    using UnityEngine.UI;
    
    [AddComponentMenu("UI/MyText", 10)]
    public class MyText : Text
    {
        protected override void Awake()
        {
            color = GUI.skin.textField.normal.textColor; // or whatever
        }
    }
