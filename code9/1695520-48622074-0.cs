    public class Controller {
    
        private bool _formHasExited = false;
    
        public static async void Main(string[] args) {
    
            var form1DataObject = default(MyType1);
            var form2DataObject = default(MyType2);
            var form3DataObject = default(MyType3);
            var form = default(Form);
    
            // Display first form, collect data
            using (form = new MyForm1()) {
                form.Exited += (s, e) => _formHasExited = true;
                await Task.Run(WaitForFormExit);
                form1DataObject = form.Data;
            }
    
    
            // Reset _formHasExited
            _formHasExited = false;
            using (form = new MyForm2(form1DataObject.RequiredData)) {
                form.Exited += (s, e) => _formHasExited = true;
                await Task.Run(WaitForFormExit);
                form2DataObject = form.Data;
            }
    
            // Reset _formHasExited
            _formHasExited = false;
            using (form = new MyForm3(form2DataObject.RequiredData)) {
                form.Exited += (s, e) => _formHasExited = true;
                await Task.Run(WaitForFormExit);
                form3DataObject = form.Data;
            }
    
            // All data required has been obtained
            // Do stuff with all data
    
        }
    
        void WaitForFormExit() {
            // Example wait
            while (!_formHasExited);
            // Return
        }
    
    }
