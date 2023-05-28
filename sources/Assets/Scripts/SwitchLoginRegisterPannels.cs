using UnityEngine;

public class SwitchLoginRegisterPannels : MonoBehaviour
{
    public GameObject loginPanel;
    public GameObject registerPanel;

    public void ClickOnLogin()
    {
        registerPanel.SetActive(false);
        loginPanel.SetActive(true);
    }

    public void ClickOnRegister()
    {
        loginPanel.SetActive(false);
        registerPanel.SetActive(true);
    }
}
