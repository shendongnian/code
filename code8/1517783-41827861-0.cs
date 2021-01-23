    clsCHPChassis chassis1 = new clsCHPChassis("Rear Port", "Management", "192.168.1.1");
            clsCHPChassis chassis2 = new clsCHPChassis("Front USB", "Local", "10.10.10.1");
    
            myList.Add(chassis1);
            myList.Add(chassis2);
    
            dgv.DataSource = myList;
    dgv.DataBind();
        }
