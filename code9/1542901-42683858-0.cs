    var request = new HttpRequest("", url, "");
    var formType = request.Form.GetType();
    formType.GetMethod("MakeReadWrite", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).Invoke(request.Form, null);
    request.Form["__EVENTTARGET"] = eventTarget;
    formType.GetMethod("MakeReadOnly", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).Invoke(request.Form, null);
