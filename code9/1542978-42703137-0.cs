    PCFMessage reqeuestMessage = new PCFMessage(MQC.MQCMD_INQUIRE_Q);
    reqeuestMessage.AddParameter(MQC.MQCA_Q_NAME, "*");
    reqeuestMessage.AddParameter(MQC.MQIA_Q_TYPE, MQC.MQQT_LOCAL);
    reqeuestMessage.AddParameter(MQCFC.MQIACF_Q_ATTRS,
                                 new int [] { MQC.MQCA_Q_NAME,
                                              MQC.MQIA_Q_TYPE,
                                              MQC.MQIA_CURRENT_Q_DEPTH,
                                              MQC.MQIA_OPEN_INPUT_COUNT,
                                              MQC.MQIA_OPEN_OUTPUT_COUNT });
    PCFMessage[] pcfResponse = messageAgent.Send(reqeuestMessage);
