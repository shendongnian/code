    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    using UnityEditor;
    using UnityEngine;
    
    [InitializeOnLoad]
    public class ExceptionCatcher
    {
        private static readonly Regex StackTraceRegex = new Regex(@"\(at (.*):([0-9]+)\)");
    
        static ExceptionCatcher()
        {
            // Handle logs
            Application.logMessageReceived += OnLogMessageReceived;
        }
    
        private static void OnLogMessageReceived(string condition, string stackTrace, LogType type)
        {
            // Check if stack trace has file name and line number
            var matches = StackTraceRegex.Matches(stackTrace);
            foreach (Match match in matches)
            {
                // Get full path file name or VS will open new window
                string filePath = Path.GetDirectoryName(Application.dataPath) + "/" + match.Groups[1].Value;
                int lineNumber = Convert.ToInt32(match.Groups[2].Value);
    
                // If file exists
                if (File.Exists(filePath))
                {
                    // Pause editor
                    Debug.Break();
    
                    // Switch to code editor
                    UnityEditorInternal.InternalEditorUtility.OpenFileAtLineExternal(filePath, lineNumber);
                    break;
                }
            }
        }
    }
