    void Start()
    {
        StartCoroutine(RotateMe(Vector3.forward * 90f, 1f));
    }
    IEnumerator RotateMe(Vector3 byAngles1, float inTime1)
    {
        while (true)
        {
            var fromAngle1 = transform.rotation;
            var toAngle1 = Quaternion.Euler(transform.eulerAngles + byAngles1);
            for (var t = 0f; t < 1; t += Time.deltaTime / inTime1)
            {
                transform.rotation = Quaternion.Lerp(fromAngle1, toAngle1, t);
                yield return null;
            }
            yield return new WaitForSeconds(3);
            byAngles1 *= -1;
        }
    }
