using System.Collections;
using System.Collections.Generic;
using TowerDefense.Abilities.Data;
using TowerDefense.Level;
using TowerDefense.Towers.Data;
using UnityEngine;

namespace TowerDefense.Abilities
{
    /// <summary>
    /// Common functionality for all types of abilities
    /// </summary>
    public class Ability : MonoBehaviour
    {
        /// <summary>
        /// Reference to scriptable object with ability data on it
        /// </summary>
        public AbilityData abilityData;

        /// <summary>
        /// Name of the ability
        /// </summary>
        public string abilityName;

        /// <summary>
        /// Gets the ability description
        /// </summary>
        public string description
        {
            get { return abilityData.description; }
        }

        /// <summary>
        /// Gets the cost value
        /// </summary>
        public int cost
        {
            get { return abilityData.cost; }
        }

        /// <summary>
        /// Gets the duration value
        /// </summary>
        public float duration
        {
            get { return abilityData.duration; }
        }

        public float currentDuration;

        /// <summary>
        /// Gets the cooldown value
        /// </summary>
        public float cooldown
        {
            get { return abilityData.cooldown; }
        }

        public float currentCooldown;


        /// <summary>
        /// Gets the ability icon
        /// </summary>
        public Sprite icon
        {
            get { return abilityData.icon; }
        }

        public void ActivateAbility()
        {
            if(currentCooldown == 0)
            {
                if (LevelManager.instance.currency.TryPurchase(cost))
                {
                    currentDuration = duration;
                    currentCooldown = cooldown;
                }
            }
        }
        public virtual void Update()
        {
            currentDuration = currentDuration > 0 ? currentDuration-Time.deltaTime : 0;
            currentCooldown = currentCooldown > 0 ? currentCooldown-Time.deltaTime : 0;
        }
    }
}

