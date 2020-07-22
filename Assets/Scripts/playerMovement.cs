using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    public float velocity = 10f;
    public Rigidbody rb;
    private int score;
    public Text scoreText;
    public float speed;
    public Transform cam;
    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        setScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            //// player movement for circle
            //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.AddForce(direction * velocity);

            //rb.MovePosition(direction * speed * Time.deltaTime);

        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            score += 1;
            setScoreText();
            print("Score: " + score);
        }

        if (other.gameObject.CompareTag("Grow"))
        {
            rb.transform.localScale += new Vector3(1f, 1f, 1f) * 2;
            other.gameObject.SetActive(false);

        }
    }

    void setScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

}
