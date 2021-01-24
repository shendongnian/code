    using UnityEditor;
    using System.IO;
    using UnityEditor.Build;
    using UnityEngine;
    
    class MyCustomBuildProcessor : IPostprocessBuild
    {
        public int callbackOrder { get { return 0; } }
        public void OnPostprocessBuild(BuildTarget target, string path)
        {
            File.Copy("sourceFilePath","destinationFilePath");
        }
    }
