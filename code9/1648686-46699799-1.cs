    public class MyHelpers{
       public static SelectList DropDownListGoalTypes(int? selected) {
            var list = db.GoalType.ToList();
            return new SelectList(list, "Id", "Type", selected);
       } 
     } 
