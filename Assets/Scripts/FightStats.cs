using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FightStat : MonoBehaviour
{
    public string unitName;
    public int damage;
    public int maxHP;
    public int currentHP;

    public GameObject DeathHUD;
    public GameObject FightMenuUI;
    public GameObject Monster;

    public Slider hpSlider;
    public bool invincible;

    public void Start()
    {
        DeathHUD.SetActive(false);
        FightMenuUI.SetActive(true);

        SetHUD();
    }

    public void Update()
    {

    }
    IEnumerator MainMenu()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("TitleScreen");
    }
    public void SetHUD()
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

        //Death Screen
        if (currentHP < 1)
        {
            DeathHUD.SetActive(true);
            FightMenuUI.SetActive(false);
            StartCoroutine(MainMenu());
            Debug.Log("Died");

        }
        if (GetComponent<Karkios_Behavior>() != null && currentHP < 50)
        {
            invincible = true;
            Monster.GetComponent<Animator>().CrossFadeInFixedTime("Base Layer.Karkios_Bury", 1f);
        }
    }
}
