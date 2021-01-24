private static GameLevel _startLevel;
public static GameLevel StartLevel
{
	get
	{
		if(_startLevel == null)
		{
			_startLevel = new Level();
			_startLevel.Action.Add(action1);
			_startLevel.Action.Add(action2);
		}
	
		return _startLevel;
	}
}
