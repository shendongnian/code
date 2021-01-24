     //View Code-Behind
    public partial class FacultyViewModel : INotifyPropertyChanged
    {
         public event PropertyChangedEventHandler PropertyChanged;
         
         private Person _person;
         private List<Person> _facultyList;
         
         public FacultyViewModel(){
            InitializeComponents();
            DataContext = new FacultyViewModel();
            //list will not get renewed till you restart app
            //any additions to the list while running will not be shown.
            _facultyList = a.ToObject<List<Faculty>>();
         }
         
         // includes your other stuff here....
         //Selected a Faculty member from the listview.
         public Person SelectedPerson {
              get{ return _person;}
              set{ _person = value;
                   RaisePropertyChange(()=>SelectedPerson);
             }
         }
  
        // list to populate the listview
        public List<Person> FacultyList{
             get{ return _facultyList;}
        }
         public virtual void RaisePropertyChange([CallerMemberName] string propertyName = null){
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName)));
         }
         
       public void RaisePropertyChange<TProperty>(Expression<Func<TProperty>> property){
            RaisePropertyChange(property.GetMemberInfo().Name);
       }
       protected void OnPropertyChanged(PropertyChangedEventArgs e){
          var handler = PropertyChanged;
          if(handler != null){
             handler(this,e);
          }
      }
    }
