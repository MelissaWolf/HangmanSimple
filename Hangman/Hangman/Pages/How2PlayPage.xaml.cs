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
    public partial class How2PlayPage : ContentPage
    {
        public How2PlayPage()
        {
            InitializeComponent();

            Title = "How To Play";
        }
    }
}