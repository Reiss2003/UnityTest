using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour

{
        float movementX;
            float movementY;
        bool jump;
        public float velocity = 100f;

        public Rigidbody2D rb;

        new public Collider2D collider2D;

        public float jumpforce = 4f;
   
        public bool facingRight = true;
   
        public bool isGrounded = true;
    
        public Animator animator; 
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementX = Input.GetAxis("Horizontal");
        animator.SetFloat("horizontalX", movementX);
       // animator.SetFloat("movementY", movementY);
        
        
        //rb.velocity = new Vector2(movementX * velocity * Time.fixedDeltaTime, rb.velocity.y);
        
    }

    void FixedUpdate(){
        RaycastHit2D[] results = new RaycastHit2D[5];
        if (collider2D.Raycast(Vector2.down,results) >= 1) {
            foreach (var result in results)
            {
                if (result.distance == null) continue;
                Debug.Log(result.distance);
                if (result.collider.tag == "Ground" && result.distance < 0.20) {
                    isGrounded=true;
                }
            }
        }
        rb.velocity = new Vector2(movementX * velocity * Time.fixedDeltaTime, rb.velocity.y);

        if(Input.GetButtonDown("Jump")&& isGrounded && jump == false){
            jump = true;
            animator.SetBool("jumpAnimation",jump);
            rb.velocity = Vector2.up * jumpforce;
            isGrounded = false;
        }
        if(movementX < 0 && facingRight == true) {
            transform.Rotate(0, 180, 0);
            facingRight = false;
            
         }
        else if(movementX > 0 && facingRight == false) {
            transform.Rotate(0, 180, 0);
            facingRight = true;
        
        }
        
        
    }


}