using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NS
{
    public class DefenderCam : MonoBehaviour
    {

        public Transform Player;
        public Transform Camera;
        Defender playerMove;

        private float characterX = 2.0f;
        private float cameraY = 2.0f;
        private float mouseX = 0.0f;
        private float mouseY = 0.0f;

        public float maxh;
        public float minh;

        public bool isLocked;
        // Use this for initialization
        void Start()
        {
            SetCursorLock(true);
        }

        //Locks cursor
        public void SetCursorLock(bool isLocked)
        {
            this.isLocked = isLocked;
            Cursor.visible = !isLocked;

            if (isLocked == true)
            {
                Cursor.lockState = CursorLockMode.Locked;

            }
            else
            {
                Cursor.lockState = CursorLockMode.None;

            }
            //
        }
        // Update is called once per frame
        void LateUpdate()
        {
            if (isLocked)
            {
                //adds mouse movement each frame
                mouseX += characterX * Input.GetAxis("Mouse X");
                mouseY += cameraY * Input.GetAxis("Mouse Y");

                mouseY = Mathf.Clamp(mouseY, maxh, minh);

                //translates the mouse movement to the camera and player
                Player.transform.eulerAngles = new Vector3(0.0f, mouseX, 0.0f);
                Camera.transform.eulerAngles = new Vector3(Mathf.Clamp(mouseY, maxh, minh), mouseX, 0.0f);
            }

            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                SetCursorLock(!isLocked);
            }
        }
    }
}