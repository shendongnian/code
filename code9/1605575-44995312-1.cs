    using UnityEngine;
    using UnityEngine.Events;
    using System.Collections;
    
    namespace Namespace {
        public class ActionListener : MonoBehaviour {
            public SomeClass script;
            public void OnHover(GameObject sender, GameObject action) {
                script.OnSomething(sender, action);
            }
            public void OnClick(GameObject sender, GameObject action) {
                script.OnSomethingElse(sender, action);
            }
        }
    }
