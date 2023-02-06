using System;
using Core.Economy;
using TowerDefense.Level;
using TowerDefense.Abilities;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TowerDefense.UI.HUD
{
	/// <summary>
	/// A button controller for calling abilities
	/// </summary>
	[RequireComponent(typeof(RectTransform))]
	public class AbilityCallButton : MonoBehaviour, IDragHandler
	{
		/// <summary>
		/// The text attached to the button
		/// </summary>
		public Text buttonText;

		public Image abilityIcon;

		public Button buyButton;

		public Image energyIcon;

		public Color energyDefaultColor;
		
		public Color energyInvalidColor;

		public Color defaultBuyButtonColor;

		/// <summary>
		/// Fires when the button is tapped
		/// </summary>
		public event Action<Ability> buttonTapped;

		/// <summary>
		/// Fires when the pointer is outside of the button bounds
		/// and still down
		/// </summary>
		public event Action<Ability> draggedOff;

        /// <summary>
        /// The ability controller that defines the button
        /// </summary>
        Ability m_Ability;

		/// <summary>
		/// Cached reference to level currency
		/// </summary>
		Currency m_Currency;

		/// <summary>
		/// The attached rect transform
		/// </summary>
		RectTransform m_RectTransform;

		/// <summary>
		/// Checks if the pointer is out of bounds
		/// and then fires the draggedOff event
		/// </summary>
		public virtual void OnDrag(PointerEventData eventData)
		{
			if (!RectTransformUtility.RectangleContainsScreenPoint(m_RectTransform, eventData.position))
			{
				if (draggedOff != null)
				{
					draggedOff(m_Ability);
				}
			}
		}

		/// <summary>
		/// Define the button information for the ability
		/// </summary>
		/// <param name="abilityData">
		/// The ability to initialize the button with
		/// </param>
		public void InitializeButton(Ability abilityData)
		{
			m_Ability = abilityData;

			if (abilityData != null)
			{
				buttonText.text = abilityData.cost.ToString();
				abilityIcon.sprite = abilityData.icon;
				m_Ability = Instantiate(m_Ability,transform);
				m_Ability.cooldownChanged += UpdateButton;
			}
			else
			{
				Debug.LogWarning("[Ability Spawn Button] No data for ability");
			}

			if (LevelManager.instanceExists)
			{
				m_Currency = LevelManager.instance.currency;
				m_Currency.currencyChanged += UpdateButton;
			}
			else
			{
				Debug.LogWarning("[Ability Spawn Button] No level manager to get currency object");
			}
			UpdateButton();
		}

		/// <summary>
		/// Cache the rect transform
		/// </summary>
		protected virtual void Awake()
		{
			m_RectTransform = (RectTransform) transform;
		}

		/// <summary>
		/// Unsubscribe from events
		/// </summary>
		protected virtual void OnDestroy()
		{
			if (m_Currency != null)
			{
				m_Currency.currencyChanged -= UpdateButton;
                m_Ability.cooldownChanged -= UpdateButton;
            }
		}

		/// <summary>
		/// The click for when the button is tapped
		/// </summary>
		public void OnClick()
		{
			if (buttonTapped != null)
			{
				buttonTapped(m_Ability);
			}
		}

		/// <summary>
		/// Update the button's button state based on cost
		/// </summary>
		void UpdateButton()
		{
			if (m_Currency == null)
			{
				return;
			}

			// Enable button
			if (m_Currency.CanAfford(m_Ability.cost) && m_Ability.currentCooldown == 0)
			{
				energyIcon.color = energyDefaultColor;
                buyButton.image.color = defaultBuyButtonColor;
            }
			else if (!m_Currency.CanAfford(m_Ability.cost) || m_Ability.currentCooldown != 0)
			{
				energyIcon.color = energyInvalidColor;
				buyButton.image.color = energyInvalidColor;
            }
		}
	}
}
