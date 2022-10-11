# РАЗРАБОТКА ИГРОВЫХ СЕРВИСОВ
Отчет по лабораторной работе #2 выполнил(а):
- Шайханов Марат Артурович
- РИ300019
Отметка о выполнении заданий (заполняется студентом):

| Задание | Выполнение | Баллы |
| ------ | ------ | ------ |
| Задание 1 | * | 60 |
| Задание 2 | # | 20 |
| Задание 3 | # | 20 |

знак "*" - задание выполнено; знак "#" - задание не выполнено;

Работу проверили:
- к.т.н., доцент Денисов Д.В.
- к.э.н., доцент Панов М.А.
- ст. преп., Фадеев В.О.

[![N|Solid](https://cldup.com/dTxpPi9lDf.thumb.png)](https://nodesource.com/products/nsolid)

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

Структура отчета

- Данные о работе: название работы, фио, группа, выполненные задания.
- Цель работы.
- Задание 1.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Задание 2.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Задание 3.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Выводы.
- ✨Magic ✨

## Цель работы
Cоздание интерактивного приложения и изучение принципов интеграции в него игровых сервисов.

## Задание 1
### По теме видео практических работ 1-5 повторить реализацию игры на Unity. Привести описание выполненных действий.

1. Я создал новый проект из шаблона 3D – Core. Подключил в него ассет пак с драконами. Разместил на сцене префаб дракона.
Установил вместо стандартной анимации анимацию парения в воздухе. Растегал яйцо и дракона;


![alt-текст](https://github.com/CyberTatarin/DA-in-GameDev-lab1/blob/main/lab2/screenshots/pervaya.gif)


2. Зарандомил движение дракона и создал префаб энергощита;
3. Создал Plane и наложил текстуру лавы. Добавил случайную смену направления движения в скрипте. Добавил метод для сброса яиц;
4. Написал скрипт для уничтожения яйца при Y=-30, а ещё главный скрипт для генерации и скалирования щитов;
5. Заполнил 80% информации об игре на консоли разработчика Яндекс;


![alt-текст](https://github.com/CyberTatarin/DA-in-GameDev-lab1/blob/main/lab2/screenshots/vtoraya.gif)


```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDragon : MonoBehaviour
{   
    public GameObject dragonEggPrefab; 
    public float speed = 1;
    public float timeBetweenEggDrops = 1f;
    public float leftRightDistance = 10f;
    public float chanceDirection = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropEgg", 2f);

    }

    void DropEgg(){
        Vector3 myVector = new Vector3(0.0f, 5.0f, 0.0f);
        GameObject egg = Instantiate<GameObject>(dragonEggPrefab);
        egg.transform.position = transform.position + myVector;
        Invoke("DropEgg", timeBetweenEggDrops);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftRightDistance){
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftRightDistance){
            speed = -Mathf.Abs(speed);
            
        }
    }
    private void FixedUpdate() {
        if (Random.value < chanceDirection){
            speed *= -1;
        }
    }
}
```


## Задание 2
### Продемонстрируйте на сцене в Unity следующее:
### -Что произойдёт с координатами объекта, если он перестанет быть дочерним?
Координаты дочернего элемента(в данном случае куба) меняются вместе с родительским.


![alt-текст](https://github.com/CyberTatarin/DA-in-GameDev-lab1/blob/main/screenshots/child.gif)


Куб перестал быть дочерним и стал самостоятельным. Теперь он не перенимает свойства и изменение координат сферы. 


![alt-текст](https://github.com/CyberTatarin/DA-in-GameDev-lab1/blob/main/screenshots/pp4.jpg)


![alt-текст](https://github.com/CyberTatarin/DA-in-GameDev-lab1/blob/main/screenshots/rigid.gif)


1. Красный куб; Режим Kinematic;
2. Сфера; Режим Dynamic;
3. Белый куб; Пример вращения.


```c#
public class SpinObject : MonoBehaviour
{
    public float Speed;
    public float AngularSpeed;
    protected Rigidbody r;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Speed = r.velocity.magnitude;
        AngularSpeed = r.angularVelocity.magnitude;

        r.AddTorque(Vector3.forward);
    }
}
```
## Задание 3
### Сложное)



## Выводы

Я научился писать некоторые скрипты для объектов на движке Unity.

## Powered by

**BigDigital Team: Denisov | Fadeev | Panov**
