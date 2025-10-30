using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PortalTrigger : MonoBehaviour
{
    [Header("Destino del portal")]
    [Tooltip("Objeto vacío o punto donde aparecerá el jugador al usar el portal.")]
    public Transform puntoLlegada; 


    private void Reset()
    {
        
        Collider col = GetComponent<Collider>();
        if (col != null) col.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (!other.CompareTag("Player"))
            return;

        if (puntoLlegada == null)
        {
            Debug.LogWarning("PortalTrigger: No se ha asignado el punto de llegada.");
            return;
        }

        
        ControllerScene1 controller = FindObjectOfType<ControllerScene1>();
        if (controller != null)
            controller.TimeScene();

    
        CharacterController controllerJugador = other.GetComponent<CharacterController>();

        
        if (controllerJugador != null)
            controllerJugador.enabled = false;

  
        other.transform.position = puntoLlegada.position;

  
        if (controllerJugador != null)
            controllerJugador.enabled = true;

        Debug.Log($"Jugador teletransportado a: {puntoLlegada.position}");
    }
}
