using UnityEngine;

public class AnemoBallScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float moveSpeed;
    [SerializeField] private float deadZone = 30;
    private AudioSource airBallPop;
    
    void Start()
    {
        airBallPop = GameObject.FindGameObjectWithTag("Air Ball Pop SFX").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.right * moveSpeed * Time.deltaTime);

        if(transform.position.x > deadZone) {
            Destroy(gameObject);
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        airBallPop.Play();
        Destroy(gameObject);
    }
}
