using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TeaPotMove : MonoBehaviour
{
    public GameObject win;

    // скорость вращения
    private float ySpeed = 250.0f;

    //Угол поворота
    private float y = 0.0f;
    private bool blockMouse = false;
    private bool end_game = false;

    private float turningRotationY = 55f; //конечный угол - объект в идеальном повороте
    private float finishRotationMin = 38f;
    private float finishRotationMax = 64f;
    private float turningRotationY_2 = -129.4f; //конечный угол - объект в идеальном повороте
    private float finishRotationMin2 = -113f;
    private float finishRotationMax2 = -131f;

    private float time_ending = .6f;
    private float _divider = 100; //на сколько частей делим разницу м/у конечным углом и текущим

    void Start()
    {
        transform.position = new Vector3(0.4f,6f,-6.5f);
        //transform.rotation = Quaternion.Euler(0.0f, 77.0f, 0.0f)
        win.SetActive(false);
    }

    public void BackMenu() 
    {
        SceneManager.LoadScene (0);
    }

    private IEnumerator dovorot(float end_angle)
    {
        end_game = true;
        int i = 0;
        float cur_angle = y;
        float dif_angle = end_angle - cur_angle;
        while(i < _divider)
        {
            cur_angle += dif_angle / _divider;
            transform.rotation = Quaternion.Euler(0.0f, cur_angle, 0.0f);
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
                y -= Input.GetAxis("Mouse X") * ySpeed * 0.02f;
                // Debug.Log(y);
                // Углы Эйлера конвертируются в кватернионы
                transform.rotation = Quaternion.Euler(0, y, 0);
            }
        }
        if (y > finishRotationMin && y < finishRotationMax && !end_game)
        {
            blockMouse = true;
            StartCoroutine(dovorot(turningRotationY));//
        }

        else if(y < finishRotationMin2 && y > finishRotationMax2 && !end_game)
        {
            blockMouse = true;
            StartCoroutine(dovorot(turningRotationY_2));//корутины регистрируются и выполняются до первого yield с помощью метода StartCoroutine.
        }
    }
}