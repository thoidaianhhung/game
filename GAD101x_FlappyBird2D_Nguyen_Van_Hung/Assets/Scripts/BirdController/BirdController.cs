using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public static BirdController instance;
    public float bounceForce;
    private Rigidbody2D myBody;

    // animator to play the animation
    private Animator anim;

    [SerializeField]
    private AudioSource audioSource;

    // these are all audio sound clips of the bird
    [SerializeField]
    private AudioClip flyClip, pingClip, diedClip;

    private bool isAlive;
    private bool didFlap;

    private GameObject spawner;

    public float flag = 0;
    public int score = 0;

    // Start is called before the first frame update
    void Awake()
    {
        isAlive = true;
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        MakeInstance();
        spawner = GameObject.Find("Spawner Pipe");
    }

    void MakeInstance()
    {
        if (instance == null) {
            instance = this;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        BirdMoveMent();
    }

    // Bird jumped
    void BirdMoveMent() {
        if (isAlive) { 
            if (didFlap) {
                didFlap = false;
                myBody.velocity = new Vector2(myBody.velocity.x, bounceForce);
                audioSource.PlayOneShot(flyClip);
            }
        }
        
        if(myBody.velocity.y > 0)
        {
            float angel = 0;
            angel = Mathf.Lerp(0, 90, myBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        } else if (myBody.velocity.y == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        } else if (myBody.velocity.y < 0)
        {
            float angel = 0;
            angel = Mathf.Lerp(0, -90, -myBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
    }

    // Catch the event to jump
    public void FlapButton() {
        didFlap = true;
    }


    // Handling collisions PipeHolder
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PipeHolder")
        {
            score++;
            if (GamePlayController.instance != null)
            {
                GamePlayController.instance.SetScore(score);
                Debug.Log("OnTriggerEnter2D: " +score);
            }
            audioSource.PlayOneShot(pingClip);
        }
    }

    // // Handling collisions Pipe and Ground
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Pipe" || collision.gameObject.tag == "Ground")
        {
            flag = 1;
            if (isAlive)
            {
                isAlive = false;
                Destroy(spawner);
                audioSource.PlayOneShot(diedClip);
                anim.SetTrigger("Died");
            }
            if (GamePlayController.instance != null)
            {
                GamePlayController.instance.BirdDiedShowPanel(score);
            }
        }
    }
}
