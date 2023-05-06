using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    public Text ScoreText;
    public Sprite[] livesSprites;
    public Image LivesImage;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "Score:" + 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScore(int score)
    {
        ScoreText.text = "Score:" + score.ToString();
    }
    public void UpdateLives(int current_lives)
    {
        LivesImage.sprite = livesSprites[current_lives];
    }
}
