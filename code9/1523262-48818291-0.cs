    internal class Program
    {
        private static void Main(string[] args)
        {
            String[] InputLines, outputLines;
            Int32 scriptBegin = 0, scriptEnd = 0;
    
            String scriptName = args[0];
            String inputPath = "C:\\Users\\hfand\\source\\repos\\se-scripts\\" + scriptName + ".cs";
    
            if (File.Exists(inputPath))
            {
                InputLines = File.ReadAllLines(inputPath);
    
                for (int i = 0; i < InputLines.Length; i++)
                {
                    if (InputLines[i].Contains("script-begin"))
                    {
                        scriptBegin = i + 1;
                    }
                    if (InputLines[i].Contains("script-end"))
                    {
                        scriptEnd = i - 1;
                    }
                }
    
                outputLines = new List<string>(InputLines).GetRange(scriptBegin, scriptEnd - scriptBegin + 1).ToArray();
    
                for (int i = 0; i < outputLines.Length; i++)
                {
                    if (outputLines[i].Length >= 8)
                    {
                        outputLines[i] = outputLines[i].Substring(8);
                    }
                }
    
                String outputPath = "C:\\Users\\hfand\\AppData\\Roaming\\SpaceEngineers\\IngameScripts\\local\\" + scriptName;
    
                if (Directory.Exists(outputPath))
                {
                    File.WriteAllLines(outputPath + "\\Script.cs", outputLines);
                }
                else
                {
                    Directory.CreateDirectory(outputPath);
                    File.WriteAllLines(outputPath + "\\Script.cs", outputLines);
                }
    
                Console.WriteLine(scriptName + " sincronizado");
            }
            else
            {
                Console.WriteLine("Arquivo \"" + inputPath + "\" não encontrado");
            }
        }
    }
