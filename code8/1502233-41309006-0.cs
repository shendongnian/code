    //Record Set Destination Component Instantiation
            IDTSComponentMetaData100 recSetComponentMetadataObject = pipeline.ComponentMetaDataCollection.New();
            recSetComponentMetadataObject.ComponentClassID = "{C457FD7E-CE98-4C4B-AEFE-F3AE0044F181}";
            //recSetComponentMetadataObject.ComponentClassID = "DtsAdapter.RecordSetDestination";
            CManagedComponentWrapper recSetDesignTimeObject = recSetComponentMetadataObject.Instantiate();
            recSetDesignTimeObject.ProvideComponentProperties();
            // name, description etc if needed
            recSetComponentMetadataObject.Name = "HoHoHo";
            // Setting the User Variable
            recSetDesignTimeObject.SetComponentProperty("VariableName", "User::MyRecSetVariableName");
            // Connect to previous component;
            // Assuming pipeline is the MainPipe object from the parent Data Flow Task and srcComponent is the IDTSComponentMetaData100 object of previous oledb source component
            IDTSPath100 path = pipeline.PathCollection.New();
            path.AttachPathAndPropagateNotifications(
                srcComponent.OutputCollection[0],
                recSetComponentMetadataObject.InputCollection[0]);
            // Set usage type to the required columns
            IDTSInput100 recSetInput = recSetComponentMetadataObject.InputCollection[0];
            IDTSVirtualInput100 virtualInput = recSetInput.GetVirtualInput();
            // call SetUsageType for each column you need. Here I am assuming I need columns "col_a" and col_b
            IDTSInputColumn100 inputColA = recSetDesignTimeObject.SetUsageType(
                recSetInput.ID,
                virtualInput,
                virtualInput.VirtualInputColumnCollection["col_a"].LineageID,
                DTSUsageType.UT_READONLY
                );
            IDTSInputColumn100 inputColB = recSetDesignTimeObject.SetUsageType(
                recSetInput.ID,
                virtualInput,
                virtualInput.VirtualInputColumnCollection["col_b"].LineageID,
                DTSUsageType.UT_READONLY
                );
