using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(CircleCollider2D))]

public class ChocolateGizmo : MonoBehaviour
{

    //private CircleCollider2D circleCollider;

    private float radius =1f;

    //private void Start()
    //{
    //    // Circle Collider 컴포넌트 가져오기
    //    circleCollider = GetComponent<CircleCollider2D>();

    //    // Gizmo 원의 radius 값을 Circle Collider의 radius 값과 일치시키기
    //   radius = circleCollider.radius;
    //}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        Gizmos.DrawWireSphere(transform.position, radius);
        
    }


    
}
