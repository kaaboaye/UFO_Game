using UnityEngine; using UnityEngine.UI;  public class GameControler : MonoBehaviour
{     public GameObject Player;     public GameObject PickUpGroup;     public Text ScoreText;     public Text WinText;      private Transform[] PickUps;     private Rigidbody2D PlayerBody;      [HideInInspector] public int score;      private bool is_won;      private void Start()
    {
        PlayerBody = Player.GetComponent<Rigidbody2D>();
        PickUps = PickUpGroup.GetComponentsInChildren<Transform>();

        is_won = false;
        score = 0;

        setCountText();         WinText.gameObject.SetActive(false);
    }

    private void LateUpdate() {
        // Game restart
        if ( is_won &&
            (Input.GetKey(KeyCode.Space) ||
                Input.touchCount >= 2)
            )
        {
            // Hide WinText
            WinText.gameObject.SetActive(false);

            // Show all PickUps
            foreach(Transform PickUp in PickUps)
            {
                PickUp.gameObject.SetActive(true);
            }

            // Reset score & update ScoreText
            score = 0;
            setCountText();

            // Reset Player
            PlayerBody.velocity = new Vector2(0f, 0f);
            PlayerBody.angularVelocity = 0;
            Player.transform.position = new Vector3(0, 0, 0);
            Player.transform.rotation = new Quaternion(0, 0, 0, 0);

            // Set is_won to false
            is_won = false;
        }
    }
         
    public void setCountText()
    {
        ScoreText.text = "Count: " + score.ToString();

        if (score >= PickUpGroup.transform.childCount)
        {
            is_won = true;
            ScoreText.text += "\nPress space or tap using 2 or more fingers";
            ScoreText.text += "\nto restart game";
            WinText.gameObject.SetActive(true);
        }
    } } 