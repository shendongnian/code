    foreach(var student in students) {
            // ..
            string id = student._id ;
            student.listener = MyStudentListener( id ) ;
            studentObject.GetComponent<Toggle> ().onValueChanged.AddListener(student.listener);
    }
    
    // ...
    private UnityEngine.Events.UnityAction<bool> MyStudentListener( string id )
    {
         return (val) => SomeListener( val, id ) ;
    }
    
    void SomeListener(bool isClicker, string studentId) {
        // something
    }}
