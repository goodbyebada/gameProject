using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocolateGizmo : MonoBehaviour
{
   
    public float radius = 1f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        Gizmos.DrawWireSphere(transform.position, radius);
    }


    
}
