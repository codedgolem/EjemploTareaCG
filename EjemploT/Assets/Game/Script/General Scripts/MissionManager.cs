using UnityEngine;
using System.IO;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;


[System.Serializable]
public class MisionesLista
{
    public List<Mision> misiones;
}

public class MissionManager : MonoBehaviour
{

    public static MissionManager Instance;
    public Queue<Mision> colaMisiones = new Queue<Mision>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        JsonLectura(Application.streamingAssetsPath + "/coleccionables_actualizado.json");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    public void JsonLectura(string path)
    {

        string jsonString = File.ReadAllText(path);
        MisionesLista misionesLista = JsonUtility.FromJson<MisionesLista>(jsonString);

        foreach (var m in misionesLista.misiones)
        {
            colaMisiones.Enqueue(m);
        }

        Debug.Log("Misiones cargadas: " + colaMisiones.Count);
        
    }

    public void mostrarMision(TextMeshProUGUI txtMision = null)
    {
        if (colaMisiones.Count > 0)
        {
            Mision misionActual = colaMisiones.Peek();
            string objetivoInfo = "";
            
            foreach (var objetivo in misionActual.objetivos)
            {
                objetivoInfo += objetivo.itemName + " x" + objetivo.cantidad + "\n";
            }
            txtMision.text = misionActual.titulo + " Objetivos: " + objetivoInfo;
            Debug.Log(misionActual.titulo + " Objetivos: " + misionActual.objetivos );
        }
        else
        {
            txtMision.text = "No hay misiones disponibles";
            Debug.Log("No hay misiones disponibles");
        }
    } 

    public void siguienteMision(TextMeshProUGUI txtMision = null)
    {
        Mision misionActual = colaMisiones.Dequeue();
        if (colaMisiones.Count > 0)
        {
            txtMision.text = "Mision completada: " + misionActual.titulo;
            Debug.Log("Mision completada: " + misionActual.titulo);
            GameManager.Instance.allZero();
            
        }
        else
        {
            txtMision.text = "Mision completada: " + misionActual.titulo +
                "\n No hay mas misiones disponibles";
            Debug.Log("No hay misiones disponibles");
        }
    }

    public bool VerificarMision(ItemData item)
    {
        if (colaMisiones.Count == 0)
            return false;

        Mision misionActual = colaMisiones.Peek();

        foreach (var objetivo in misionActual.objetivos)
        {
            int puntosTotales = ObtenerPuntos(objetivo.itemName);
            int valorItem = ObtenerValorItem(objetivo.itemName);

            int cantidadRecolectada = puntosTotales / valorItem;

            Debug.Log("Item: " + objetivo.itemName + "Valor item :" + item.valor + "Puntos totales: " + puntosTotales);
            Debug.Log("Recolectado: " + cantidadRecolectada + " / Objetivo: " + objetivo.cantidad);

            if (cantidadRecolectada < objetivo.cantidad)
            {
                return false;
            }
        }

        Debug.Log("Misión completada");
        return true;
    }

    int ObtenerPuntos(string itemName)
    {
        switch (itemName)
        {
            case "Apple":
                return GameManager.Instance.TotalApple;

            case "Orange":
                return GameManager.Instance.TotalOrange;

            case "Kiwi":
                return GameManager.Instance.TotalKiwi;

            case "Banana":
                Debug.Log("ENTROBANANA-------------------------------------------------" + GameManager.Instance.TotalBanana);
                return GameManager.Instance.TotalBanana;

            case "Pineapple":
                return GameManager.Instance.TotalPineapple;

            case "Cherries":
                return GameManager.Instance.TotalCherries;

            case "Strawberry":
                return GameManager.Instance.TotalStrawberry;

            case "Melon":
                return GameManager.Instance.TotalMelon;

            default:
                return 0;
        }
    }
    int ObtenerValorItem(string itemName)
    {
        foreach (var coleccionable in GameManager.Instance.listaColeccionables)
        {
            if (coleccionable.nombre.Equals(itemName))
            {
                return coleccionable.valor;
            }
        }

        Debug.LogWarning("No se encontró el valor para: " + itemName);
        return 1;
    }

}
