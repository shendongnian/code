    private void FixedUpdate() {        
        Method (fixedAtList, f => f.FixedAt() );
    }
    
    private void Update() {        
        Method (updateAtList, u => u.UpdateAt() );
    }
    
    private void LateUpdate() {        
        Method (lateUpdateAtList, l => l.LateUpdateAt() );
    }
    
    private void Method<T> (List<T> list, Action<T> method) where T : IActive {
        if (list != null) {
            for (int i = 0; i < list.Count; i++) {  
                if (list[i].IsActive)
                    method(list[i]);
            }
        }
    }
