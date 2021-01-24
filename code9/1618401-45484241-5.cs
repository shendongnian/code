    public class DifferentObject
    {
        public bool IsInErrorState { get; set; }
    }
    public class Alarm
    {
        //This is your "reference property"
        Func<DifferentObject, bool> ObjectHasError =
            (myDifferentObject => myDifferentObject.IsInErrorState);
        public void CheckThisObjectForErrors(DifferentObject diffObject)
        {
            if(ObjectHasError.Invoke(diffObject))
            {
                //there is an error in the object!
            }
        }
    }
