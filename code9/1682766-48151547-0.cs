    public static void SearchForThreads(
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
            {
                var startKey = "this.Controls.Add(";
                var endKey = ")";
    
                List<string> components = new List<string>();
    
                var designerPath = sourceFilePath.Replace(".cs", ".Designer.cs");
                if (File.Exists(designerPath))
                {
                    var designerText = File.ReadAllText(designerPath);
                    var initSearchPos = designerText.IndexOf(startKey) + startKey.Length;
    
                    do
                    {
                        var endSearchPos = designerText.IndexOf(endKey, initSearchPos);
                        var componentName = designerText.Substring(initSearchPos, (endSearchPos - initSearchPos));
                        componentName = componentName.Replace("this.", "");
                        if (!components.Contains(componentName))
                            components.Add(componentName);
    
                    } while ((initSearchPos = designerText.IndexOf(startKey, initSearchPos) + startKey.Length) > startKey.Length);
                }
    
                if (components.Any())
                {
                    var classText = File.ReadAllText(sourceFilePath);
                    var ThreadPos = classText.IndexOf("Task.Run");
                    if (ThreadPos > -1)
                    {
                        do
                        {
                            var endThreadPos = classText.IndexOf("}", ThreadPos);
    
                            if (endThreadPos > -1)
                            {
                                foreach (var component in components)
                                {
                                    var search = classText.IndexOf(component, ThreadPos);
                                    if (search > -1 && search < endThreadPos)
                                    {
                                        Console.WriteLine($"Found a call to UI thread component at pos: {search}");
                                    }
                                }
                            }
                        }
                        while ((ThreadPos = classText.IndexOf("Task.Run", ++ThreadPos)) < classText.Length && ThreadPos > 0);
                    }
                }
            }
