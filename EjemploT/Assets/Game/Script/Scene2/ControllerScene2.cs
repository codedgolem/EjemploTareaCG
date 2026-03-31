using TMPro;
using UnityEngine;

public class ControllerScene2 : MonoBehaviour
{
    public TextMeshProUGUI txtCountApple;
    public TextMeshProUGUI txtCountOrange;
    public TextMeshProUGUI txtCountKiwi;
    public TextMeshProUGUI txtCountBanana;
    public TextMeshProUGUI txtMision;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Timer tiempoJuego;
    void Start()
    {
        startTime();
        MissionManager.Instance.mostrarMision(txtMision);
        GameManager.Instance.escena = 2;
    }

    // Update is called once per frame
    void Update()
    {
        getTotal();
    }

    public void startTime() {
        tiempoJuego.TimerStart();
    }

    public void getTimeScene()
    {
       
        GameManager.Instance.TotalTime(tiempoJuego.StopTime);
    }

    public void getTotal()
    {
        txtCountApple.text = GameManager.Instance.TotalApple.ToString();
        txtCountOrange.text = GameManager.Instance.TotalOrange.ToString();
        txtCountKiwi.text = GameManager.Instance.TotalKiwi.ToString();
        txtCountBanana.text = GameManager.Instance.TotalBanana.ToString();
    }
}
