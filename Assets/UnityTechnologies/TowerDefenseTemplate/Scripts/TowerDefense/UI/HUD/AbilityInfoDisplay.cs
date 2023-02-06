using TowerDefense.Abilities;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.UI.HUD
{
    /// <summary>
    /// Used to display infomation about an ability using Unity UI
    /// </summary>
    public class AbilityInfoDisplay : MonoBehaviour
    {
        /// <summary>
        /// The text component for the name
        /// </summary>
        public Text abilityName;

        /// <summary>
        /// The text component for the description
        /// </summary>
        public Text description;

        /// <summary>
        /// The text component for the duration
        /// </summary>
        public Text duration;

        /// <summary>
        /// The text component for the cooldown
        /// </summary>
        public Text cooldown;

        /// <summary>
        /// Draws the ability data on to the canvas, if the relevant text components are populated
        /// </summary>
        /// <param name="ability">The ability to gain info from</param>
        public void Show(Ability ability)
        {
            DisplayText(abilityName, ability.abilityName);
            DisplayText(description, ability.description);
            DisplayText(duration, ability.duration.ToString("f2") + " (s)");
            DisplayText(cooldown, ability.cooldown.ToString("f2") + " (s)");
        }

        /// <summary>
        /// Draws the text if the text component is populated
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="text"></param>
        static void DisplayText(Text textBox, string text)
        {
            if (textBox != null)
            {
                textBox.text = text;
            }
        }
    }
}