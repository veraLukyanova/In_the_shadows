using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EarthMove : MonoBehaviour
{
    public GameObject earth;
    public GameObject bases;

    public GameObject win;

    // скорость вращения/перемещения
    private float RotateSpeed_x = 5f;
    private float RotateSpeed_y = 4f;
    private float MoveSpeed_x = 0.5f;
    private float MoveSpeed_y = 0.5f;

    private bool blockMouse = false;//мышь вкл
    private bool end_game = false;//не конец игры
    private bool earth_flag = false;//

    //Угол поворота
    private float earth_x = 0.0f;
    private float earth_y = 0.0f;
    private float base_x = 0.0f;
    private float base_y = 0.0f;

    private float time_ending = .5f;// секунды
    private float _divider = 100; //на сколько частей делим разницу м/у конечным углом и текущим

    // static Vector2 range = new Vector2(20f, 20f);
    private float range = 20f;

    static Vector2 earth_end_rotation = new Vector2(0.0f,0.0f);
    static Vector2 base_end_rotation = new Vector2(0.0f,0.0f);
    static Vector3 base_end_position = new Vector3(0.0f,0.0f,0.0f);

    // earth
    // позиция 1. Конечная позиция и конечный поворот
    static Vector3 earth_position_end = new Vector3(-1.049999f, 4.812508f, -4f); // конечная позиция
    static Vector2 turningRotation_1 = new Vector2(-86.75f, -7.2f); //конечное поворот - объект в идеальном повороте
    
    // позиция 2. Конечный поворот
    static Vector2 turningRotation_2 = new Vector2(-83.5f, 173.5f); //конечное поворот - объект в идеальном повороте

    // позиция 3. Конечный поворот
    static Vector2 turningRotation_earth_3 = new Vector2(91f, -3.5f); //конечное поворот - объект в идеальном повороте

    // позиция 4. Конечный поворот
    static Vector2 turningRotation_earth_4 = new Vector2(91.125f, 173.2f); //конечное поворот - объект в идеальном повороте
    // base
    // позиция 1. Конечная позиция и конечный поворот
    static Vector3 base_position_end_3 = new Vector3(-0.913f, 4.75f, -5f); // конечная позиция
    static Vector2 turningRotation_3 = new Vector2(-86.38f, 172.2f); //конечный поворот - объект в идеальном повороте
    
    // позиция 2. Конечная позиция и конечный поворот
    static Vector3 base_position_end_4 = new Vector3(-0.88f, 4.7f, -5f); // конечная позиция
    static Vector2 turningRotation_4 = new Vector2(-94.25f, -7.4f); //конечный поворот - объект в идеальном повороте


    void Start()
    {
        earth.transform.position = new Vector3(1f,6f,-4f);
        bases.transform.position = new Vector3(2f,3f,-5f);
        win.SetActive(false);
    }
 
    private bool earth_and_base_is_close(float distance)
    {
        if (Vector3.Distance(earth.transform.position, bases.transform.position) < distance)
            return (true);
        else
            return (false);
    }

    private bool earth_in_the_right_rotation(ref Vector2 end_rotation)
    {
        if (Quaternion.Angle(earth.transform.rotation, Quaternion.Euler(turningRotation_1.x, turningRotation_1.y, 0)) < range)
        {
            Debug.Log("finish earth 1");
            end_rotation = turningRotation_1;
            return (true);
        }
        else if (Quaternion.Angle(earth.transform.rotation, Quaternion.Euler(turningRotation_2.x, turningRotation_2.y, 0)) < range)
        {
            Debug.Log("finish earth 2");
            end_rotation = turningRotation_2;
            return (true);
        }
        else if (Quaternion.Angle(earth.transform.rotation, Quaternion.Euler(turningRotation_earth_3.x, turningRotation_earth_3.y, 0)) < range)
        {
            Debug.Log("finish earth 3");
            end_rotation = turningRotation_earth_3;
            return (true);
        }
        else if (Quaternion.Angle(earth.transform.rotation, Quaternion.Euler(turningRotation_earth_4.x, turningRotation_earth_4.y, 0)) < range)
        {
            Debug.Log("finish earth 4");
            end_rotation = turningRotation_earth_4;
            return (true);
        }
        return (false);
    }

    private bool base_in_the_right_rotation(ref Vector2 end_rotation, ref Vector3 end_position)
    {
        if (Quaternion.Angle(bases.transform.rotation, Quaternion.Euler(turningRotation_3.x, turningRotation_3.y, 0)) < range)
        {
            Debug.Log("finish 3");
            end_rotation = turningRotation_3;
            end_position = base_position_end_3;
            return (true);
        }
        else if (Quaternion.Angle(bases.transform.rotation, Quaternion.Euler(turningRotation_4.x, turningRotation_4.y, 0)) < range)
        {
            Debug.Log("finish 4");
            end_rotation = turningRotation_4;
            end_position = base_position_end_4;
            return (true);
        }
        return (false);
    }

    private IEnumerator dovorot(bool flag, Vector2 end_angle, Vector3 end_position)
    {
        int i = 0;
        Vector2 cur_angle = new Vector2(0.0f,0.0f);
        Vector3 cur_position = new Vector3(0.0f,0.0f,0.0f);
        if (flag == true)
        {
            cur_angle = new Vector2(earth_x, earth_y);
            cur_position = earth.transform.position;
        }
        else
        {
            cur_angle = new Vector2(base_x, base_y);
            cur_position = bases.transform.position;
        }
        Vector2 dif_angle = end_angle - cur_angle;
        Vector3 dif_position = end_position - cur_position;
        while(i < _divider)
        {
            cur_angle += dif_angle / _divider;
            cur_position += dif_position / _divider;

            if (flag == true)
            {
                earth.transform.rotation = Quaternion.Euler(cur_angle.x, cur_angle.y, 0.0f);
                earth.transform.position = cur_position;
            }
            else
            {
                bases.transform.rotation = Quaternion.Euler(cur_angle.x, cur_angle.y, 0.0f);
                bases.transform.position = cur_position;
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
            if(Input.GetKeyDown("space")) //при нажатии на спейс переключаемся с объекта на объект. Изначально earth_flag = false;
                earth_flag = !earth_flag; // нажатием на спейс меняем флаг earth_flag = true; вкл earth

            // если нажата ЛКМ
            if (Input.GetMouseButton(0))
            {
                if (earth_flag) // если earth_flag = false
                    move_object(ref earth); // ref Input.mousePosition.x, ref Input.mousePosition.y);
                else // for base /если earth_flag = true
                    move_object(ref bases); // ref Input.mousePosition.x, ref Input.mousePosition.y);
            }
            // если нажата ПКМ
            else if (Input.GetMouseButton(1))
            {
                if (earth_flag)
                    rotate_object(ref earth, ref earth_x, ref earth_y);
                else // for base
                    rotate_object(ref bases, ref base_x, ref base_y);
            }
        }
        
    
        // Debug.Log(Quaternion.Angle(bases.transform.rotation, Quaternion.Euler(turningRotation_3.x, turningRotation_3.y, 0)));
        // Debug.Log(earth.transform.rotation);
        if (base_in_the_right_rotation(ref base_end_rotation, ref base_end_position) &&
            earth_in_the_right_rotation(ref earth_end_rotation) &&
            earth_and_base_is_close(2.0f) && // 2f(float distance)дистанция м/у объектами при которой(если повороты объектов попали в промежутки min max) запускается корутиы(довороты и установление в конечной позиции)
            !end_game)
        {
            // Debug.Log("finish");
            end_game = true;
            blockMouse = true;
            StartCoroutine(dovorot(true, earth_end_rotation, earth_position_end)); // earth
            StartCoroutine(dovorot(false, base_end_rotation, base_end_position)); // bases
        }
    }
}