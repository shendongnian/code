    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Antlr4.Runtime;
    using Antlr4.Runtime.Tree;
    using System.Windows.Forms;
    
    
    namespace ExpressionParser
    {
        class Program
        {
            static void Main(string[] args)
            {
                String input = "cos(3*3+3)";
    
                ITokenSource lexer = new testGrammerLexer(new AntlrInputStream(input));
                ITokenStream tokens = new CommonTokenStream(lexer);
                testGrammerParser parser = new testGrammerParser(tokens);
                parser.AddErrorListener(new ThrowExceptionErrorListener());
                parser.BuildParseTree = true;
                IParseTree tree;
    
                try
                {
                    tree = parser.compileUnit();
                    var visitor = new testVisitor();
                    var results = visitor.Visit(tree);
    
                    MessageBox.Show(results + "");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
