using System;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Login.ViewModels;

public partial class MainViewModel : ObservableObject
{
    public ObservableCollection<string> Names { get; } = new()
    {
        "ppaschee",
        "lordcrociato",
        "sswagtho",
        "mrsccs",
        "coccoies",
        "Cat_Matt10",
        "DiegoAldy09",
        "Parliamo",
        "Matthew_What",
        "Placchiii"
    };
    
    [ObservableProperty]
    private string? _selectedName;

    [ObservableProperty]
    private string _passwordInput = string.Empty;
    
    [ObservableProperty]
    private string _newNameInput = string.Empty;

    [ObservableProperty]
    private string _displayText = "Hello";
    
    [ObservableProperty]
    private string _displayText2 = "Scegli un account";

    [ObservableProperty]
    private string _buttonText = "LOGIN";

    [ObservableProperty]
    private bool _isLoggedIn = false;
    
    partial void OnSelectedNameChanged(string? value)
    {
        if (!IsLoggedIn && value is not null)
        {
            DisplayText = $"Benvenuto/a, {value}";
        }
    }

    [RelayCommand]
    private void Submit()
    {
        if (!IsLoggedIn)
        {
            if (SelectedName is null)
            {
                DisplayText = "Selezionare un nome";
                return;
            }

            if (string.IsNullOrWhiteSpace(PasswordInput))
            {
                DisplayText = "Inserire la password";
                return;
            }

            DisplayText = $"Benvenuto/a {SelectedName}";
            ButtonText = "LOGOUT";
            IsLoggedIn = true;
        }
        else
        {
            IsLoggedIn = false;
            SelectedName = null;
            PasswordInput = string.Empty;
            DisplayText = "Arrivederci";
            ButtonText = "LOGIN";
        }
    }
    
    [RelayCommand]
    private void AddAccount()
    {
        var name = NewNameInput.Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            DisplayText = "Inserire il nome del nuovo account";
            return;
        }

        if (Names.Any(n => string.Equals(n, name, StringComparison.OrdinalIgnoreCase)))
        {
            DisplayText = $"L'account {name} esiste già";
            return;
        }

        Names.Add(name);
        SelectedName = name;
        NewNameInput = string.Empty;
    }
}