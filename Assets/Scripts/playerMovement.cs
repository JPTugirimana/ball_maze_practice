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

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * velocity);
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
    }

    void setScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

}
