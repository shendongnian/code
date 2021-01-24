    namespace myProject.HelperClasses
    {
     public static class myExtensionClass
        {
     public static void WriteLineCSV(this StringWriter sw, params object[] Data)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var str in Data)
                {
                    sb.Append(String.Format("\"{0}\",", str));
                }
                sw.WriteLine(sb);
            }
    }
    }
