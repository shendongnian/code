    public class Person{
        public string Name {get;set;}
        public double Height {get;set;}
        public double Weight {get; set;}
        public string Print(){
             return "Name: "+Name+", Height: "+Height.ToString()+", Weight: "+Weight.ToString()+"\r\n";
        }
    }
    Person[] People = new Person[10];
    int thisIndex = 0;
    private void AddButton_Click(object sender, EventArgs e)
        {
            if (this.index < 10)
        {
            if(nameBox.Text.Length==0||weightBox.Text.Length==0||heightBox.Text.Length==0)
            {
                 MessageBox.Show("You must enter a name, weight, and height!");
            }else{
                Person p = new Person();
                p.Name = nameBox.Text;
                p.Weight = double.Parse(weightBox.Text);
                p.Height = double.Parse(heightBox.Text);
                People[thisIndex] = p;
                thisIndex++;
                nameBox.Text = "";
                weightBox.Text = "";
                heightBox.Text = "";
             }   
         }
    }
    private void ShowButton_Click(object sender, EventArgs e)
     {      
           People = People.OrderBy(p=>p.Name).ToArray();
            string myString = "";
            for(int i=0;i<10;i++)
            {
                if(People[I]!=null){
                  myString+= People[I].Print();
                }
            }
            txtShow.Text = myString;
            
     }
