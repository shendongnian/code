    private async void ShowingTimer()
		{
			
				int _end = 0;
				for (int _minute = 1; _minute >= 0; _minute--)
				{
					for (int _second = 59; _second >= 0; _second--)
					{
						if (_second < 10)
							{
								_secondView.Text = Convert.ToString("0" + _second);
							}
						else
							{	
								_secondView.Text = Convert.ToString(_second);
							}
							_minuteView.Text = Convert.ToString("0" + _minute);
							await Task.Delay(1000);
					}
					_end++;
				if (_end == 2) {break;}
				}
		}
