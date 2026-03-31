using TMPro;
using UnityEngine;

public class ControllerScene3 : MonoBehaviour
{

    public TextMeshProUGUI text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShowGlobalTime();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowGlobalTime()
    {
        Debug.Log("Tiempo total: " + GameManager.Instance.GlobalTime.ToString());
        text.text = "Tiempo total: " + GameManager.Instance.GlobalTime.ToString();
    }
}

