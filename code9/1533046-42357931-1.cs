    public static class ExtensionMethod
    {
        public static Component AddComponentExt(this GameObject obj, string scriptName)
        {
            Component cmpnt = null;
    
    
            for (int i = 0; i < 10; i++)
            {
                //If call is null, make another call
                cmpnt = _AddComponentExt(obj, scriptName, i);
    
                //Exit if we are successful
                if (cmpnt != null)
                {
                    break;
                }
            }
    
    
            //If still null then let user know an exception
            if (cmpnt == null)
            {
                Debug.LogError("Failed to Add Component");
                return null;
            }
            return cmpnt;
        }
    
        private static Component _AddComponentExt(GameObject obj, string className, int trials)
        {
            //Any script created by user(you)
            const string userMadeScript = "Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null";
            //Any script/component that comes with Unity such as "Rigidbody"
            const string builtInScript = "UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null";
    
            //Any script/component that comes with Unity such as "Image"
            const string builtInScriptUI = "UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
    
            //Any script/component that comes with Unity such as "Networking"
            const string builtInScriptNetwork = "UnityEngine.Networking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
    
            //Any script/component that comes with Unity such as "AnalyticsTracker"
            const string builtInScriptAnalytics = "UnityEngine.Analytics, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null";
    
            //Any script/component that comes with Unity such as "AnalyticsTracker"
            const string builtInScriptHoloLens = "UnityEngine.HoloLens, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null";
    
            Assembly asm = null;
    
            try
            {
                //Decide if to get user script or built-in component
                switch (trials)
                {
                    case 0:
    
                        asm = Assembly.Load(userMadeScript);
                        break;
    
                    case 1:
                        //Get UnityEngine.Component Typical component format
                        className = "UnityEngine." + className;
                        asm = Assembly.Load(builtInScript);
                        break;
                    case 2:
                        //Get UnityEngine.Component UI format
                        className = "UnityEngine.UI." + className;
                        asm = Assembly.Load(builtInScriptUI);
                        break;
    
                    case 3:
                        //Get UnityEngine.Component Video format
                        className = "UnityEngine.Video." + className;
                        asm = Assembly.Load(builtInScript);
                        break;
    
                    case 4:
                        //Get UnityEngine.Component Networking format
                        className = "UnityEngine.Networking." + className;
                        asm = Assembly.Load(builtInScriptNetwork);
                        break;
                    case 5:
                        //Get UnityEngine.Component Analytics format
                        className = "UnityEngine.Analytics." + className;
                        asm = Assembly.Load(builtInScriptAnalytics);
                        break;
    
                    case 6:
                        //Get UnityEngine.Component EventSystems format
                        className = "UnityEngine.EventSystems." + className;
                        asm = Assembly.Load(builtInScriptUI);
                        break;
    
                    case 7:
                        //Get UnityEngine.Component Audio format
                        className = "UnityEngine.Audio." + className;
                        asm = Assembly.Load(builtInScriptHoloLens);
                        break;
    
                    case 8:
                        //Get UnityEngine.Component SpatialMapping format
                        className = "UnityEngine.VR.WSA." + className;
                        asm = Assembly.Load(builtInScriptHoloLens);
                        break;
    
                    case 9:
                        //Get UnityEngine.Component AI format
                        className = "UnityEngine.AI." + className;
                        asm = Assembly.Load(builtInScript);
                        break;
                }
            }
            catch (Exception e)
            {
                //Debug.Log("Failed to Load Assembly" + e.Message);
            }
    
            //Return if Assembly is null
            if (asm == null)
            {
                return null;
            }
    
            //Get type then return if it is null
            Type type = asm.GetType(className);
            if (type == null)
                return null;
    
            //Finally Add component since nothing is null
            Component cmpnt = obj.AddComponent(type);
            return cmpnt;
        }
    }
