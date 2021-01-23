    public class Form1ViewModel {
         public int Age {get; set;}
         public string Name {get; set;}
    }
    //method on Form1
    public void NavigateToForm2()
    {
        var vm = new Form1ViewModel{ Age = 32, Name = "Test name"};
        var form2 = new Form2();
        form2.SetViewModel(vm);
        form2.Show();
    }
    
