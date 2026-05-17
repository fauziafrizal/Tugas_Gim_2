using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 100;
    private int currentHP;

    public Slider healthBar;

    void Start()
    {
        currentHP = maxHP;

        healthBar.maxValue = maxHP;
        healthBar.value = currentHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        healthBar.value = currentHP;

        Debug.Log("Player terkena damage: " + damage);
        Debug.Log("HP Sekarang: " + currentHP);

        if(currentHP <= 0)
        {
            Debug.Log("Player Mati!");
        }
    }
}