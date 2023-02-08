using TowerDefense.Level;
using TowerDefense.Abilities;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.UI.HUD
{
    /// <summary>
    /// Controls the UI objects that draw the ability data
    /// </summary>
    [RequireComponent(typeof(Canvas))]
    public class AbilityUI : MonoBehaviour
    {
        /// <summary>
        /// The text object for the name
        /// </summary>
        public Text abilityName;

        /// <summary>
        /// The text object for the description
        /// </summary>
        public Text description;

        public Text upgradeDescription;

        /// <summary>
        /// Component to display the relevant information of the tower
        /// </summary>
        public AbilityInfoDisplay abilityInfoDisplay;

        public RectTransform panelRectTransform;

        public GameObject[] confirmationButtons;

        /// <summary>
        /// The main game camera
        /// </summary>
        protected Camera m_GameCamera;

        /// <summary>
        /// The current ability to draw
        /// </summary>
        protected Ability m_Ability;

        /// <summary>
        /// The canvas attached to the gameObject
        /// </summary>
        protected Canvas m_Canvas;

        /// <summary>
        /// Draws the ability data on to the canvas
        /// </summary>
        /// <param name="abilityToShow">
        /// The ability to gain info from
        /// </param>
        public virtual void Show(Ability abilityToShow)
        {
            if (abilityToShow == null)
            {
                return;
            }
            m_Ability = abilityToShow;
            m_Canvas.enabled = true;
            abilityInfoDisplay.Show(abilityToShow);
            foreach (var button in confirmationButtons)
            {
                button.SetActive(false);
            }
        }

        /// <summary>
        /// Hides the tower info UI and the radius visualizer
        /// </summary>
        public virtual void Hide()
        {
            m_Ability = null;
            if (GameUI.instanceExists)
            {
                GameUI.instance.HideRadiusVisualizer();
            }
            m_Canvas.enabled = false;
        }

        /// <summary>
        /// Upgrades the tower through <see cref="GameUI"/>
        /// </summary>
        public void UpgradeButtonClick()
        {
            GameUI.instance.UpgradeSelectedTower();
        }

        /// <summary>
        /// Sells the tower through <see cref="GameUI"/>
        /// </summary>
        public void SellButtonClick()
        {
            GameUI.instance.SellSelectedTower();
        }

        public void MoveTowerButtonClick()
        {
            GameUI.instance.MoveSelectedTower();
        }

        /// <summary>
        /// Get the text attached to the buttons
        /// </summary>
        protected virtual void Awake()
        {
            m_Canvas = GetComponent<Canvas>();
        }

        /// <summary>
        /// Fires when tower is selected/deselected
        /// </summary>
        /// <param name="newTower"></param>
        protected virtual void OnUISelectionChanged(Ability newAbility)
        {
            if (newAbility != null)
            {
                Show(newAbility);
            }
            else
            {
                Hide();
            }
        }

        /// <summary>
        /// Subscribe to mouse button action
        /// </summary>
        protected virtual void Start()
        {
            m_GameCamera = Camera.main;
            m_Canvas.enabled = false;
            if (GameUI.instanceExists)
            {
                GameUI.instance.stateChanged += OnGameUIStateChanged;
            }
        }

        /// <summary>
        /// Fired when the <see cref="GameUI"/> state changes
        /// If the new state is <see cref="GameUI.State.GameOver"/> we need to hide the <see cref="TowerUI"/>
        /// </summary>
        /// <param name="oldState">The previous state</param>
        /// <param name="newState">The state to transition to</param>
        protected void OnGameUIStateChanged(GameUI.State oldState, GameUI.State newState)
        {
            if (newState == GameUI.State.GameOver)
            {
                Hide();
            }
        }

        /// <summary>
        /// Unsubscribe from GameUI selectionChanged and stateChanged
        /// </summary>
        void OnDestroy()
        {
            if (GameUI.instanceExists)
            {
                GameUI.instance.stateChanged -= OnGameUIStateChanged;
            }
        }
    }
}