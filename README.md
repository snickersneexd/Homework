# ОСНОВЫ РАБОТЫ С UNITY
Отчет по лабораторной работе #1 выполнил(а):
- Валиев Константин Дмитриевич
- РИ300022
Отметка о выполнении заданий (заполняется студентом):

| Задание | Выполнение | Баллы |
| ------ | ------ | ------ |
| Задание 1 | * | 60 |
| Задание 2 | * | 20 |
| Задание 3 | * | 20 |

знак "*" - задание выполнено; знак "#" - задание не выполнено;

Работу проверили:
- к.т.н., доцент Денисов Д.В.
- к.э.н., доцент Панов М.А.
- ст. преп., Фадеев В.О.


## Цель работы
Ознакомиться с основными функциями Unity и взаимодействием с объектами внутри редактора.


## Задание 1
### В разделе «ход работы» пошагово выполнить каждый пункт с описанием и примера реализации задач по теме видео самостоятельной работы.
#### Ход работы (задание 1):
1) Создать новый проект из шаблона 3D – Core;
2) Проверить, что настроена интеграция редактора Unity и Visual Studio Code (пункты 8-10 введения);
3) Создать объект Plane;
4) Создать объект Cube;
5) Создать объект Sphere;
6) Установить компонент Sphere Collider для объекта Sphere;
7) Настроить Sphere Collider в роли триггера;
8) Объект куб перекрасить в красный цвет;
9) Добавить кубу симуляцию физики, при это куб не должен проваливаться под Plane;
10) Написать скрипт, который будет выводить в консоль сообщение о том, что объект Sphere столкнулся с объектом Cube;
11) При столкновении Cube должен менять свой цвет на зелёный, а при завершении столкновения обратно на красный.

#### Начальное положение объектов на сцене.
![Alt text](Images/1.png?raw=true "Title")

#### Сфера падает и касается куба, при взаимодействии объектов куб меняет свой цвет на зеленый.
![Alt text](Images/2.png?raw=true "Title")

#### При касании сферой пола, она "взрывается" и разлетается на маленьккие части.
![Alt text](Images/3.png?raw=true "Title")

#### Использованные скрипты:

#### 1) CheckCollider (служит для вывода в консоль информации о начале и завершении соприкосновения объектов)

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Произошло столкновение с " + other.gameObject.name);
        other.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Завершенно столкновение с " + other.gameObject.name);
        other.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }
}
```

#### 2) CheckCollision (во время касания цвет куба меняется на зеленый, при отсутствии соприкосновения возвращает обратно свой красный цвет)

```csharp
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Cube")
        {
            other.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "Cube")
        {
            other.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
    }
}
```

#### 3) DestroyObject (код для "взрыва" объекта)

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    // Start is called before the first frame update
    public float radius = 5.0f;

    public float force = 10.0f;

    public GameObject prefabBoomPoint;

    public GameObject prefabBoomSphere;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Sphere")
        {
            Destroy(other.gameObject);
            Vector3 boomPosition = other.gameObject.transform.position;
            Instantiate(prefabBoomPoint, other.gameObject.transform.position, other.gameObject.transform.rotation);
            Instantiate(prefabBoomSphere, other.gameObject.transform.position, other.gameObject.transform.rotation);
            Collider[] colliders = Physics.OverlapSphere(boomPosition, radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(force, boomPosition, radius, 3.0f);
                }
            }
        }
    }
}
```


## Задание 2
### Продемонстрируйте на сцене в Unity следующее:
### - Что произойдёт с координатами объекта, если он перестанет быть дочерним?
### - Создайте три различных примера работы компонента RigidBody?
#### Ход работы (задание 2):

#### Пример работы объектов с компонентом Rigidbody:

#### Сфера начинает свое движение и скатывается с одной поверхности на другую, "взрываясь" при касании пола.
![Alt text](Images/4.png?raw=true "Title")
![Alt text](Images/5.png?raw=true "Title")
![Alt text](Images/6.png?raw=true "Title")

#### Пример работы объектов с компонентом Rigidbody:

#### 4 куба находятся на одинаковом расстоянии друг от друга, верхний куб имеет большую массу, из-за чего после падения "сдавливает" остальные кубы.
![Alt text](Images/7.png?raw=true "Title")
![Alt text](Images/8.png?raw=true "Title")
![Alt text](Images/9.png?raw=true "Title")

#### На данном скриншоте изображен дочерний объект (белый куб) и его координаты:
![Alt text](Images/13.png?raw=true "Title")
#### Здесь изображены координаты объекта, если он перестанет быть дочерним (его координаты изменились, так как координаты просчитываются относительно родительского объекта)
![Alt text](Images/14.png?raw=true "Title")


## Задание 3
### Реализуйте на сцене генерацию n кубиков. Число n вводится пользователем после старта сцены.
#### Ход работы (задание 3):

#### На данной сцене присутсвует пользовательский интерфейс, в котором можно вписать n кол-во кубов, после чего они заспавнятся:
![Alt text](Images/10.png?raw=true "Title")
![Alt text](Images/11.png?raw=true "Title")
![Alt text](Images/12.png?raw=true "Title")

#### Использованные скрипты:

#### 1) ObjectSpawner (служит для спавна n кол-ва кубов)

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using System;

public class ObjectSpawner : MonoBehaviour
{
    public string cubeCount;
    public float pauseTime;
    public GameObject input;
    public GameObject spawnObject;

    // Start is called before the first frame update
    void Start()
    {
        waiter();
    }

    public async void waiter()
    {
        cubeCount = input.GetComponent<Text>().text;
        for (int i = 0; i < int.Parse(cubeCount); i++)
        {
            Instantiate(spawnObject, this.transform.position, this.transform.rotation);
            await Task.Delay(TimeSpan.FromSeconds(pauseTime));
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
```


## Выводы
#### Ознакомился с основными функциями Unity и взаимодействием с объектами внутри редактора.