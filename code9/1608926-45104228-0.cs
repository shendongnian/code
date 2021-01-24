        else // If a specific file name is selected
        {
            //List<int> filteredfiles = DataForProject.Where(x => DataForProject.w == CboxReceiveNameFile.Text).ToList();
            foreach (GetInfoForGraph item in DataForProject.Where(list => list.File_Name == CboxReceiveNameFile.Text))
            {
                FormA_DataType.GraphData newData = new FormA_DataType.GraphData();
                newData.Date = item.Time;
                newData.Temp1 = item.Start_inlet_temp;
                newData.Temp2 = item.Start_outlet_temp;
                newData.Type = "";
                _gData.Add(newData);
            }
            Graph.Graph(_gData);
        }
