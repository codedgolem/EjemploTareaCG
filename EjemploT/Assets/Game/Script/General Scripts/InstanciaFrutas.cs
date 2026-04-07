using System.Collections.Generic;
using UnityEngine;

public class InstanciaFrutas : MonoBehaviour
{
    public GameObject Prefab;

    public Transform[] instanciaPuntos;

    public List<ItemS> items;

    Sprite[] sprites;
    Sprite spriteI;

    void Start()
    {
        SpawnItems(GameManager.Instance.listaColeccionables);
    }

    void SpawnItems(List<Collecionable> lista)
    {
        int puntoActual = 0;

        foreach (var coleccionable in lista)
        {
            ItemData item = ScriptableObject.CreateInstance<ItemData>();

            item.nombre = coleccionable.nombre;
            item.rareza = coleccionable.rareza;
            item.valor = coleccionable.valor;
            item.itemType = (ItemType)System.Enum.Parse(typeof(ItemType), coleccionable.nombre, true);
            item.iconoid = coleccionable.iconoId;

            foreach (var spawn in items)
            {
                if (spawn.nombre.ToLower().Trim() == item.itemType.ToString().ToLower().Trim())
                {
                    for (int i = 0; i < spawn.cantidad; i++)
                    {
                        if (puntoActual >= instanciaPuntos.Length)
                        {
                            Debug.LogWarning("No hay más puntos disponibles");
                            return;
                        }

                        Transform punto = instanciaPuntos[puntoActual];

                        GameObject obj = Instantiate(
                            Prefab,
                            punto.position,
                            Quaternion.identity
                        );

                        // Cargar sprite
                        sprites = Resources.LoadAll<Sprite>("Fruits/" + item.iconoid);

                        spriteI = null;
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

                        puntoActual++; // 👉 pasa al siguiente punto
                    }
                }
            }
        }
    }
}