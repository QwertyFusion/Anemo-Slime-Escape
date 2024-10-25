using UnityEngine;

public class PillarSpawnScript : MonoBehaviour
{
    public GameObject pillar;
    public GameObject destructiblePillar;
    public float spawnRate = 3.5F;
    public float timer = 0;
    public float heightOffset = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPillar();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate) {
            timer += Time.deltaTime;
        } else {
            spawnPillar();
            timer = 0;
        }
    }

    void spawnPillar() {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        float value = Random.Range(1, 100);
        if( value > 30) {
            Instantiate(pillar, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        } else {
            Instantiate(destructiblePillar, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        }
    }
}
