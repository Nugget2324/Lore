using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NS
{
    public class EscapeMenu : MonoBehaviour
    {
        MainMenu mainMenu;
        // Use this for initialization
        void Start()
        {
            mainMenu = gameObject.GetComponent<MainMenu>();
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
