using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private player Player;
    public int PowerUpId;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

           player Player = GameObject.Find("player").GetComponent<player>();
            if (Player != null)
            {
                switch (PowerUpId)
                {
                    case 0:
                        Player.TripleShotPowerupActive();
                        break;
                    case 1:
                        Player.SpeedBoostActive();
                        break;
                    case 2:
                        Player.ShieldBoostActive();
                        break;
                }
            }
        }
    }

}
