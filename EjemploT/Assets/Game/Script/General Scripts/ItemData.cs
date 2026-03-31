using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{

    public string nombre;
    public string rareza;
    public int valor;
    public string iconoid;
    public ItemType itemType;

}

public enum ItemType
{
    Apple,
    Orange,
    Kiwi,
    Banana,
    Cherries,
    Melon,
    Pineapple,
    Strawberry
}
