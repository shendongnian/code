    using NSoup;
    using NSoup.Nodes;
    using NSoup.Select;
    using System;
    using System.Collections.Generic;
    using System.IO;
    namespace NSoupTest
    {
        
        class Program
        {
    
            private class TestNodeVisitor : NodeVisitor
            {
                List<String> wordList;
    
                public TestNodeVisitor(List<String> wordList)
                {
                    this.wordList = wordList;
                }
    
                public void Head(Node node, int depth)
                {
                    if(depth == 1)
                    {
                        String value = node.OuterHtml();
    
                        if(!wordList.Contains(value))
                            wordList.Add(value);
                    }
                    
                }
    
                public void Tail(Node node, int depth)
                {
                    
                }
            }
    
    
            public static String parseHtml( String str ) {
                Document doc = NSoupClient.Parse(str);
    
    
                List<String> wordList 
                    = new List<String>();
    
                doc.Select("body").Traverse(new TestNodeVisitor(wordList));
    
    
                foreach (String word in wordList)
                {
    
                    Console.WriteLine(word);
                }
    
                return "";
            }
    
            static void Main(string[] args)
            {
                try
                {
                    parseHtml("We are <b><i>very</i></b><b>a</b>mused!\nThank you.");
                }
                catch (FileNotFoundException fe) {
                    Console.WriteLine(fe.Message);
                }
                
            }
        }
    }
