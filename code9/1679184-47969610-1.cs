    private void FixedUpdate()
      {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 3000))
        {
          Vector3 mousePos = hit.point;
          Debug.DrawLine(transform.position, hit.point, Color.yellow);
          Vector3 rayDir = transform.position - mousePos;
          Vector3[] explorePoints = new Vector3[6] {
            Quaternion.Euler(0, 0, 45) * rayDir.normalized,
            Quaternion.Euler(0, 0, 90) * rayDir.normalized,
            Quaternion.Euler(0, 0, 135) * rayDir.normalized,
            Quaternion.Euler(0, 0, -45) * rayDir.normalized,
            Quaternion.Euler(0, 0, -90) * rayDir.normalized,
            Quaternion.Euler(0, 0, -135) * rayDir.normalized,
          };
          float starLength = 100;
          for (int x = 0; x < explorePoints.Length; x++)
          {
            // we want to use the vector as DIRECTION, not point, hence mousePos + explorePoints[x] (starLength is just the length of the red line)
            Debug.DrawLine(mousePos, mousePos + (explorePoints[x] * starLength), Color.red);
          }
        }
      }
