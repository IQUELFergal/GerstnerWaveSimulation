using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    bool hidden = true;
    public GameObject settingsMenu;

    public void Hide()
    {
        if(hidden)
        {
            settingsMenu.SetActive(true);
        }
        else
        {
            settingsMenu.SetActive(false);
        }
        hidden = !hidden;
    }

}
