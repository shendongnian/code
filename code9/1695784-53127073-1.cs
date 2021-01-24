        <!-- language-all: c# -->
        public void OnInteractiveHitTest(HitTestResult result)
        {
            var listenerBehaviour = GetComponent<AnchorInputListenerBehaviour>();
            if (listenerBehaviour != null)
            {
                listenerBehaviour.enabled = false;
            }
         }
