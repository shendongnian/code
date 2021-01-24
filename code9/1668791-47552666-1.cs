    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Resources;
    using System.Reflection;
    
    namespace LogWizard
    {
        static class Localizer
        {
            private static ResourceManager MainResourse = null;
    
            public static void InitLocalizedResource(string LanguagePrefix, string ResourseBase, string Delimeter = "_")
            {
                string FullResourseName = ResourseBase;
                Assembly assembly = Assembly.GetExecutingAssembly();
    
                var ResList = assembly.GetManifestResourceNames().ToList();
    
                if (ResList.
                    Where(x => x.Equals(FullResourseName + Delimeter + LanguagePrefix + ".resources"))
                    .Count() == 1)
                    FullResourseName += Delimeter + LanguagePrefix;
    
                MainResourse = new ResourceManager(FullResourseName, assembly);
            }
    
            public static string Localize(this string str)
            {
                return GetString(str);
            }
    
            public static string GetString(string name)
            {
                try
                {
                    if (MainResourse == null) 
                        return name;
    
                    string result = MainResourse.GetString(name);
                    return (result == null) ? name : result;
                }
                catch
                {
                    return name;
                }
            }
    
        }
    }
