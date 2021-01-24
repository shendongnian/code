    private void fillWorkListBox()
            {
                IList<WorkModel> managerWorks = new List<WorkModel>
                {
                    new WorkModel {name="fooNameOne",id=1 },
                    new WorkModel {name="fooNameTwo",id=2 }
                };
    
                listBox1.DisplayMember = "Название";
                listBox1.ValueMember = "ID";
    
                WorkModel workModel = new WorkModel();
    
                for (var i = 0; i < managerWorks.Count; i++)
                {
                    string name = "№" + managerWorks[i].id + " - " + managerWorks[i].name;
    
                    workModel.name = name;
                    workModel.id = managerWorks[i].id;
                    listBox1.Items.Add("Name:" + workModel.name + "Id:" + workModel.id.ToString());
                }
            }
