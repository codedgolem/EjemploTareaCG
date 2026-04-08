using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemRecolectable : MonoBehaviour
{
    public ItemData _itemData_;
    public AudioClip sonido;

    public GameObject Prefab;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.TotalItem(_itemData_);
            AudioSource.PlayClipAtPoint(sonido, transform.position);
            Debug.Log($"Recolectaste un {_itemData_.nombre} de tipo {_itemData_.itemType} con valor {_itemData_.valor}");
            if (MissionManager.Instance.VerificarMision(_itemData_))
            {
                Canvas canvas = FindFirstObjectByType<Canvas>();

                GameObject obj = Instantiate(Prefab, canvas.transform, false);

                if (GameManager.Instance.escena == 2)
                {
                    Button boton = obj.GetComponentInChildren<Button>();
                    boton.onClick.AddListener(() =>
                    {
                        LoaderScene.Instance.LoadScene("Menu");
                    });

                    boton.GetComponentInChildren<TextMeshProUGUI>().text = "Volver al menu";

                    MissionManager.Instance.siguienteMision(obj.GetComponentInChildren<TextMeshProUGUI>());
                }else
                {

                    Button boton = obj.GetComponentInChildren<Button>();
                    boton.onClick.AddListener(() =>
                    {
                        LoaderScene.Instance.LoadScene("Escena" + (GameManager.Instance.escena + 1));
                    });

                    boton.GetComponentInChildren<TextMeshProUGUI>().text = "Siguiente nivel";

                    MissionManager.Instance.siguienteMision(obj.GetComponentInChildren<TextMeshProUGUI>());
                }


            }
            
            Destroy(gameObject);
        }
    }
}
