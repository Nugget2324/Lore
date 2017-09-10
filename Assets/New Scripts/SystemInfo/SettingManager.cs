using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

namespace NS
{
    public class SettingManager : MonoBehaviour
    {
        
        public Dropdown displaySize;
        public Dropdown resolutionDropdown;
        public Dropdown displayMonitor;
        //public Dropdown displayRatio;
        public Button applyButton;

        public Display[] monitors;
        public Resolution[] resolutions;
        public GameSettings gameSettings;

        void Start()
        {
            if (Screen.fullScreen == true)
            {
                Debug.Log("True");
            }
            else if (Screen.fullScreen == false)
            {
                Debug.Log("False");
            }
        }
        void OnEnable()
        {
            int i = 0;
            gameSettings = new GameSettings();

            displaySize.onValueChanged.AddListener(delegate { onFullScreen(); });
            resolutionDropdown.onValueChanged.AddListener(delegate { onResolutionChange(); });
            displayMonitor.onValueChanged.AddListener(delegate { onMonitorChange(); });
            applyButton.onClick.AddListener(delegate { onApplyClick(); });

            resolutions = Screen.resolutions;
            monitors = Display.displays;

            foreach (Resolution resolution in resolutions)
            {
                resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
            }

            foreach (Display display in monitors)
            {
                i++;
                displayMonitor.options.Add(new Dropdown.OptionData("Monitor "+i));
            }

            loadSettings();
        }

        public void onFullScreen()
        {
            if (displaySize.value == 0)
            {
                Screen.fullScreen = true;
            }
            else if(displaySize.value == 1)
            {
                Screen.fullScreen = false;
            }
            
            gameSettings.displaySize = displaySize.value;
        }

        public void onResolutionChange()
        {
            Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
            gameSettings.resolutionIndex = resolutionDropdown.value;
        }

        public void onMonitorChange()
        {
            gameSettings.displayMonitor = displayMonitor.value;
        }

        public void onApplyClick()
        {
            SaveSettings();
        }

        public void onDefaultClick()
        {

        }

        public void ratioLeftClick()
        {

        }

        public void ratioRightClick()
        {

        }

        public void SaveSettings()
        {
            string jsonData = JsonUtility.ToJson(gameSettings, true);
            File.WriteAllText(Application.persistentDataPath + "/gamesetting.json", jsonData);

        }

        public void defaultSettings()
        {

        }

        public void loadSettings()
        {
            if (File.Exists(Application.persistentDataPath + "/gamesetting.json"))
            {
                gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesetting.json"));
                resolutionDropdown.value = gameSettings.resolutionIndex;
                displayMonitor.value = gameSettings.displayMonitor;
                displaySize.value = gameSettings.displaySize;
                //displayRatio.value = gameSettings.displayRatio;
                //displayRatio.RefreshShownValue();
                displaySize.RefreshShownValue();
                displayMonitor.RefreshShownValue();
                resolutionDropdown.RefreshShownValue();
            }
        }
    }
}
