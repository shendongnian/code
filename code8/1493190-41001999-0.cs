    void OnObjectListChanged(IEnumerable objects){
        if( IsDisposed || !Visible || !IsHandleCreated ) return;
        if( InvokeRequired ) {
            Invoke ((Action)(()=>OnObjectListChanged (objects)));
            return;
        }
        // ....
    }
