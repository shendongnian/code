    namespace Lerp2APIEditor
    {
        public class LerpedEditorCore
        {
    
            private static LerpedThread<FileSystemWatcher> m_Watcher;
    
            [InitializeOnLoadMethod]
            static void HookWatchers() 
            {
                EditorApplication.update += OnEditorApplicationUpdate;
                
                m_Watcher.matchedMethods.Add("OnChanged", () => {
                    Debug.Log("Origin files has been changed!");
                });
    
                m_Watcher.StartFSW();
            }
    
            static void OnEditorApplicationUpdate()
            {
                if(EditorApplication.timeSinceStartup > nextSeek)
                {
                    if (m_Watcher.isCalled)
                    {
                        foreach (KeyValuePair<string, Action> kv in m_Watcher.matchedMethods)
                            if (m_Watcher.methodCalled == kv.Key)
                                kv.Value();
                        m_Watcher.isCalled = false;
                    }
                    nextSeek = EditorApplication.timeSinceStartup + threadSeek;
                }
            }
        }
    }
