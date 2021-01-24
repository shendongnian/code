    namespace StackOverfFLow {
    
        using System;
        using System.Collections.Generic;
        using System.Linq;
    
        internal class Program {
            private static readonly HashSet<string> UniqueWords = new HashSet<string>();
            private static readonly HashSet<string> Repeats = new HashSet<string>();
            private static readonly List<string> CertainWords = new List<string> { "Section 1", "Section 2" };
            private static readonly List<string> Words = new List<string> { "Something One", "Something [ABC] Two", "Something [ABC] Three", "Something Four Section 1", "Something Four Section 2", "Something Five" };
    
            private static void Main(string[] args) {
                FindRepeatedWords();
                var result = CleanUpWordsAndDoNotChangeList();
                result.ForEach(Console.WriteLine);
                Console.ReadKey();
            }
    
            /// <summary>
            /// Cleans Up Words And Des oNot Change List.
            /// </summary>
            /// <returns></returns>
            private static List<string> CleanUpWordsAndDoNotChangeList() {
                var newList = new List<string>();
                foreach(var t in Words) {
                    var sp = SeperateStringByString(t);
                    for(var index = 0; index < sp.Count; index++) {
                        if(Repeats.Contains(sp[index]) != true) { continue; }
                        var fixedTocheck = sp.ElementAtOrDefault(index + 1);
                        if(fixedTocheck == null || CertainWords.Contains(fixedTocheck)) { continue; }
                        sp.RemoveAt(index);
                        index = index - 1;
                    }
                    newList.Add(string.Join(" ", sp));
                }
                return newList;
            }
    
            /// <summary>
            /// Finds Unique and Repeated Words.
            /// </summary>
            private static void FindRepeatedWords() {
                foreach(var eachWord in Words) {
                    foreach(var element in SeperateStringByString(eachWord)) {
                        if(UniqueWords.Add(element) == false) { Repeats.Add(element); };
                    }
                }
            }
    
            /// <summary>
            /// Seperates a string by another string
            /// </summary>
            /// <param name="source">Source string</param>
            /// <returns></returns>
            private static List<string> SeperateStringByString(string source) {
                var seperatedStringByString = new List<string>();
                foreach(var certainWord in CertainWords) {
                    var indexOf = source.IndexOf(certainWord);
                    if(indexOf <= -1) { continue; }
                    var a = source.Substring(0, indexOf).Trim().Split(' ');
                    seperatedStringByString.AddRange(a);
                    seperatedStringByString.Add(certainWord);
                }
                if(seperatedStringByString.Count < 1) { seperatedStringByString.AddRange(source.Split(' ')); }
                return seperatedStringByString;
            }
        }
    }
