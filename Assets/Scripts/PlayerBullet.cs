using TreeEditor;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 1.0f;    



    void Update()
    {
        Move();
    }
    
    void Move()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (transform.position.y > 4.3f)
        {
            Destroy(this.gameObject);
        }
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            
            
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
