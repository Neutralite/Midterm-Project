using System;
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
    public abstract class Ability : MonoBehaviour
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

        /// <summary>
        /// Occurs when cooldown changed.
        /// </summary>
        public event Action cooldownChanged;

        public void ActivateAbility()
        {
            if(currentCooldown == 0)
            {
                if (LevelManager.instance.currency.TryPurchase(cost))
                {
                    currentDuration = duration;
                    currentCooldown = cooldown;
                    cooldownChanged();
                }
            }
        }
        public void DurationCooldownDecrease()
        {
            if (currentDuration > 0)
            {
                currentDuration -= Time.deltaTime;
            }
            else if (currentDuration != 0)
            {
                currentDuration = 0;
            }
            if (currentCooldown > 0)
            {
                currentCooldown -= Time.deltaTime;
            }
            else if (currentCooldown != 0)
            {
                currentCooldown = 0;
                cooldownChanged();
            }
        }
    }
}

