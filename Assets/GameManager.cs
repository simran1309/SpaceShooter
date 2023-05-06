using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public bool isGameOver=false;
    public GameObject Player;
    public GameObject Score;
    public GameObject Lives;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        Player.SetActive(false);
        Score.SetActive(false);
        Lives.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
       if (Input.GetKeyDown(KeyCode.R) && isGameOver == true) 
       {
          SceneManager.LoadScene("Game");
       }
        
    }
    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0;
        


    } public void NewGame()
    {
        isGameOver = false;
        Time.timeScale = 1;
        Player.SetActive(true);
        Score.SetActive(true);
        Lives.SetActive(true);


    }
    public void Quit()
    {
        Application.Quit();


 }

}
