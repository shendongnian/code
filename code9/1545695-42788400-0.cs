    using System;
    using System.Reflection;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class MissingOnClickDetector : MonoBehaviour
    {
        void Start()
        {
            searchForMissingOnClickFunctions();
        }
    
        void searchForMissingOnClickFunctions()
        {
            //Find all Buttons in the scene including hiding ones
            Button[] allButtonScriptsInScene = Resources.FindObjectsOfTypeAll<Button>() as Button[];
            for (int i = 0; i < allButtonScriptsInScene.Length; i++)
            {
                detectButtonError(allButtonScriptsInScene[i]);
            }
        }
    
        //Searches each registered onClick function in each class
        void detectButtonError(Button button)
        {
            for (int i = 0; i < button.onClick.GetPersistentEventCount(); i++)
            {
                //Get the target name
                UnityEngine.Object objectName = button.onClick.GetPersistentTarget(i);
    
                //Get the function name
                string methodName = button.onClick.GetPersistentMethodName(i);
    
                //Debug.Log(methodName);
                //Debug.Log(objectName);
    
                //Check if the class that holds the function exist 
                if (objectName == null || classExist(objectName.name))
                {
                    Debug.LogError("Button " + button.gameObject.name + " is missing the script that has the supposed button. Please check if this script has been renamed", button.gameObject);
                    continue; //Don't run code below
                }
    
                //Check if function Exist as public 
                if (functionExistAsPublicInTarget(objectName, methodName))
                {
                    //No Need to Log if function exist
                    //Debug.Log("Function Exist");
                }
    
                //Check if function Exist as private 
                else if (functionExistAsPrivateInTarget(objectName, methodName))
                {
                    Debug.LogWarning("The registered Function \"" + methodName + "\" Exist as private function. Please change " + methodName +
                        " from the " + objectName.name + " script to a public Access Modifier", button.gameObject);
                }
    
                //Function does not even exist at-all
                else
                {
                    Debug.LogError("The \"" + methodName + "\" function Does NOT Exist in the " + objectName.name + " script", button.gameObject);
                }
            }
        }
    
        //Checks if class exit or has been renamed
        bool classExist(string className)
        {
            Type myType = Type.GetType(className);
            return myType != null;
        }
    
        //Checks if functions exist as public function
        bool functionExistAsPublicInTarget(UnityEngine.Object target, string functionName)
        {
            Type type = target.GetType();
            MethodInfo targetinfo = type.GetMethod(functionName);
            return targetinfo != null;
        }
    
        //Checks if functions exist as private function
        bool functionExistAsPrivateInTarget(UnityEngine.Object target, string functionName)
        {
            Type type = target.GetType();
            MethodInfo targetinfo = type.GetMethod(functionName, BindingFlags.Instance | BindingFlags.NonPublic);
            return targetinfo != null;
        }
    }
