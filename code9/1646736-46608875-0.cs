    protected void Action_Bold(object sender, EventArgs e)
	{
		TextIter iA, A, B;
		bool isBold = false;
		if (selectedTextView.Buffer.GetSelectionBounds(out A, out B))
		{
			iA = A;
			while (iA.Compare(B) < 0)
			{
				foreach (TextTag tag in A.Tags)
				{
					if (tag.Name == "bold") isBold = true;
				}
					
				iA.ForwardChar();
			}
			if (isBold == true)
			{
				selectedTextView.Buffer.RemoveTag("bold", A, B);
			}
			else
			{
				selectedTextView.Buffer.ApplyTag("bold", A, B);
			}
		}
	}
