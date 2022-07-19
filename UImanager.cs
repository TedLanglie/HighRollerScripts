using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UImanager : MonoBehaviour
{
    public static UImanager instance; // create instance of canvas

    [Header ("Panel Properties")]
    public TextMeshProUGUI currentSideText;
    public TextMeshProUGUI upgradeText;
    [SerializeField] private Slider _slider;

    [Header ("Values")]
    private int currentSide = 2;
    private float timeForNextRoll = 5;
    private float timer = 1;
    private bool isAlive = true;
    private float timeBetweenRolls = 5;
    [Header ("Effects")]
    [SerializeField] private GameObject _upgradeEffect;
    [Header ("Audio Components")]
    [SerializeField] private AudioSource _sideChangeSoundEffect;
    [SerializeField] private AudioSource _deathSoundEffect;
    [SerializeField] private AudioSource _upgradeSoundEffect;
    [SerializeField] private AudioSource _downgradeSoundEffect;
    [SerializeField] private AudioSource _winSoundEffect;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentSideText.text = currentSide.ToString();
        upgradeText.text = "";
    }

    void Update()
    {
        if(isAlive == true)
        {
            timer = timer + Time.deltaTime;
            timeForNextRoll = timeForNextRoll - Time.deltaTime;
            if(_slider.value == 0f)
            {
                timeForNextRoll = timeBetweenRolls;
                RollUpgrade();
            }
            SetValue(timeForNextRoll);
        }
    }

    public void ChangeSide(int side)
    {
        if(currentSide != side)
        {
            _sideChangeSoundEffect.Play();
            currentSide = side;
        }
        if(isAlive == true) currentSideText.text = currentSide.ToString();
    }

    public void SetValue(float value)
    {
        _slider.value = value;
    }

    private void RollUpgrade()
    {
        switch(currentSide)
        {
            case 1:
            GameObject.FindWithTag("Player").GetComponent<TedLanglie_PlayerController>().changeMoveSpeed(5);
            StartCoroutine(upgradeResponse("1 : Increased movement speed!"));
            _upgradeSoundEffect.Play();
            Debug.Log("changed move speed");
            break;
            case 2:
            GameObject.FindWithTag("Player").GetComponent<TedLanglie_PlayerController>().changeJumpForce(-1);
            StartCoroutine(upgradeResponse("2 : Decreased jump height!"));
            Debug.Log("changed jump force");
            _downgradeSoundEffect.Play();
            break;
            case 3:
            GameObject.FindWithTag("Enemy").GetComponent<Enemy>().changeEnemySpeed(-5);
            StartCoroutine(upgradeResponse("3 : Decreased enemy movement speed!"));
            _upgradeSoundEffect.Play();
            break;
            case 4:
            GameObject.FindWithTag("Player").GetComponent<TedLanglie_PlayerController>().changeMoveSpeed(-3);
            StartCoroutine(upgradeResponse("4 : Decreased movement speed!"));
            _downgradeSoundEffect.Play();
            Debug.Log("changed move speed");
            break;
            case 5:
            GameObject.FindWithTag("Player").GetComponent<TedLanglie_PlayerController>().changeJumpForce(4);
            StartCoroutine(upgradeResponse("5 : Increased jump height!"));
            _upgradeSoundEffect.Play();
            Debug.Log("changed jump force");
            break;
            case 6:
            GameObject.FindWithTag("Enemy").GetComponent<Enemy>().changeEnemySpeed(5);
            StartCoroutine(upgradeResponse("6 : Increased enemy movement speed!"));
            _downgradeSoundEffect.Play();
            break;
        }
        Instantiate(_upgradeEffect, GameObject.FindWithTag("Player").transform.position, Quaternion.identity);
    }

    IEnumerator upgradeResponse(string text)
    {
        upgradeText.text = text;
        yield return new WaitForSeconds(2);
        if(isAlive) upgradeText.text = "";
    }

    public void DeathEvent()
    {
        _deathSoundEffect.Play();
        GameObject.FindWithTag("Cam").GetComponent<Camera>().toggleLockOn(); // lock cam
        isAlive = false;
        currentSideText.text = "";
        upgradeText.color = Color.black;
        upgradeText.text = "Consumed by the void...";
        StartCoroutine(deathResponse());
    }

    public void WinEvent()
    {
        _winSoundEffect.Play();
        GameObject.FindWithTag("Cam").GetComponent<Camera>().toggleLockOn(); // lock cam
        GameObject.FindWithTag("boat").GetComponent<SailAway>().SetSail();
        isAlive = false;
        currentSideText.text = "";
        upgradeText.text = "You've made it. " + Mathf.Round(timer);
        StartCoroutine(winResponse());
    }

    IEnumerator deathResponse()
    {
        yield return new WaitForSeconds(2);
        // back to menu
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator winResponse()
    {
        yield return new WaitForSeconds(4);
        // back to menu
        SceneManager.LoadScene("MainMenu");
    }
}
