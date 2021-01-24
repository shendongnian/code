    using System;
    using System.Windows.Media; // requires PresentationCore.dll
    
    namespace ConsoleAppFontMetrics
    {
        internal class Metrics
        {
            internal static void PrintWidths(string path)
            {
                var ffs = Fonts.GetFontFamilies(path);
                foreach (var ff in ffs)
                {
                    foreach (var t in ff.GetTypefaces())
                    {
                        Console.WriteLine(t.Style);
                        if (t.TryGetGlyphTypeface(out GlyphTypeface gt))
                        {
                            foreach (var ctg in gt.CharacterToGlyphMap)
                            {
                                var width = (int)Math.Round(gt.AdvanceWidths[ctg.Value] * 1000);
                                
                                Console.WriteLine($"{(char)ctg.Key} ({ctg.Key}) Width = {width}");
                            }
                        }
                    }
                }
            }
        }
    }
