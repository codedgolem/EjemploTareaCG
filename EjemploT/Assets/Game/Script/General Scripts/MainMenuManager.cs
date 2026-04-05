using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject panelInstrucciones;

    public void Jugar()
    {
        Debug.Log("Cargando Nivel 1...");

        SceneManager.LoadScene(1);
    }

    public void AbrirInstrucciones()
    {
        if (panelInstrucciones != null)
            panelInstrucciones.SetActive(true);
    }

    public void CerrarInstrucciones()
    {
        if (panelInstrucciones != null)
            panelInstrucciones.SetActive(false);
    }

    public void Salir()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
       
    }
}