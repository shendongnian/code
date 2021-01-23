        public void OnBeginDrag(PointerEventData eventData)
        {
            ...
            if (!UIObject)
            {
                var collider = gameObject.GetComponent<Collider>();
                collider.enabled = false;
            }
        }
        public void OnDrag(PointerEventData eventData)
        {
            // Move object and stuff
            ...
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            NotifyDroppedOnObjects(eventData);
            if (!UIObject)
            {
                var collider = gameObject.GetComponent<Collider>();
                collider.enabled = true;
            }
        }
        private void NotifyDroppedOnObjects(PointerEventData eventData)
        {
            // Currently using transform.position as raycast origin, could easily be something else if desired.
            var rayCastOrigin = transform.position;
            // Save the current layer the dropped object is in,
            // and then temporarily place the object in the IgnoreRaycast layer to avoid hitting self with Raycast.
            int oldLayer = gameObject.layer;
            gameObject.layer = 2;
            var raycastOriginInScreenSpace = Camera.main.WorldToScreenPoint(rayCastOrigin);
            var screenRay = Camera.main.ScreenPointToRay(new Vector3(raycastOriginInScreenSpace.x, raycastOriginInScreenSpace.y, 0.0f));
            // Perform Physics.Raycast from transform and see if any 3D object was under transform.position on drop.
            RaycastHit hit3D;
            if (Physics.Raycast(screenRay, out hit3D))
            {
                var dropComponent = hit3D.transform.gameObject.GetComponent<IDropHandler>();
                if (dropComponent != null)
                    dropComponent.OnDrop(eventData);
            }
            // Perform Physics2D.GetRayIntersection from transform and see if any 2D object was under transform.position on drop.
            RaycastHit2D hit2D = Physics2D.GetRayIntersection(screenRay);
            if (hit2D)
            {
                var dropComponent = hit2D.transform.gameObject.GetComponent<IDropHandler>();
                if (dropComponent != null)
                    dropComponent.OnDrop(eventData);
            }
            // Reset the object's layer to the layer it was in before the drop.
            gameObject.layer = oldLayer;
        }
