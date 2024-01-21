using UnityEngine;

namespace TrueTacticalStudio
{
    public class ObjectHealth : HealthManager, IHealthManager
    {
        // Fields for material types
        [SerializeField] private Material damagedMaterial;
        [SerializeField] private Material healMaterial;
        [SerializeField] private Material defaultMaterial;

        // Reference to the HealthUI component
        [SerializeField] private HealthUI healthUI;

        private void Start()
        {
            // Initialize variables to default values
            InitVariables();

            // Find and set the HealthUI component
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

        public override void CheckHealth()
        {
            base.CheckHealth();

            // Apply material based on current health range
            if (currentHealth > 1 && currentHealth < 99)
            {
                ApplyDefaultMaterial();
            }

            // Destroy the object if health is zero
            if (currentHealth <= 0)
            {
                Destroy();
            }

            // Apply healing material if health reaches maximum
            if (currentHealth >= maxHealth)
            {
                ApplyHealMaterial();
            }
        }

        public override void Destroy()
        {
            base.Destroy();

            // Additional logic for object destruction, e.g., particle effects, sound, etc.
            
            // Change the material to the damagedMaterial
            GetComponent<MeshRenderer>().material = damagedMaterial;
        }

        private void ApplyHealMaterial()
        {
            if (currentHealth >= maxHealth)
            {
                GetComponent<MeshRenderer>().material = healMaterial;
            }
        }

        private void ApplyDefaultMaterial()
        {
            GetComponent<MeshRenderer>().material = defaultMaterial;
        }
    }
}