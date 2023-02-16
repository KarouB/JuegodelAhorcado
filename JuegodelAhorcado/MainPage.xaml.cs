using System.ComponentModel;
using System.Diagnostics;
using System.IO.Pipes;

namespace JuegodelAhorcado;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
    #region UI Properties
    public string SpotLight
    {
        get => spotLight;
        set
        {
            spotLight = value;
            OnPropertyChanged();
        }
    }

    public List<char> Letter
    {
        get => letter; 
        set
        {
            letter = value;
            OnPropertyChanged();
        }
    }


    #endregion

    #region Fields

    List<string> words = new List<string>()
    {
        "phyton",
        "javascript",
        "maui",
        "csharp",
        "sql",
        "xalm",
        "code",
        "developer"
    };

    string answer = "";

    private string spotLight;

    List<char> guessed = new List<char>();

    private List<char> letter = new List<char>();

    #endregion

    public MainPage()
    {
        InitializeComponent();
        Letter.AddRange("abcdefghijklmnopqrstuvwxyz");
        BindingContext = this;
        PickWord();
        CalculateWord(answer, guessed);

    }

    #region Game Engine

    private void PickWord()
    {
        answer =
            words[new Random().Next(0, words.Count)];

        Debug.WriteLine(answer);
    }
    private void CalculateWord(string answer, List<char> guessed)
    {
        var temp = answer.Select(x => (guessed.IndexOf(x) >= 0 ? x : '_')).ToArray();
        SpotLight = string.Join(' ', temp);
    }

    #endregion
}

