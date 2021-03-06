﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core.UI;
using LeanCloud;
using LeanCloud.Storage;

public class NamePanel : SimpleMainMenuPage
{
    public InputField nicknameInputField;

    public async void OnOKClicked() {
        string nickname = nicknameInputField.text;
        if (!LCUtils.IsValidString(nickname)) {
            LCUtils.ShowToast(this, "Please input nickname");
            return;
        }

        try {
            LCUser user = await LCUser.GetCurrent();
            user.SetNickname(nickname);
            await user.Save();
            SendMessageUpwards("BackToLCMainMenu", SendMessageOptions.RequireReceiver);
        } catch (LCException e) {
            LCUtils.LogException(e);
            LCUtils.ShowToast(this, e);
        }
    }
}
