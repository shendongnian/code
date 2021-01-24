       // You User Interface, should use Business level classes (not data)
        class YourForm
        {
            private readonly YourService _myLogicService;
    
            public YourForm()
            {
                _myLogicService = new YourService(new YourFilePersistor());
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                OpenFileDialog open = new OpenFileDialog();
                if (open.ShowDialog() == DialogResult.OK) ;
                {
                    textBox1.Text = _myLogicService.Read(open.FileName);
                }
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                var toSave = textBox1.Text;
    
                SaveFileDialog save = new SaveFileDialog();
                if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    _myLogicService.Write(save.FileName, toSave);
                }
            }
        }
    
        // Data Layer: this class has dependencies from file system 
        // (in future a database can be used but you will not change your business service, just implement the interface)
        public class YourFilePersistor : IPersistor
        {
            public string Read(string filePath)
            {
                return System.IO.File.ReadAllText(filePath); // Or your code
            }
    
            public void Write(string filePath, string fileContent)
            {
                System.IO.File.WriteAllText(filePath, fileContent); // Or your code
            }
        }
    
        public interface IPersistor
        {
            string Read(string filePath);
    
            void Write(string filePath, string fileContent);
        }
    
    
       
        // Service is your "Business Level" for put your application logic on your domain data  
        // Business classes uses intefaces to abstract data layer and work without dependencies from components like database, remote apis and so on...
        public class YourService
        {
            private readonly IPersistor _repository;
    
            public YourService(IPersistor repository)
            {
                _repository = repository;
            }
    
            public string Read(string filePath)
            {
                var data = _repository.Read(filePath);
    
                return data;
            }
    
            public void Write(string filePath, string fileContent)
            {
                var data = fileContent;
                // here you could do some logic i.e. to validate your data  
                if (string.IsNullOrWhiteSpace(fileContent))
                {
                    throw new InvalidOperationException("Data is null");
                }
                // ---
    
                _repository.Write(filePath, data);
            }
        }
