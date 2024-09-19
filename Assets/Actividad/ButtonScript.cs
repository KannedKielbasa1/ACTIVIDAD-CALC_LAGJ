using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public string buttonValue;  // El valor del bot�n que se usar� en la calculadora

    // Este m�todo detecta la colisi�n
    private void OnCollisionEnter(Collision collision)
    {
        // Verificamos que el objeto que impact� el bot�n tiene el tag "Projectile"
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("Bot�n presionado: " + buttonValue);
            CalculatorManager.Instance.ButtonPressed(buttonValue);
        }
    }
}
