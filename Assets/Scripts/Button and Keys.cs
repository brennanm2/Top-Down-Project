using UnityEngine;

public class ButtonandKeys : MonoBehaviour
{
    public bool buttonPressed;
    public int keysCollected;
     public SpriteRenderer spr;
     public GameObject keyPrefab;
     public Vector3 keySpawn1;

    public Sprite buttonPressedImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
     
        if (buttonPressed == true)
        {
            spr.sprite = buttonPressedImage;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered collision with : " + collision.gameObject.name);

        if (collision.gameObject.tag == "Player")
        {
            buttonPressed = true;
            Instantiate(keyPrefab, keySpawn1, Quaternion.identity);
        }
        if (gameObject.tag == "Key")
      {
        // add one to our key counter
        keysCollected += 1;

        // make the coin disabled
            gameObject.SetActive(false);
      }   

    }
      
}