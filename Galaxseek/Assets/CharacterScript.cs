using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public SpriteRenderer spriteRender;
    [SerializeField] private Sprite facingLeft;
    [SerializeField] private Sprite facingRight;
    public float moveSpeed;
    float distance = 50; // only used in teleportation testing
    public int maxHealth = 20;
    public HealthBar HealthBar;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // WASD CONTROLS

            // makes sprite jump when space bar hit
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                myRigidBody.velocity = Vector2.up * 10 * myRigidBody.gravityScale;
            }

            // makes the sprite move right when D is pressed
            if (Input.GetKey(KeyCode.A))
            {
                spriteRender.sprite = facingLeft;
                transform.position = transform.position + (Vector3.left * moveSpeed * Time.deltaTime); 
            }

            // makes the sprite move left when A is pressed
            if (Input.GetKey(KeyCode.D))
            {
                spriteRender.sprite = facingRight;
                transform.position = transform.position - (Vector3.left * moveSpeed * Time.deltaTime); 
            }

            // testing take damage when "h" hit
            if (Input.GetKeyDown(KeyCode.H))
            {
                takeDamage(2);
            }

        // TELEPORTATION
        //eventually should switch exact values to parameters so methods are transferable to planets with different dimensions.
        //important to note: the main camera dimensions are 200x100 in unity (so "ends" of walkable planet should be 100 from the true planet end)

        // teleports player to x = -200 if player reaches x = 200
        if (transform.position.x > 200)
            {
                transform.position = new Vector3(transform.position.x - 400, transform.position.y, transform.position.z); 
            }

            // teleports player to x = 200 if player reaches x = -200
            if (transform.position.x < -200)
            {
                transform.position = new Vector3(transform.position.x + 400, transform.position.y, transform.position.z);
            }

            // testing teleportation with "t" key. will comment out later
            if (Input.GetKeyDown(KeyCode.T))
            {
                transform.position = new Vector3(transform.position.x - distance, transform.position.y, transform.position.z);
            }
     
    }

    // HEALTH + DAMAGE

    // controls health changes upon collisions with other objects
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && currentHealth > 0)   // takes damage when collides with enemy
        {
           takeDamage(2); 
        }

        if (other.gameObject.CompareTag("Heart") && currentHealth < maxHealth)   // regens when collides with health heart 
        {
            regenHealth(2);
        }
    }

    void regenHealth(int regen)
    {
        currentHealth = currentHealth + regen;
        HealthBar.SetHealth(currentHealth);
    }
      

    void takeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        HealthBar.SetHealth(currentHealth);
    }
}
