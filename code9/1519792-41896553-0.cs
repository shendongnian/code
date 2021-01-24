    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    namespace Experiment
    {
        public static class Program
        {
            static bool hasTwoPeriodsLinq(string text)
            {
                return text.Count(x => x == '.') == 2;
            }
            
            static bool hasTwoPeriodsLoop(string text)
            {
                int count = 0;
                
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == '.')
                    {
                        // This early break makes the loop faster than regex
                        if (count == 2)
                        {
                            return false;
                        }
                        
                        count++;
                    }
                }
                
                return count == 2;
            }
            
            static Regex twoPeriodsRegex = new Regex(@"^.*\..*\..*$", RegexOptions.Compiled);
            
            static bool hasTwoPeriodsRegex(string text)
            {
                return twoPeriodsRegex.IsMatch(text);
            }
            
            public static void Main(string[] args)
            {
                var text = @"The young Princess Bolk6nskaya had 
    brought some work in a gold-embroidered vel- 
    vet bag. Her pretty little upper lip, on which 
    a delicate dark down was just perceptible, was 
    too short for her teeth, but it lifted all the more 
    sweetly, and was especially charming when she 
    occasionally drew it down to meet the lower 
    lip. As is always the case with a thoroughly at- 
    tractive woman, her defectthe shortness of 
    her upperlip and her half-open mouth seemed 
    to be her own special and peculiar form of 
    beauty. Everyone brightened at the sight of 
    this pretty young woman, so soon to become 
    a mother, so full of life and health, and carry- 
    ing her burden so lightly. Old men and dull 
    dispirited young ones who looked at her, after 
    being in her company and talking to her a 
    litttle while, felt as if they too were becoming, 
    like her, full of life and health. All who talked 
    to her, and at each word saw her bright smile 
    and the constant gleam of her white teeth, 
    thought that they were in a specially amiable 
    mood that day. ";
                
                const int iterations = 100000;
                
                // Warm up... 
                for (int i = 0; i < iterations; i++)
                {
                    hasTwoPeriodsLinq(text);
                    hasTwoPeriodsLoop(text);
                    hasTwoPeriodsRegex(text);
                }
                
                var watch = System.Diagnostics.Stopwatch.StartNew();
                
                // hasTwoPeriodsLinq
                watch.Restart();
                
                for (int i = 0; i < iterations; i++)
                {
                    hasTwoPeriodsLinq(text);
                }
                
                watch.Stop();
                
                Console.WriteLine("hasTwoPeriodsLinq " + watch.ElapsedMilliseconds);
                
                // hasTwoPeriodsLoop
                watch.Restart();
                
                for (int i = 0; i < iterations; i++)
                {
                    hasTwoPeriodsLoop(text);
                }
                
                watch.Stop();
                
                Console.WriteLine("hasTwoPeriodsLoop " + watch.ElapsedMilliseconds);
                
                // hasTwoPeriodsRegex
                watch.Restart();
                
                for (int i = 0; i < iterations; i++)
                {
                    hasTwoPeriodsRegex(text);
                }
                
                watch.Stop();
                
                Console.WriteLine("hasTwoPeriodsRegex " + watch.ElapsedMilliseconds);
            }
        }
    }
