using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    public SettingsMenu settingsMenu;
    public int waveIndex;
    public WaveController waveController;
    public Slider dirX;
    public Slider dirY;
    public Slider steepness;
    public Slider wavelength;

    public void UpdateUI()
    {
        dirX.value = waveController.waves[waveIndex].x;
        dirY.value = waveController.waves[waveIndex].y;
        steepness.value = waveController.waves[waveIndex].w;
        wavelength.value = waveController.waves[waveIndex].z;
    }


    public void SetDirX(float dirX)
    {
        if (waveController != null)
        {
            waveController.waves[waveIndex].x = dirX;
            waveController.UpdateMaterial();
        }
    }

    public void SetDirY(float dirY)
    {
        if (waveController != null)
        {
            waveController.waves[waveIndex].y = dirY;
            waveController.UpdateMaterial();
        }
    }

    public void SetSteepness(float steepness)
    {
        if (waveController != null)
        {
            waveController.waves[waveIndex].z = steepness;
            waveController.UpdateMaterial();
        }
    }

    public void SetWavelength(float wavelength)
    {
        if (waveController != null)
        {
            waveController.waves[waveIndex].w = wavelength;
            waveController.UpdateMaterial();
        }
    }
}
