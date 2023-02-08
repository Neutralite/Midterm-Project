using Core.Health;
using TowerDefense.Agents;
using TowerDefense.Economy;
using TowerDefense.Level;
using UnityEngine;

namespace TowerDefense.Abilities
{
    public class DoubleEarnings : Ability
    {
        public int lootMultiplier;
        public void Update()
        {
            if (currentDuration > 0)
            {
                for (int i = 0; i < LevelManager.instance.activeAgents.Count; i++)
                {
                    Agent temp = LevelManager.instance.activeAgents[i];

                    if (temp.GetComponent<LootDrop>().lootDoubled == false)
                    {
                        temp.GetComponent<LootDrop>().lootDropped *= lootMultiplier;
                        temp.GetComponent<LootDrop>().lootDoubled = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < LevelManager.instance.activeAgents.Count; i++)
                {
                    Agent temp = LevelManager.instance.activeAgents[i];

                    if (temp.GetComponent<LootDrop>().lootDoubled == true)
                    {
                        temp.GetComponent<LootDrop>().lootDropped /= lootMultiplier;
                        temp.GetComponent<LootDrop>().lootDoubled = false;
                    }
                }
            }
            DurationCooldownDecrease();
        }
    }
}