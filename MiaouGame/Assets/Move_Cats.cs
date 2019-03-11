using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Cats : SMAAgent
{
private float latestDirectionChangeTime;
private readonly float directionChangeTime = 3f;
private float characterVelocity = 50f;
private Vector2 movementDirection;
private Vector2 movementPerSecond;
public SpriteRenderer m_renderer;
 
private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Dark_Grass"){characterVelocity=20.0f;}
    }

private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Dark_Grass"){characterVelocity=100.0f;}
    }
 void Start(){
     latestDirectionChangeTime = 0f;
     calcuateNewMovementVector();
 }
 
 void calcuateNewMovementVector(){
    //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
     movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
     movementPerSecond = movementDirection * characterVelocity;
 }
 
 public override void SMAUpdate(float dt){
    if (Time.time - latestDirectionChangeTime > directionChangeTime){
        latestDirectionChangeTime = Time.time;
        calcuateNewMovementVector();
        }
    Rigidbody2D catsRb2D = GetComponent<Rigidbody2D>();
    Vector2 newPos = new Vector2(transform.position.x + (movementPerSecond.x * dt),transform.position.y + (movementPerSecond.y * dt));
    catsRb2D.MovePosition(newPos);
 }

 public override void SMAFixedUpdate(float dt){

 }
//  void Update(){
//      //if the changeTime was reached, calculate a new movement vector
//      if (Time.time - latestDirectionChangeTime > directionChangeTime){
//          latestDirectionChangeTime = Time.time;
//          calcuateNewMovementVector();
//      }

//      Rigidbody2D catsRb2D = GetComponent<Rigidbody2D>();

//      Vector2 newPos = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime), 
//      transform.position.y + (movementPerSecond.y * Time.deltaTime));


//      catsRb2D.MovePosition(newPos);
     
//      //move enemy: 
     
 
//  }
}