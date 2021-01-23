        public void OnDrop(PointerEventData eventData)
        {
            // Save the current layer the dropped object is in,
            // and then temporarily place the object in the IgnoreRaycast layer to avoid hitting self with Raycast.
            int oldLayer = gameObject.layer;
            gameObject.layer = 2;
            var screenRay = Camera.main.ScreenPointToRay(new Vector3(eventData.position.x, eventData.position.y, 0.0f));
            RaycastHit hit;
            if (Physics.Raycast(screenRay, out hit))
            {
                Debug.LogFormat("Dropped in front of {0}!", hit.transform);
            }
            
            // Reset the object's layer to the layer it was in before the drop.
            gameObject.layer = oldLayer;
        }
