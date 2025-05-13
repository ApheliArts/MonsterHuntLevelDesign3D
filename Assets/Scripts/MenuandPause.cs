using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MenuandPause : MonoBehaviour
{
    public AudioSource ButtonNoise;
    public AudioClip ButtonSound;
    public GameObject ControlUI;
    public GameObject ButtonUI;
    public void LoadLevel()
    {
        StartCoroutine(LevelLoad("LevelOne"));
    }
    public IEnumerator LevelLoad(string LevelOne)
    {
        yield return new WaitForSeconds(.66f);
        SceneManager.LoadScene(1);
        Debug.Log("LevelLoaded");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    public void PlaySound()
    {
        ButtonNoise.clip = ButtonSound;
        ButtonNoise.Play();
    }
    public void OpenControls()
    {
        ControlUI.SetActive(true);
        ButtonUI.SetActive(false);
    }
    public void CloseControls()
    {
        ControlUI.SetActive(false);
        ButtonUI.SetActive(true);
    }
    public void Start()
    {
        ControlUI.SetActive(false);
        ButtonUI.SetActive(true);

        pausePanel.SetActive(false);
    }

    //Logan Code

    public GameObject pausePanel;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause(true);
            pausePanel.SetActive(true);

        }
    }
    public void LoadLevel(string TitleScreen) 
    {
        SceneManager.LoadScene(TitleScreen);
    }

    private void Pause(bool pause)
    {

    }
}
