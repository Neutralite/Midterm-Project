using TowerDefense.Level;
using TowerDefense.Abilities;
using UnityEngine;

namespace TowerDefense.UI.HUD
{
    /// <summary>
    /// UI component that displays towers that can be built on this level.
    /// </summary>
    public class AbilitySidebar : MonoBehaviour
    {
        /// <summary>
        /// The prefab spawned for each button
        /// </summary>
        public AbilityCallButton abilityCallButton;

        /// <summary>
        /// Initialize the tower spawn buttons
        /// </summary>
        protected virtual void Start()
        {
            if (!LevelManager.instanceExists)
            {
                Debug.LogError("[UI] No level manager for ability list");
            }
            foreach (Ability ability in LevelManager.instance.abilityLibrary)
            {
                AbilityCallButton button = Instantiate(abilityCallButton, transform);
                button.InitializeButton(ability);
                button.buttonTapped += OnButtonTapped;
                button.draggedOff += OnButtonDraggedOff;
            }
        }

        /// <summary>
        /// Activate ability
        /// </summary>
        /// <param name="ability"></param>
        void OnButtonTapped(Ability ability)
        {
            ability.ActivateAbility();
        }

        /// <summary>
        /// Activate ability
        /// </summary>
        /// <param name="towerData"></param>
        void OnButtonDraggedOff(Ability ability)
        {
            ability.ActivateAbility();
        }

        /// <summary>
        /// Unsubscribes from all the ability call buttons
        /// </summary>
        void OnDestroy()
        {
            AbilityCallButton[] childButtons = GetComponentsInChildren<AbilityCallButton>();

            foreach (AbilityCallButton abilityButton in childButtons)
            {
                abilityButton.buttonTapped -= OnButtonTapped;
                abilityButton.draggedOff -= OnButtonDraggedOff;
            }
        }
    }
}