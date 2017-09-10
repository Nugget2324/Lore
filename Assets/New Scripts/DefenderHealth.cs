using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace NS
{
    public class DefenderHealth : MonoBehaviour
    {
        EnemyAI enemyAI;
        public Image healthBar;
        public Transform enemy;
        Animator defenderAnim;

        public float maxVal = 100f;
        public float curVal = 0f;
        // Use this for initialization

        void Start()
        {
            curVal = maxVal;
            enemyAI = enemy.GetComponent<EnemyAI>();
            defenderAnim = GetComponent<Animator>();

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
