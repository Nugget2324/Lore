using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NS
{
    public class MainMenu : MonoBehaviour
    {
        public Animator CameraObject;
        [SerializeField]
        public GameObject[] Allpanel;
        

        void online()
        {

        }

        public void profile()
        {
            Allpanel[0].gameObject.active = false;
            Allpanel[10].gameObject.active = true;
        }
        public void option()
        {
            Allpanel[0].gameObject.active = false;
            Allpanel[5].gameObject.active = true;
        }

        public void video()
        {
            Allpanel[15].gameObject.active = true;

        }

        public void ReturnMain()
        {
            Allpanel[0].gameObject.active = true;
            Allpanel[5].gameObject.active = false;
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Allpanel[0].gameObject.active = true;
                Allpanel[5].gameObject.active = false;
                Allpanel[10].gameObject.active = false;
            }
        }
    }
}
