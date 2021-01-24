    using System;
    using System.Reflection;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class MissingOnClickDetector : MonoBehaviour
    {
        void Awake()
        {
            //Debug.Log("Class exist? " + classExist("ok.ButtonCallBackTest"));
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
                //Get the target class name
                UnityEngine.Object objectName = button.onClick.GetPersistentTarget(i);
    
                //Get the function name
                string methodName = button.onClick.GetPersistentMethodName(i); ;
    
                //////////////////////////////////////////////////////CHECK CLASS/SCRIPT EXISTANCE/////////////////////////////////////////
    
                //Check if the class that holds the function is null then exit if it is 
                if (objectName == null)
                {
                    Debug.LogError("<color=blue>Button \"" + button.gameObject.name +
                        "\" is missing the script that has the supposed button callback function. " +
                        "Please check if this script still exist or has been renamed</color>", button.gameObject);
                    continue; //Don't run code below
                }
    
                //Get full target class name(including namespace)
                string objectFullNameWithNamespace = objectName.GetType().FullName;
    
                //Check if the class that holds the function exist then exit if it does not
                if (!classExist(objectFullNameWithNamespace))
                {
                    Debug.LogError("<color=blue>Button \"" + button.gameObject.name +
                         "\" is missing the script that has the supposed button callback function. " +
                         "Please check if this script still exist or has been renamed</color>", button.gameObject);
                    continue; //Don't run code below
                }
    
                //////////////////////////////////////////////////////CHECK FUNCTION EXISTANCE/////////////////////////////////////////
    
                //Check if function Exist as public (the registered onClick function is ok if this returns true)
                if (functionExistAsPublicInTarget(objectName, methodName))
                {
                    //No Need to Log if function exist
                    //Debug.Log("<color=green>Function Exist</color>");
                }
    
                //Check if function Exist as private 
                else if (functionExistAsPrivateInTarget(objectName, methodName))
                {
                    Debug.Log("<color=yellow>The registered Function \"" + methodName + "\" Exist as a private function. Please change \"" + methodName +
                        "\" function from the \"" + objectFullNameWithNamespace + "\" script to a public Access Modifier</color>", button.gameObject);
                }
    
                //Function does not even exist at-all
                else
                {
                    Debug.Log("<color=red>The \"" + methodName + "\" function Does NOT Exist in the \"" + objectFullNameWithNamespace + "\" script</color>", button.gameObject);
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
