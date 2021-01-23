    void OnObjectListChanged(IEnumerable objects){
        if( IsDisposed || Disposing || !Visible || !IsHandleCreated ) return;
        if( InvokeRequired ) {
            Invoke ((Action)(()=>OnObjectListChanged (objects)));
            return;
        }
        // ....
    }
