using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private Slider _slider;
    void Start()
    {
        Cursor.visible = true;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GBCamera_RenderTexture");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeVolume()
    {
        AudioListener.volume = _slider.value;
    }
}
