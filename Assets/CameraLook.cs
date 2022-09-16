using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    Transform cameraTransform;
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        cameraTransform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, cameraTransform.position.z);
    }
}
