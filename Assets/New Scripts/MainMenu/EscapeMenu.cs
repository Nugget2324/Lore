using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NS
{
    public class EscapeMenu : MonoBehaviour
    {
        MainMenu mainMenu;
        public Camera camera;
        // Use this for initialization
        void Start()
        {
            mainMenu = camera.GetComponent<MainMenu>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("pressed");
            }
            else
            {

            }
        }
    }
}
