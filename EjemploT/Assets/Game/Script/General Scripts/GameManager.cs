using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class ColeccionableLista
{
    public List<Collecionable> coleccionables;
}

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public List<Collecionable> listaColeccionables;

    private float globalTime;

    private int totalApple;
    private int totalOrange;
    private int totalKiwi;
    private int totalBanana;
    private int totalMelon;
    private int totalStrawberry;
    private int totalCherries;
    private int totalPineapple;
    public int escena;



    void Awake()
    {
        
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
            
            Instance = this;
            DontDestroyOnLoad(gameObject);
          
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        globalTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TotalTime(float timeScene)
    {
        globalTime += timeScene;
    }

    public void TotalItem(ItemData item) {
    
        switch(item.itemType)
        {
            case ItemType.Apple:
                totalApple += item.valor;
                Debug.Log("Total Apple: " + totalApple);
                break;
            case ItemType.Orange:
                totalOrange += item.valor;
                break;
            case ItemType.Kiwi:
                totalKiwi += item.valor;
                break;
            case ItemType.Banana:
                totalBanana += item.valor;
                Debug.Log("Total Banana: " + totalBanana);
                break;
            case ItemType.Pineapple:
                totalPineapple += item.valor;
                break;
            case ItemType.Cherries:
                totalCherries += item.valor;
                break;
            case ItemType.Melon:
                totalMelon += item.valor;
                break;
            case ItemType.Strawberry:
                totalStrawberry += item.valor;
                break;
        }

    }

    public void lecturaJson(string path)
    { 
        
        string jsonString = File.ReadAllText(path);
        ColeccionableLista coleccionableLista = JsonUtility.FromJson<ColeccionableLista>(jsonString);
        listaColeccionables = coleccionableLista.coleccionables;
        Debug.Log("Coleccionables cargados: " + coleccionableLista.coleccionables + coleccionableLista.coleccionables[0].nombre);
    } 

    public void allZero() 
    { 
        totalApple = 0;
        totalOrange = 0;
        totalKiwi = 0;
        totalBanana = 0;
        totalMelon = 0;
        totalStrawberry = 0;
        totalCherries = 0;
        totalPineapple = 0;
    }

    
    public float GlobalTime { get => globalTime; set => globalTime = value; }
    public int TotalApple { get => totalApple; set => totalApple = value; }
    public int TotalOrange { get => totalOrange; set => totalOrange = value; }
    public int TotalKiwi { get => totalKiwi; set => totalKiwi = value; }
    public int TotalBanana { get => totalBanana; set => totalBanana = value; }
    public int TotalMelon { get => totalMelon; set => totalMelon = value; }
    public int TotalStrawberry { get => totalStrawberry; set => totalStrawberry = value; }
    public int TotalCherries { get => totalCherries; set => totalCherries = value; }
    public int TotalPineapple { get => totalPineapple; set => totalPineapple = value; }
}
