
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 1;

    public Vector3 dir;
    private float delta;
    private float span;
    

 
  
    void Update()
    
    {
        transform.Translate(transform.position * speed * Time.deltaTime, Space.World);
    }
}
