    using UnityEngine;
    public class test : MonoBehaviour {
    public bool editorStart = false;
    public bool editorExit = false;
    // Update is called once per frame
    void Update () {
        if (editorStart)
        {
            Debug.Log("editorStart changed to TRUE");
            editorStart = false;
        }
        if (editorExit)
        {
            Debug.Log("editorExit changed to TRUE");
            editorExit = false;
        }
    }
    //better way
    public void EditorStart()
    {
        //do you stuff
    }
    public void EditorExit()
    {
        //do you stuff
    }
    }
