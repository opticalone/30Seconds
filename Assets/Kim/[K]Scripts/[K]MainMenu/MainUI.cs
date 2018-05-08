using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
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

    public void graphics()
    {
        
        switch((int)qSlider.value)
        {
            case 1:
                QualitySettings.SetQualityLevel(0);
                qText.text = "Quality: Lowest";
                Debug.Log(QualitySettings.GetQualityLevel());
                break;
            case 2:
                QualitySettings.SetQualityLevel(1);
                qText.text = "Quality: Low";
                Debug.Log(QualitySettings.GetQualityLevel());
                break;
            case 3:
                QualitySettings.SetQualityLevel(2);
                qText.text = "Quality: Medium";
                Debug.Log(QualitySettings.GetQualityLevel());
                break;
            case 4:
                QualitySettings.SetQualityLevel(3);
                qText.text = "Quality: High";
                Debug.Log(QualitySettings.GetQualityLevel());
                break;
            case 5:
                QualitySettings.SetQualityLevel(4);
                qText.text = "Quality: Highest";
                Debug.Log(QualitySettings.GetQualityLevel());
                break;
            case 6:
                QualitySettings.SetQualityLevel(5);
                qText.text = "Quality: Ultra";
                Debug.Log(QualitySettings.GetQualityLevel());
                break;
        }
    }

    public void FullScreenToggle()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
