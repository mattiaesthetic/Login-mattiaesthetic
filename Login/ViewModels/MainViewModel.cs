using System.Collections.ObjectModel;
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
        "coccoies"
    };
    
    [ObservableProperty]
    private string? _selectedName;

    [ObservableProperty]
    private string _passwordInput = string.Empty;

    [ObservableProperty]
    private string _displayText = "Benvenuto";

    [ObservableProperty]
    private string _buttonText = "LOGIN";

    [ObservableProperty]
    private bool _isLoggedIn = false;
    
    partial void OnSelectedNameChanged(string? value)
    {
        if (!IsLoggedIn && value is not null)
        {
            DisplayText = $"Benvenuto/a {value}";
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
}