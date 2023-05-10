using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;



public class NewMonsterMoving : MonoBehaviour
{
	public Transform target;
	public Vector3 direction;
	public float moveSpeed = 4.2f;
	public Vector3 default_direction;
	private Vector3 newPosition;

	public float chasingDistance = 3.5f;
	public float distanceToKeep = 0.5f;

	public Tilemap tilemap;
	private float distance;

	//효과음 
	public AudioSource audioSource;
	public AudioClip bgm;
	private bool isPlaying;


	void setRandomDirection()
    {
		// 자동으로 움직일 방향 벡터
		default_direction.x = Random.Range(0, 1.0f); // 0~1.0f 랜덤한 값 direction이 
		default_direction.y = Random.Range(0, 1.0f);
	}

	void Start()
	{
        tilemap = GameObject.FindGameObjectWithTag("Tilemap").GetComponent<Tilemap>();

		setRandomDirection();
		//효과음
		audioSource = GetComponent<AudioSource>();
        isPlaying = false;
		audioSource.clip = bgm;
		audioSource.loop = true;

}

	Vector3 getNextPosition()
	{
        //return transform.position + default_direction * moveSpeed * Time.deltaTime;
		
        return new Vector3(transform.position.x + (default_direction.x * moveSpeed * Time.deltaTime),
                                                   transform.position.y,
                                                   transform.position.z);
		//x축으로만 이동하는 getNewPosition
    }


	void Update()
	{
		// Player의 현재 위치를 받아오는 Object
		target = GameObject.FindGameObjectWithTag("Student").transform;
		// Player와 객체 간의 거리 계산
		//transform.position : 경비원 위치

		distance = Vector3.Distance(target.position, transform.position);


		if (distance <= chasingDistance)
		{
			//print("player 감지! 효과음 상태: " + audioSource.isPlaying);
			MoveToTarget(); //타켓을 향해 이동
		
		}
		else
		{

				newPosition = getNextPosition(); //default_direction 방향으로 이동 -> start에서 default_direction.x,default_direction.y 랜덤 0~1.0의 값을 가지고 있음
												 //x축 방향으로만 이동
			
				//newPosition = new Vector3(transform.position.x ,
				//								   transform.position.y + +(default_direction.y * moveSpeed * Time.deltaTime),
				//								   transform.position.z);	
		}

		Vector3Int cellPosition = tilemap.WorldToCell(newPosition); // cell화 시킨 cellPosition -> tilemap에 있는지 확인
		if (tilemap.HasTile(cellPosition))
		{
			//print("tilemap has Tile");
			transform.position = newPosition; //tilemap 안에 있다면 현재 위치가 됨 -> 

		}
		else
		{
			//print("	타일에 없다면 반대 방향으로 이동해");
            //setRandomDirection(); //같은 랜덤 값 반환하느라 움직이지 않음 -> 계속 tilemap에 없는 값 반환 -> 다시 랜덤 무한반복 -> 안움직임 
            default_direction.x = -default_direction.x;
       
            //타일에 없다면 x축으로 반대 방향으로 이동 

        }



		//효과음 
		float volum = 1.0f - distance / 10.0f;
		if (volum > 0.0f)
        {
			audioSource.volume = volum;
			isPlaying = true;
        }
		else
        {
			isPlaying = false;
        }
		playSound();
	
    }


	private void playSound()
	{
		if (isPlaying && !audioSource.isPlaying)
		{
			audioSource.Play();
			print("===BGM ON ===");
		}
        else if(!isPlaying)
        {
			audioSource.Stop();
			print("===BGM STOP ===");
		}

	}


	public void MoveToTarget()
	{
		default_direction = (target.position - transform.position).normalized;
		// Player의 위치와 이 객체의 위치 사이의 거리를 단위 벡터화 => 방향을 알려줌 

		if (distance < distanceToKeep)
		{
			print("distance < distanceToKeep");
			//플레이어랑 거리 유지해야함 하지만 유지하지 못했을때 
			// 플레이어 캐릭터 위치에서 일정 거리만큼 떨어뜨림
			default_direction *= -1f;

		}

		newPosition = transform.position + default_direction * moveSpeed * Time.deltaTime;

	}


    private void OnDrawGizmosSelected()
    {
        // Draw a sphere around the enemy to show the chasing distance
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chasingDistance);
    }

}