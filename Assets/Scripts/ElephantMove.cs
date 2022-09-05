using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ElephantMove : MonoBehaviour
{
    public GameObject win;

    // скорость вращения
    private float xSpeed = 250.0f;
    private float ySpeed = 250.0f;

    //Угол поворота
    private float x = 0.0f;
    private float y = 0.0f;
    private bool blockMouse = false;
    private bool end_game = false;

    static Vector2 range = new Vector2(15f, 15f);

    static Vector2 turningRotation_1 = new Vector2(100f, 157f); //конечное положение - объект в идеальном повороте
    static Vector2 finishRotationMin_1 = new Vector2(turningRotation_1.x - range.x, turningRotation_1.y - range.y);
    static Vector2 finishRotationMax_1 = new Vector2(turningRotation_1.x + range.x, turningRotation_1.y + range.y);

    static Vector2 turningRotation_2 = new Vector2(80f, -20f); //конечное положение - объект в идеальном повороте
    static Vector2 finishRotationMin_2 = new Vector2(turningRotation_2.x - range.x, turningRotation_2.y - range.y);
    static Vector2 finishRotationMax_2 = new Vector2(turningRotation_2.x + range.x, turningRotation_2.y + range.y);

    private float time_ending = .5f;
    private float _divider = 100; //на сколько частей делим разницу м/у конечным углом и текущим

    void Start()
    {
        win.SetActive(false);
    }

    public void BackMenu() 
    {
        SceneManager.LoadScene (0);
    }

    private IEnumerator dovorot(float end_angle_X, float end_angle_Y)
    {
        int i = 0;
        float cur_angle_X = x;
        float dif_angle_X = end_angle_X - cur_angle_X;
        float cur_angle_Y = y;
        float dif_angle_Y = end_angle_Y - cur_angle_Y;
        while(i < _divider)
        {
            cur_angle_X += dif_angle_X / _divider;
            cur_angle_Y += dif_angle_Y / _divider;
            transform.rotation = Quaternion.Euler(cur_angle_X, cur_angle_Y, 0.0f);
            yield return new WaitForSeconds(time_ending / _divider);
            ++i;
        }
        win.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetMouseButton(1))
        {
            if (!blockMouse) 
            {
                //Input.GetAxis("MouseX ") Получить расстояние по оси X движения мыши
                x -= Input.GetAxis("Mouse Y") * ySpeed * 0.01f;
                y -= Input.GetAxis("Mouse X") * xSpeed * 0.01f;
                x += (x < -180f) ? 360 : 0;
                x -= (x > +180f) ? 360 : 0;
                y += (y < -180f) ? 360 : 0;
                y -= (y > +180f) ? 360 : 0;
                // Debug.Log("move_x");
                // Debug.Log(x);
                // Debug.Log("move_y");
                // Debug.Log(y);
                // Углы Эйлера конвертируются в кватернионы
                transform.rotation = Quaternion.Euler(x, y, 0);
            }
        }

        if( finishRotationMin_1.x < x && x < finishRotationMax_1.x &&
            finishRotationMin_1.y < y && y < finishRotationMax_1.y &&
            !end_game)
        {
            // Debug.Log("finish 1");
            end_game = true;
            blockMouse = true;
            StartCoroutine(dovorot(turningRotation_1.x, turningRotation_1.y)); //корутины работают параллельно
            // StartCoroutine(dovorot_X(turningRotation_X));
        }
        else if (   finishRotationMin_2.x < x && x < finishRotationMax_2.x &&
                    finishRotationMin_2.y < y && y < finishRotationMax_2.y &&
                    !end_game)
        {
            // Debug.Log("finish 2");
            end_game = true;
            blockMouse = true;
            StartCoroutine(dovorot(turningRotation_2.x, turningRotation_2.y)); //корутины работают параллельно
            // StartCoroutine(dovorot_X(turningRotation_X2));
        }
    }
}