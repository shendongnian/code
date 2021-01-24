   	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using Location.Model;
	using System.Windows.Controls;
	namespace Location.ViewModel
	{
		public class LocationViewModel: INotifyPropertyChanged
		{
			public LocationViewModel()
			{
				SetEfficiency();
			}
			
			private DateTime _mDate = DateTime.Now;
			public DateTime MDate
			{
				get { return _mDate; }
				set 
				{
					_mDate = value;
					OnPropertyChanged("MDate");
					SetEfficiency();
				}
			}
			decimal efficiency;
			public decimal Efficiency
			{
				get { return efficiency; }
				set
				{
					efficiency = value;
					OnPropertyChanged("Efficiency");
				}
			}
			DailyEntities db = new DailyEntities();
			private void SetEfficiency()
			{
				var month;
				int.TryParse(MDate.ToString("MM"), out month);
				Efficiency = Convert.ToDecimal(db.LocationKPI.Where(a => a.sMonth == month).Select(a => a.Efficiency).FirstOrDefault());
			}
			public event PropertyChangedEventHandler PropertyChanged;
			protected virtual void OnPropertyChanged(string propertyName = null)
			{
				if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
