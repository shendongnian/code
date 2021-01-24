    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using VRTK;
    public class JoinObjects : MonoBehaviour {
    public GameObject GO1, GO2;
    public GameObject ControllerL;
    public GameObject ControllerR;
    public GameObject GO;
    // Use this for initialization
    void Start ()
    {
        GetComponent<VRTK_InteractableObject>().InteractableObjectGrabbed += new InteractableObjectEventHandler(ObjectGrabbed);
        GetComponent<VRTK_InteractGrab>().GetGrabbedObject();
    }
    private void ObjectGrabbed(object sender, InteractableObjectEventArgs e)
    {
        Debug.Log("Im Grabbed");
    }
    public void Click()
    {
        Debug.Log("pouet");
        ControllerL = VRTK_DeviceFinder.GetControllerLeftHand();
        ControllerR = VRTK_DeviceFinder.GetControllerRightHand();
        GO1 = ControllerL.GetComponent<VRTK_InteractGrab>().GetGrabbedObject();
        GO2 = ControllerR.GetComponent<VRTK_InteractGrab>().GetGrabbedObject();
        if (GO1 != null)
        {
            Debug.Log(GO1.name);
        }
        if (GO2 != null)
        {
            Debug.Log(GO2.name);
        }
        ConfigurableJoint CJoint;
        CJoint = GO1.AddComponent<ConfigurableJoint>();
        CJoint.connectedBody = GO2.GetComponent<Rigidbody>();
        //CJoint.angularXMotion = ConfigurableJointMotion.Locked;
        //CJoint.angularYMotion = ConfigurableJointMotion.Locked;
        //CJoint.angularZMotion = ConfigurableJointMotion.Locked;
        CJoint.xMotion = ConfigurableJointMotion.Locked;
        CJoint.yMotion = ConfigurableJointMotion.Locked;
        CJoint.zMotion = ConfigurableJointMotion.Locked;
    }
}
