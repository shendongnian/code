        horizontalAngle += (Input.GetAxis("Mouse X") * horizontalSensitivity);
        verticalAngle += (-Input.GetAxis("Mouse Y") * verticalSensitivity);
        horizontalSmoothAngle = Mathf.Lerp(horizontalSmoothAngle, horizontalRotation, smoothAmount * Time.deltaTime);
        verticalSmoothAngle = Mathf.Lerp(verticalSmoothAngle , verticalRotation, smoothAmount * Time.deltaTime);
        horizontalRotation = Quaternion.Euler(0, smoothRotation ? horizontalSmoothAngle: horizontalAngle, 0);
        verticalRotation = Quaternion.Euler(smoothRotation ? verticalSmoothAngle : verticalAngle, 0, 0);
