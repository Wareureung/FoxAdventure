using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog_move : MonoBehaviour
{
    Animator _animator;

    int value;

    float speed;    
    float repeat_time;
    float check_time;

    Vector3 vec_direction;

    void Start()
    {
        value = 0;
        repeat_time = 3.0f;
        _animator = GetComponent<Animator>();
        _animator.SetInteger("Direction", 1);
    }
        
    void Update()
    {
        check_time += Time.deltaTime;
        if (check_time > repeat_time && value < 3)
        {
            value++;
            speed = 1.0f;
            _animator.SetInteger("Direction", 0);
            vec_direction = new Vector3(-10.0f, 0.0f, 0.0f);
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x - 1, 2.0f);            
            check_time = 0;
        }
        else if(check_time > repeat_time && value > 2)
        {
            value++;
            speed = 1.0f;
            _animator.SetInteger("Direction", 0);
            vec_direction = new Vector3(10.0f, 0.0f, 0.0f);
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x + 1, 2.0f);
            check_time = 0;
            if (value > 5)
                value = 0;
        }
        else if(check_time < repeat_time)
        {
            speed = 0.0f;
            _animator.SetInteger("Direction", 1);
            vec_direction = new Vector3(0.0f, 0.0f, 0.0f);
        }
        transform.Translate(vec_direction * speed * Time.deltaTime);
    }
}
