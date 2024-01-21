using UnityEngine;

namespace TrueTacticalStudio
{
    // HealthManager class implements the IHealthManager interface
    public class HealthManager : MonoBehaviour, IHealthManager
    {
        // Protected fields to store health-related information
        [SerializeField] protected int maxHealth;
        [SerializeField] protected int currentHealth;
        [SerializeField] protected bool isHealthEmpty;

        // Public properties for accessing health-related information
        public int MaxHealth { get => maxHealth; set => maxHealth = value; }
        public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
        public bool IsHealthEmpty { get => isHealthEmpty; set => isHealthEmpty = value; }

        private void Start()
        {
            // Initialize variables to default values
            InitVariables();
        }

        // Method to check and adjust health values within valid bounds
        public virtual void CheckHealth()
        {
            // Ensure current health is not below zero
            if (currentHealth <= 0)
            {
                currentHealth = 0;
            }

            // Ensure current health is not above the maximum
            if (currentHealth >= maxHealth)
            {
                currentHealth = maxHealth;
            }
        }

        // Method to mark the health as empty (used for destruction logic)
        public virtual void Destroy()
        {
            // Set the health-empty flag to true
            isHealthEmpty = true;
        }

        // Method to set current health to a specific value and check for validity
        private void SetCurrentHealth(int newCurrentHealth)
        {
            // Set the current health to the specified value
            currentHealth = newCurrentHealth;

            // Check and adjust health values within valid bounds
            CheckHealth();
        }

        // Method to deduct damage from the current health
        public void TakeDamage(int damage)
        {
            // Calculate the new health after deducting damage
            int currentHealthAfterDamage = currentHealth - damage;

            // Set the current health to the calculated value and check for validity
            SetCurrentHealth(currentHealthAfterDamage);
        }

        // Method to increase the current health by a specified amount
        public void Heal(int heal)
        {
            // Calculate the new health after healing
            int currentHealthAfterHeal = currentHealth + heal;

            // Set the current health to the calculated value and check for validity
            SetCurrentHealth(currentHealthAfterHeal);
        }

        // Method to initialize health-related variables to default values
        public void InitVariables()
        {
            // Set maximum health to a default value
            maxHealth = 100;

            // Set current health to the maximum and reset the health-empty flag
            SetCurrentHealth(maxHealth);
            isHealthEmpty = false;
        }
    }
}