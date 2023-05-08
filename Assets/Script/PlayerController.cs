using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float moveSpeed = 5f; // 이동 속도
    public Tilemap tilemap; // 타일맵
    public int health = 3;

    private void Update()
    {
        //수평 방향 입력 받기
        float horizontalInput = Input.GetAxis("Horizontal");
        // 수직 방향 입력 받기
        float verticalInput = Input.GetAxis("Vertical");

        // 이동 방향 계산
        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0f).normalized;

        //현재 위치와 이동 방향을 기반으로 새로운 위치 계산
        Vector3 newPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime;

        // 새로운 위치가 타일맵 내에 있는지 검사
        Vector3Int cellPosition = tilemap.WorldToCell(newPosition);
        if (tilemap.HasTile(cellPosition))
        {
            // 타일맵 내에 있다면 캐릭터 이동
            transform.position = newPosition;
        }

        if(health == 0)
        {
            Application.Quit();
        }
    }

   private void OnTriggerEnter2D(Collider2D collision)

    {

        if (collision.gameObject.CompareTag("Monster"))
        {
            // 플레이어와 충돌한 경우 처리

            //print("wtf");
            //health--;
            //print("health :" + health);

        }
        if ( health == 0) {
            //print("플레이어는 죽었습니다 . ");
            //Application.Quit();
 




        }



    }


   

}

