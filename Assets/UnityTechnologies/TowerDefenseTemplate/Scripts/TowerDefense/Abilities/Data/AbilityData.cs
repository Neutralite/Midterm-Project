using UnityEngine;

namespace TowerDefense.Abilities.Data
{
    /// <summary>
    /// Data container for ability settings
    /// </summary>
    [CreateAssetMenu(fileName = "AbilityData.asset", menuName = "TowerDefense/Ability Configuration", order = 1)]
    public class AbilityData : ScriptableObject
    {
        /// <summary>
        /// A description of the ability for displaying on the UI
        /// </summary>
        /// 
        [TextArea(3, 15)]
        public string description;

        /// <summary>
        /// The cost to use this ability
        /// </summary>
        public int cost;

        /// <summary>
        /// The duration of this ability
        /// </summary>
        public float duration;

        /// <summary>
        /// The cooldown between uses of this ability
        /// </summary>
        public float cooldown;

        /// <summary>
        /// The ability icon
        /// </summary>
        public Sprite icon;
    }
}

