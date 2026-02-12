using JetBrains.Annotations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class ControllerGame : MonoBehaviour
{
    public TextMeshProUGUI question;
    public TextMeshProUGUI option1;
    public TextMeshProUGUI option2;
    public TextMeshProUGUI option3;
    public TextMeshProUGUI option4;
    public TextMeshProUGUI description;
    public TextMeshProUGUI title;
    public TextMeshProUGUI difficulty;
    List<MultipleQuestion> list_questions = new List<MultipleQuestion>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadQuestions();
        ShowInScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowInScene()
    {
        question.text = list_questions[0].Question;
        option1.text = list_questions[0].Option1;
        option2.text = list_questions[0].Option2;
        option3.text = list_questions[0].Option3;
        option4.text = list_questions[0].Option4;
        difficulty.text = list_questions[0].Difficult;

    }

    public void AnswerVerify(int option)
    {
        switch (option)
        {
            case 1:
                if (option1.text == list_questions[0].Answer)
                {
                    title.text = "Correcto";
                    description.text = list_questions[0].Versiculo;
                }
                else
                {
                    title.text = "Incorrecto";
                    description.text = "Intenta de nuevo";
                }
                break;
            case 2:
                if (option2.text == list_questions[0].Answer)
                {
                    title.text = "Correcto";
                    description.text = list_questions[0].Versiculo;
                }
                else
                {
                    title.text = "Incorrecto";
                    description.text = "Intenta de nuevo";
                }
                break;
            case 3:
                if (option3.text == list_questions[0].Answer)
                {
                    title.text = "Correcto";
                    description.text = list_questions[0].Versiculo;
                }
                else
                {
                    title.text = "Incorrecto";
                    description.text = "Intenta de nuevo";
                }
                break;
            case 4:
                if (option4.text == list_questions[0].Answer)
                {
                    title.text = "Correcto";
                    description.text = list_questions[0].Versiculo;
                }
                else
                {
                    title.text = "Incorrecto";
                    description.text = "Intenta de nuevo";
                }
                break;
        }


    }

    public void LoadQuestions()
    {
        string route = Path.Combine(Application.streamingAssetsPath, "ArchivoPreguntas.txt");
        StreamReader info = new StreamReader(route);

        string line;

        while ((line = info.ReadLine()) != null)
        {
            //Debug.Log(line);

            string[] datos = line.Split('-');
            MultipleQuestion question = new MultipleQuestion(datos[0], datos[1], datos[2], datos[3], datos[4], datos[5], datos[6], datos[7]);
            list_questions.Add(question);
            Debug.Log(question.Question + "Opcion 1" + question.Option1);

        }
        info.Close();
    }
}
