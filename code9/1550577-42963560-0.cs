    void btnExe_Click(object sender, RoutedEventArgs e) {
            var course1 = Convert.ToDouble(txtCourse1.Text);
            var course2 = Convert.ToDouble(txtCourse2.Text);
            var course3 = Convert.ToDouble(txtCourse3.Text);
            student.Add(new Students());
            
            student[positionIndex].c1 = course1;
            student[positionIndex].c2 = course2;
            student[positionIndex].c3 = course3;
    
            student[positionIndex].Name = positionIndex;
            stdNames.Text = student[positionIndex].Name.ToString();
            positionIndex++;
            if (positionIndex == 6) {
                btnExe.IsEnabled = false;
                calculate();
            };
        }
