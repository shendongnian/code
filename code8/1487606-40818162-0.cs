    void Main()
    {
       var startingNode = <root/first node of the treeview>;
       var aResult = new List<String>();
       
       CheckedNames(startingNode, aResult);
    }
    void CheckedNames(TreeNode node, List<String> result)
    {
       do
       {
          if (node.FirstNode != null)
          {
             CheckedNames(node.FirstNode, result);
          }
          else
          {
             if (node.Checked)
             {
                // use your regex here
                result.Add(node.Text);
             }
          }
          node = node.NextNode;
       } while (node != null);
    }
