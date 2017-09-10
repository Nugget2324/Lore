using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NS
{
    public class EnemyAIHealth : MonoBehaviour
    {

        public Image healthBar;

        public float maxVal = 100f;
        public float curVal = 0f;
        // Use this for initialization

        void Start()
        {
            curVal = maxVal;

        }

        private void Update()
        {
            HealthBar();
        }

        // Update is called once per frame
        void HealthBar()
        {
            healthBar.fillAmount = curVal / maxVal;
        }
    }
}