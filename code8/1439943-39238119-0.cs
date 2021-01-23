    // modify source list order
    for (int i = 0; i < lbCameras.Items.Count; i++)
    {
        UnifyCamera cam = lbCameras.Items[i] as UnifyCamera;
        if (presets.JumpCameras.ContainsKey(cam.Name))
        {
            this.inputData.Cameras.Remove(cam);
            this.inputData.Cameras.Insert(presets.JumpCameras[cam.Name].Index, cam);
        }
    }
    // re-set the list box bounding to re-set the order.
    ((ListBox)lbCameras).DataSource = null;
    ((ListBox)lbCameras).DataSource = this.inputData.Cameras;
    ((ListBox)lbCameras).DisplayMember = "Name";
    // set check boxes
    foreach (KeyValuePair<string, ValuePair> item in presets.JumpCameras)
    {
        int index1 = lbCameras.FindStringExact(item.Key);
        if (index1 != -1)
        {
            lbCameras.SetItemCheckState(index1, item.Value.Checked == true ? CheckState.Checked : CheckState.Unchecked);
        }
    }
