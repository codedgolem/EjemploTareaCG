using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Mision
{
    public int id;
    public string titulo;
    public List<Objetivo> objetivos;

    public Mision(int id, string titulo, List<Objetivo> objetivos)
    {
        this.id = id;
        this.titulo = titulo;
        this.objetivos = objetivos;
    }
}
