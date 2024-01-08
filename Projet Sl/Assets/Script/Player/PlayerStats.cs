using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    private PlayerLocomotion locomotion;

    public Image defeatScreen;
    
    public Slider healthSlider;
    public Slider staminaSlider;

    [Header("Stats")]
    public float maxHealth = 100;
    public float health;
    public float maxStamina = 100;
    public float stamina;

    public bool isDead;
    public bool noStamina;

    void Start()
    {
        StartCoroutine(RegenStamina());
        locomotion = GetComponent<PlayerLocomotion>();

        health = maxHealth;
        stamina = maxStamina;
    }

    void Update()
    {
        SliderRefresher();
        if (health <= 0)
        {
            isDead = true;
        }

        if (stamina <= 0)
        {
            noStamina = true;
        }
        else if (stamina >= 0)
        {
            noStamina = false;
        }
    }

    void takeDamage(float damage)
    {
        health -= damage;
    }

    void Dead()
    {
        if (isDead)
        {
            defeatScreen.gameObject.SetActive(true);
        }
    }

    void SliderRefresher()
    {
        healthSlider.value = health; 
        staminaSlider.value = stamina;
    }

    public IEnumerator DrainStamina()
    {
        while (locomotion.isSprinting)
        {
            stamina -= 6; 
            yield return new WaitForSeconds(0.5f);
        }
    }
    public IEnumerator RegenStamina()
    {
        while (stamina < maxStamina)
        {
            stamina += 2;
            yield return new WaitForSeconds(1f); 
        }
    }
}
