using UnityEngine;

namespace TrueTacticalStudio
{
    // TestHealth class for testing health-related functions
    public class TestHealth : MonoBehaviour
    {
        private void Update()
        {
            // Apply healing function when key O is pressed
            ApplyHealFunction();

            // Apply damage function when key P is pressed
            ApplyDamageFunction();
        }

        private void ApplyHealFunction()
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                foreach (GameObject gameObject in FindObjectsOfType<GameObject>())
                {
                    // Try to get the HealthManager component and apply healing
                    gameObject.GetComponent<HealthManager>()?.Heal(10);
                }
            }
        }

        private void ApplyDamageFunction()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                foreach (GameObject gameObject in FindObjectsOfType<GameObject>())
                {
                    // Try to get the HealthManager component and apply damage
                    gameObject.GetComponent<HealthManager>()?.TakeDamage(10);
                }
            }
        }
    }
}