    public class DifferentObject
    {
        public bool IsInErrorState { get; set; }
    }
    public class Alarm
    {
        //This is your "reference property"
        Func<DifferentObject, bool> DifferentObjectHasError =
            (myDifferentObject => myDifferentObject.IsInErrorState);
        public void CheckThisObjectForErrors(DifferentObject diffObject)
        {
            if(DifferentObjectHasError.Invoke(diffObject))
            {
                //there is an error in the object!
            }
        }
    }
