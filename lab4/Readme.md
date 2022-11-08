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


![alt-текст](https://github.com/CyberTatarin/DA-in-GameDev-lab1/blob/main/lab3/screenshots/3laba1.gif)


### Основной скрипт DragonPicker.cs
```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragonPicker : MonoBehaviour
{
    public GameObject energyShieldPrefab;
    public int numEnergyShield = 3;
    public float energyShieldBottomY = -6f;
    public float energyShieldRadius = 1.5f;
    public List<GameObject> shieldList;
    // Start is called before the first frame update
    void Start()
    {
        shieldList = new List<GameObject>();

        for (int i = 1; i <= numEnergyShield; i++){
            GameObject tShieldGo = Instantiate<GameObject>(energyShieldPrefab);
            tShieldGo.transform.position = new Vector3(0, energyShieldBottomY, 0);
            tShieldGo.transform.localScale = new Vector3(1*i, 1*i, 1*i);
            shieldList.Add(tShieldGo);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DragonEggDestroyed(){
        GameObject[] tDragonEggArray = GameObject.FindGameObjectsWithTag("Dragon Egg");
        foreach (GameObject tGO in tDragonEggArray){
            Destroy(tGO);
        }
        int shieldIndex = shieldList.Count - 1;
        GameObject tShieldGo = shieldList[shieldIndex];
        shieldList.RemoveAt(shieldIndex);
        Destroy(tShieldGo);

        if (shieldList.Count == 0){
            SceneManager.LoadScene("_0Scene");
        }
    }
}
```


### Cкрипт EnergyShield.cs
```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnergyShield : MonoBehaviour
{
    public TextMeshProUGUI scoreGT;

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
    }
}
```


## Задание 2
### Практические работы «Уменьшение жизни. Добавление текстур» и «Структурирование исходных файлов в папке».

Жизни уменьшаются (Слои щита исчезают при потере яйца). Прибрался, удалил ненужные штуковины.


![alt-текст](https://github.com/CyberTatarin/DA-in-GameDev-lab1/blob/main/lab3/screenshots/3lab2.png)


## Задание 3
### Не сделал
<img src="https://media.giphy.com/media/vFKqnCdLPNOKc/giphy.gif" width="40" height="40" />


## Выводы

Я научился писать некоторые скрипты для объектов на движке Unity.

## Powered by

**BigDigital Team: Denisov | Fadeev | Panov**
