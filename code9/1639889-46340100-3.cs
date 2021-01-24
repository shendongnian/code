    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using ConsoleApp1;
    namespace Demo
    {
        class Program
        {
            static void Main()
            {
                string[] needles = createNeedles(1500).ToArray();
                string haystack = createHaystack(100000);
                var sw = Stopwatch.StartNew();
                anyViaContains(needles, haystack);
                Console.WriteLine("anyViaContains() took " + sw.Elapsed);
                sw.Restart();
                anyViaAhoCorasick(needles, haystack);
                Console.WriteLine("anyViaAhoCorasick() took " + sw.Elapsed);
            }
            static bool anyViaContains(string[] needles, string haystack)
            {
                return needles.Any(haystack.Contains);
            }
            static bool anyViaAhoCorasick(string[] needles, string haystack)
            {
                var trie = new Trie();
                trie.Add(needles);
                trie.Build();
                return trie.Find(haystack).Any();
            }
            static IEnumerable<string> createNeedles(int n)
            {
                for (int i = 0; i < n; ++i)
                    yield return n + "." + n + "." + n;
            }
            static string createHaystack(int n)
            {
                var sb = new StringBuilder();
                for (int i = 0; i < n; ++i)
                    sb.AppendLine("Sample Text Sample Text Sample Text Sample Text Sample Text Sample Text Sample Text Sample Text");
                return sb.ToString();
            }
        }
    }
