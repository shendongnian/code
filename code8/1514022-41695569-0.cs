    using System.Collections.Generic;
    
    namespace Assets.Foo
    {
      public class DataHolder
      {
        public List<object> courses;
      }
    
      public class Class1
      {
        private DataHolder dataHolder;
    
        void CheckIfCoursesHasBeenPulled (string dataType) {
          //dataHolder has been initialised in Start function
          if (dataHolder.courses != null && dataHolder.courses.Count > 0) {
            UpdateDropdown(dataHolder.courses);
          }
    
          // Convert object to object[] or List<Foo> or whatever here...
          var objects = dataHolder.GetType().GetField(dataType).GetValue(dataHolder) as List<object>;
          if (objects != null && objects.Count > 0) {
            UpdateDropdown(dataHolder.courses);
          }
        }
    
        private void UpdateDropdown(List<object> dataHolderCourses)
        {
          throw new System.NotImplementedException();
        }
      }
    }
