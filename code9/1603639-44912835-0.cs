    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace Thesaurus
    {
      
        class MainClass
        {
            static void Main(string[] args)
            {
                // Declare an interface instance.
                IThesaurus obj = new Thesaurus();
                List<string> words = new List<string>();
                // Call the member.
                obj.AddSynonyms(words);
                obj.GetSynonyms(words[0]);
                obj.GetWords();
            }
        }
        //<summary>
        /// Represents a thesaurus.
        /// </summary>
        public interface IThesaurus
        {
            /// <summary>
            /// Adds the given synonyms to the thesaurus
            /// </summary>
            /// <param name="synonyms">The synonyms to add.</param>
            void AddSynonyms(IEnumerable<string> synonyms);
            /// <summary>
            /// Gets the synonyms for a given word.
            /// </summary>
            /// <param name="word">The word the synonyms of which to get.</param>
            /// <returns>A <see cref="string"/> with all synonyms for the given word.</returns>
            IEnumerable<string> GetSynonyms(string word);
            /// <summary>
            /// Gets all words from the thesaurus.
            /// </summary>
            /// <returns>An <see cref="IEnumerable<string>"/> containing
            /// all the words in the thesaurus.</returns>
            IEnumerable<string> GetWords();
        }
        public class Thesaurus : IThesaurus
        {
            private Dictionary<string, List<string>> lookup =
                new Dictionary<string, List<string>>();
            
            public void AddSynonyms(IEnumerable<string> allWords) //public void AddSynonyms(IEnumerable<string> synonyms)
            {
                var words = allWords.Distinct().ToList();
                foreach (var word in words)
                {
                    var currentWordSynonyms = words.Where(s => s == word);
                    if (lookup.ContainsKey(word))
                    {
                        foreach (var synonym in currentWordSynonyms)
                        {
                            if (!lookup[word].Contains(synonym))
                                lookup[word].Add(synonym);
                        }
                    }
                    else
                    {
                        List<string> newSynonyms =  new List<string>();
                        newSynonyms.AddRange(currentWordSynonyms);
                        lookup.Add(word, newSynonyms);
                    }
                }
            }
            public IEnumerable<string> GetSynonyms(string word)
            {
                if (lookup.ContainsKey(word))
                    return lookup[word];
                return Enumerable.Empty<string>();
                // Or throw an exception.
            }
            public IEnumerable<string> GetWords()
            {
                return lookup.AsEnumerable().Select(x => x.Key).ToList();
            }
        }
    }
