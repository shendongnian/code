    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        var result = new List<IList<int>>();
        var que = new Queue<TreeNode>();
        //if(root==null) return result;
        que.Enqueue(root);
        while (que.Count != 0)
        {
            int n = que.Count;
            var subList = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (que.Peek().left != null)
                    que.Enqueue(que.Peek().left);
                if (que.Peek().right != null)
                    que.Enqueue(que.Peek().right);
                subList.Add(que.Dequeue().val);
            }
            result.Add(subList);
        }
        return result;
    }
