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
        public Button applyButton;
        public Button defaultButton;

        public Display[] monitors;
        public Resolution[] resolutions;
        public GameSettings gameSettings;

        void OnEnable()
        {
            
            gameSettings = new GameSettings();

            //displaySize.onValueChanged.AddListener(delegate { onFullScreen(); });
            resolutionDropdown.onValueChanged.AddListener(delegate { onResolutionChange(); });
            displayMonitor.onValueChanged.AddListener(delegate { onMonitorChange(); });
            applyButton.onClick.AddListener(delegate { onApplyClick(); });
            defaultButton.onClick.AddListener(delegate { defaultSettings(); });

            resolutions = Screen.resolutions;
            monitors = Display.displays;
            foreach(Resolution resolution in resolutions)
            {
                resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
            }

            foreach(Display display in monitors)
            {
                displayMonitor.options.Add(new Dropdown.OptionData(display.ToString()));
            }

            loadSettings();
        }

        public void onFullScreen()
        {

        }

        public void onResolutionChange()
        {
            Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
            gameSettings.resolutionIndex = resolutionDropdown.value;
        }

        public void onMonitorChange()
        {

        }

        public void onApplyClick()
        {
            SaveSettings();
        }

        public void SaveSettings()
        {
            string jsonData = JsonUtility.ToJson(gameSettings, true);
            File.WriteAllText(Application.persistentDataPath + "/gamesetting.json", jsonData);

        }

        public void defaultSettings()
        {
            if (File.Exists(Application.persistentDataPath + "/defaultsetting.json"))
            {
                Debug.Log("Pressed");
                gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/defaultsetting.json"));
            }
        }

        public void loadSettings()
        {
            if(File.Exists(Application.persistentDataPath + "/gamesetting.json"))
                gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesetting.json"));
            resolutionDropdown.value = gameSettings.resolutionIndex;
            displayMonitor.value = gameSettings.displayMonitor;
            displaySize.value = gameSettings.displaySize;
            resolutionDropdown.RefreshShownValue();
        }
    }
}
