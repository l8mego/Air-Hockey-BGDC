using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private AudioSource enterSound;
    [SerializeField] private AudioSource quitSound;
    public void PlayButton()
    {
        StartCoroutine(PlayGame());
    }

    public void QuitButton()
    {
        StartCoroutine(QuitGame());
    }

    IEnumerator PlayGame()
    {
        enterSound.Play();
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator QuitGame()
    {
        quitSound.Play();
       
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Success");
        Application.Quit();
    }

}
