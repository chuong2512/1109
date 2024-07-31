using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    int CurrentLevel, targets;
    bool GameEnd;
    public Text CurrentLevelText;
    public GameObject GameWinUI;
    public GameObject ShootBtn;
    public GameObject[] Level;
    // Start is called before the first frame update


    public void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        ShootBtn.SetActive(false);
        CurrentLevel = PlayerPrefs.GetInt("Level", 0);
        CurrentLevelText.text = "MISSION: " + (CurrentLevel + 1);
        Instantiate(Level[CurrentLevel]);
        GameEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        targets = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Debug.Log(targets + "    Enemy");

        if (targets == 0 && !GameEnd)
        {
            GameEnd = true;
            StartCoroutine(GameWin());
        }
    }


    IEnumerator GameWin()
    {
        yield return new WaitForSeconds(1f);
        Adcontrol.ShowAds();
        GameWinUI.SetActive(true);
        PlayerPrefs.SetInt("Level", (CurrentLevel + 1));
    }


    public void Reload()
    {
        SceneManager.LoadScene("Game");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Shoot()
    {
        GameObject.FindGameObjectWithTag("Shooter").GetComponent<Player>().Spawn();
    }
}