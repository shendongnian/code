            Touch t = Input.GetTouch(0);
            Vector2 guiPosition = new Vector2(t.position.x, Screen.height - t.position.y);
            Camera cam = Camera.main;
            RaycastHit hitInfo;
            if (t.phase != TouchPhase.Began)
            {
                return;
            }
            if (m_selectedRect.Contains(guiPosition))
            {
                // do nothing, the button will handle it
            }
            else if (Physics.Raycast(cam.ScreenPointToRay(t.position), out hitInfo))
            {
                // Found a marker, select it (so long as it isn't disappearing)!
                GameObject tapped = hitInfo.collider.gameObject;
                if (!tapped.GetComponent<Animation>().isPlaying)
                {
                    m_selectedMarker = tapped.GetComponent<ARMarker>();
                }
            }
