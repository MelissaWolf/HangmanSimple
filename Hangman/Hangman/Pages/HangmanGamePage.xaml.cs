using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hangman.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HangmanGamePage : ContentPage
    {
        Logic Logic;

        //Defing Labels & Btns
        Label ScoreLbl;

        Image HMimage;

        Label GuessLbl;

        //AphabetBtns
        Button AlphaBtn;
        Button[] AlphaBtns = new Button[26];
        int btnsIndex = 0;

        Button GemBtn;

        public HangmanGamePage(string Diff)
        {
            InitializeComponent();

            Logic = new Logic();

            NavigationPage.SetHasNavigationBar(this, false);

            //Making Grid
            Grid grid = new Grid
            {
                RowDefinitions =
            {
                new RowDefinition { Height = new GridLength(250) },
                new RowDefinition { Height = new GridLength(100) },
                new RowDefinition { Height = new GridLength(55) },
                new RowDefinition { Height = new GridLength(55) },
                new RowDefinition { Height = new GridLength(55) },
                new RowDefinition { Height = new GridLength(55) },
                new RowDefinition { Height = new GridLength(55) }
            },
                ColumnDefinitions =
            {
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition()
            }
            };

            //Upper Half
            //Image & Score Part
            BoxView topBoxView = new BoxView
            {
                Color = Color.Black
            };
            Grid.SetRow(topBoxView, 0);
            Grid.SetColumnSpan(topBoxView, 6);
            HMimage = new Image
            {
                Aspect = Aspect.AspectFill,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            Grid.SetRow(HMimage, 0);
            Grid.SetColumnSpan(HMimage, 6);

            ScoreLbl = new Label
            {
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Center
            };
            Grid.SetRow(ScoreLbl, 0);
            Grid.SetColumnSpan(ScoreLbl, 6);
            //Image & Score Part Ends

            //Hidden Word Part
            BoxView boxView2 = new BoxView
            {
                Color = Color.Black
            };
            Grid.SetRow(boxView2, 1);
            Grid.SetColumnSpan(boxView2, 6);
            GuessLbl = new Label
            {
                TextColor = Color.White,
                FontSize = 25,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            Grid.SetRow(GuessLbl, 1);
            Grid.SetColumnSpan(GuessLbl, 6);

            //Adding to Grid
            grid.Children.Add(topBoxView);
            grid.Children.Add(boxView2);
            grid.Children.Add(HMimage);
            grid.Children.Add(ScoreLbl);
            grid.Children.Add(GuessLbl);
            //Hidden Word Part Ends
            //Upper Half ENDS

            //Alphabet Buttons
            //The First and Last Letters
            int letter = 65; //Starts at A
            int Z = 90;
            char myChar;

            //The Rows
            for (int r = 2; letter <= Z; r++)
            {

                //The Columns
                for (int c = 0; c < 6 && letter <= Z; c++)
                {
                    myChar = Convert.ToChar(letter);

                    if (myChar == 'Y')
                    {
                        c = c + 2;
                    }

                    grid.Children.Add(new BoxView
                    {
                        Margin = 0,
                        WidthRequest = 55,
                        HeightRequest = 55
                    }, c, r);
                    grid.Children.Add(AlphaBtn = new Button()
                    {
                        Text = Convert.ToString(myChar),
                        FontSize = 25,
                        WidthRequest = 50,
                        HeightRequest = 50,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center
                    }, c, r);
                    AlphaBtn.BackgroundColor = Color.DodgerBlue;
                    AlphaBtn.TextColor = Color.Black;
                    AlphaBtn.Clicked += Logic.GuessChar;
                    AlphaBtns[btnsIndex] = AlphaBtn;

                    btnsIndex++;
                    letter++;
                }
            }
            //Alphabet Buttons ENDS

            //Adding Gem Btn
            grid.Children.Add(new BoxView
            {
                Margin = 0,
                WidthRequest = 55,
                HeightRequest = 55
            }, 4, 6);
            grid.Children.Add(GemBtn = new Button()
            {
                ImageSource = "GemsIcon.png",
                HeightRequest = 50,
                WidthRequest = 110,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 4, 6);
            Grid.SetRow(GemBtn, 6);
            Grid.SetColumnSpan(GemBtn, 2);
            GemBtn.BackgroundColor = Color.DodgerBlue;
            GemBtn.TextColor = Color.Black;
            GemBtn.Clicked += Logic.UseGem;
            //Adding Gem Btn ENDS

            Content = grid;

            //Getting Game Difficulty
            Logic.SelectDiff(Diff);

            //Sets Up First Game
            Logic.NewHMGame(ScoreLbl, HMimage, GuessLbl, AlphaBtns, GemBtn);
        }
    }
}