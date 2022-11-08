# РАЗРАБОТКА ИГРОВЫХ СЕРВИСОВ
Отчет по лабораторной работе #4 выполнил(а):
- Шайханов Марат Артурович
- РИ300019
Отметка о выполнении заданий (заполняется студентом):

| Задание | Выполнение | Баллы |
| ------ | ------ | ------ |
| Задание 1 | * | 60 |
| Задание 2 | * | 20 |
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
Используя видео-материалы практических работ 1-5 повторить реализацию игровых механик: 

## Задание 1
### Используя видео-материалы практических работ 1-5 повторить реализацию приведенного ниже функционала:
- 1 Практическая работа «Создание анимации объектов на сцене».
- 2 Практическая работа «Создание стартовой сцены и переключение между ними».
- 3 Практическая работа «Доработка меню и функционала с остановкой игры».
- 4 Практическая работа «Добавление звукового сопровождения в игре».
- 5 Практическая работа «Добавление персонажа и сборка сцены для публикации на web-ресурсе».



Сделал всё по видеолекциям.




https://user-images.githubusercontent.com/94743111/200647297-2fb0df89-d168-43c4-b841-b693790a1b3e.mp4




В камерах обоих сцен присутствуют источники аудио.
### Дополненный скрипт EnergyShield.cs
```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnergyShield : MonoBehaviour
{
    public TextMeshProUGUI scoreGT;
    public AudioSource audioSource;

    void Start() {
        GameObject scoreGO = GameObject.Find("Score");
        scoreGT = scoreGO.GetComponent<TextMeshProUGUI>();
        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    private void OnCollisionEnter(Collision coll) {
        GameObject Collided = coll.gameObject;
        if (Collided.tag == "Dragon Egg"){
            Destroy(Collided);
        }
        int score = int.Parse(scoreGT.text);
        score += 1;
        scoreGT.text = score.ToString();
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}
```


### Cкрипт DragonEgg.cs
```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonEgg : MonoBehaviour
{   
    public static float bottomY = -30f;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        var em = ps.emission;
        em.enabled = true;

        Renderer rend;
        rend = GetComponent<Renderer>();
        rend.enabled = false;

        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY){
            Destroy(this.gameObject);
            DragonPicker apScript = Camera.main.GetComponent<DragonPicker>();
            apScript.DragonEggDestroyed();
        }
    }
}
```


### Cкрипт MainMenu.cs
```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame(){
        Application.Quit();
    }
}

```


### Cкрипт Pause.cs
```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private bool paused = false;
    public GameObject panel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            if(!paused){
                Time.timeScale = 0;
                paused = true;
                panel.SetActive(true);
            }
            else{
                Time.timeScale = 1;
                paused = false;
                panel.SetActive(false);
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}

```


## Задание 2
### Привести описание того, как происходит сборка проекта проекта под другие платформы. Какие могут быть особенности? 


Сборку можно осуществлять под разные платформы: Windows, Mac, Linux, PlayStation, Android, даже на удалённый сервак. Для изменения платформы следуем 
"File -> Build Settings -> Platform" и выбираем желаемую. Иногда требуется ковыряться в настройках для фикса ошибок(у меня например вылезла ошибка рендринга
Color Space* ). Следует разделять систему обработки ввода, так как у разных платформ разные способы ввода. 


## Задание 3
### Не сделал
<img src="https://media.giphy.com/media/vFKqnCdLPNOKc/giphy.gif" width="40" height="40" />


## Выводы

Я научился писать некоторые скрипты для объектов на движке Unity.

## Powered by

**BigDigital Team: Denisov | Fadeev | Panov**
