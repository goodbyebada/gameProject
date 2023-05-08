using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;



public class NewMonsterMoving : MonoBehaviour
{
	public Transform target;
	public Vector3 direction;
	public float velocity;
	public float default_velocity;
	public float accelaration;
	public Vector3 default_direction;
	private Vector3 newPosition;

	private float chasingDistance = 1.5f;


	public Tilemap tilemap;

	//효과음 
	public AudioSource audioSource;
	public AudioClip bgm;
	private bool isPlaying;

	void Start()
	{


		tilemap = GameObject.FindGameObjectWithTag("Tilemap").GetComponent<Tilemap>();

		// 자동으로 움직일 방향 벡터
		default_direction.x = Random.Range(0, 1.0f);
		default_direction.y = Random.Range(0, 1.0f);
		// 가속도 지정 (추후 힘과 질량, 거리 등 계산해서 수정할 것)
		accelaration = 0.1f;
		default_velocity = 0.1f;


		//효과음
		audioSource = GetComponent<AudioSource>();
        isPlaying = false;
		audioSource.clip = bgm;
		audioSource.loop = true;
	}

	void Update()
	{
		// Player의 현재 위치를 받아오는 Object
		target = GameObject.FindGameObjectWithTag("Student").transform;
		// Player와 객체 간의 거리 계산
		float distance = Vector3.Distance(target.position, transform.position);


        if (distance <= chasingDistance)
		{
			print("player 감지! 효과음 상태: " + audioSource.isPlaying);
			MoveToTarget();
			// 일정 거리안에 있다가 다시 멀어졌을 때, 일정거리안에 있었던 player의 방향으로 움직임
			default_direction = direction;
		}
		// 일정거리 밖에 있을 시, 속도 초기화하고 해당 방향으로 무빙 
		else
		{
			//velocity = 0.0f;
			newPosition = new Vector3(transform.position.x + (default_direction.x * default_velocity),
												   transform.position.y + (default_direction.y * default_velocity),
												   transform.position.z);
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

		Vector3Int cellPosition = tilemap.WorldToCell(newPosition);
        if (tilemap.HasTile(cellPosition))
        {
            transform.position = newPosition;
		
        }
        else {
			direction = -direction;
		
		}

	
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
		// Player의 위치와 이 객체의 위치를 빼고 단위 벡터화 한다.
		direction = (target.position - transform.position).normalized;
		// 초가 아닌 한 프레임으로 가속도 계산하여 속도 증가 
		//velocity += accelaration * Time.deltaTime;
		// 해당 방향으로 무빙
		newPosition = new Vector3(transform.position.x + (direction.x * velocity),
											   transform.position.y + (direction.y * velocity),
												  transform.position.z);

	}


    private void OnDrawGizmosSelected()
    {
        // Draw a sphere around the enemy to show the chasing distance
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chasingDistance);
    }

}