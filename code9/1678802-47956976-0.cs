    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] inputs = {
                                      "žvakah žvakati Vme1s 0 0.000000",
                                      "žvakahu žvakati Vme3p 0 0.000000",
                                      "žvakala žvakati Vmp-pn 0 0.000000",
                                      "žvakala žvakati Vmp-sf 45 0.000081",
                                      "žvakale žvakati Vmp-pf 11 0.000020",
                                      "žvakali žvakati Vmp-pm 66 0.000119",
                                      "žvakalo žvakati Vmp-sn 10 0.000018",
                                      "žvakan žvakati Appmsann 0 0.000000",
                                      "žvakan žvakati Appmsnn 0 0.000000",
                                      "žvakan žvakati Appmsvn 0 0.000000"
                                  };
                LexicalResource resource = new LexicalResource();
                foreach (string input in inputs)
                {
                    resource.Add(input);
                }
                //look up in dictionary
               KeyValuePair<int,decimal> lookup = resource.Get("žvakale žvakati Vmp-pf");
               
            }
        }
        public class LexicalResource
        {
            public string lexical { get; set; }
            public HashSet<LexicalResource> hash { get; set; }
            public KeyValuePair<int, decimal> value { get; set; }
            public LexicalResource() { }
            public void Add(string lexical)
            {
                string[] tempArray = lexical.Split(new char[] { ' ' });
                AddRecursively(this, tempArray);
            }
            public KeyValuePair<int, decimal> Get(string lexical)
            {
                string[] tempArray = lexical.Split(new char[] { ' ' });
                return GetRecursive(this, tempArray);
            }
            KeyValuePair<int, decimal> GetRecursive(LexicalResource resource, string[] lexicon)
            {
                KeyValuePair<int, decimal> results = new KeyValuePair<int, decimal>();
                int numberChildren = lexicon.Length;
                if (numberChildren == 0)
                {
                    results = resource.value;
                }
                else
                {
                    LexicalResource child = resource.hash.Where(x => x.lexical == lexicon[0]).FirstOrDefault();
                    results = GetRecursive(child, lexicon.Skip(1).ToArray());
                }
                return results;
            }
            void AddRecursively(LexicalResource resource, string[] lexicon)
            {
                lexical = lexicon[0];
                int numberChildren = lexicon.Length;
                if (numberChildren == 2)
                {
                    resource.value = new KeyValuePair<int, decimal>(int.Parse(lexicon[0]), decimal.Parse(lexicon[1]));
                }
                else
                {
                    if (resource.hash == null)
                    {
                        resource.hash = new HashSet<LexicalResource>();
                    }
                    LexicalResource child = resource.hash.Where(x => x.lexical == lexicon[0]).FirstOrDefault();
                    if (child == null)
                    {
                        child = new LexicalResource() { lexical = lexicon[0]};
                        resource.hash.Add(child);
                    }
                    AddRecursively(child, lexicon.Skip(1).ToArray());
                }
            }
        }
    }
