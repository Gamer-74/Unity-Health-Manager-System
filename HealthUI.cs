using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TrueTacticalStudio
{
    // HealthUI class for displaying health-related UI elements
    public class HealthUI : MonoBehaviour
    {
        // Private fields for base and maximum health values
        private int baseValue;
        private int maxValue;

        // Serialized fields for UI elements
        [SerializeField] private Image fill;  // Image for the health bar
        [SerializeField] private TextMeshProUGUI amount;  // Text UI for the amount of the current health

        // Method to set the base and maximum health values and update UI
        public void SetValues(int _baseValue, int _maxValue)
        {
            baseValue = _baseValue;
            maxValue = _maxValue;

            // Update the UI elements
            amount.text = baseValue.ToString();
            CalculateFillAmount();
        }

        // Method to calculate and update the fill amount of the health bar
        public void CalculateFillAmount()
        {
            float fillAmount = (float)baseValue / maxValue;
            fill.fillAmount = fillAmount;
        }
    }
}