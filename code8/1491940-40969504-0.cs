	private void FillDataInTree( DataRowCollection rows )
	{
		foreach( DataRow r in rows )
		{
			TreeNode node = new TreeNode( r["pName"].ToString() );
			playerTreeView.Nodes.Add( node );
			for( int i = 0; i < 3; i++ )
				node.Nodes.Add( r[i + 1].ToString() );
		}
	}
