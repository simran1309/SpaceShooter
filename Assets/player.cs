using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed;
    public GameObject laser;
    [SerializeField]
    public GameObject tripleShot;
    public float firerate;
    public float canfire;
    [SerializeField]
    private int Lives = 3;
    [SerializeField]
    public SpawnManager spawn;
    public bool isTripleShotActive = false;
    public bool speedBoostisActive = false;
    public bool  ShieldisActive= false;
    [SerializeField]
    private GameObject ShieldVisualizer;
    public int speedMultiplier = 4;
    int score;
    public uiManager UI;
    public GameObject gameOver;
    public GameObject Restart;
    [SerializeField]
    private AudioClip laserClip;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private GameManager game;

    // Start is called before the first frame update
    void Start()
    {
        //spawn = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        audioSource = GetComponent<AudioSource>();
        ShieldVisualizer.SetActive(false);
        gameOver.gameObject.SetActive(false);
        Restart.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canfire)
        {
            SpawnLaser();
        }
       
    }

    void CalculateMovement()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(HorizontalInput, VerticalInput, 0);
       
        //if (transform.position.y >= 0)
         transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -2.14f, 0), 0);
        if (speedBoostisActive==false)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(direction * speed * speedMultiplier * Time.deltaTime);
        }

        if (transform.position.x >= 7.0f)
        {
            transform.position = new Vector3(-7.0f, transform.position.y, 0);
        }
        else if (transform.position.x <= -7.0)
        {
            transform.position = new Vector3(7f, transform.position.y, 0);
        }
    }
    void SpawnLaser()
    { 
        
            canfire = Time.time + firerate;
        if (isTripleShotActive)
        {
            Instantiate(tripleShot, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
        }
        else
        {
            Instantiate(laser, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
        }

        audioSource.Play();
    }
    public void Damage()
    {if (ShieldisActive == true)
        {
            ShieldisActive = false;
            return;
        }
        Lives--;
        UI.UpdateLives(Lives);
        if (Lives < 1)
        {
            spawn.OnPlayerDeath();
            gameOver.gameObject.SetActive(true);
            Restart.SetActive(true);
            game.GameOver();
           
            Destroy(this.gameObject);
        }
        
    }
    public void TripleShotPowerupActive()
    {
        isTripleShotActive = true;
        StartCoroutine(TripleShotCountDown());
    }
    IEnumerator TripleShotCountDown()
    {
        yield return new WaitForSeconds(5.0f);
        isTripleShotActive = false;
    }
    public void AddScore(int points)
    {
        score += points;
        UI.UpdateScore(score);
    }
    public void SpeedBoostActive() 
    {
        speedBoostisActive = true;
        StartCoroutine(SpeedBoostPowerUp());
    }
    IEnumerator SpeedBoostPowerUp()
    {
        yield return new WaitForSeconds(5.0f);
        speedBoostisActive = false;
    }
    public void ShieldBoostActive()
    {
        ShieldisActive = true;
        ShieldVisualizer.SetActive(true);
        StartCoroutine(ShieldBoostPowerUp());
    }
    IEnumerator ShieldBoostPowerUp()
    {
        yield return new WaitForSeconds(5.0f);
        ShieldisActive = false;
        ShieldVisualizer.SetActive(false);
    }
}
