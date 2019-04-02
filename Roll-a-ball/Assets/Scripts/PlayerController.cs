using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private int count;
    private int winningScore = 30;
    static int deathCount = 0;
    public GUIText countText;
    public GUIText winText;
    public GUIText deathText;
    public GameObject internalCube;
    public AudioSource PickupSound;
    public AudioSource BellSound;
    public AudioSource MagicSound;
    public AudioSource DeathSound;
    public AudioSource WinSound;
    public AudioSource Music;
    private bool hasWin = false;

    void Start()
    {
        Time.timeScale = 1.0f;
        count = 0;
        SetCountText();
        SetDeathText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            ResetGame();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count++;
            PickupSound.Play();
            SetCountText();
        }

        if (other.tag == "Hole")
        {
            winText.text = "You lose!";
            DeathSound.Play();
            deathCount++;
            StartCoroutine(ResetAfterSeconds(5));
            Time.timeScale = 0f;
        }

        if (other.tag == "MagicPickup")
        {
            internalCube.GetComponent<Renderer>().material.color = other.GetComponent<Renderer>().material.color;
            other.gameObject.SetActive(false);
            MagicSound.Play();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BlueBall")
        {
            ContactPoint contact = collision.contacts[0];
            float multiplier = 10;
            GetComponent<Rigidbody>().AddForce(multiplier * contact.normal.x, 
                                               multiplier * contact.normal.y, 
                                               multiplier * contact.normal.z, 
                                               ForceMode.Impulse);
            BellSound.Play();
        }
    }

    void SetCountText()
    {
        countText.text = "Count " + count.ToString() + "/" + winningScore.ToString();
        if (count >= winningScore)
        {
            winText.text = "You win!";
            hasWin = true;
            Music.Stop();
            WinSound.Play();
            StartCoroutine(ResetAfterSeconds(5));
            Time.timeScale = 0f;
        }
    }

    void SetDeathText()
    {
        deathText.text = "Death count :" + deathCount.ToString();
    }

    private IEnumerator ResetAfterSeconds(int seconds)
    {
        float pauseEndTime = Time.realtimeSinceStartup + seconds;

        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return null;
        }

        ResetGame();
    }

    void ResetGame()
    {
        Time.timeScale = 1.0f;

        if (!hasWin)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

}
