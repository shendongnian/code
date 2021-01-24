    button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(selectedFilePath != null){
                    dialog = ProgressDialog.show(MainActivity.this,"","Uploading File...",true);
                            uploadFile(selectedFilePath);
                          //  OnSendFileInfo();
                }else{
                    Toast.makeText(MainActivity.this,"Please choose a File First",Toast.LENGTH_SHORT).show();
                }
            }
        });
