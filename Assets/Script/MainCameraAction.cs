using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainCameraAction : MonoBehaviour
{
    public float cameraSpeed = 5.0f;

    public GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Student");
    }

    private void Update()
    {
        Vector3 direction = player.transform.position - this.transform.position;
        //float direction = (player.position - transform.position).normalized;

        Vector3 moveVector = new Vector3(direction.x * cameraSpeed * Time.deltaTime, direction.y * cameraSpeed * Time.deltaTime, 0.0f);


        //Vector3 moveVector = player.transform.position + direction * cameraSpeed * Time.deltaTime;
        this.transform.Translate(moveVector);
    }
}