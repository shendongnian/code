        int y = 114;
        foreach (var subject in subjects)
        {
                Console.WriteLine(module);
                subname = subject.Element("subjectName").Value,
                subid = subject.Element("subjectId").Value,
                subvalue = subject.Element("subjectvalue").Value
                TextBox box = new TextBox();
                box.Location = new System.Drawing.Point(50, y);
                box.Size = new System.Drawing.Size(300, 15);
                box.Text = @"Subject Name :  " + subName + "  Subject Id :  " + subID + "  Subject Value :  " + subValue + " ";
                this.Controls.Add(box);
                y += 25;
        }
