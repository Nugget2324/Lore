using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NS
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CapsuleCollider))]
    public class Defender : MonoBehaviour
    {
        Animator anim;
        Rigidbody ridig;
        public string[] animate;
        public bool timer = false;
        float clickTime;
        DefenderCam defcam;
        public CapsuleCollider swordCollider;

        DefenderHealth health;

        // Use this for initialization
        void Start()
        {
            anim = GetComponent<Animator>();
            swordCollider.enabled = false;
            health = GetComponent<DefenderHealth>();
        }

        // Update is called once per frame
        void Update()
        {
            Move();
            if(clickTime > 0)
            {
                clickTime -= Time.deltaTime;
            }
            if(clickTime < 0)
            {
                clickTime = 0;
                timer = false;
            }
            DetectAction();
        }

        void Move()
        {
            anim.SetFloat("vertical", Input.GetAxis("Vertical"), 0.1f, Time.deltaTime);
            anim.SetFloat("horizontal", Input.GetAxis("Horizontal"), 0.3f, Time.deltaTime);
        }

        void DetectAction()
        {
            string targetAnim = null;
            if (Input.GetAxis("RB") > 0 && !timer)
            {
                int n = Random.Range(1, animate.Length);
                targetAnim = animate[n];
                clickTime = 2.3f;
                timer = true;
                health.curVal -= 10;
            }
            if (string.IsNullOrEmpty(targetAnim))
            {
                return;
            }
            
            anim.CrossFade(targetAnim, 0.3f);
        }
        void OpenCollision()
        {
            swordCollider.enabled = true;
        }

        void CloseCollision()
        {
            swordCollider.enabled = false;
        }
    }
}
