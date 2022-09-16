using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnEnemy : MonoBehaviour
{
    public float spawnTimer = 0.5f;
    private float previousSpawnTimer = 0f;
    public GameObject spawnGameObject;
    private Camera cam;
    private Transform camTransform;
    // Start is called before the first frame update
    void Start()
    {
        cam = this.GetComponent<Camera>();
        camTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (previousSpawnTimer < spawnTimer)
        {
            previousSpawnTimer += Time.deltaTime;
        } else
        {
            previousSpawnTimer = 0f;
            Rect boundRect = cam.rect;
            boundRect.height = 2f * cam.orthographicSize;
            boundRect.width = boundRect.height * cam.aspect;
            float xPos = Random.Range(this.transform.position.x - boundRect.width / 2 + spawnGameObject.GetComponent<SpriteRenderer>().size.x, this.transform.position.x + boundRect.width / 2 - spawnGameObject.GetComponent<SpriteRenderer>().size.x);
            float yPos = Random.Range(this.transform.position.y - boundRect.height / 2 + spawnGameObject.GetComponent<SpriteRenderer>().size.y, this.transform.position.y + boundRect.height / 2 - spawnGameObject.GetComponent<SpriteRenderer>().size.y);
            Instantiate(spawnGameObject, new Vector3(xPos, yPos, 0), Quaternion.identity);
        }
    }
}
