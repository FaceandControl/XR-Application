using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AccountManager : MonoBehaviour
{
    public static bool IsLoggedIn { get; private set; } = false;
    public static string AccountLogin { get; private set; } = string.Empty;

    public SwitchScene switchScene;
    public InputField loginPanelLoginInputField;
    public InputField loginPanelPasswordInputField;
    public InputField registerPanelLoginInputField;
    public InputField registerPanelPasswordInputField;
    public InputField registerPanelConfirmPasswordInputField;

    private static readonly List<Account> _registeredAccounts = new List<Account>
    {
        new Account
        {
            Login = "test",
            Password = "pass"
        }
    };

    public void LoginAction()
    {
        var login = loginPanelLoginInputField.text;
        var password = loginPanelPasswordInputField.text;


        if (ValidateLogin(login, password)) 
        {
            AccountLogin = login;
            switchScene.ToMainScene();
        }
    }

    public void LogoutAction()
    {
        IsLoggedIn = false;
        AccountLogin = string.Empty;
    }

    public void RegisterAction()
    {
        var login = registerPanelLoginInputField.text;
        var password = registerPanelPasswordInputField.text;
        var confirmedPassword = registerPanelConfirmPasswordInputField.text;

        if (ValidateRegistration(login, password, confirmedPassword))
        {
            _registeredAccounts.Add(new Account { Login = login, Password = password });
            switchScene.ToRegisterScene();
        }
    }

    private bool ValidateLogin(string login, string password)
    {
        Account account = _registeredAccounts.FirstOrDefault(x => x.Login == login);

        if (account != null && account.Password == password)
        {
            return true;
        }

        return false;
    }

    private bool ValidateRegistration(string login, string password, string repliedPassword)
    {
        if (IsRegisterInputValid(login, password, repliedPassword) && IsAccountNotRegistered(login))
        {
            return true;
        }

        return false;
    }

    private bool IsRegisterInputValid(string login, string password, string repliedPassword)
    {
        if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password) && password == repliedPassword)
        {
            return true;
        }

        return false;
    }

    private bool IsAccountNotRegistered(string login)
    {
        Account account = _registeredAccounts.FirstOrDefault(x => x.Login == login);

        if (account == null)
        {
            return true;
        }

        return false;
    }
}

public class Account
{
    public string Login { get; set; }
    public string Password { get; set; }
}