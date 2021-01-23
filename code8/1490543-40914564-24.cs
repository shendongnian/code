	using GalaSoft.MvvmLight.CommandWpf;
	using RAMQ.PPP.CRP6_GraduMdl_iut1.Classes;
	using RAMQ.PPP.CRP6_GraduMdl_iut1.Interfaces;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Linq;
	using System.Security;
	using System.Text;
	using System.Threading.Tasks;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Input;
	using GalaSoft.MvvmLight;
	namespace RAMQ.PPP.CRP6_GraduMdl_iut1.ViewModels
	{
		/// <summary>
		/// 
		/// </summary>
        // I have inherited from ViewModelBase from the GalaSoft.MvvmLight namespace
		public class MainWindowViewModel : ViewModelBase
		{
			#region Proprietes privées
            // This is now a RelayCommand
			private readonly RelayCommand<string> _clickCommand;
			
			private string _idUtilisateur;
			private string _passwordUtilisateur;
			private string _environnementSource;
			#endregion Proprietes privées
            // Let's 'Set' these properties once before updating the actual value
			#region proprietes publiques
			public string IdUtilisateur
			{
				get { return _idUtilisateur; }
				set
				{
					Set(ref _idUtilisateur, value);
					_idUtilisateur = value;
				}
			}
			public string PasswordUtilisateur
			{
				get { return _passwordUtilisateur; }
				set
				{
					Set(ref _passwordUtilisateur, value);
					_passwordUtilisateur = value;
				}
			}
			public string EnvironnementSource
			{
				get { return _environnementSource; }
				set
				{
					Set(ref _environnementSource, value);
					_environnementSource = value;
				}
			}
			#endregion proprietes publiques
			private bool _enabledView;
			public bool EnabledView
			{
				get { return _enabledView; }
				set
				{
					if (_enabledView == value)
					{
						return;
					}
					Set(ref _enabledView, value);
					_enabledView = value;
				}
			}
			public MainWindowViewModel()
			{
                // Initialize this command, it can always execute
				ButtonCommand = new RelayCommand(ConnectionBase, () => true);
				
                // Bool's default value is false, no need to initialize unless it's a Nullable<bool> (bool?)
				//EnabledView = false;
			}
			public RelayCommand<string> ButtonClickCommand
			{
				get { return _clickCommand; }
			}
			private void ConnectionBase()
			{
				if (Validation.ValidationConnection(IdUtilisateur, PasswordUtilisateur, EnvironnementSource))
				{
					EnabledView = true;
				}
				else
				{
					string msgErreur = "KO";
				}
			}
			private void Login(object parameter)
			{
			   
			}
            // These are RelayCommand's
			private RelayCommand _buttonCommand;
			public RelayCommand ButtonCommand
			{
				get
				{
					return _buttonCommand;
				}
				set
				{
					_buttonCommand = value;
				}
			}
		}
	}
