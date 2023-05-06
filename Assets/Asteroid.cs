using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float rotateSpeed=3.0f;
    private Animator anim;
    [SerializeField]
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -3.18)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            anim.SetTrigger("explode");
            //Instantiate(explosionPrefab, transform.position, Quaternion.identity);
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
            //Destroy(other.gameObject, 1.0f);
            Destroy(this.gameObject, 1.0f);

        }
    }
}
