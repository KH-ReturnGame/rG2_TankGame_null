using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int stagePoint;
    public int stageIndex;
    
    public OnKeyPress_MoveSprite player;

    public GameObject[] stages;

    public Image HP_Fill_Image;
    public Image[] UIStage;
    public GameObject RestartButton;
    public GameObject Game_Clear;

    void Start()
    {
        stageIndex = 0;
    }

    public void NextStage()
    {
        if (stageIndex < stages.Length - 1)
        {
            stages[stageIndex].SetActive(false);
            UIStage[stageIndex].fillAmount = 0;
            stageIndex++;
            stages[stageIndex].SetActive(true);
            UIStage[stageIndex].fillAmount = 1;
            PlayerReposition();
            player.curHealth = 100;
        }
        else
        {
            GameClear();
        }
    }

    public void GameOver()
    {
            // Player die
            player.Die();
            
            // Result UI
            Debug.Log("Player is destroyed");
            
            // Retry button UI
            RestartButton.SetActive(true);
    }

    void PlayerReposition()
    {
        player.transform.position = new Vector3(-5.5f, -2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHPBar();

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            GameClear();
        }
    }

    void UpdateHPBar()
    {
        float fillAmount = player.curHealth / player.maxHealth;
        HP_Fill_Image.fillAmount = fillAmount;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    void GameClear()
    {
        // Game clear
        // Player control lock
        Time.timeScale = 0;
        // Result UI
        Debug.Log("Game Clear!");
        // Restart button UI
        Game_Clear.SetActive(true);
    }
}
