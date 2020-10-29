using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Char_move : MonoBehaviour
{
    Animator _animator;
    float speed;
    public float jump_pos;
    public bool jump_state;
    public bool jump_number;
    float climb_value;
    bool climb;
    Vector3 vec_direction;
    public int eat_num;
    public int bullet_num;
    public int fox_state;

    public bool get_key_down;
    Bullet bullet;

    void Start()
    {
        speed = 0.0f;
        jump_pos = 3.5f;
        jump_state = false;
        jump_number = false;
        climb = false;
        climb_value = 0.0f;
        _animator = GetComponent<Animator>();
        _animator.SetInteger("Direction", 0);

        eat_num = 0;
        bullet_num = 0;
        fox_state = 0;

        get_key_down = false;
        bullet = GameObject.Find("bullet").GetComponent<Bullet>();
    }

    void Update()
    {
        Input_Key();

        //다 먹었는지 확인
        if (eat_num == 8)
        {
            SceneManager.LoadScene("Two");
        }
    }

    void Input_Key()
    {
        //초기화
        _animator.SetInteger("Direction", 0);
        vec_direction = new Vector3(0.0f, 0.0f, 0.0f);

        //좌우 이동
        if (Input.GetKey(KeyCode.RightArrow))
        {
            fox_state = 1;
            speed = 1.0f;
            _animator.SetInteger("Direction", 1);
            vec_direction = new Vector3(1.0f, 0.0f, 0.0f);
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            if (Input.GetKey(KeyCode.Space) && jump_number == true)
            {
                jump_state = true;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            fox_state = 2;
            speed = 1.0f;
            _animator.SetInteger("Direction", 1);
            vec_direction = new Vector3(-1.0f, 0.0f, 0.0f);
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            if (Input.GetKey(KeyCode.Space) && jump_number == true)
            {
                jump_state = true;
            }
        }
        //점프
        if (Input.GetKey(KeyCode.Space) && jump_number == true)
        {
            jump_state = true;
        }
        if (jump_state == true)
        {
            GameObject.Find("s_jump").GetComponent<AudioSource>().Play();
            _animator.SetInteger("Direction", 2);
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump_pos);
            jump_number = false;
            jump_state = false;
        }
        //사다리 타기
        if (Input.GetKey(KeyCode.UpArrow) && climb == true)
        {
            _animator.SetInteger("Direction", 3);

            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 1.0f);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && climb == true)
        {
            _animator.SetInteger("Direction", 3);
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -1.0f);
        }
        //총알 발사
        if (Input.GetKeyDown(KeyCode.LeftShift) && bullet_num > 0)
        {
            GameObject.Find("s_shoot").GetComponent<AudioSource>().Play();
            bullet.bullet_state = true;
        }
        //이동
        transform.Translate(vec_direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Grid")
        {
            jump_number = true;
        }

        if(collision.transform.tag == "frog")
        {
            jump_number = true;
        }

        if(collision.transform.tag == "Platform")
        {
            jump_number = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Ladder")
        {
            climb = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        climb = false;
    }
}
