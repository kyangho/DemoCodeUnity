using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMoveEnemy : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private Transform transform;
    public Camera cam;
    private Rect camBoundRect;
    public float speed = 12f;
    private float xPos;
    private float yPos;
    private float step;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        step = speed * Time.deltaTime; // calculate distance to move
        randomNewPosition();
    }

    // Update is called once per frame
    void Update()
    {
        updateCamBound();
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(xPos, yPos), step);
        if (transform.position.x == xPos && transform.position.y == yPos)
        {
            randomNewPosition();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(this);
        }
    }

    private void randomNewPosition()
    {
        xPos = Random.Range(cam.transform.position.x - camBoundRect.width / 2 + this.GetComponent<SpriteRenderer>().size.x,
            cam.transform.position.x + camBoundRect.width / 2 - this.GetComponent<SpriteRenderer>().size.x);
        yPos = Random.Range(cam.transform.position.y - camBoundRect.height / 2 + this.GetComponent<SpriteRenderer>().size.y,
            cam.transform.position.y + camBoundRect.height / 2 - this.GetComponent<SpriteRenderer>().size.y);
    }

    private void updateCamBound()
    {
        speed = cam.orthographicSize;
        camBoundRect = cam.rect;
        camBoundRect.height = 2f * cam.orthographicSize;
        camBoundRect.width = camBoundRect.height * cam.aspect;
    }
}
