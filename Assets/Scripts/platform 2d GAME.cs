using UnityEngine;

public class platform2dGAME : MonoBehaviour
{
    // Do display in the editor,
    public float moveSpeed;
    public bool buttonPressed;
    public int keysCollected;
    public Rigidbody2D rb;
    public SpriteRenderer spr;
    public GameObject keyPrefab;
     public Vector3 keySpawn1;
     public float playerHeight;
    public PlayerData data;

    


    public Sprite lookRightImage;
    public Sprite lookUpImage;

    // Do not display this in the editor, the code will manage it
private float horizontalInput;
private float verticalInput;
private int groundLayer =6;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      groundLayer = 1 << groundLayer;
    }

    // Update is called once per frame
    void Update()
    {
        // Movement with transforms (outside of the physics system)
        // float movementInput = Input.GetAxisRaw("Horizontal");
        // transform.position += Vector3.right * movementInput * moveSpeed * Time.deltaTime;

        // Movement inputs (done every frame for responsiveness)
        horizontalInput = Input.GetAxisRaw("Horizontal");
         verticalInput = Input.GetAxisRaw("Vertical");

if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log(data.keysCollected);
        }
        
if (Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.right, playerHeight + 2f, groundLayer);
            if (keysCollected >= 4)
            {
                if (hit)
                {
                    Destroy(hit.transform.gameObject);
                }
            }
        }
        
        
} 


// Called once per PHYSICS frame
    void FixedUpdate()
    {

        // Have the player face the direction they are moving in
        if (horizontalInput > 0)
        {
            spr.sprite = lookRightImage;
            spr.flipX = false;
        }
         if (horizontalInput < 0)
        {
            spr.sprite = lookRightImage;
            spr.flipX = true;
        }
        if (verticalInput > 0)
        {
            spr.sprite = lookUpImage;
            spr.flipY = false;
        }
         if (verticalInput < 0)
        {
            spr.sprite = lookUpImage;
            spr.flipY = true;
        }
        
         // movement with rigidbody (inside the physics system)
          rb.position += Vector2.right * horizontalInput * moveSpeed * Time.fixedDeltaTime;
        // rb.MovePosition(rb.position + Vector2.right * movementInput * moveSpeed * Time.deltaTime);
        rb.position += Vector2.up * verticalInput * moveSpeed * Time.fixedDeltaTime;

        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
         Debug.Log("Triggered collision with : " + collision.gameObject.name);

        if (collision.gameObject.tag == "Player")
        {
            buttonPressed = true;
            Instantiate(keyPrefab, keySpawn1, Quaternion.identity);
        }
        if (collision.gameObject.tag == "Key")
      {
        // add one to our key counter
        keysCollected += 1;

        // make the coin disabled
            collision.gameObject.SetActive(false);

        // completely remove the coin
        Destroy(collision.gameObject);
      }   
    
}
}


