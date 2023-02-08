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

        Ability shownAbility;

        /// <summary>
        /// Draws the ability data on to the canvas, if the relevant text components are populated
        /// </summary>
        /// <param name="ability">The ability to gain info from</param>
        public void Show(Ability ability)
        {
            shownAbility = ability;
            DisplayText(abilityName, ability.abilityName);
            DisplayText(description, ability.description);
            if (ability.duration < 1)
            {
                DisplayText(duration, "Instant");
            }
            else
            {
                DisplayText(duration, ability.currentDuration.ToString("f1") + " / " + ability.duration.ToString("f0") + " (s)");
            }

            DisplayText(cooldown, ability.currentCooldown.ToString("f1") + " / " + ability.cooldown.ToString("f0") + " (s)");
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
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

        private void Update()
        {
            if (shownAbility != null)
            {
               if (shownAbility.duration >= 1)
               {
                   DisplayText(duration, shownAbility.currentDuration.ToString("f1") + " / " + shownAbility.duration.ToString("f0") + " (s)");
               }

               DisplayText(cooldown, shownAbility.currentCooldown.ToString("f1") + " / " + shownAbility.cooldown.ToString("f0") + " (s)");
            }

        }
    }
}