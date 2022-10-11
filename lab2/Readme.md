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
Установил вместо стандартной анимации анимацию парения в воздухе. Растегал яйцо и дракона.


![alt-текст](https://github.com/CyberTatarin/DA-in-GameDev-lab1/blob/main/screenshots/pervaya.gif)


2. Проверить, что настроена интеграция редактора Unity и Visual Studio Code (пункты 8-10 введения);
3. Создать объект Plane;
4. Создать объект Cube;
5. Создать объект Sphere;



```c#
public class CheckCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Столкновение произошло с " + other.gameObject.name);
        other.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    }


    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Столкновение завершено с " + other.gameObject.name);
        other.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
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
