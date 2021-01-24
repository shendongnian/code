    public void SomeMethod()
    {
          IEnumerator<Cell> Cell_List = this.Table_Section.GetEnumerator();
          Workout_Cell firstCell = Cell_List.FirstOrDefault() as Workout_Cell
    
          firstCell.AccessMyMethodsWoopWoop();
    }
