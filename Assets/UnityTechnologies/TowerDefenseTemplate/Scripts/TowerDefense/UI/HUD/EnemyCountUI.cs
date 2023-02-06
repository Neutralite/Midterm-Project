using TowerDefense.Level;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.UI.HUD
{
    /// <summary>
    /// A class for displaying the enemy feedback
    /// </summary>
    [RequireComponent(typeof(Canvas))]
    public class EnemyCountUI : MonoBehaviour
    {
        /// <summary>
        /// The text element to display information on
        /// </summary>
        public Text display;

        

        /// <summary>
        /// The total amount of enemies for this level
        /// </summary>
        protected int TotalEnemies;

        protected Canvas m_Canvas;

   
        protected virtual void Start()
        {
            m_Canvas = GetComponent<Canvas>();
           
            
        }

        protected virtual void Update()
        {
            UpdateDisplay();
        }

        /// <summary>
        /// Write the current enemy amount to the display
        /// </summary>
        protected void UpdateDisplay()
        {
            m_Canvas.enabled = true;
            int currentEnemies = LevelManager.instance.numberOfEnemies;
            string output = string.Format("{0}", currentEnemies, TotalEnemies);
            display.text = output;
        }

       

        
    }
}
