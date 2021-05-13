using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hangman.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Game_Difficulty : ContentPage
    {
        public Game_Difficulty()
        {
            InitializeComponent();
            Title = "Game Difficulty";
        }

        public async void Nav2HMgame(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                //Pushing GameMode to HMGame
                char Diff = btn.Text[0];

                await Navigation.PushAsync(new HangmanGamePage(Convert.ToString(Diff)));
            }
        }
    }
}