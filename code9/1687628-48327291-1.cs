    public K this[int index]
    {
    	get
    	{
    		return this.Key(this.GetNodeByIndex(index).NodeID);
    	}
    }
    private NodePath GetNodeByIndex(int userIndex)
    {
    	int num;
    	int mainTreeNodeID = default(int);
    	if (this._inUseSatelliteTreeCount == 0)
    	{
    		num = this.ComputeNodeByIndex(this.root, userIndex + 1);
    		mainTreeNodeID = 0;
    	}
    	else
    	{
    		num = this.ComputeNodeByIndex(userIndex, out mainTreeNodeID);
    	}
    	if (num == 0)
    	{
    		if (TreeAccessMethod.INDEX_ONLY == this._accessMethod)
    		{
    			throw ExceptionBuilder.RowOutOfRange(userIndex);
    		}
    		throw ExceptionBuilder.InternalRBTreeError(RBTreeError.IndexOutOFRangeinGetNodeByIndex);
    	}
    	return new NodePath(num, mainTreeNodeID);
    }
    private int ComputeNodeByIndex(int x_id, int index)
    {
    	while (x_id != 0)
    	{
    		int num = this.Left(x_id);
    		int num2 = this.SubTreeSize(num) + 1;
    		if (index < num2)
    		{
    			x_id = num;
    		}
    		else
    		{
    			if (num2 >= index)
    			{
    				break;
    			}
    			x_id = this.Right(x_id);
    			index -= num2;
    		}
    	}
    	return x_id;
    }
 
