using UnityEngine;

public class BreakAnimationScript : MonoBehaviour
{
    [SerializeField] private Animator geoBreakAnim;
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private GameObject geoConstruct;
    [SerializeField] private CircleCollider2D geoCollider;
    [SerializeField] private AudioSource rockBreak;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        geoCollider.GetComponent<Collider2D>().enabled = false;
        rockBreak.Play();
        geoBreakAnim.SetTrigger("Break");
        explosionParticle.Play();
    }
}
