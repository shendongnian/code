    public sealed class GraphRenderer : IDotEngine
    {
        public string Run(GraphvizImageType imageType, string dot, string outputFileName)
        {
            string output = outputFileName;
            File.WriteAllText(output, dot);
            // assumes dot.exe is in the path EnvVar:
            var args = $@"{output} -Tjpg -O";
            System.Diagnostics.Process.Start("dot", args);
            return output;
        }
    }
