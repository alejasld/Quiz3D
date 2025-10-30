using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CollectableItem : MonoBehaviour
{
    [Header("Puntaje que otorga este ítem")]
    public int valor = 5;

    [Header("Número total de ítems en la escena")]
    public int totalItems = 3;

    private bool recolectado = false;
    private Camera mainCam;

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void OnMouseDown()
    {
        if (recolectado) return;

        recolectado = true;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScore(valor);
            GameManager.Instance.AddItem();

            // Si ya recogió todos los ítems
            if (GameManager.Instance.ItemsCount >= totalItems)
            {
                Debug.Log("Todos los ítems recolectados. Fin del examen.");

                if (FinalPanelController.Instance != null)
                    FinalPanelController.Instance.MostrarFinal();
                else
                    Debug.LogWarning("No se encontró el FinalPanelController en la escena.");
            }
        }

        // Desactivar el objeto tras recogerlo
        gameObject.SetActive(false);
    }
}
