using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Animator anim;
    public player Player;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -3.18)
        {
            transform.position = new Vector3(Random.Range(-5f, 5f), 7, 0);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")

        { player Player= GameObject.Find("player").GetComponent<player>();
            if (Player != null)
            {
                Player.AddScore(10);
            }
           
            Destroy(other.gameObject);
            anim.SetTrigger("explode");
            audioSource.Play();
            Destroy(this.gameObject,1.0f);
        }
        if (other.tag == "Player")

        {
            player Player = other.transform.GetComponent<player>();
            if (Player != null)
            {
                Player.Damage();
            }
            anim.SetTrigger("explode");
            audioSource.Play();
            Destroy(this.gameObject, 1.0f);

        }
    }
}
