using System.Collections;
using Mono.Cecil;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int hp;
    public float speed = 1.0f;
    public Sprite[] sprites;
    public SpriteRenderer spriteRenderer;
    public GameObject enemyBulletPrefab;
    public Player player;
    

    private float delta = 0;
    private float span = 1.0f;
    
   
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -5.9f)
        {
            Destroy(gameObject);
        }

        
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        spriteRenderer.sprite = sprites[1];
        
        // 다시 본래 스프라이트로 돌아온다
        StartCoroutine(ReturnSprite());

        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }




    }

    IEnumerator ReturnSprite()
    {
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.sprite = sprites[0];
    }

    public void CreateEnemyBullet()
    {
         GameObject enemyGO = Instantiate(enemyBulletPrefab, this.transform.position, this.transform.rotation);
         EnemyBullet enemyBullet = enemyGO.GetComponent<EnemyBullet>();
         Player.transform.position - this.transform.position;
    }
    
   
    

  



}
