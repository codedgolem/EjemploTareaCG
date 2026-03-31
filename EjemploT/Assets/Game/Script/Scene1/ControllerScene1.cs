using TMPro;
using UnityEngine;

public class ControllerScene1 : MonoBehaviour
{

    public Timer tiempoJuego;

    public TextMeshProUGUI txtCountApple;
    public TextMeshProUGUI txtCountOrange;
    public TextMeshProUGUI txtCountKiwi;
    public TextMeshProUGUI txtCountBanana;
    public TextMeshProUGUI txtMision;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tiempoJuego.TimerStart();
        lecturaColeccionables();
        MissionManager.Instance.mostrarMision(txtMision);
        GameManager.Instance.escena = 1;
    }

    // Update is called once per frame
    void Update()
    {
        getTotal();
    }

   

    public void getTimeScene() {
        GameManager.Instance.TotalTime(tiempoJuego.StopTime);
    }

    public void lecturaColeccionables() 
    { 
        string path = Application.streamingAssetsPath + "/coleccionables_actualizado.json";
        GameManager.Instance.lecturaJson(path);

        Debug.Log("Coleccionables cargados: " + GameManager.Instance.listaColeccionables.Count + GameManager.Instance.listaColeccionables[0].nombre);

    }

    public void getTotal() {
        txtCountApple.text = GameManager.Instance.TotalApple.ToString();
        txtCountOrange.text = GameManager.Instance.TotalOrange.ToString();
        txtCountKiwi.text = GameManager.Instance.TotalKiwi.ToString();
        txtCountBanana.text = GameManager.Instance.TotalBanana.ToString();
    }
}
