using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1.0f;
    public float delta = 0;
    public float span = 0.1f;
    public Transform firePoint;
        
    private Animator animator;
    public GameObject playerBulletPrefab;
    
    
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        ReLoad();
        Bullet();

    }

    void ReLoad()
    {
        delta += Time.deltaTime;
    }
    void Bullet()
    {
        if (!Input.GetButton("Fire1"))
            return;

        if (delta < span)
            return;

        Instantiate(playerBulletPrefab, firePoint.position,transform.rotation);
        delta = 0f;
    }
    void Move()
    {
        float horizon = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        /*Debug.Log(horizon);
        Debug.Log(vertical);*/

        Vector2 move = new Vector2(horizon, vertical);
        transform.Translate(move.normalized *speed * Time.deltaTime);
        this.animator.SetInteger("direction", (int)horizon);

        float clampGuideX = Mathf.Clamp(transform.position.x, -2.6f, 2.6f);
        float clampGuideY = Mathf.Clamp(transform.position.y, -3.5f, 3.5f);
        this.transform.position = new Vector2(clampGuideX,clampGuideY );
        // 클램프로 조절한 값을 꼭 현재 위치에 넣어야한다


    }

    void OnTiggerEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
        //에너미 거나 불렛태그만 셋엑티브 를 폴스로
        if ( other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyBullet"))
        {
            this.gameObject.SetActive(false);
        }
    }
    
    
}
