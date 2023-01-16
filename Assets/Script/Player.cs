using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Player : MonoBehaviour
{
    
    public float speed;
    private Rigidbody rigidBody;
    public Text countText;
    public Text winText;
    private int count;
    public bool isGrounded;

    private void Start()
    {
        
        rigidBody = this.GetComponent<Rigidbody>();
        isGrounded = false;
        count = 0;
        setCountText();
        winText.text = " ";
    }
    void setCountText()
    {
        countText.text = "Count : " + count.ToString();
        if(count >= 5)
        {
            winText.text = "You can pass!";
        }
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown("space") && rigidBody.transform.position.y <= 0.51f)
        {
            Vector3 jump = new Vector3(0.0f, 300.0f, 0.0f);
            rigidBody.AddForce(jump);
        }
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical);
        rigidBody.AddForce(movement * speed);
    }
    void OnCollisionEnter(Collision collision) {
        
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    private void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            setCountText();
            if (count >= 5)
            {
                winText.text = "Wait next level!!";
                StartCoroutine(WaitForSceneLoad());
                
            }
        }
    }

    
}
