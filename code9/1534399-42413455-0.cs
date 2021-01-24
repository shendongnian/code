    objectA.objectX currentObject = null;
    int previousObjectIndex = 0;
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (currentObject == null)
        {
            currentObject = listA[comboBox1.SelectedIndex].GetWantedObjectX();
            textBox1.Text = currentObject.Prop1;
        }
        else
        {
            currentObject.Prop1 = textBox1.Text;
                    
            if (!listA[previousObjectIndex].listX.Any(x => x.Prop1 == currentObject.Prop1))
                listA[previousObjectIndex].listX.Add(currentObject);
                    
            currentObject = listA[comboBox1.SelectedIndex].GetWantedObjectX();
    
            if (currentObject == null)
                currentObject = new objectA.objectX();
    
            previousObjectIndex = comboBox1.SelectedIndex;
    
            textBox1.Text = currentObject.Prop1;
        }
    }
