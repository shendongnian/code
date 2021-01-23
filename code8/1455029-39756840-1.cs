    var tree = CSharpSyntaxTree.ParseText(
    @"public class Thing
    {
	    public int Item { get; }
	    public Thing(int item)
	    {
		    Item = Item; // note incorrect assignment: rhs should be item, the passed-in arg, hence analyzer should warn
	    }
	    public Thing(Thing other)
	    {
		    Item = other.Item; // correct assignment, should NOT trigger analyzer
	    }
    }");
    var root = tree.GetRoot();
    var incorrectAssignment = root.DescendantNodes().OfType<AssignmentExpressionSyntax>().First();
    var correctAssignment = root.DescendantNodes().OfType<AssignmentExpressionSyntax>().Last();
    var b1 = IsAssignmentBad(correctAssignment); // doesn't consider the assignment bad
    var b2 = IsAssignmentBad(incorrectAssignment); // this one does
