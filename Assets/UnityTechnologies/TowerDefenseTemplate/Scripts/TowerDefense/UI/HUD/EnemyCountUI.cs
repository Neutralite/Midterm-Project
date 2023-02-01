using TowerDefense.Level;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.UI.HUD
{
    /// <summary>
    /// A class for displaying the wave feedback
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

        /// <summary>
        /// cache the total amount of waves
        /// Update the display 
        /// and Subscribe to waveChanged
        /// </summary>
        protected virtual void Start()
        {
            m_Canvas = GetComponent<Canvas>();
            //m_Canvas.enabled = false;
            //TotalEnemies = LevelManager.instance.numberOfEnemies;
            
        }

        protected virtual void Update()
        {
            UpdateDisplay();
        }

        /// <summary>
        /// Write the current wave amount to the display
        /// </summary>
        protected void UpdateDisplay()
        {
            m_Canvas.enabled = true;
            int currentEnemies = LevelManager.instance.numberOfEnemies;
            string output = string.Format("{0}", currentEnemies, TotalEnemies);
            display.text = output;
        }

       

        /// <summary>
        /// Unsubscribe from events
        /// </summary>
        //protected void OnDestroy()
        //{
        //    if (LevelManager.instanceExists)
        //    {
        //        LevelManager.instance.waveManager.waveChanged -= UpdateDisplay;
        //    }
        //}
    }
}
