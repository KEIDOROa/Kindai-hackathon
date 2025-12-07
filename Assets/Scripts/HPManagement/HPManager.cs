using UnityEngine;

/// <summary>
/// Manages HP for a character or entity.
/// </summary>
public class HPManager : MonoBehaviour
{
    [SerializeField]
    private int maxHP = 15; // Default max HP

    private int currentHP;
    private bool isDead = false;

    public int MaxHP => maxHP;
    public int CurrentHP => currentHP;
    public bool IsDead => isDead;

    private void Awake()
    {
        // Initialize current HP to max at start
        currentHP = maxHP;
    }

    /// <summary>
    /// Apply damage to the entity.
    /// </summary>
    /// <param name="damage">Amount of damage (positive integer).</param>
    public void ApplyDamage(int damage)
    {
        if (isDead) return;
        currentHP -= Mathf.Max(damage, 0);
        if (currentHP <= 0)
        {
            currentHP = 0;
            isDead = true;
            OnDeath();
        }
        else
        {
            OnHPChanged();
        }
    }

    /// <summary>
    /// Heal the entity.
    /// </summary>
    /// <param name="amount">Healing amount (positive integer).</param>
    public void Heal(int amount)
    {
        if (isDead) return;
        currentHP = Mathf.Min(currentHP + Mathf.Max(amount, 0), maxHP);
        OnHPChanged();
    }

    private void OnHPChanged()
    {
        // Placeholder for UI update or event notification.
        Debug.Log($"HP Updated: {currentHP}/{maxHP}");
    }

    private void OnDeath()
    {
        // Placeholder for death handling logic.
        Debug.Log("Entity died.");
    }
}
