using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float m_speed = 100.0f;
    public Sprite m_frontSprite;
    public Sprite m_backSprite;
    public Sprite m_sideSprite;
    public SpriteRenderer m_renderer;
    public int m_state;
    public Rigidbody2D rb;
    private ParticleSystem ps;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Dark_Grass"){m_speed=20.0f;}
        if (collision.gameObject.tag=="BadGuy"){m_state=m_state-1;}
        if (collision.gameObject.tag=="GoodGuy"){m_state=m_state+1;}
    }

     private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Dark_Grass"){m_speed=100.0f;}
    }

    void Start()
    {
        ps=GetComponent<ParticleSystem>();
    }

    void FixedUpdate()
    {
        var main=ps.main;
        var tmp=m_state;
        if (m_state<=0){
            tmp=0;
        }
        main.maxParticles=Mathf.RoundToInt(m_state);
        float movey = Input.GetAxis("Horizontal");
        float movex = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(movey*m_speed,movex*m_speed);
        if (m_state==0){
            m_renderer.color=Color.white;
        }
        if (m_state<0){
            m_renderer.color=Color.red;
        }
        if(m_state==-5){
            Destroy(gameObject);
        }
        if(m_state>5){
            m_state=5;
        }
    }
    // Update is called once per frame
    void Update()
    {
    if (Input.GetKey (KeyCode.LeftArrow)) {
        m_renderer.sprite=m_sideSprite;
        m_renderer.flipX=true;
       }
    if (Input.GetKey (KeyCode.RightArrow)) {
        m_renderer.sprite=m_sideSprite;
        m_renderer.flipX=false;
        }
    if (Input.GetKey (KeyCode.UpArrow)) {
        m_renderer.sprite=m_backSprite;
        }
    if (Input.GetKey (KeyCode.DownArrow)) {
        m_renderer.sprite=m_frontSprite;
        }
    }
}