    	public override void OnInspectorGUI()
		{
            //update the editor's representation of the object
            // which you're using the editor for
			serializedObject.Update();
            // Here goes your editor's custom logic
            //Save the changes you or editor's user has made to 
            // the target object
            serializedObject.ApplyModifiedProperties();
         }
