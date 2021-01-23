    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    
    namespace WPFCSharpTesting
    {
      public class MainWindowViewModel : INotifyPropertyChanged
      {
        private string _text;
    
        public string Text
        {
          get { return _text; }
          set
          {
            _text = value;
            OnPropertyChanged(nameof(Text));
          }
        }
    
        private ObservableCollection<tePerson> _people;
    
        public ObservableCollection<tePerson> People
        {
          get { return _people; }
          set
          {
            _people = value;
            OnPropertyChanged(nameof(People));
          }
        }
    
        private readonly List<tePerson> _allPeople;
              
                           
        public MainWindowViewModel()
        {
          Text = "Brett";       
          using (var context = new TesterEntities())
          {
            _allPeople = context.tePerson.ToList();
          }
    
          People = new ObservableCollection<tePerson>(_allPeople);
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void OnPropertyChanged(String info)
        {
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    
        DelegateCommand _CommandGetFirstName;
    
        public ICommand CommandGetFirstName
        {
          get
          {
            if (_CommandGetFirstName == null)
            {
              _CommandGetFirstName = new DelegateCommand(param => this.CommandGetByFirstNameExecute());
            }
            return _CommandGetFirstName;
          }
        }
    
        private void CommandGetByFirstNameExecute()
        {
          var newitems = _allPeople.Exists(x => x.FirstName == Text) ? _allPeople.Where(x => x.FirstName == Text)?.ToList() : _allPeople;
          People = new ObservableCollection<tePerson>(newitems);
        }
