		public class VehicleInfo : Model {
			private Vehicle selectedVehicle;
			public Vehicle SelectedVehicle {
				get { return selectedVehicle; }
				set {
					if (selectedVehicle != value) {
						selectedVehicle = value;
						OnPropertyChanged("SelectedVehicle");
					}
				}
			}
			private ObservableCollection<Vehicle> vehicles;
			public ObservableCollection<Vehicle> Vehicles {
				get { return vehicles; }
				set {
					if (vehicles != value) {
						vehicles = value;
						OnPropertyChanged("Vehicles");
					}
				}
			}
			private Template selectedTemplate;
			public Template SelectedTemplate {
				get { return selectedTemplate; }
				set {
					if (selectedTemplate != value) {
						selectedTemplate = value;
						OnPropertyChanged("SelectedTemplate");
					}
				}
			}
		}
