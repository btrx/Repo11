using UnityEngine;
using TMPro;
using UnityEngine.UI; // Important for TextMeshPro

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public TextMeshProUGUI healthText; // Drag your Text (TMP) object here in the Inspector
    public TextMeshProUGUI currentHealthText; // Optional: for displaying health in a bar format

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth < 0)
        {
            currentHealth = 0;
            gameObject.SetActive(false); // Disable the object when health is 0
            Debug.Log(gameObject.name + " has been defeated!");
            // Add logic for player death, game over, etc.
        }
        UpdateHealthText();
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateHealthText();
    }

    void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health : " + currentHealth;
        }
    }
}
