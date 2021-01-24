    public static Learner SGDLearner(ParameterVector parameters, TrainingParameterScheduleDouble learningRateSchedule);
    public static Learner MomentumSGDLearner(ParameterVector parameters, TrainingParameterScheduleDouble learningRateSchedule, TrainingParameterScheduleDouble momentumSchedule);
    public static Learner FSAdaGradLearner(ParameterVector parameters, TrainingParameterScheduleDouble learningRateSchedule, TrainingParameterScheduleDouble momentumSchedule);
    public static Learner AdamLearner(ParameterVector parameters, TrainingParameterScheduleDouble learningRateSchedule, TrainingParameterScheduleDouble momentumSchedule);
    public static Learner AdaGradLearner(ParameterVector parameters, TrainingParameterScheduleDouble learningRateSchedule);
    public static Learner RMSPropLearner(ParameterVector parameters, TrainingParameterScheduleDouble learningRateSchedule, double gamma, double inc, double dec, double max, double min);
    public static Learner AdaDeltaLearner(ParameterVector parameters, TrainingParameterScheduleDouble learningRateSchedule);
