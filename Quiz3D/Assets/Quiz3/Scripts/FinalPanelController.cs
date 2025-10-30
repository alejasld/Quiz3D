using UnityEngine;
using TMPro;

public class FinalPanelController : MonoBehaviour
{
    public static FinalPanelController Instance;

    public GameObject panelFinal;
    public TextMeshProUGUI textoFinal;
    public TextMeshProUGUI textoTiempo;

    private void Awake()
    {
        Instance = this;
        panelFinal.SetActive(false);
    }

    public void MostrarFinal()
    {
        Debug.Log("✅ Método MostrarFinal ejecutado");

        if (panelFinal == null)
        {
            Debug.LogWarning("⚠️ No se asignó el panel final en el Inspector.");
            return;
        }

        panelFinal.SetActive(true);

        if (textoFinal != null)
            textoFinal.text = "¡Fin del Examen! 🎉";

        if (textoTiempo != null)
            textoTiempo.text = "Tiempo total: " + GameManager.Instance.GlobalTime.ToString("F2") + " s";
    }

}
