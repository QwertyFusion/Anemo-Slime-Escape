using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SlimeScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public float ballSpeed;
    public LogicScript logic;
    bool slimeIsAlive = true;
    private Animator animator = null;
    [SerializeField] private AudioSource wingFlapSound;
    [SerializeField] private AudioSource deathSound;
    [SerializeField] private GameObject pressSpaceText;
    [SerializeField] private GameObject anemoBall;
    [SerializeField] private GameObject tutorialScreen;

    private bool gamePause = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        Time.timeScale = 0;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        animator = GetComponent<Animator>();

        if(PlayerPrefs.GetInt("ShowTutorial") == 1) {
            tutorialScreen.SetActive(true);
            PlayerPrefs.SetInt("ShowTutorial", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gamePause && tutorialScreen.activeSelf)  {
            if(Input.GetKeyDown(KeyCode.Space)) {
                tutorialScreen.SetActive(false);
            }
        } else if(gamePause) {
            if(Input.GetKeyDown(KeyCode.Space) && slimeIsAlive) {
                Time.timeScale = 1;
                gamePause = false;
                pressSpaceText.SetActive(false);
            }
        } else {
            if(Input.GetKeyDown(KeyCode.Space) && slimeIsAlive) {
                animator.SetTrigger("Flap");
                wingFlapSound.Play();
                myRigidBody.linearVelocity = Vector2.up * flapStrength;
            }

            if(Input.GetKeyDown(KeyCode.F) && slimeIsAlive) {
                Instantiate(anemoBall, new Vector3(transform.position.x + 3, transform.position.y, 0), transform.rotation);
            }

            if(transform.position.y > 14 || transform.position.y < -14) {
                slimeIsAlive = false;
                logic.gameOver();
            }
        }
    }

    public bool getSlimeIsAlive() {
        return slimeIsAlive;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(slimeIsAlive){
            deathSound.Play();
            slimeIsAlive = false;
            transform.localScale = Vector3.zero;
            Invoke("logic.gameOver", 5);
        }
    }
}
