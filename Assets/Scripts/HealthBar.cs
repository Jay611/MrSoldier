using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider healthBarSlider; 
    public Gradient gradient;
    public Image fill;

    [Header("Health Properties")]
    [Range(0, 100)]
    public int currentHealth = 100;
    [Range(1, 100)]
    public int maximumHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        healthBarSlider = GetComponent<Slider>();
        currentHealth = maximumHealth;
    }
    public void TakeDamage(int damage)
    {
        healthBarSlider.value -= damage;
        currentHealth -= damage;
        if (healthBarSlider.value <= 0)
        {
            GetComponent<Enemy>().Die();
            healthBarSlider.value = 0;
            currentHealth = 0;
        }
    }
    public void SetHealth(int health)
    {
        //Sets the current health of the player to the slider.
        healthBarSlider.value = health;
        fill.color = gradient.Evaluate(healthBarSlider.normalizedValue);
    }
}
