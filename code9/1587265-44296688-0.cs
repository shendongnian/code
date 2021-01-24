	private void SetDelegate()
	{
		if (_fromRow == -1)
		{
			_changePropMethod = SetUnknown;
		}
		//Single cell
		else if (_fromRow == _toRow && _fromCol == _toCol && Addresses == null)
		{
			_changePropMethod = SetSingle;
		}
		//Range (ex A1:A2)
		else if (Addresses == null)
		{
			_changePropMethod = SetRange;
		}
		//Multi Range (ex A1:A2,C1:C2)
		else
		{
			_changePropMethod = SetMultiRange;
		}
	}
