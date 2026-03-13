using UnityEngine;

public class PLATFORMMOVEMENT : MonoBehaviour
{
    // Do display in the editor,
    public float moveSpeed;
    public Rigidbody2D rb;
    public SpriteRenderer spr;

    public Sprite lookRightImage;
    public Sprite lookUpImage;

    // Do not display this in the editor, the code will manage it
private float horizontalInput;
private float verticalInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
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
}
