//using UnityEngine;
//using UnityEngine.Tilemaps;

//public class monsterMove : MonoBehaviour


//{

//    public Tilemap tilemap;

//    public float velocity = 5f; // speed
//    public float chasingDistance = f; // distance
//    public Transform playerTransform; // transform of player

//    private bool isChasing = false; // Indicates if the enemy is chasing player
//    private Vector3 newPosition;
//    public PlayerController player;


//    public Vector3 direction;
//    public float accelaration;
//    public Vector3 default_direction;
//    //private Vector3 Direction;


//    private void Start()
//    {
//        //Direction = Random.insideUnitCircle.normalized;
//        tilemap = GameObject.FindGameObjectWithTag("Tilemap").GetComponent<Tilemap>();

//    }

//    private void Update()
//    {
//        float distance = Vector3.Distance(transform.position, playerTransform.position);
//        if (distance <= chasingDistance)
//        {
//            isChasing = true;
//        }
//        else
//        {
//            isChasing = false;
//        }


//        //chasing
//        if (isChasing)
//        {
//            //newPosition = Vector3.MoveTowards(transform.position, chasingPosition, velocity * Time.deltaTime);
//            MoveToTarget();
//        }
//        else
//        {
//            // Move around randomly
//            //newPosition = new Vector3(
//            //    startPosition.x + Random.Range(0.0f, 1.5f),
//            //    startPosition.y,
//            //    startPosition.z);
//            //MoveToTarget();

          
//            //newPosition = new Vector3(transform.position.x + (default_direction.x * default_velocity),
//            //                                       transform.position.y + (default_direction.y * default_velocity),
//            //                                       transform.position.z);


//            //newPosition = new Vector3(transform.position.x + (default_direction.x * velocity *Time.deltaTime),
//            //                                       transform.position.y + (default_direction.y * velocity* Time.deltaTime),
//            //                                       transform.position.z);

//            print("newPostion!");



//            // 이동 방향 변경
//            if (Random.Range(0, 100) < 5)
//            {
//                Direction = Random.insideUnitCircle.normalized;
//            }

//            // 이동
//            GetComponent<Rigidbody2D>().velocity = Direction * velocity * Time.deltaTime;

//            // 타일맵 경계를 벗어나는 경우 반대 방향으로 이동
//            Vector3Int tilePos = tilemap.WorldToCell(transform.position);
//            if (!tilemap.HasTile(tilePos))
//            {
//                Direction = -Direction;
//            }


//        }



//        Vector3Int cellPosition = tilemap.WorldToCell(newPosition);
//        if (tilemap.HasTile(cellPosition))
//        {
//            transform.position = newPosition;
         
//        }

//    }

//    private void OnDrawGizmosSelected()
//    {
//        // Draw a sphere around the enemy to show the chasing distance
//        Gizmos.color = Color.red;
//        Gizmos.DrawWireSphere(transform.position, chasingDistance);
//    }

//    public void MoveToTarget()
//    {
//        // Player의 위치와 이 객체의 위치를 빼고 단위 벡터화 한다.
//        direction = (playerTransform.position - transform.position).normalized;


//        // 초가 아닌 한 프레임으로 가속도 계산하여 속도 증가
//        velocity = (velocity + accelaration * Time.deltaTime);


//        // 해당 방향으로 무빙
//        newPosition = new Vector3(transform.position.x + (direction.x * velocity),
//                                               transform.position.y + (direction.y * velocity),
//                                                  transform.position.z);

//    }
//    private void MonsterWin()
//    {
//        if (player.health == 0)
//        {
//            print(" 경비원의 승리");
//            Application.Quit();
//        }
//    }



//}



