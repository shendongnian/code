            if (!rotateToggle)
            {
                if (Input.GetMouseButton(0))
                {
                    rotationX += Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
                    rotationY += Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
                }
                rotationY = Mathf.Clamp(rotationY, -90, 90);
                transform.localRotation = transform.localRotation * Quaternion.AngleAxis(rotationX, Vector3.up);
                transform.localRotation = transform.localRotation * Quaternion.AngleAxis(rotationY, Vector3.left);
                transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, 0);
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    cameraSpeed = 150f;
                }
                else
                {
                    cameraSpeed = 50f;
                }
                transform.position += transform.forward * cameraSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
                transform.position += transform.right * cameraSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
                rotationX = Mathf.Lerp(rotationX, 0f, 0.1f);
                rotationY = Mathf.Lerp(rotationY, 0f, 0.1f);
            }
            else
            {
                rotationX = Input.GetAxis("Mouse X") * RotateAmount;
                rotationY = Input.GetAxis("Mouse Y") * RotateAmount;
                Vector3 angles = transform.eulerAngles;
                angles.z = 0;
                transform.eulerAngles = angles;
                transform.RotateAround(rotationTarget.position, Vector3.up, rotationX);
                rotationY = Mathf.Clamp(rotationY, -30, 30);
                transform.RotateAround(rotationTarget.position, Vector3.left, -rotationY);
                transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, 0);
            }
