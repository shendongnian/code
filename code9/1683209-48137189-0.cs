    public class Example {
      private Transform _followTarget;
      MoveSelectedToCursorPosition() {
        RaycastHit raycastHit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out raycastHit, 1000.0f)) {
          if (raycastHit.collider.tag == "Terrain") {
            gameController.UnitSelection.MoveSelectionToPosition(raycastHit.point);
          }
    
    
          if (raycastHit.collider.tag == "Minion") {
            this._followTarget = raycastHit.collider.transform;
          gameController.UnitSelection.MoveSelectionToPosition(this._followTarget.position);
          }
        }
      }
    }
