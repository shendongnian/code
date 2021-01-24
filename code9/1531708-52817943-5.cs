    private void callWCFService() {
            String url = "<Your Server URL>";
            url = url + "MyServiceMethod"; // MyServiceMethod is a method name.
            RequestModel requestModel = new RequestModel();
            requestModel.param1 = "param1 value";
            requestModel.param2 = 23;
            WebRequest<ResponseModel> req = new WebRequest<>(getActivity());
            req.execute(Request.Method.POST, url, ResponseModel.class, requestModel, new Response.Listener<ResponseModel>() {
                @Override
                public void onResponse(ResponseModel response) {
                    // Here you got the response of webservice.
                }
            }, new Response.ErrorListener() {
                @Override
                public void onErrorResponse(VolleyError error) {
                    // handle error
                }
            });
        }
