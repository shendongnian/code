	class Program
	{
		internal class TreeNode
		{
		  internal TreeNode(int level)
		  {
			Level = level;
		  }
		  internal int Level { get; }
		}
		static void Main(string[] args)
		{
		  ParallelWalk(new TreeNode(0));
		  Console.Read();
		}
		static void ParallelWalk(TreeNode node)
		{
		  if (node == null) return;
		  Console.WriteLine(node.Level);
		  Thread.Sleep(5);
		  if(node.Level > 4) return;
		  int nextLevel = node.Level + 1;
		  var t1 = Task.Factory.StartNew(
					 () => ParallelWalk(new TreeNode(nextLevel)));
		  var t2 = Task.Factory.StartNew(
					 () => ParallelWalk(new TreeNode(nextLevel)));
		  Task.WaitAll(t1, t2);
		}
	}
