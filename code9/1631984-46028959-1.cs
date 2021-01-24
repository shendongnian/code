    [Language("Logical Proposition", "1.0", "")]
    public class LogicalPropositionGrammar : Grammar
    {
        public LogicalPropositionGrammar()
        {
            //syntax terminals
            var lpar = ToTerm("(");
            var rpar = ToTerm(")");
            var comma = ToTerm(",");
            var trueTerm = ToTerm("1") | "true";
            var falseTerm = ToTerm("0") | "false";
            //nonterms
            var predicate = new NonTerminal("Predicate");
            var connective = new NonTerminal("Connective");
            var pexp = new NonTerminal("PredExpression");
            var formula = new NonTerminal("Formula");
            var literal = new NonTerminal("Literal");
            var singleTerm = new NonTerminal("SingleTerm");
            var multiTerm = new NonTerminal("MultiTerm");
            //formulat non terms
            var negation = new NonTerminal("Negation");
            var implication = new NonTerminal("Implication");
            var biImplication = new NonTerminal("Bi-Implication");
            var andTerm = new NonTerminal("And");
            var orTerm = new NonTerminal("Or");
            literal.Rule = trueTerm | falseTerm;
            singleTerm.Rule = lpar + pexp + rpar; //single term is (pexp)
            multiTerm.Rule = lpar + pexp + comma + pexp + rpar; //mult term = (pexp, pexp)
            //formula rules
            negation.Rule = ToTerm("~") + singleTerm;
            implication.Rule = ToTerm(">") + multiTerm;
            biImplication.Rule = ToTerm("=") + multiTerm;
            andTerm.Rule = ToTerm("&") + multiTerm;
            orTerm.Rule = ToTerm("|") + multiTerm;
            //predicate terms
            predicate.Rule = ToTerm("A") | "B" | "C" | "D" | "E" | "F" | "G" |
                                "H" | "I" | "J" | "K" | "L" | "M" | "N" | "O" |
                                "P" | "Q" | "R" | "S" | "T" | "U" | "V" | "W" |
                                "X" | "Y" | "Z" | literal;
            //predicate rule
            pexp.Rule = predicate | negation | implication | biImplication | andTerm | orTerm;
            //a base formulat
            formula.Rule = MakeStarRule(formula, pexp);
            RegisterOperators(10, "&", "~", ">", "=", "|");
            MarkPunctuation(",", "(", ")");
            MarkTransient(pexp, singleTerm);
            Root = formula;
        }
    }
