    using System;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using RGiesecke.DllExport;
    namespace TestDll
    {
        public class FolderHandling
        {
            [DllExport(nameof(GetFilesByExtensions), CallingConvention.StdCall)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static bool GetFilesByExtensions(
                ref object arrayOfFiles,                                  //out doesn't work
                [MarshalAs(UnmanagedType.AnsiBStr)] string folderPath,
                object extensions,                                       //type safety breaks it..somehow
                [MarshalAs(UnmanagedType.Bool)] bool includeSubdirectories)
            {
                try
                {
                    if (!Directory.Exists(folderPath))
                    {
                        arrayOfFiles = new[] { $"Parameter {nameof(folderPath)} ({folderPath}) is not a folder" };
                        return false;
                    }
                    if (!(extensions is string[]))
                    {
                        arrayOfFiles = new[] { $"Parameter {nameof(extensions)} is not a string array" };
                        return false;
                    }
                    var exts = ((string[])extensions).Select(e => e.Trim('.').ToLowerInvariant()).ToArray();
                    var files = Directory.GetFiles(folderPath, "*.*",
                            includeSubdirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)
                        .Where(f => exts.Contains(Path.GetExtension(f)?.Trim('.').ToLowerInvariant() ?? ";;;"))
                        .ToArray();
                    //normalize ANSI just in case
                    General.NormalizeANSI(ref files);
                    arrayOfFiles = files;
                    return true;
                }
                catch (Exception ex)
                {
                    arrayOfFiles = new[] { "Exception: " + ex };
                    return false;
                }
            }
        }
    }
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    namespace TestDll
    {
        static class General
        {
            public static void NormalizeANSI(ref string[] files)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    files[i] = string.Concat(files[i].Normalize(NormalizationForm.FormD).Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark));
                }
            }
        }
    }
