using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Hangman.Pages
{
    public class Logic
    {
        //The Hidden/Visable Word
        string HidWord;
        string VisWord;

        //Score
        int ScoreCount = 0;

        //Gem
        int GemCount = 0;

        //!!!!!!!!!!!!!!!!!!!!!!!!!! Hard Code !!!!!!!!
        List<string> HMword = new List<string>();
        //!!!!!!!!!!!!!!!!!!!!!!!!!! Hard Code !!!!!!!!

        //Pics Prefix Based on Difficulty
        string HMpics;

        //Game Difficulty Info
        int deadNum;
        int PointsWorth;

        //Total Wrong Guesses
        int badGuess = 0;

        //Indicates if Game is Still Going or Not
        int GameState = 1;

        //Creates Random Chance
        Random luck = new Random();


        //Selects Game Difficuly
        public void SelectDiff(string Diff)
        {
            switch (Diff)
            {
                case "Easy":
                    HMpics = "HME";
                    deadNum = 12;
                    PointsWorth = 1; break;
                case "Normal":
                    HMpics = "HMN";
                    deadNum = 9;
                    PointsWorth = 3; break;
                case "Hard":
                    HMpics = "HMH";
                    deadNum = 6;
                    PointsWorth = 7; break;
            }
        }

        //!!!!!!!!!!!!!!!!!!!!!!!!!! Hard Code !!!!!!!!
        //Adding to HM Word List
        HMword.Add("Siberian Husky");
        HMword.Add("Pirate");
        HMword.Add("Mythical Creature");
        HMword.Add("inevitable");
        HMword.Add("Movie Night");
        HMword.Add("Candy Floss");
        HMword.Add("Wolf");
        HMword.Add("Challenge");
        HMword.Add("Hangman");
        HMword.Add("Ice Cream");
        HMword.Add("Pizza");
        HMword.Add("Hamburger");
        HMword.Add("Soccer");
        HMword.Add("Archery");
        HMword.Add("Horse Riding");
        HMword.Add("To Boldly Go");
        HMword.Add("Cowboy");
        HMword.Add("Valley");
        HMword.Add("Ball");
        HMword.Add("Toy");
        HMword.Add("Chocolate");
        HMword.Add("Nacho");
        HMword.Add("Possible");
        HMword.Add("Crazy");
        HMword.Add("Villan");
        HMword.Add("Hero");
        HMword.Add("Social Butterfly");
        HMword.Add("Nerd");
        HMword.Add("Programmer");
        HMword.Add("Dragon");
        HMword.Add("Map");
        HMword.Add("Internet");
        HMword.Add("Unknown");
        HMword.Add("Dinosaur");
        HMword.Add("Weapon");
        HMword.Add("Pencil");
        HMword.Add("Game");
        HMword.Add("Tired");
        HMword.Add("Bored");
        HMword.Add("Travel");
        HMword.Add("Friends");
        HMword.Add("Star Trek");
        HMword.Add("Irritating");
        HMword.Add("Star");
        //!!!!!!!!!!!!!!!!!!!!!!!!!! Hard Code !!!!!!!!



        //Makes the Correct Num of '_' for VisWord
        public void MakeBlankChars()
        {
            for (int i = 0; i < HidWord.Length; i++)
            {
                //If it isn't a letter
                if (!Char.IsLetter(Convert.ToChar(HidWord.Substring(i, 1))))
                {
                    VisWord += HidWord.Substring(i, 1);
                }
                else
                {
                    VisWord += "_";
                }
            }
        }

        public string SpaceString(string MyString)
        {
            string spacedString = "";

            for (int i = 0; i < MyString.Length; i++)
            {
                spacedString += " " + MyString.Substring(i, 1) + " ";
            }

            return spacedString;
        } //Space String ENDS


        public void NewHMGame(Label ScoreLbl, Image HMimage, Label GuessLbl, Button[] AlphaBtns, Button GemBtn) //Sets Up Hangman Game
        {
            //Showing the Total Score & Gems
            ScoreLbl.Text = Convert.ToString(ScoreCount);
            GemBtn.Text = "X " + GemCount;

            //Getting New Word
            //!!!!!!!!!!!!!!!!!!!!!!!!!! Hard Code !!!!!!!!
            HidWord = HMword[luck.Next(HMword.Count)].ToUpper();
            //!!!!!!!!!!!!!!!!!!!!!!!!!! Hard Code !!!!!!!!

            VisWord = "";

            //Showing the Visable Word Letter Count
            MakeBlankChars();

            GuessLbl.Text = SpaceString(VisWord);

            //Enabling Gems 1++
            if (GemCount > 0)
            {
                GemBtn.IsEnabled = true;
                GemBtn.BackgroundColor = Color.DodgerBlue;
            }
            else //Disabling Gems 0
            {
                GemBtn.IsEnabled = false;
                GemBtn.BackgroundColor = Color.LightGray;
            }

            //Re-Enabling ALL Alphabet Btns
            for (int i = 0; i < AlphaBtns.Length; i++)
            {
                AlphaBtns[i].IsEnabled = true;
                AlphaBtns[i].BackgroundColor = Color.DodgerBlue;
            }

            //Showing Img, Score & set bad Guesses to Zero
            HMimage.Source = HMpics + 1 + ".png";
            ScoreLbl.Text = "Score: " + ScoreCount;
            badGuess = 0;

            //Start New Game
            GameState = 1;
        } //NewHMGame ENDS


        public async void GuessChar(object sender, EventArgs e, Label ScoreLbl, Image HMimage, Label GuessLbl, Button[] AlphaBtns, Button GemBtn)
        {
            //Only While Game is Active
            if (sender is Button btn && GameState == 1)
            {
                btn.IsEnabled = false;

                //The Char Exists in HidWord
                if (HidWord.Contains(btn.Text) == true)
                {
                    //Background is greenish for correct input
                    btn.BackgroundColor = Color.FromRgb(223, 236, 223);

                    string NewVisWord = "";

                    for (int i = 0; i < HidWord.Length; i++)
                    {
                        if (HidWord.Substring(i, 1) == btn.Text)
                        {
                            NewVisWord += btn.Text;
                        }
                        else
                        {
                            NewVisWord += VisWord.Substring(i, 1);
                        }
                    }

                    VisWord = NewVisWord;
                    GuessLbl.Text = SpaceString(VisWord);

                    //If all Letters are Found
                    if (VisWord.Contains("_") == false)
                    {
                        //Game Over
                        GameState = 0;
                        GameEnd(1, ScoreLbl, HMimage, GuessLbl, AlphaBtns, GemBtn);
                    }

                } //The Char Exists in HidWordENDS
                else
                {
                    badGuess++;

                    //No Lives are left
                    if ((badGuess + 1) == deadNum)
                    {
                        HMimage.Source = "HMDead.png";
                        GuessLbl.Text = SpaceString(HidWord);

                        //Game Over
                        GameState = 0;
                        GameEnd(0, ScoreLbl, HMimage, GuessLbl, AlphaBtns, GemBtn);

                        //Background is redish for incorrect input
                        btn.BackgroundColor = Color.FromRgb(255, 102, 102);

                        //Dead Char Changes to badGuess Color
                        await Task.Delay(1000);
                        btn.BackgroundColor = Color.FromRgb(236, 223, 223);
                    }
                    else
                    {
                        HMimage.Source = HMpics + (badGuess + 1) + ".png";

                        //Background is redish for incorrect input
                        btn.BackgroundColor = Color.FromRgb(236, 223, 223);
                    }
                }
            }
        } //GuessChar ENDS


        public void UseGem(object sender, EventArgs e, Label ScoreLbl, Image HMimage, Label GuessLbl, Button[] AlphaBtns)
        {
            //Only While Game is Active
            if (sender is Button GemBtn && GameState == 1 && GemCount > 0)
            {
                //Uses A Gem
                GemCount = GemCount - 1;
                GemBtn.Text = "X " + GemCount;

                //Giving Hint
                string PossHint = "";

                string NewVisWord = "";

                //Getting Not Used Letters
                //Safety Measure for For Loop
                if (HidWord.Length == VisWord.Length)
                {
                    for (int i = 0; i < HidWord.Length; i++)
                    {
                        //If Characters is still Unknown and not a current PossHint
                        if (VisWord.Substring(i, 1) == "_" && PossHint.Contains(VisWord.Substring(i, 1)) == false)
                        {
                            PossHint += HidWord.Substring(i, 1);
                        }
                    }
                }
                else
                {
                    Debug.WriteLine("Error: Hidden Word and Visable Word Lengths Are Different");
                }
                //Getting Not Used Letters ENDS

                //Selecting Hint Character
                PossHint = PossHint.Substring(luck.Next(PossHint.Length), 1);

                //Revealing ALL of Character
                if (HidWord.Length == VisWord.Length)
                {
                    for (int i = 0; i < HidWord.Length; i++)
                    {
                        if (HidWord.Substring(i, 1) == PossHint)
                        {
                            NewVisWord += PossHint;
                        }
                        else
                        {
                            NewVisWord += VisWord.Substring(i, 1);
                        }
                    }
                }
                else
                {
                    Debug.WriteLine("Error: Hidden Word and Visable Word Lengths Are Different");
                }
                //Revealing ALL of Character ENDS

                VisWord = NewVisWord;
                GuessLbl.Text = SpaceString(VisWord);

                //Disabling Character's Btn
                int CharValue = Convert.ToInt32(Convert.ToChar(PossHint)) - 65;
                AlphaBtns[CharValue].IsEnabled = false;
                AlphaBtns[CharValue].BackgroundColor = Color.FromRgb(223, 236, 223);
                //Giving Hint ENDS

                //If all Letters are Found
                if (VisWord.Contains("_") == false)
                {
                    //Game Over
                    GameState = 0;
                    GameEnd(1, ScoreLbl, HMimage, GuessLbl, AlphaBtns, GemBtn);
                }

                //Disables Btn if No Gems Left
                if (GemCount <= 0)
                {
                    GemBtn.IsEnabled = false;
                    GemBtn.BackgroundColor = Color.LightGray;
                }


            }
        } //UseGem ENDS


        public async void GameEnd(int gameResult, Label ScoreLbl, Image HMimage, Label GuessLbl, Button[] AlphaBtns, Button GemBtn)
        {
            //Shows Game Result
            await GameResult(gameResult, HMimage, GuessLbl, GemBtn);

            //New Hangman Game
            if (gameResult == 1)
            {
                NewHMGame(ScoreLbl, HMimage, GuessLbl, AlphaBtns, GemBtn);
            }
            else //GAME OVER
            {
                //!!!!!!!!!!!!!!!!!!!!!!!!
            }
        }


        //Little Fun Result 'Animation'
        public async Task GameResult(int gameResult, Image HMimage, Label GuessLbl, Button GemBtn)
        {
            int GemsEarned = 0;

            if (gameResult == 1)
            {
                HidWord = "You Win!";

                //Getting this Rounds Total Points
                int RoundPoints = ((deadNum - 1) - badGuess) * PointsWorth;

                //Adding to the Total Score
                ScoreCount = ScoreCount + RoundPoints;

                //Adding to Users Gems
                GemsEarned = RoundPoints / 10;
                GemCount = GemCount + GemsEarned;
            }
            else
            {
                HidWord = "Game Over";
            }

            HidWord = HidWord.ToUpper();
            VisWord = "";

            //Showing the Visable Word Letter Count
            MakeBlankChars();

            //Gives User Time to See the HM Word
            await Task.Delay(1000);

            //Showing Gems Earned
            if (GemsEarned > 0)
            {
                switch (GemsEarned)
                {
                    case 1: HMimage.Source = "HMGem.png"; break;
                    case 2: HMimage.Source = "HMGem2.png"; break;
                    case 3: HMimage.Source = "HMGem3.png"; break;
                }

                GemBtn.Text = "+ " + GemsEarned;
            }

            //Reveals New Word
            GuessLbl.Text = SpaceString(VisWord);

            //Reveal Results Character by Character
            for (int i = 1; i < HidWord.Length; i++)
            {
                //Only Wait to Reveal Characters
                if (Char.IsLetter(Convert.ToChar(HidWord.Substring((i - 1), 1))))
                {
                    await Task.Delay(200);
                }

                GuessLbl.Text = SpaceString(HidWord.Substring(0, i) + VisWord.Substring(i, (HidWord.Length - i)));
            }

            await Task.Delay(200);
            GuessLbl.Text = SpaceString(HidWord);

            //Gives User Time to See Result
            await Task.Delay(1000);
        }
    }
}
