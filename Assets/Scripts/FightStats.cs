using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FightStat : MonoBehaviour
{
    public string unitName;
    public int damage;
    public int maxHP;
    public int currentHP;

    public ParticleSystem particle;
    public GameObject DeathHUD;
    public GameObject FightMenuUI;

    public Slider hpSlider;
    public bool invincible;

    public void Start()
    {
        DeathHUD.SetActive(false);
    }
    IEnumerator MainMenu()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Main Menu");
    }
    public void SetHUG()
    {
        hpSlider.maxValue = maxHP;
        hpSlider.value = currentHP;

    }
    public void TakeDamage(int Damage)
    {
        currentHP -= damage;

        if (currentHP < 0)
        {
            currentHP = 0;
        }
        hpSlider.value = currentHP;

        //Blood Death Screen
        if (currentHP < 1)
        {
            particle.Play();
            DeathHUD.SetActive(true);
            FightMenuUI.SetActive(false);
            StartCoroutine(MainMenu());
            Debug.Log("Died");

        }
    }
}
