using Core.Health;
using TowerDefense.Agents;
using TowerDefense.Level;
using UnityEngine;

namespace TowerDefense.Abilities
{
    public class ScreenClearAbility : Ability
    {
        /// <summary>
        /// The alignment of the damager
        /// </summary>
        public SerializableIAlignmentProvider alignment;

        public IAlignmentProvider alignmentProvider
        {
            get { return alignment != null ? alignment.GetInterface() : null; }
        }

        public override void Update()
        {
            if (currentDuration > 0)
            {
                for (int i = 0; i < LevelManager.instance.activeAgents.Count; i++)
                {
                    Agent temp = LevelManager.instance.activeAgents[i];
                    temp.TakeDamage(temp.configuration.currentHealth, temp.position, alignmentProvider);
                
                }
            }
            base.Update();
        }
    }
}