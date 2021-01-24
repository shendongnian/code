            string bodyName;
            string bodiesCount = Part.HybridShapeFactory.Parent.Bodies.count;
            for (int i = 1; i <= bodiesCount; i++)
            {
                bodyName = Part.HybridShapeFactory.Parent.Bodies.Item(i).Name
                MessageBox.Show(bodyName);
            }
