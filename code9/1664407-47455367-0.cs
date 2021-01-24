    using npAssemblies;
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using System.ComponentModel;
    
    namespace combobox_test__01
    {
        public class VM : INotifyPropertyChanged
        {
            private ObservableCollection<Person> people;
            public ObservableCollection<Person> People
            {
                get { return people; }
                set
                {
                     people = value;
                    OnPropertyChanged("People");
                }
            }
    
            private Person selectedPerson;
            public Person SelectedPerson
            {
                get { return selectedPerson; }
                set
                {
                    selectedPerson = value;
                    OnPropertyChanged("SelectedPerson");
                }
            }
    
            private int cboPeopleSelectedIndex;
            public int CboPeopleSelectedIndex
            {
                get { return cboPeopleSelectedIndex; }
                set
                {
                    cboPeopleSelectedIndex = value;
                    OnPropertyChanged("CboPeopleSelectedIndex");
                }
            }
    
            private int newPidx = 0;
            private string[,] newP;
            private string DefaultPic = @"D:\Visual Studio Testing\Icons\user-icon.png",
                NewPic = @"D:\Visual Studio Testing\Small size pictures\mugshot";
            private Random random = new Random();
    
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs(propertyName));
                }
            }
    
            public VM()
            {
                People = new ObservableCollection<Person>()
                {
                    new Person() {Name="Aa", Type="Taa", PicFullPath=DefaultPic},
                    new Person() {Name="Bb", Type="Tbb", PicFullPath=DefaultPic},
                    new Person() {Name="Cc", Type="Tcc", PicFullPath=DefaultPic}
                };
    
                newP = new string[4, 3] { { "Dd", "Tdd", "" }, { "Ee", "Tee", "" }, { "Ff", "Tff", "" }, { "Gg", "Tgg", "" } };
            }
    
            public ICommand AlterRowCommand => new RelayCommandBase(AlterRow);
            private void AlterRow(object parameter)
            {
                //Make SelectedPerson.Type into a string ending with 2 randomish digits
                string fmts, picChoice;
                GetDifferentData(out fmts, out picChoice);
                string s = SelectedPerson.Type.Substring(0,3).PadRight(5);
                SelectedPerson.Type = s + fmts;
                // Use those 2 randomish digits to choose a picture from existing ones
                SelectedPerson.PicFullPath = NewPic + picChoice;
                // refresh the control the collection is bound to
                ResetBoundItems(SelectedPerson);
            }
    
            public ICommand NewRowCommand => new RelayCommandBase(NewRow);
            private void NewRow(object parameter)
            {
                string fmts, picChoice;
                int highIdx = People.Count;
                GetDifferentData(out fmts, out picChoice);
                Person newPerson = new Person() { Name = newP[newPidx, 0], Type = newP[newPidx++, 1], PicFullPath = NewPic + picChoice };
                People.Add(newPerson);
                // refresh the control the collection is bound to and select the new row
                ResetBoundItems(newPerson, highIdx);
            }
    
            private void GetDifferentData(out string fmts, out string picChoice)
            {
                int randomi = random.Next(1, 35);
                fmts = randomi.ToString("D2");
                picChoice = fmts + ".jpg";
            }
    
            private void ResetBoundItems(Person inPerson, int gotoIndex = -1)
            {
                // refreshes the display of the combobox otherwise it is visually stale
                int idx = gotoIndex;
                if (gotoIndex == -1)
                {
                    // a preferred index was not supplied; use the currently selected index
                    idx = CboPeopleSelectedIndex;
                }
                // save a copy of the current selected person
                Person tmpP = (Person)inPerson.Clone();
                // save the current ItemsSource
                ObservableCollection<Person> refPC = new ObservableCollection<Person>();
                refPC = People;
                // reset the ItemsSource
                ObservableCollection<Person> tmpPC = new ObservableCollection<Person>();
                People = tmpPC;
                // set it back
                People = refPC;
                // restore the selected person
                SelectedPerson = (Person)tmpP.Clone();
                // select the relevant row
                CboPeopleSelectedIndex = idx;
            }
        }
    
        public class Person
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public string PicFullPath { get; set; }
    
            public Person Clone()
            {
                return (Person)this.MemberwiseClone();
            }
        }
    }
