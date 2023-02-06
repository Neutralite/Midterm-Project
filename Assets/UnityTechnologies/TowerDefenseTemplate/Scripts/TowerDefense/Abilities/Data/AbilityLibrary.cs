using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TowerDefense.Towers;
using UnityEngine;

namespace TowerDefense.Abilities.Data
{
    /// <summary>
    /// The asset which holds the list of different abilities
    /// </summary>
    [CreateAssetMenu(fileName = "AbilityLibrary.asset", menuName = "TowerDefense/Ability Library", order = 1)]

    public class AbilityLibrary : ScriptableObject, IList<Ability>, IDictionary<string, Ability>
    {
        /// <summary>
        /// The list of all the abilities
        /// </summary>
        public List<Ability> configurations;

        /// <summary>
        /// The internal reference to the dictionary made from the list of abilities
        /// with the name of ability as the key
        /// </summary>
        Dictionary<string, Ability> m_ConfigurationDictionary;

        /// <summary>
        /// The accessor to the towers by index
        /// </summary>
        /// <param name="index"></param>
        public Ability this[int index]
        {
            get { return configurations[index]; }
        }

        /// <summary>
        /// Convert the list (m_Configurations) to a dictionary for access via name
        /// </summary>
        public void OnAfterDeserialize()
        {
            if (configurations == null)
            {
                return;
            }
            m_ConfigurationDictionary = configurations.ToDictionary(t => t.abilityName);
        }

        public bool ContainsKey(string key)
        {
            return m_ConfigurationDictionary.ContainsKey(key);
        }

        public void Add(string key, Ability value)
        {
            m_ConfigurationDictionary.Add(key, value);
        }

        public bool Remove(string key)
        {
            return m_ConfigurationDictionary.Remove(key);
        }

        public bool TryGetValue(string key, out Ability value)
        {
            return m_ConfigurationDictionary.TryGetValue(key, out value);
        }

        Ability IDictionary<string, Ability>.this[string key]
        {
            get { return m_ConfigurationDictionary[key]; }
            set { m_ConfigurationDictionary[key] = value; }
        }

        public ICollection<string> Keys
        {
            get { return ((IDictionary<string, Ability>)m_ConfigurationDictionary).Keys; }
        }

        ICollection<Ability> IDictionary<string, Ability>.Values
        {
            get { return m_ConfigurationDictionary.Values; }
        }

        IEnumerator<KeyValuePair<string, Ability>> IEnumerable<KeyValuePair<string, Ability>>.GetEnumerator()
        {
            return m_ConfigurationDictionary.GetEnumerator();
        }

        public void Add(KeyValuePair<string, Ability> item)
        {
            m_ConfigurationDictionary.Add(item.Key, item.Value);
        }

        public bool Remove(KeyValuePair<string, Ability> item)
        {
            return m_ConfigurationDictionary.Remove(item.Key);
        }

        public bool Contains(KeyValuePair<string, Ability> item)
        {
            return m_ConfigurationDictionary.Contains(item);
        }

        public void CopyTo(KeyValuePair<string, Ability>[] array, int arrayIndex)
        {
            int count = array.Length;
            for (int i = arrayIndex; i < count; i++)
            {
                Ability config = configurations[i - arrayIndex];
                KeyValuePair<string, Ability> current = new KeyValuePair<string, Ability>(config.abilityName, config);
                array[i] = current;
            }
        }

        public int IndexOf(Ability item)
        {
            return configurations.IndexOf(item);
        }

        public void Insert(int index, Ability item)
        {
            configurations.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            configurations.RemoveAt(index);
        }

        Ability IList<Ability>.this[int index]
        {
            get { return configurations[index]; }
            set { configurations[index] = value; }
        }

        public IEnumerator<Ability> GetEnumerator()
        {
            return configurations.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)configurations).GetEnumerator();
        }

        public void Add(Ability item)
        {
            configurations.Add(item);
        }

        public void Clear()
        {
            configurations.Clear();
        }

        public bool Contains(Ability item)
        {
            return configurations.Contains(item);
        }

        public void CopyTo(Ability[] array, int arrayIndex)
        {
            configurations.CopyTo(array, arrayIndex);
        }

        public bool Remove(Ability item)
        {
            return configurations.Remove(item);
        }

        public int Count
        {
            get { return configurations.Count; }
        }

        public bool IsReadOnly
        {
            get { return ((ICollection<Ability>)configurations).IsReadOnly; }
        }
    }
}

