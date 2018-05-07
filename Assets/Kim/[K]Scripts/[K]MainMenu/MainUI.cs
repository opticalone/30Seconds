using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public void Load(string Scene)
    {
        SceneManager.LoadScene(Scene);
    }
    
    public void Quit()
    {
        Application.Quit();
    }

    public Dropdown res;
    public Slider qSlider;
    public Text qText;

    private void Start()
    {
        Resolution[] resolution;
        resolution = Screen.resolutions;

        res.onValueChanged.AddListener(delegate { Screen.SetResolution(resolution[res.value].width, resolution[res.value].height, Screen.fullScreen); });

        for (int i = 0; i < resolution.Length; i++)
        {
            Dropdown.OptionData addedData = new Dropdown.OptionData(ResToString(resolution[i]));
            res.options.Add(addedData);
        }

        qSlider.maxValue = 6;
        qSlider.minValue = 1;
        QualitySettings.SetQualityLevel(0);


    }

    private string ResToString(Resolution RTS)
    {
        return RTS.width + " x " + RTS.height;
    }

    public void graphics()
    {
        Slider graphics = qSlider;
        Text graphicsText = qText;
        switch((int)graphics.value)
        {
            case 1:
                QualitySettings.SetQualityLevel(0);
                graphicsText.text = "Quality: Lowest";
                break;
            case 2:
                QualitySettings.SetQualityLevel(1);
                graphicsText.text = "Quality: Low";
                break;
            case 3:
                QualitySettings.SetQualityLevel(2);
                graphicsText.text = "Quality: Medium";
                break;
            case 4:
                QualitySettings.SetQualityLevel(3);
                graphicsText.text = "Quality: High";
                break;
            case 5:
                QualitySettings.SetQualityLevel(4);
                graphicsText.text = "Quality: Highest";
                break;
            case 6:
                QualitySettings.SetQualityLevel(5);
                graphicsText.text = "Quality: Ultra";
                break;
        }
    }
    public void FullScreenToggle()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
