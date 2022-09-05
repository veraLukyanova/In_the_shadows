using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumbersSchool : MonoBehaviour
{
    public GameObject logo4;
    public GameObject logo2;

    public GameObject win;
    // скорость вращения/перемещения
    private float RotateSpeed_x = 5f;
    private float RotateSpeed_y = 4f;
    private float MoveSpeed_x = 0.5f;
    private float MoveSpeed_y = 0.5f;

    private bool blockMouse = false;//мышь вкл
    private bool end_game = false;//не конец игры
    private bool logo4_flag = false;//

    //Угол поворота
    private float logo4_x = 0.0f;
    private float logo4_y = 0.0f;
    private float logo2_x = 0.0f;
    private float logo2_y = 0.0f;

    private float time_ending = 0.5f;// секунды
    private float _divider = 200; //на сколько частей делим разницу м/у конечным углом и текущим

    // static Vector2 range = new Vector2(20f, 20f);
    private float range = 10f;

    // static Vector2 logo4_end_rotation = new Vector2(0.0f,0.0f);
    // static Vector2 logo2_end_rotation = new Vector2(0.0f,0.0f);
    // static Vector3 logo4_end_position = new Vector3(0.0f,0.0f,0.0f);
    // static Vector3 logo2_end_position = new Vector3(0.0f,0.0f,0.0f);

    // logo2
    // позиция 1. Конечная позиция и конечный поворот
    static Vector3 logo2_position_end = new Vector3(0.04346943f, 5.960546f, -5f); // конечная позиция
    static Vector3 turningRotation_logo2 = new Vector3(8.325f, -185.375f, 0); //конечный поворот - объект в идеальном повороте
    static Vector3 turningRotation_2_logo2 = new Vector3(8.325f, -185.375f, 180); //конечный поворот - объект в идеальном повороте

    // logo4
    // позиция 1. Конечная позиция и конечный поворот
    static Vector3 logo4_position_end = new Vector3(-1.730867f, 4.8f, -6f); // конечная позиция
    static Vector3 turningRotation_logo4 = new Vector3(3.525f, 176.5f, 0); //конечное поворот - объект в идеальном повороте

    void Start()
    {
        logo2.transform.position = new Vector3(-1f,6f,-5f);
        logo4.transform.position = new Vector3(3f,4f,-6f);
        logo2.transform.rotation = Quaternion.Euler(46.275f, -3.75f, 0.0f);
        logo4.transform.rotation = Quaternion.Euler(-1.95f,27f,0.0f);
        win.SetActive(false);
    }
 
    private bool logo4_and_logo2_is_close(float distance)
    {
        if (Vector3.Distance(logo4.transform.position, logo2.transform.position) < distance &&
            logo4.transform.position.x < logo2.transform.position.x - 1f &&
            logo4.transform.position.y < logo2.transform.position.y - 1f)
            return (true);
        else
            return (false);
    }

    private bool logo4_in_the_right_rotation()
    {
        if (Quaternion.Angle(logo4.transform.rotation, Quaternion.Euler(turningRotation_logo4.x, turningRotation_logo4.y, turningRotation_logo4.z)) < range)
        {
            //Debug.Log("finish 1");
            return (true);
        }
        return (false);
    }

    private bool logo2_in_the_right_rotation()
    {
        if (Quaternion.Angle(logo2.transform.rotation, Quaternion.Euler(turningRotation_logo2.x, turningRotation_logo2.y, turningRotation_logo2.z)) < range ||
            Quaternion.Angle(logo2.transform.rotation, Quaternion.Euler(turningRotation_2_logo2.x, turningRotation_2_logo2.y, turningRotation_2_logo2.z)) < range)
        {
            //Debug.Log("finish 3");
            return (true);
        }
        return (false);
    }

    private IEnumerator dovorot(bool flag, Vector3 end_angle, Vector3 end_position)
    {
        int i = 0;
        Vector3 cur_angle = new Vector3(0.0f,0.0f,0.0f);
        Vector3 cur_position = new Vector3(0.0f,0.0f,0.0f);
        if (flag == true)
        {
            cur_angle = new Vector3(logo4_x, logo4_y, 0f);
            cur_position = logo4.transform.position;
        }
        else
        {
            cur_angle = new Vector3(logo2_x, logo2_y, 0f);
            cur_position = logo2.transform.position;
        }
        Vector3 dif_angle = end_angle - cur_angle;
        Vector3 dif_position = end_position - cur_position;
        while(i < _divider)
        {
            cur_angle += dif_angle / _divider;
            cur_position += dif_position / _divider;

            if (flag == true)
            {
                logo4.transform.rotation = Quaternion.Euler(cur_angle.x, cur_angle.y, 0.0f);
                logo4.transform.position = cur_position;
            }
            else
            {
                logo2.transform.rotation = Quaternion.Euler(cur_angle.x, cur_angle.y, 0.0f);
                logo2.transform.position = cur_position;
            }
            yield return new WaitForSeconds(time_ending / _divider);
            ++i;
        }
        win.SetActive(true);
    }

    private void move_object(ref GameObject obj)// ref float new_x, ref float new_y)
    {
        float move_x = Input.GetAxis("Mouse X") * MoveSpeed_x;
        float move_y = Input.GetAxis("Mouse Y") * MoveSpeed_y;
        // добавить расстояние на которое переместилось
        obj.transform.position += new Vector3(move_x, move_y, 0.0f);
    }

    private void rotate_object(ref GameObject obj, ref float angle_x, ref float angle_y)
    // поворачиваем объекты
    {
        angle_x -= Input.GetAxis("Mouse Y") * RotateSpeed_x;
        angle_y += Input.GetAxis("Mouse X") * RotateSpeed_y;
        angle_x = (angle_x < -180f) ? angle_x + 360 : angle_x;
        angle_x = (angle_x > +180f) ? angle_x - 360 : angle_x;
        angle_y = (angle_y < -180f) ? angle_y + 360 : angle_y;
        angle_y = (angle_y > +180f) ? angle_y - 360 : angle_y;
        // Углы Эйлера конвертируются в кватернионы
        obj.transform.rotation = Quaternion.Euler(angle_x, angle_y, 0.0f);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            SceneManager.LoadScene(0);
        }
        
        if (!blockMouse)
        {
            if(Input.GetKeyDown("space"))
                logo4_flag = !logo4_flag;

            // если нажата ЛКМ
            if (Input.GetMouseButton(0))
            {
                if (logo4_flag) // если logo4_flag = false
                    move_object(ref logo4); // ref Input.mousePosition.x, ref Input.mousePosition.y);
                else // for logo2 /если logo4_flag = true
                    move_object(ref logo2); // ref Input.mousePosition.x, ref Input.mousePosition.y);
            }
            // если нажата ПКМ
            else if (Input.GetMouseButton(1))
            {
                if (logo4_flag)
                    rotate_object(ref logo4, ref logo4_x, ref logo4_y);
                else // for logo2
                    rotate_object(ref logo2, ref logo2_x, ref logo2_y);
            }
        }
        
    
        if (logo2_in_the_right_rotation() &&
            logo4_in_the_right_rotation() &&
            logo4_and_logo2_is_close(4.0f) && // 2f(float distance)дистанция м/у объектами при которой(если повороты объектов попали в промежутки min max) запускается корутиы(довороты и установление в конечной позиции)
            !end_game)
        {
            // Debug.Log("finish");
            end_game = true;
            blockMouse = true;
            StartCoroutine(dovorot(true, turningRotation_logo4, logo4_position_end)); // logo4
            StartCoroutine(dovorot(false, turningRotation_logo2, logo2_position_end)); // logo2
        }
    }
}