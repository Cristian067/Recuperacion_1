using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public int points;

    public bool isGameOver = false;

    private int highscore;

    private Rigidbody rigidbody;

    [SerializeField] private TMP_Text pointsText;
    [SerializeField] private TMP_Text highText;

    [SerializeField] private TMP_Text resetText;

    [SerializeField] private ParticleSystem get;
    [SerializeField] private ParticleSystem hurt;

    [SerializeField] private AudioSource camAudio;
    private AudioSource audio;

    [SerializeField] private AudioClip get_sfx;
    [SerializeField] private AudioClip hurt_sfx;



    private void Awake()
    {
        audio = GetComponent<AudioSource>();

        highscore = PlayerPrefs.GetInt("highscore");

        
    }

    // Start is called before the first frame update
    void Start()
    {
        
        rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {

        pointsText.text = $"Score: {points}";
        highText.text = $"Highscore: {highscore}";

        transform.Rotate(new Vector3(0, 1, 0) * 50 * Time.deltaTime);
        
        if(transform.position.y > 14)
        {
            transform.position = new Vector3(transform.position.x, 14, transform.position.z);
            rigidbody.AddForce(new Vector3(0,1,0) * -100);
        }

        if(transform.position.y <= 0)
        {
            isGameOver = true;
        }

        if (!isGameOver)
        {
            if (Input.GetKeyDown("space"))
            {
                //Debug.Log("saltando...");
                rigidbody.AddForce(new Vector3(0, 1, 0) * 500);

            }

        }

        
        
        if (isGameOver)
        {
            camAudio.volume = 0.02f;
            resetText.text = "Press 'R' to restart";

            if (Input.GetKeyDown("r"))
            {
                SceneManager.LoadScene("Challenge 3");
            }

            if (points > highscore)
            {
                PlayerPrefs.SetInt("highscore", points);
            }

            
        }


    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            points++;
            Debug.Log($"Score: {points}");
            get.Play();
            audio.PlayOneShot(get_sfx);
            Destroy(collision.gameObject);


        }
        if (collision.gameObject.tag == "Bomb")
        {
            isGameOver = true;
            hurt.Play();
            audio.PlayOneShot(hurt_sfx);
            
        }
    }



}
