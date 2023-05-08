using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class monsterController : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Student"))
        {
            // 플레이어와 충돌한 경우 처리

            //print("hello");

        }
    }




}
