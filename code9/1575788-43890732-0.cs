    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ExpressionParser
    {
        class testVisitor: testGrammerBaseVisitor<double>
        {
            public override double VisitCompileUnit(testGrammerParser.CompileUnitContext context)
            {
                return Visit(context.expression(0));
            }
    
            public override double VisitExpression(testGrammerParser.ExpressionContext context)
            {
                var left = context.multiplyingExpression(0);
                var right = context.multiplyingExpression(1);
    
                if (right != null)
                {
                    if (context.PLUS(0) == null)
                    {
                        return Visit(left) - Visit(right);
                    }
    
                    return Visit(left) + Visit(right);
                }
    
                return Visit(left);
            }
    
            public override double VisitMultiplyingExpression(testGrammerParser.MultiplyingExpressionContext context)
            {
                var left = context.powExpression(0);
                var right = context.powExpression(1);
    
                if (right != null)
                {
                    if (context.DIV(0) == null)
                    {
                        return Visit(left) * Visit(right);
                    }
    
                    return Visit(left) / Visit(right);
                }
    
                return Visit(left);
            }
    
            public override double VisitPowExpression(testGrammerParser.PowExpressionContext context)
            {
                var left = context.atom(0);
                var right = context.atom(1);
    
                if (right != null)
                {
                    return Math.Pow(Visit(left), Visit(right));
                }
    
                return Visit(left);
            }
    
            public override double VisitAtom(testGrammerParser.AtomContext context)
            {
                if (context.scientific() != null)
                {
                    return Visit(context.scientific());
                }
                
                if (context.variable() != null)
                {
                    return Visit(context.variable());
                }
    
                if (context.expression() != null) //need to check this out
                {
                    return Visit(context.expression());
                }
    
                return Visit(context.func());
            }
    
            public override double VisitScientific(testGrammerParser.ScientificContext context)
            {
                var left = context.number(0);
                var right = context.number(1);
    
                if (right != null)
                {
                    return Visit(left) * Math.E * Visit(right);
                }
    
                return Visit(left);
            }
    
            public override double VisitFunc(testGrammerParser.FuncContext context)
            {
                var type = context.funcname().GetText();
    
                switch (type)
                {
                    case "cos":
                        return Math.Cos(Visit(context.expression()));
    
                    case "sin":
                        return Math.Sin(Visit(context.expression()));
    
                    case "tan":
                        return Math.Tan(Visit(context.expression()));
    
                    case "acos":
                        return Math.Acos(Visit(context.expression()));
    
                    case "asin":
                        return Math.Asin(Visit(context.expression()));
    
                    case "atan":
                        return Math.Atan(Visit(context.expression()));
    
                    case "ln":
                        return Math.Log(Visit(context.expression()));
    
                    case "log":
                        return Math.Log(Visit(context.expression()));
                }
    
                return Visit(context.expression());
            }
    
            public override double VisitNumber(testGrammerParser.NumberContext context)
            {
                var left = context.DIGIT(0);
                var right = context.DIGIT(1);
                int minus = 1;
    
                if (context.MINUS() != null)
                {
                    minus = -1;
                }
    
                if (right != null)
                {
                    return (minus * Visit(left)) + Visit(right);
                }
    
                return minus * Visit(left);
            }
    
            public override double VisitVariable(testGrammerParser.VariableContext context)
            {
                return base.VisitVariable(context); // yet to implement this
            }
    
            public override double VisitTerminal(Antlr4.Runtime.Tree.ITerminalNode node)
            {
                return double.Parse(node.GetText());
            }
    
        }
    }
