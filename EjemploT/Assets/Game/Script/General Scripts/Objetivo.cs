using UnityEngine;

[System.Serializable]
public class Objetivo
{
    public string itemName;
    public int cantidad;

    public Objetivo(string itemName, int cantidad)
    {
        this.itemName = itemName;
        this.cantidad = cantidad;
    }
}
