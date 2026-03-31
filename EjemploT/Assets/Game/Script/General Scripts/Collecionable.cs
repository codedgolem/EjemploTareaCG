using UnityEngine;
[System.Serializable]   
public class ItemS 
{
    public string nombre;
    public int cantidad;
}


[System.Serializable]
public class Collecionable
{
    public string nombre;
    public string rareza;
    public int valor;

    public string iconoId;

    public Collecionable(string nombre, string rareza, int valor, string iconoId)
    {
        this.nombre = nombre;
        this.rareza = rareza;
        this.valor = valor;
        this.iconoId = iconoId;
    }
}

