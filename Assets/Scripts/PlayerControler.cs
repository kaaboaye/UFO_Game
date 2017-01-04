using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody2D PlayerBody;
    private GameControler Game;

    public float speed;
    public float keyboardSensivity;
    public float touchSensivity;

    private void Start()
    {
        GameObject MainGameObject = GameObject.FindGameObjectWithTag("Game");
        Game = MainGameObject.GetComponent<GameControler>();

        PlayerBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal;
        float moveVertical;
        Vector2 movement;

        // KeyBoard movement
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        movement = new Vector2(moveHorizontal, moveVertical) * keyboardSensivity;

        // Touchpad movement
        if (
            Input.touchCount > 0 &&
            Input.GetTouch(0).phase == TouchPhase.Moved
            )
        {
            movement = Input.GetTouch(0).deltaPosition * touchSensivity;
        }

        PlayerBody.AddForce(movement * speed);
    }

    private void OnTriggerEnter2D(Collider2D PickUp)
    {
        if (PickUp.gameObject.CompareTag("PickUp"))
        {
            Game.score++;
            Game.setCountText();
            PickUp.gameObject.SetActive(false);
        }
    }

}


