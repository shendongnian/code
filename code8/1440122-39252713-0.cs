    public override TaskStatus OnUpdate() {
        for (int i = 0; i < possibleTargets.Length; ++i) {
            if (withinSight(possibleTargets [i], fieldOfViewAngle)) {
                target.Value = possibleTargets [i];
                gameObject.tag = "Untagged";
                return TaskStatus.Success;
            }
        }
        return TaskStatus.Failure;
    }
