using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Hangman.Pages;
using Xamarin.Forms;

namespace Hangman
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Title = "Hangman";
        }

        public void Nav2GameDiff(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Game_Difficulty());
        }

        public void Nav2How2Play(object sender, EventArgs e)
        {
            Navigation.PushAsync(new How2PlayPage());
        }

        public void Nav2HighScoresPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HighScoresPage());
        }
    }
}
