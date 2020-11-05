using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eagle_col : MonoBehaviour
{
    public int value;

    float check_time;
    float repeat_time;    
    float speed;

    Vector3 vec_direction;

    int hit_num;

    void Start()
    {
        repeat_time = 3.0f;
        value = 0;
        hit_num = 0;
    }

    void Update()
    {
        check_time += Time.deltaTime;
        if (check_time > repeat_time && value == 0)
        {
            value = 1;
            vec_direction = new Vector3(-10.0f, 8.0f, 0.0f);
            transform.localScale = new Vector3(7.0f, 7.0f, 7.0f);
            check_time = 0;            
        }
        if(check_time > repeat_time && value == 1)
        {
            value = 2;
            vec_direction = new Vector3(-18.0f, 0.0f, 0.0f);
            transform.localScale = new Vector3(7.0f, 7.0f, 7.0f);
            check_time = 0;
        }
        if(check_time > repeat_time && value == 2)
        {
            value = 3;
            vec_direction = new Vector3(0.0f, -10.0f, 0.0f);
            check_time = 0;
        }
        if (check_time > repeat_time && value == 3)
        {
            value = 4;
            vec_direction = new Vector3(-10.0f, 0.0f, 0.0f);
            check_time = 0;
        }
        if (check_time > repeat_time && value == 4)
        {
            value = 5;
            vec_direction = new Vector3(15.0f, 0.0f, 0.0f);
            transform.localScale = new Vector3(-7.0f, 7.0f, 7.0f);
            check_time = 0;
        }
        if (check_time > repeat_time && value == 5)
        {
            value = 1;
            vec_direction = new Vector3(15.0f, 12.0f, 0.0f);
            transform.localScale = new Vector3(-7.0f, 7.0f, 7.0f);
            check_time = 0;
        }

        if (check_time < 0.3f && value != 0)
        {
            speed = 0.5f;
            transform.Translate(vec_direction * speed * Time.deltaTime);
        }

        if(hit_num >= 7)
        {
            value = 6;
            vec_direction = new Vector3(30.0f, 30.0f, 0.0f);
            transform.localScale = new Vector3(7.0f, 7.0f, 7.0f);
            check_time = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "gem_bullet")
        {
            GameObject.Find("e_hit").GetComponent<AudioSource>().Play();
            hit_num++;
        }
    }
}
