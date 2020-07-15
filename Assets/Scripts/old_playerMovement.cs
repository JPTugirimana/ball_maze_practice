using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class old_playerMovement : MonoBehaviour
{
    public float velocity = 10f;

    public Rigidbody rb;

    public int score;

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
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveH, 0.0f, moveV);

        rb.AddForce(movement * velocity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            score += 1;
            setScoreText(); //needed to add this one function call! tou
            print("Score: " + score);
        }
        else if (other.gameObject.CompareTag("Grow"))
        {
           rb.transform.localScale += new Vector3(1f, 1f, 1f) * 2;
           other.gameObject.SetActive(false);

           

        }
        //else if (other.gameObject.CompareTag("")
    }

    void setScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
