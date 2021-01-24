    using System;
    using System.IO;
    using System.Text;
    
    namespace ParenParser {
        public class Program
        {
            public static Stream GenerateStreamFromString(string s)
            {
                MemoryStream stream = new MemoryStream();
                StreamWriter writer = new StreamWriter(stream);
                writer.Write(s);
                writer.Flush();
                stream.Position = 0;
                return stream;
            }
    
            public static String Process(StreamReader s) { // root
                StringBuilder output = new StringBuilder();
                while (!s.EndOfStream) {
                    var ch = Convert.ToChar(s.Read());
                    if (ch == '<') {
                        output.Append(ProcessTag(s, true));
                    } else {
                        output.Append(ch);
                    }
                }
    
                return output.ToString();
            }
    
            public static String ProcessTag(StreamReader s, bool skipOpeningBracket = true) {
                int currentParenDepth = 0;
                StringBuilder openingTag = new StringBuilder(), allTagText = new StringBuilder(), closingTag = new StringBuilder();
                bool inOpeningTag = false, inClosingTag = false;
                if (skipOpeningBracket) {
                    inOpeningTag = true;
                    openingTag.Append('<');
                    skipOpeningBracket = false;
                }
    
                while (!s.) {
                    var ch = Convert.ToChar(s.Read());
                    if (ch == '<') { // start of a tag
                        var nextCh = Convert.ToChar(s.Peek());
                        if (nextCh == '/') { // closing tag!
                            closingTag.Append(ch);
                            inClosingTag = true;
                        } else if (openingTag.ToString().Length != 0) { // already seen a tag, recurse
                            allTagText.Append(ProcessTag(s, true));
                            continue;
                        } else {
                            openingTag.Append(ch);
                            inOpeningTag = true;
                        }
                    }
                    else if (inOpeningTag) {
                        openingTag.Append(ch);
                        if (ch == '>') {
                            inOpeningTag = false;
                        }
                    }
                    else if (inClosingTag) {
                        closingTag.Append(ch);
                        if (ch == '>') {
                            // Done!
                            var allTagTextString = allTagText.ToString();
                            if (allTagTextString.Length > 0 && allTagTextString[0] == '(' && allTagTextString[allTagTextString.Length - 1] == ')' && currentParenDepth == 0) {
                                return "(" + openingTag.ToString() + allTagTextString.Substring(1, allTagTextString.Length - 2) + closingTag.ToString() + ")";
                            } else if (allTagTextString.Length > 0 && allTagTextString[0] == '(' && currentParenDepth > 0) { // unclosed
                                return "(" + openingTag.ToString() + allTagTextString.Substring(1, allTagTextString.Length - 1) + closingTag.ToString();
                            } else if (allTagTextString.Length > 0 && allTagTextString[allTagTextString.Length - 1] == ')' && currentParenDepth < 0) { // unopened
                                return openingTag.ToString() + allTagTextString.Substring(0, allTagTextString.Length - 1) + closingTag.ToString() + ")";
                            } else {
                                return openingTag.ToString() + allTagTextString + closingTag.ToString();
                            }
                        }
                    }
                    else
                    {
                        allTagText.Append(ch);
                        if (ch == '(') {
                            currentParenDepth++;
                        }
                        else if (ch == ')') {
                            currentParenDepth--;
                        }
                    }
                }
    
                return openingTag.ToString() + allTagText.ToString() + closingTag.ToString();
            }
    
            public static void Main()
            {
                var testCases = new String[] {
                    // Should change
                    "<italic>(When a parenthetical sentence stands on its own)</italic>",
                    "<italic>(When a parenthetical sentence stands on its own</italic>",
                    "<italic>When a parenthetical sentence stands on its own)</italic>",
    
                    // Should remain unchanged
                    "<italic>(When) a parenthetical sentence stands on its own</italic>",
                    "<italic>When a parenthetical sentence stands on its (own)</italic>",
                    "<italic>When a parenthetical sentence stands (on) its own</italic>",
    
                    // Should be changed
                    "<italic>((When) a parenthetical sentence stands on its own</italic>",
                    "<italic>((When) a parenthetical sentence stands on its own)</italic>",
                    "<italic>(When) a parenthetical sentence stands on its own)</italic>",
                    "<italic>When a parenthetical sentence stands on its (own))</italic>",
                    "<italic>(When a parenthetical sentence stands on its (own)</italic>",
    
                    // Other cases
                    "<italic>(Try This on!)</italic>",
                    "<italic><italic>(Try This on!)</italic></italic>",
                    "<italic></italic>",
                    "",
                    "()",
                    "<italic>()</italic>",
                    "<italic>"
                };
    
                foreach(var testCase in testCases) {
                    using(var testCaseStreamReader = new StreamReader(GenerateStreamFromString(testCase))) {
                        Console.WriteLine(testCase + " --> " + Process(testCaseStreamReader));
                    }
                }
            }
        }
    }
