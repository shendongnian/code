	public class MainForm : Form
	{
		public MainForm(StateManager stateManager)
		{
			_stateManager = stateManager;
			
			//data binding for your text box
			txtPatientName.DataBindings.Add(nameof(txtPatientName.Text), stateManager, nameof(stateManager.PatientName));
			
			//data binding for your grid
			historyGrid.DataSource = stateManager.History;
		}
		
		private void btnShowForm_Click(object sender, EventArgs e)
		{
			using(var form = new DialogForm())
			{
				var result = form.ShowDialog();
				if(result == DialogResult.Ok)
				{
					_stateManager.UpdatePatient(form.InputPatientName);
				}
			}
		}
		
		private StateManager _stateManager;
	}
	//this is the form where you enter the patient name
	public class DialogForm : Form
	{
		//this holds the value where the patient's name is entered on the form
		public string InputPatientName { get; set; }
	}
	//this class maintains your state
	public class StateManager : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		
		public string PatientName
		{
			get { return _patientName; }
			set 
			{
				_patientName = value;
				OnPropertyChanged(nameof(PatientName));
			}
		}
		
		public BindingList<MedicalHistoryItems> History => _history ?? (_history = new BindingList<MedicalHistoryItems>());
		
		public void UpdatePatient(string patientName)
		{
			History.Clear();
			
			var historyRetriever = new HistoryRetriever();
			History.AddRange(historyRetriever.RetrieveHistory(patientName));
		}
		
		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(propertyName);
		}
		private BindingList<MedicalHistoryItems> _history;
		private string _patientName;
	}
