		public string LEL
		{
			get { return _LEL; }
			set
			{
				if(value!=null)
				{
					int testVal=Utilities.ConvertSafe.ToInt32(value);
					for(int i = 0;i<_evalList.Length;i++)
					{
						if(testVal<_evalList[i]) { continue; }
						throw new Exception("LEL not correct");
					}
					_LEL=value;
					NotifyPropertyChanged(this,"LEL");
				}
			}
		}
