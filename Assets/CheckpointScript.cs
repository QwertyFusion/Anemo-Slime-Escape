using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public LogicScript logic;
    public GameObject slime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        slime = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == 3 && slime.GetComponent<SlimeScript>().getSlimeIsAlive()) {
            logic.addScore(1);
        }
    }
}
