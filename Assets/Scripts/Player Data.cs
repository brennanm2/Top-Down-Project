using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public bool buttonPressed;
    public float keysCollected;
     public SpriteRenderer spr;

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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Button")
        {
            buttonPressed = true;
            
        }
    }

}