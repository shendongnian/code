    using System.Linq;
    using UnityEngine;
    using UnityEditor;
    using System.Reflection;
    
    public class OnChangedCallAttribute : PropertyAttribute
    {
        public string methodName;
        public OnChangedCallAttribute(string methodNameNoArguments)
        {
            methodName = methodNameNoArguments;
        }
    }
    
    #if UNITY_EDITOR
    
    [CustomPropertyDrawer(typeof(OnChangedCallAttribute))]
    public class OnChangedCallAttributePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginChangeCheck();
            EditorGUI.PropertyField(position, property);
            if(EditorGUI.EndChangeCheck())
            {
                OnChangedCallAttribute at = attribute as OnChangedCallAttribute;
                MethodInfo method = property.serializedObject.targetObject.GetType().GetMethods().Where(m => m.Name == at.methodName).First();
    
                if (method != null && method.GetParameters().Count() == 0)// Only instantiate methods with 0 parameters
                    method.Invoke(property.serializedObject.targetObject, null);
            }
        }
    }
    
    #endif
