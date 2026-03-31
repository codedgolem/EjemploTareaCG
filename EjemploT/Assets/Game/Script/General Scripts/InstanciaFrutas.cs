using NUnit.Framework.Interfaces;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InstanciaFrutas : MonoBehaviour
{

    public GameObject Prefab;

    public Transform[] instanciaPuntos;
    public List<ItemS> items;
    private int cantidad;
    List<int> usados = new List<int>();
    Sprite[] sprites;
    Sprite spriteI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnItems(GameManager.Instance.listaColeccionables);
    }

 

    void SpawnItems(List<Collecionable> lista)
    {
        foreach(var coleccionable in lista)
        {
            ItemData item = ScriptableObject.CreateInstance<ItemData>();
            item.nombre = coleccionable.nombre;
            item.rareza = coleccionable.rareza;
            item.valor = coleccionable.valor;
            item.itemType = (ItemType)System.Enum.Parse(typeof(ItemType), coleccionable.nombre, true); 
            item.iconoid = coleccionable.iconoId;

            foreach (var spawn in items)
            {
                if(spawn.nombre.Equals(item.itemType.ToString()))
                {
                    cantidad = spawn.cantidad;
                    Debug.Log("Cantidad de " + spawn.nombre + ": Cantidad:" + cantidad);
                    for (int i = 0; i < cantidad; i++)
                    {
                        int randomIndex;

                        do
                        {
                            randomIndex = Random.Range(0, instanciaPuntos.Length);
                        }
                        while (usados.Contains(randomIndex));

                        usados.Add(randomIndex);

                        GameObject obj = Instantiate(Prefab, instanciaPuntos[randomIndex].position, Quaternion.identity);

                        sprites = Resources.LoadAll<Sprite>("Fruits/"+item.iconoid);

                        foreach (Sprite s in sprites)
                        {
                            if (s.name == item.iconoid + "_0")
                            {
                                spriteI = s;
                                break;
                            }
                        }


                        obj.GetComponent<ItemRecolectable>()._itemData_ = item;
                        obj.GetComponent<SpriteRenderer>().sprite = spriteI;

                        



                    }
                }
            }
     
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
