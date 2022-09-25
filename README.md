# РАЗРАБОТКА ИГРОВЫХ СЕРВИСОВ
Отчет по лабораторной работе #1 выполнил(а):
- Шайханов Марат Артурович
- РИ300019
Отметка о выполнении заданий (заполняется студентом):

| Задание | Выполнение | Баллы |
| ------ | ------ | ------ |
| Задание 1 | # | 60 |
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
Ознакомиться с основными операторами зыка Python на примере реализации линейной регрессии.

## Задание 1
### В разделе «ход работы» пошагово выполнить каждый пункт с описанием и примером реализации задач по теме видео самостоятельной работы
Ход работы:
1. Создать новый проект из шаблона 3D – Core;
2. Проверить, что настроена интеграция редактора Unity и Visual Studio Code (пункты 8-10 введения);
3. Создать объект Plane;
4. Создать объект Cube;
5. Создать объект Sphere;


![alt-текст](https://github.com/CyberTatarin/DA-in-GameDev-lab1/blob/main/screenshots/pp.jpg)


6. Установить компонент Sphere Collider для объекта Sphere;
7. Настроить Sphere Collider в роли триггера;


![alt-текст](https://github.com/CyberTatarin/DA-in-GameDev-lab1/blob/main/screenshots/pp3.png)


8. Объект куб перекрасить в красный цвет;


![alt-текст](https://github.com/CyberTatarin/DA-in-GameDev-lab1/blob/main/screenshots/pp2.jpg)


9. Добавить кубу симуляцию физики, при это куб не должен проваливаться под Plane;
10. Написать скрипт, который будет выводить в консоль сообщение о том, что объект Sphere столкнулся с объектом Cube;
11. При столкновении Cube должен менять свой цвет на зелёный, а при завершении столкновения обратно на красный.


![alt-текст](https://github.com/CyberTatarin/DA-in-GameDev-lab1/blob/main/screenshots/perv.gif "gifka")


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


## Задание 3
### Какова роль параметра Lr? Ответьте на вопрос, приведите пример выполнения кода, который подтверждает ваш ответ. В качестве эксперимента можете изменить значение параметра.

- Перечисленные в этом туториале действия могут быть выполнены запуском на исполнение скрипт-файла, доступного [в репозитории](https://github.com/Den1sovDm1triy/hfss-scripting/blob/main/ScreatingSphereInAEDT.py).
- Для запуска скрипт-файла откройте Ansys Electronics Desktop. Перейдите во вкладку [Automation] - [Run Script] - [Выберите файл с именем ScreatingSphereInAEDT.py из репозитория].

```py

import ScriptEnv
ScriptEnv.Initialize("Ansoft.ElectronicsDesktop")
oDesktop.RestoreWindow()
oProject = oDesktop.NewProject()
oProject.Rename("C:/Users/denisov.dv/Documents/Ansoft/SphereDIffraction.aedt", True)
oProject.InsertDesign("HFSS", "HFSSDesign1", "HFSS Terminal Network", "")
oDesign = oProject.SetActiveDesign("HFSSDesign1")
oEditor = oDesign.SetActiveEditor("3D Modeler")
oEditor.CreateSphere(
	[
		"NAME:SphereParameters",
		"XCenter:="		, "0mm",
		"YCenter:="		, "0mm",
		"ZCenter:="		, "0mm",
		"Radius:="		, "1.0770329614269mm"
	], 
)

```

## Выводы

Абзац умных слов о том, что было сделано и что было узнано.

| Plugin | README |
| ------ | ------ |
| Dropbox | [plugins/dropbox/README.md][PlDb] |
| GitHub | [plugins/github/README.md][PlGh] |
| Google Drive | [plugins/googledrive/README.md][PlGd] |
| OneDrive | [plugins/onedrive/README.md][PlOd] |
| Medium | [plugins/medium/README.md][PlMe] |
| Google Analytics | [plugins/googleanalytics/README.md][PlGa] |

## Powered by

**BigDigital Team: Denisov | Fadeev | Panov**
