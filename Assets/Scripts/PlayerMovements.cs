using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] CircleCollider2D redBallCollider;
    [SerializeField] CircleCollider2D blueBallCollider;

    public static PlayerMovements Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;

    Rigidbody2D rb;
    Vector3 startPosition;
    float touchPosX;

    void Start()
    {
        startPosition = transform.position;

        rb = GetComponent<Rigidbody2D>();

        MoveUp();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isGameOver)
        {
            // Check for touch input
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                touchPosX = touch.position.x;
            }

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                if (touchPosX > Screen.width / 2)
                    RotateRight();
                else
                    RotateLeft();
            }
            else
                rb.angularVelocity = 0f;

            // Keyboard controls (for testing)
            if (Input.GetKey(KeyCode.LeftArrow))
                RotateLeft();
            else if (Input.GetKey(KeyCode.RightArrow))
                RotateRight();
            else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
                rb.angularVelocity = 0f;
        }
    }

    void MoveUp()
    {
        rb.velocity = Vector2.up * speed;
    }

    void RotateLeft()
    {
        rb.angularVelocity = rotationSpeed;
    }

    void RotateRight()
    {
        rb.angularVelocity = -rotationSpeed;
    }

    public void Restart()
    {
        redBallCollider.enabled = false;
        blueBallCollider.enabled = false;

        rb.angularVelocity = 0f;
        rb.velocity = Vector2.zero;

        transform.DORotate(Vector3.zero, 1f)
            .SetDelay(1f)
            .SetEase(Ease.InOutBack);

        transform.DOMove(startPosition, 1f)
            .SetDelay(1f)
            .SetEase(Ease.OutFlash)
            .OnComplete(() =>
            {
                redBallCollider.enabled = true;
                blueBallCollider.enabled = true;

                GameManager.Instance.isGameOver = false;

                MoveUp();
            });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LevelEnd"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Win");

            int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;

            if (currentLevelIndex < SceneManager.sceneCountInBuildSettings)
                SceneManager.LoadScene(++currentLevelIndex);
        }
    }
}