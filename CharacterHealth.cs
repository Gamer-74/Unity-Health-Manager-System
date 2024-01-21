using UnityEngine;

namespace TrueTacticalStudio
{
    [RequireComponent(typeof(Animator))]
    public class CharacterHealth : HealthManager, IHealthManager
    {
        // Fields for Animator and HealthUI components
        [SerializeField] private Animator animator;
        [SerializeField] private HealthUI healthUI;

        // Properties to access and modify health-related information
        public new int MaxHealth { get => maxHealth; set => maxHealth = value; }
        public new int CurrentHealth { get => currentHealth; set => currentHealth = value; }
        public new bool IsHealthEmpty { get => isHealthEmpty; set => isHealthEmpty = value; }

        private void Start()
        {
            // Initialize variables to default values
            InitVariables();

            // Find and set the Animator and HealthUI components
            animator = GetComponent<Animator>();
            healthUI = GetComponent<HealthUI>();
            SetHealthUI(healthUI);
        }

        private void SetHealthUI(HealthUI _healthUI)
        {
            healthUI = _healthUI;
        }

        private void Update()
        {
            // Check and update health values
            CheckHealth();

            // Update the HealthUI if available
            if (healthUI != null)
            {
                healthUI.SetValues(currentHealth, maxHealth);
            }
        }

        // CheckHealth method with additional logic for character destruction
        public override void CheckHealth()
        {
            base.CheckHealth();

            // Set health to zero and destroy the character if health is zero
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Destroy();
            }
        }

        // Destroy method with additional logic for character destruction
        public override void Destroy()
        {
            base.Destroy();

            // Additional logic for character destruction, e.g., character death animation
            GetComponent<Animator>().SetBool("IsDead", true);
            // You can add more code here to do other things when the character health reaches 0.
        }
    }
}