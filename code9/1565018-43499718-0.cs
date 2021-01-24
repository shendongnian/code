    Quaternion inputAngle = Quaternion.identity;
                if (Character.IsFacingRight)
                    inputAngle = Quaternion.FromToRotation(forwardVector, playerInput);
                else
                    inputAngle = Quaternion.FromToRotation(playerInput, forwardVector);
                Quaternion minAngle = Quaternion.Euler(0F, 0F, addedForce.force.angle);
                Quaternion angleRange = Quaternion.Euler(0F, 0F, addedForce.force.angleRange);
                Quaternion maxAngle = angleRange * minAngle;
                float roll = (float)Math.Atan2(2.0 * (inputAngle.x * inputAngle.y + inputAngle.w * inputAngle.z), inputAngle.w * inputAngle.w + inputAngle.x * inputAngle.x - inputAngle.y * inputAngle.y - inputAngle.z * inputAngle.z);
                float correctedRotation = roll / Mathf.PI * 180F;
                float minAngleF = minAngle.eulerAngles.z;
                float maxAngleF = maxAngle.eulerAngles.z;
                if (correctedRotation < 0) correctedRotation += 360;
                if (maxAngleF < 0) maxAngleF += 360;
                if (minAngleF < 0) minAngleF += 360;
                if (minAngleF > maxAngleF) minAngleF -= 360;
                if (correctedRotation < minAngleF || correctedRotation > maxAngleF)
                {
                    float rotationToMax = Quaternion.Angle(Quaternion.Euler(0F, 0F, correctedRotation), Quaternion.Euler(0F, 0F, maxAngleF));
                    float rotationToMin = Quaternion.Angle(Quaternion.Euler(0F, 0F, correctedRotation), Quaternion.Euler(0F, 0F, minAngleF));
                    if (Mathf.Abs(rotationToMax) < Mathf.Abs(rotationToMin))
                        correctedRotation = maxAngleF;
                    else
                        correctedRotation = minAngleF;
                }
                Quaternion endAngle = Quaternion.Euler(0F, 0F, correctedRotation);
