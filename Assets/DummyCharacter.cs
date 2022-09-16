using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyCharacter : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;
    private Rigidbody2D rigidbody2D;
    public GameObject bullet;
    private float maxSpeed = 20f;
    private float delay = 0.2f;
    private bool isDone = true;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            if (isDone)
            {
                StartCoroutine(Fire());
            }
            
        }
    }

    IEnumerator Fire()  //  <-  its a standalone method
    {
        isDone = false;
        yield return new WaitForSeconds(delay);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rigidbody2D.AddForce(Vector3.Normalize(gameObject.transform.position - mousePos) * 50f, ForceMode2D.Impulse);
        rigidbody2D.velocity = new Vector2(Mathf.Clamp(rigidbody2D.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(rigidbody2D.velocity.y, -maxSpeed, maxSpeed));
        
        GameObject prefabBullet = Instantiate(bullet, playerTransform.position, Quaternion.identity);
        prefabBullet.GetComponent<Rigidbody2D>().AddForce(Vector3.Normalize(mousePos - gameObject.transform.position) * 100f, ForceMode2D.Impulse);

        isDone = true;
        yield return new WaitForSeconds(0.3f);
        Destroy(prefabBullet);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
    }
}
