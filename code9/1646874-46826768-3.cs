    public static class Parser
    {
        private static Node currNode;
        private static Stack<Node> prevNodes;
        private static IEnumerable<Token> tokens;
        static Parser()
        {
            prevNodes = new Stack<Node>();
        }
        public static Node Deserialize(string input)
        {
            tokens = Tokenizer.Scan(input);
            if (!(tokens.FirstOrDefault() is OpenNodeToken rootToken)) 
                throw new FormatException("Missing root node");
            currNode = new Node(rootToken.Name);
            foreach(Token token in tokens.Skip(1))
            {
	    switch (token)          
                {
                    case ContentToken c:
                        string s = string.IsNullOrEmpty(currNode.Contents) ? c.Text : " " + c.Text;
                        currNode.Contents += s;
                        break;
                    case OpenNodeToken n:
                        prevNodes.Push(currNode);
                        currNode = new Node(n.Name);
                        break;
                    case CloseNodeToken c:
                        if (prevNodes.Any())
                        {
                            Node childNode = currNode; 
                            currNode = prevNodes.Pop();
                            currNode.InnerNodes.Add(childNode);
                        }
                        break;
                    default: throw new NotImplementedException(token.GetType().Name);
                }
            }
            return currNode;
        }
    }
