    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI; // Required when Using UI elements.
    public class Damage : MonoBehaviour
    {
    public Image healthBar;
    public float scaleFactor;
    public float currentHealth;
    private Color red;
    private void Start()
    {
        healthBar.type = Image.Type.Filled;
        red = new Color(249, 0, 0);
    }
    public void ChangeHealthBar()
    {
        scaleFactor = hurtEnemy.damageToGive / currentHealth;
        healthBar.fillAmount = scaleFactor;
        healthBar.color = red;
    }
    }
