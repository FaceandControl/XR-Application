using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AccountManager : MonoBehaviour
{
    public static bool IsLoggedIn { get; private set; } = false;
    public static string AccountLogin { get; private set; } = string.Empty;

    public SwitchScene switchScene;
    public InputField loginInputField;
    public InputField passwordInputField;

    private static readonly List<Account> _registeredAccounts = new List<Account>
    {
        new Account
        {
            Login = "max",
            Password = "pass"
        }
    };

    public void LoginAction() // string login, string password
    {
        var login = loginInputField.text;
        var password = passwordInputField.text;
        AccountLogin = login;
        switchScene.ToMainScene();
    }

    public void LogoutAction()
    {
        IsLoggedIn = false;
        AccountLogin = string.Empty;

        //return true;
    }

    public bool RegisterAction(string login, string password, string repliedPassword)
    {
        if (ValidateRegistration(login, password, repliedPassword))
        {
            _registeredAccounts.Add(new Account { Login = login, Password = password });
        }
        return false;
    }

    private bool ValidateLogin(string login, string password)
    {
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
        return string.IsNullOrEmpty(login) && string.IsNullOrEmpty(password) && password == repliedPassword;
    }

    private bool IsAccountNotRegistered(string login)   
    {
        return _registeredAccounts.FirstOrDefault(x => x.Login == login) != null;
    }
}

public class Account
{
    public Image Avatar { get; set; } = null; // Default avatar, feature with changing avatar is not implemented
    public string Login { get; set; }
    public string Password { get; set; }
}